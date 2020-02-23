using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace Kolokviji
{
    public partial class formaZaPrikazRaporeda : Form
    {
        private Random rnd = new Random();

        SqlConnection connection;
        string connectionString;

        // Podaci dobiveni iz prethodnih formi odabirom vremena i dvorane
        string trazenaDvorana;
        int trazenoVrijeme;
        int vrstaKorisnika;

        // Lista sa gumbima
        List<List<Button>> matricaGumba = new List<List<Button>>();

        // Riječnik u kojem će nam ključ biti naziv kolegija, a vrijednost lista studenata koji ga pišu u traženo vrijeme
        Dictionary<string, List<string>> ListDict = new Dictionary<string, List<string>>();

        // Rječnik u kojem je ključ kolegiji iz kojeg se piše kolokviji, a vrijednost boja kojom ćemo predstaviti taj kolegiji
        Dictionary<string, Color> rjecnikBojaZaKolegije = new Dictionary<string, Color>();


        #region Inicijalizacija forme za prikaz rasporeda
        public formaZaPrikazRaporeda(string dvorana, int vrijeme, int visi_pristup)
        {
            InitializeComponent();
            //connectionString = ConfigurationManager.ConnectionStrings["Kolokviji.Properties.Settings.Database1ConnectionString"].ConnectionString;
            connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Lucija\PMF\5.godina\RP3\Projekt4\-rp3-kolokviji\Database1.mdf;Integrated Security=True";

            // Postavljamo oznaku dvorane za pretrazivanje baze i stavljanje naslova na formu
            trazenaDvorana = dvorana;
            dvoranaIVrijemeOdrzavanjaKolokvijaLabel.Text = "dvorana: " + dvorana.ToString();

            // Postavljamo traženo vrijeme i dodajemo ga u naslov
            trazenoVrijeme = vrijeme;
            dvoranaIVrijemeOdrzavanjaKolokvijaLabel.Text += "\t vrijeme: " + trazenoVrijeme.ToString();

            // Postavljamo vrstu korisnika - admin(1)/obični(0)
            vrstaKorisnika = visi_pristup;
        }
        #endregion

        #region Učitavanje forme za prikaz rasporeda
        private void formaZaPrikazRaporeda_Load(object sender, EventArgs e)
        {
            if( vrstaKorisnika == 1)
            {
                // Omogući adminu promjenu rasporeda 
                panelZaAdminaZamjenaStudenata.Visible = true;
            }

            // Funkcija koja pronalazi sve studente koji pišu kolokviji u traženoVrijeme
            pronadiStudente();

            // Grafički prikaži dvoranu
            RasporediPoDvoranama();
        }
        #endregion

        #region Pomoćna funkcija za popunjavanje riječnika svih kolegija koji se pišu traženo vrijeme i svih studentat koji pišu taj kolegiji
        private void pronadiStudente()
        {
            // Pronađimo kolegije koji se pišu u zadano vrijeme
            string query = "SELECT DISTINCT Kolegij FROM Studenti WHERE Vrijeme = @Vrijeme";

            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                command.Parameters.AddWithValue("@Vrijeme", trazenoVrijeme);

                DataTable Kolegiji = new DataTable();
                adapter.Fill(Kolegiji);

                // Prikaži kolegije u popisKolegijaListBox
                //popisKolegijaListBox.DisplayMember = "Kolegij";
                //popisKolegijaListBox.ValueMember = "Kolegij";
                //popisKolegijaListBox.DataSource = Kolegiji;

                // Podijelimo studente u liste ovisno o kolegiju
                foreach (DataRow row in Kolegiji.Rows)
                {
                    string kolegij = row["Kolegij"].ToString();

                    // Pronađimo sve studente koji pišu određeni kolegij
                    string query2 = "SELECT JMBAG, Ime_Prezime, BrojDvorane, MjestoUDvorani FROM Studenti WHERE Kolegij = @k";

                    using (connection = new SqlConnection(connectionString))
                    using (SqlCommand command2 = new SqlCommand(query2, connection))
                    using (SqlDataAdapter adapter2 = new SqlDataAdapter(command2))
                    {
                        command2.Parameters.AddWithValue("@k", kolegij);

                        DataTable Studenti = new DataTable();
                        adapter2.Fill(Studenti);

                        // Popunimo riječnik sa dobivenim rezultatima (naziv kolegija je ključ)
                        ListDict.Add(kolegij, new List<string>());

                        // Vrijednosti su studenti - oblika: jmbag; ime_prezime
                        foreach (DataRow row2 in Studenti.Rows)
                        {
                            if( !string.IsNullOrEmpty(row2["BrojDvorane"].ToString())  && !string.Equals(row2["BrojDvorane"].ToString(), trazenaDvorana) )
                            {
                                // Student je već smješten u neku drugu dvoranu, ne trebamo ga gledati
                                continue;
                            }
                            else if(!string.IsNullOrEmpty(row2["BrojDvorane"].ToString()) && string.Equals(row2["BrojDvorane"].ToString(), trazenaDvorana)
                                    && !string.IsNullOrEmpty(row2["MjestoUDvorani"].ToString()) )
                            {
                                // Student je već smješten u dvorani
                                ListDict[kolegij].Add(row2["JMBAG"] + "; " + row2["Ime_Prezime"] + "; " + row2["MjestoUDvorani"]);
                                continue;
                            }

                            // Svi ostali slučajevi
                            ListDict[kolegij].Add(row2["JMBAG"] + "; " + row2["Ime_Prezime"]);

                        }
                            
                    }

                    // Na slučajan način odabiremo boju za neki kolegiji
                    rjecnikBojaZaKolegije.Add(kolegij, Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256)));
                }

                // Prikaži kolegije u popisKolegijaListView i oboji ih
                for (var i = 0; i < Kolegiji.Rows.Count; i++)
                {
                    string imeKolegija = Kolegiji.Rows[i].ItemArray.AsEnumerable().First().ToString();
                    ListViewItem item = new ListViewItem();
                    item.ForeColor = rjecnikBojaZaKolegije[imeKolegija];
                    item.Text = imeKolegija;
                    popisKolegijaListView.Items.Add(item);
                }
            }

        }
        #endregion

        /// <summary>
        /// Dohvatimo podatke iz baze o osobnostima dvorane, kreiramo potreban broj gumbi na formi i onda zovemo 
        /// pomoćnu funkciju obojiSjedalaIRazmjestiNerazmješteneStudente koja zapravo radi cijeli posao razmiještaja .
        /// </summary>
        #region Pomoćna funkcija za grafički prikaz rasporeda studenata
        private void RasporediPoDvoranama()
        {
            // Dohvaćamo podatke o broju redaka i stupaca te dvorane za traženu dvoranu iz baze Dvorane 
            string query = "SELECT Broj_Stupaca, Broj_Redaka, Razmak FROM Dvorane WHERE BrojDvorane = @Dvorana";
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                command.Parameters.AddWithValue("@Dvorana", trazenaDvorana);

                DataTable infoDvorana = new DataTable();
                adapter.Fill(infoDvorana);

                // Tražimo broj stupaca, redaka, te ima li razmak
                // Kako je BrojDvorane PRIMARYKEY kroz ovaj foreach uvijek prolazimo samo jednom
                foreach (DataRow row in infoDvorana.Rows)
                {
                    int brojStupaca = (int)row["Broj_Stupaca"];
                    int brojRedaka = (int)row["Broj_Redaka"];
                    int razmak = (int)row["Razmak"];

                    for (int i = 0; i < brojRedaka; i++)
                    {
                        // Za dodavanje razmaka
                        int r = 0;
                        List<Button> redakSGumbima = new List<Button>();

                        for (int j = 0; j < brojStupaca; j++)
                        {
                            Gumb button = new Gumb();

                            button.Location = new Point(this.Width / 4 + j * 40 + r, this.Height / 6 + i * 40);
                            button.Size = new System.Drawing.Size(30, 30);
                            button.Anchor = AnchorStyles.Top;

                            // Svaki gumb imat će ime
                            // npr pozicija_1*1
                            button.Name = "pozicija_" + i + "*" + j;
                            button.AccessibleName = "";
                            button.AccessibleDescription = "";

                            // Također, svaki gumb će imati i AccessibleName - ako je na njemu raspoređena neki student - ime studenta_jmbag
                            // i AccessibleDescription ako je na njemu raspoređena neki student - predmet koji piše
                            // To ćemo dodati ako neki student bude smješten na to mjesto

                            this.Controls.Add(button);

                            // Ako treba biti razmak, stavimo taj razmak na sredini, tj. na polovini broja svih stupaca
                            if (razmak == 1 && j == brojStupaca / 2 - 1) r += 60;

                            redakSGumbima.Add(button);
                        }
                        matricaGumba.Add(redakSGumbima);
                    }
                    obojiSjedalaIRazmjestiNerazmješteneStudente(brojRedaka, brojStupaca, razmak);
                }
            }
        }
        #endregion


        /// <summary>
        /// Boji gumbe koji predstavljaju sjedala sa bojama koje predstavljaju određeni kolegiji
        /// za svakog studenta koji piše kolokviji iz tog kolegija.
        /// Ako je student već razmiješten (u bazi podataka smo u prethodnim pokretanjima aplikacije zapisali njegov razmještaj),
        /// treba samo obojati tu poziciju, ako ne treba mu naći slobodnu poziciju.
        /// Ako nema slobodnog mjesta, tj ako ne možemo staviti da ima barem jedno mjesto razmaka između svaka dva student,
        /// dodaj ga na prvo slobodno mjesto, ali tako da pored njega studenti ne pišu isti kolegiji
        /// </summary>
        /// <param name="brojRedaka"> Parametar koji nam govori koliko redaka ima u dvorani </param>
        /// <param name="brojStupaca"> Parametar koji nam govori koliko stupaca ima u dvorani</param>
        /// <param name="razmak"> Parametar koji nam govori ima li razmaka u dvorani </param>
        #region Pomoćna funkcija koja razmiješta studente
        private void obojiSjedalaIRazmjestiNerazmješteneStudente(int brojRedaka, int brojStupaca, int razmak)
        {
            bool suzenje = false;
            int posljednjiRedakSuzenja = -1;

            // Prvo oboji sve koji imaju određenu poziciju
            foreach (string kolegij in ListDict.Keys)
            {
                foreach (string student in ListDict[kolegij])
                {
                    // Varijabla student je string oblika JMBAG; ImeIPrezime(; PozicijaX*PozicijaY)+ 
                    // Tako da, ako je count 1, onda se radi o studentu koji još nema poziciju, 
                    // a ako je count 2, onda student ima poziciju
                    int count = student.Count(f => f == ';');
                    if ( count == 2 )
                    {
                        // Student već ima poziciju u dvorani, ne treba tražiti novu
                        // Izvuci poziciju iz stringa
                        // imePrezime
                        int index1 = student.IndexOf(';');
                        string jmbag = student.Substring(0, index1);
                        string substring1 = student.Substring(index1 + 2);

                        // jmbag
                        index1 = substring1.IndexOf(';');
                        string imePrezime = substring1.Substring(0, index1);

                        // pozicija
                        string pozicija = substring1.Substring(index1 + 2);

                        obojiGumb(kolegij, imePrezime, jmbag, pozicija);
                        continue;
                    }
                }
            }


            // Oboji sve ostale
            int j = 0, k = 0;
            int kSuzeni = 0;
            foreach (string kolegij in ListDict.Keys)
            {
                int brojKolegija = ListDict.Keys.Count;

                foreach (string student in ListDict[kolegij])
                {
                    // Varijabla student je string oblika JMBAG; ImeIPrezime(; PozicijaX*PozicijaY)+ 
                    // Tako da, ako je count 1, onda se radi o studentu koji još nema poziciju, 
                    // a ako je count 2, onda student ima poziciju
                    int count = student.Count(f => f == ';');
                    if (count == 2)
                        continue;


                    // Prvo popunjavamo stupce svaka brojKolegija mjesta
                    var result = popuniStupac(k, brojRedaka, kolegij, student);
                    if (result)
                        continue;

                    // Dosli smo do kraja stupca - probaj za sve retke 
                    // Retke biram tako da gledam koliko kolegija se piše u prostoriji
                    bool test = false;
                    for( j = k + 2*brojKolegija; j < brojStupaca; j += 2*brojKolegija)
                    {
                        // Pokušamo popuniti stupac j od nultog retka
                        result = popuniStupac(j, brojRedaka, kolegij, student);
                        if (result)
                        {
                            test = true;
                            break;
                        }
                    }

                    // Uspjeli smo smjestiti studenta
                    if (test)
                        continue;


                    //Nedovoljno je mjesta u učionici za taj kolegiji, iako smo gusto posložili - probaj naći negdje drugdje
                    //MessageBox.Show("Student " + student + " ne stane u ovu učionicu tako da bude mjesto razmaka sa drugim studentima koji pišu " + kolegij);

                    // Probaj u sve ostale stupce ako nije doslo do suzenja
                    if( !suzenje )
                    {
                        for (var jj = 0; jj < brojStupaca; jj += 2)
                        {
                            result = popuniStupac(j, brojRedaka, kolegij, student);
                            if (result)
                            {
                                test = true;
                                break;
                            }
                        }
                        // Uspjeli smo smjestiti studenta
                        if (test)
                            continue;

                    }

                    // Svi su stupci popunjeni - ne može biti barem jedan razmak između studenata
                    // "Skupi red"
                    // treba naprviti swapAndSave tako da, ako je bilo RP1 _ RP2 _ RP3 
                    // sada bude RP1 RP2 RP3 _ _ _
                    // i neka nam je postavljena varijabla suzenje na true čim preuredimo barem jedan takav redak.
                    while( !test )
                    {
                        // Treba brejkat ako dođemo do slučaja posljednjiRedakSuzenja >= brojRedaka
                        if (suzenje)
                        {
                            // Vec se dogodilo suzenje
                            // Provjerimo ima li i dalje mjesta u nekom od redaka manjim od posljednjemRetkuSuzenja za taj Kolegiji, odnosno studenta

                            for (var q = 0; q <= posljednjiRedakSuzenja; q++)
                            {
                                // U svakom retku provjeri postoji li moguća pozicija
                                // Ako ima, postavi, THE END
                            }
                            // Ako nema, napravi novo suzenje
                        }
                        else
                        {
                            suzenje = true;
                            posljednjiRedakSuzenja++;
                            //trebaNApravitiSuzenjeNultogRetka
                        }
                    }


                    // Ako posljednjiRedakSuzenja >= brojRedaka
                    // E ako sad bas ne nademo poziciju prodi kroz sva mjesta i vidi da nemas susjednog da pise isti kolegiji.
                    // Ako nema takve pozicije, dvorana je gotovo sigurno maximalno popunjana.
                    // THE END
                }
                // Ostavi razmak između 2 kolegija 
                k += 2;
                kSuzeni++;
            }

        }
        #endregion

        #region Popunjavamo zadani stupac - svaka 2 mjesta
        private bool popuniStupac(int j, int brojRedaka, string kolegij, string student)
        {
            for( var i = 0; i < brojRedaka; i++ )
            {
                if (i < brojRedaka && string.IsNullOrEmpty(matricaGumba[i][j].AccessibleName))
                {
                    //Uspjeli smo naći mjesto
                    obojiPoznatiGumb(student, kolegij, i, j);
                    return true;
                }
            }
            return false;
        }
        #endregion

        #region Pomoćna funkcija koja boja gumb s točno određenom pozicijom
        private void obojiGumb(string kolegij, string imePrezime, string jmbag, string pozicija)
        {
            pozicija = pozicija.Replace(" ", String.Empty);
            foreach (Control ctrl in this.Controls)
            {
                // Pronađemo traženi gumb
                if (ctrl.Name.ToString().Contains("pozicija") && ctrl.Name.ToString().Contains(pozicija))
                {
                    // Oboji ga
                    ctrl.BackColor = rjecnikBojaZaKolegije[kolegij];
                    ctrl.AccessibleName = imePrezime + "_" + jmbag ;
                    ctrl.AccessibleDescription = kolegij;

                    UpdateBaze(pozicija, jmbag/*, imePrezime, kolegij*/);
                    return;
                }
            }
        }
        #endregion

        #region Pomoćna funkcija koja boja gumb s točno određenim gumbom
        private void obojiPoznatiGumb(string student,  string kolegij, int i, int j)
        {
            // Izvuci ime i jmbag iz stringa za pravilno ime buttona

            int index1 = student.IndexOf(';');
            string jmbag = student.Substring(0, index1);
            string imePrezime = student.Substring(index1 + 2);

            matricaGumba[i][j].AccessibleName = imePrezime + "_" + jmbag;
            matricaGumba[i][j].AccessibleDescription = kolegij;
            matricaGumba[i][j].BackColor = rjecnikBojaZaKolegije[kolegij];

            UpdateBaze(i.ToString() + "*" + j.ToString(), jmbag/*, imePrezime, kolegij*/);
        }
        #endregion

        #region Selektirali smo neki predmet, boldaj rub svih mjesta na kojima se nalaze studenti koji pišu taj predmet -- TO BE IMPLEMENTED
        private void popisKolegijaListView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        #endregion

        /// <summary>
        /// Treba još implementirati.
        /// Pokušati dodatno implementirati tako da možemo stisnuti na gumb i tako premjestiti studenta ili neka varijanta toga, npr povlačenje gumba.
        /// </summary>
        #region Zamjeni položaj dva studenta ako se radi o višem korisniku 
        private void zamjeniStudenteGumb_Click(object sender, EventArgs e)
        {
            if( !string.IsNullOrEmpty(jmbagPrvogStudentaText.Text) && !string.IsNullOrEmpty(jmbagDrugogStudentaText.Text))
            {
                string jmbag1 = jmbagPrvogStudentaText.Text;
                string jmbag2 = jmbagDrugogStudentaText.Text;
                jmbag1 = jmbag1.Replace(" ", String.Empty);
                jmbag2 = jmbag2.Replace(" ", String.Empty);
                bool nasaoJedan = false;
                Button zamjeniSa = new Button();

                foreach (Control ctrl in this.Controls)
                {
                    if (!string.IsNullOrEmpty(ctrl.AccessibleName) )
                    {
                        // Pronađemo traženi gumb
                        if (ctrl.AccessibleName.ToString().Contains(jmbag1))
                        {
                            if (nasaoJedan)
                            {
                                swapAndSave(ctrl as Button, jmbag1, zamjeniSa, jmbag2);
                                return;
                            }
                            else
                            {
                                nasaoJedan = true;
                                zamjeniSa = ctrl as Button;
                            }
                        }
                        else if (ctrl.AccessibleName.ToString().Contains(jmbag2))
                        {
                            if (nasaoJedan)
                            {
                                swapAndSave(ctrl as Button, jmbag2, zamjeniSa, jmbag1);
                                return;
                            }
                            else
                            {
                                nasaoJedan = true;
                                zamjeniSa = ctrl as Button;
                            }
                        }
                    }
                    
                }
            }
        }
        #endregion

        #region Button swap
        private void swapAndSave(Button b1, string jmbag1, Button b2, string jmbag2)
        {
            // Grafički zamjeni
            string aName = b1.AccessibleName;
            string aDesc = b1.AccessibleDescription;
            Color myColor = b1.BackColor;
            b1.AccessibleName = b2.AccessibleName;
            b1.AccessibleDescription = b2.AccessibleDescription;
            b1.BackColor = b2.BackColor;
            b2.AccessibleName = aName;
            b2.AccessibleDescription = aDesc;
            b2.BackColor = myColor;

            
            // Zamjeni u bazi
            string pozicija1 = b2.Name.Replace("pozicija_", String.Empty);
            string pozicija2 = b1.Name.Replace("pozicija_", String.Empty);

            UpdateBaze(pozicija1, jmbag1);
            UpdateBaze(pozicija2, jmbag2);

            /*
            // Mjenjamo podatke o smještaju studenta u bazi
            string query1 = "UPDATE Studenti SET BrojDvorane ='" + trazenaDvorana.Replace(" ", String.Empty) + "', MjestoUDvorani = '" + pozicija1 + "' WHERE JMBAG = " + jmbag1;
            string query2 = "UPDATE Studenti SET BrojDvorane ='" + trazenaDvorana.Replace(" ", String.Empty) + "', MjestoUDvorani = '" + pozicija2 + "' WHERE JMBAG = " + jmbag2;

            using (connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT JMBAG, BrojDvorane, MjestoUDvorani FROM Studenti", connection);

                adapter.UpdateCommand = new SqlCommand("UPDATE Studenti SET BrojDvorane = @BrojDvorane, MjestoUDvorani = @MjestoUDvorani " + "WHERE  JMBAG = @JMBAG", connection);

                adapter.UpdateCommand.Parameters.Add("@BrojDvorane", SqlDbType.Char, 10, "BrojDvorane");
                adapter.UpdateCommand.Parameters.Add("@MjestoUDvorani", SqlDbType.Char, 10, "MjestoUDvorani");


                SqlParameter parameter = adapter.UpdateCommand.Parameters.Add("@JMBAG", SqlDbType.Int);
                parameter.SourceColumn = "JMBAG";
                parameter.SourceVersion = DataRowVersion.Original;
                parameter.Value = jmbag1;

                DataTable categoryTable = new DataTable();
                adapter.Fill(categoryTable);

                DataRow categoryRow = categoryTable.Rows[0];
                categoryRow["BrojDvorane"] = trazenaDvorana.Replace(" ", String.Empty);
                categoryRow["MjestoUDvorani"] = pozicija1;

                adapter.Update(categoryTable);

            }
            */

        }
        #endregion

        #region Update baze

        private void UpdateBaze(string pozicija, string jmbag/*, string imePrezime, string kolegij*/)
        {
            //Update
            /*using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(
                    "SELECT JMBAG, BrojDvorane, MjestoUDvorani FROM Studenti", connection);

                dataAdapter.UpdateCommand = new SqlCommand(
                "UPDATE Studenti SET BrojDvorane = @BrojDvorane, MjestoUDvorani = @MjestoUdvorani " +
                "WHERE JMBAG = @JMBAG", connection);

                dataAdapter.UpdateCommand.Parameters.Add("@BrojDvorane", SqlDbType.Char, 10, "BrojDvorane");
                dataAdapter.UpdateCommand.Parameters.Add(
                    "@MjestoUDvorani", SqlDbType.Char, 10, "MjestoUDvorani");

                SqlParameter parameter = dataAdapter.UpdateCommand.Parameters.Add("@JMBAG", SqlDbType.Int);
                parameter.SourceColumn = "JMBAG";
                parameter.SourceVersion = DataRowVersion.Original;
                parameter.Value = Convert.ToInt32(jmbag);

                dataAdapter.UpdateCommand.ExecuteNonQuery();

                DataTable categoryTable = new DataTable();
                dataAdapter.Fill(categoryTable);

                DataRow categoryRow = categoryTable.Rows[0];
                categoryRow["BrojDvorane"] = trazenaDvorana;
                categoryRow["MjestoUDvorani"] = pozicija;

                dataAdapter.Update(categoryTable);
                connection.Close();
            }*/

            //Update malo drukcije
            SqlConnection cnn = new SqlConnection(connectionString);
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            String sql = "";

            sql = "UPDATE Studenti SET BrojDvorane=@BrojDvorane, MjestoUDvorani=@MjestoUDvorani WHERE JMBAG=@JMBAG";


            cnn.Open();
            command = new SqlCommand(sql, cnn);
            //adapter.UpdateCommand = new SqlCommand(sql, cnn);
            adapter.UpdateCommand = command;
            adapter.UpdateCommand.Parameters.Add("@BrojDvorane", trazenaDvorana);
            adapter.UpdateCommand.Parameters.Add("@MjestoUDvorani", pozicija);
            adapter.UpdateCommand.Parameters.Add("@JMBAG", jmbag);
            adapter.UpdateCommand.ExecuteNonQuery();

            adapter.UpdateCommand.Dispose();
            cnn.Close();

            //Delete i Insert

            /*SqlConnection cnn = new SqlConnection(connectionString);
            cnn.Open();
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            String sql = "";

            sql = "DELETE Studenti WHERE JMBAG=" + jmbag;

            command = new SqlCommand(sql, cnn);

            adapter.DeleteCommand = new SqlCommand(sql, cnn);
            adapter.DeleteCommand.ExecuteNonQuery();

            DataTable categoryTable = new DataTable();
            adapter.Fill(categoryTable);

            command.Dispose();
            cnn.Close();*/
            /*cnn.Open();

            sql = "INSERT INTO Studenti (JMBAG, Ime_Prezime, Kolegij, Vrijeme, BrojDvorane, MjestoUDvorani)" +
                " VALUES (" + jmbag + "," + imePrezime + "," + kolegij + "," +
                trazenaDvorana.Replace(" ", String.Empty) + "," + pozicija + ")";

            command = new SqlCommand(sql, cnn);

            adapter.InsertCommand = new SqlCommand(sql, cnn);
            adapter.InsertCommand.ExecuteNonQuery();

            command.Dispose();
            cnn.Close();*/
        }
        #endregion

        

        #region Povratak na prethodnu formu
        private void vratiSeNaFormuZaODabirVremenaIDvoraneGumb_Click(object sender, EventArgs e)
        {
            this.Hide();
            formaZaOdabirVremenaIDvorane form3 = new formaZaOdabirVremenaIDvorane(vrstaKorisnika);
            form3.Closed += (s, args) => this.Close();
            form3.Show();
        }
        #endregion

    }
}
