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
    public partial class formaZaOdabirVremenaIDvorane : Form
    {
        SqlConnection connection;
        string connectionString;
        int vrijemeKolokvija = 0;
        string brojDvorane = "";
        int vrstaKorisnika;

        // Varijabla koja nam govori način prikaza 
        // - prvo odabiremo vrijeme pa dvoranu (0) 
        // ili prvo odabiremo dvoranu pa onda vrijeme (1)
        int vrstaPrikaza;

        #region Inicijalizacija forme za Odabir vremena i dvorane održavanja kolokvija
        public formaZaOdabirVremenaIDvorane(int visi_pristup)
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["Kolokviji.Properties.Settings.Database1ConnectionString"].ConnectionString;
            vrstaKorisnika = visi_pristup;
        }
        #endregion

        #region Rukovanje pritiska na neko od vrijeme održavanja kolokvija
        private void listaVremenaBox_Click(object sender, EventArgs e)
        {
            // Spremimo rezultat odabira vremena kolokvija 
            if (listaVremenaBox.SelectedValue != null)
            {
                bool result = Int32.TryParse(listaVremenaBox.SelectedValue.ToString(), out vrijemeKolokvija);
                if (!result)
                {
                    MessageBox.Show("Nije se dobro pretvorio string u int!? " + listaVremenaBox.SelectedValue.ToString(), "Greška 0x0 u aplikaciji");
                }
            }
            else
            {
                vrijemeKolokvija = 0;
            }

            // Samo ako je način prikaza da smo prvo odabrali vrijeme se onda treba pokazati i dvorane
            if( vrstaPrikaza == 0)
            {
                popuni_listaDvoranaBox();
            }
        }
        #endregion

        #region Rukovanje pritiska na neku od dvorana u kojima se održavaju kolokviji
        private void listaDvoranaBox_Click(object sender, EventArgs e)
        {
            // Spremimo rezultat odabira dvorane održavanja kolokvija 
            if ( !string.IsNullOrEmpty(listaDvoranaBox.SelectedValue.ToString()) )
            {
                brojDvorane = listaDvoranaBox.SelectedValue.ToString();
            }
            else
            {
                // just in case
                brojDvorane = "";
            }

            if (vrstaPrikaza == 1)
            {
                popuni_listaVremenaBox();
            }
        }
        #endregion

        #region Rukovanje odabira biranja rasporeda po vremenu (promjena vrijednosti u radio gumbu)
        private void odabirPoVremenuRadioGumb_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                // Pritisnuli smo odabir po vremenu 
                panelZaOdabirVremena.Location = new Point(356, 23);
                panelZaOdabirDvorane.Location = new Point(356, 308);
                vrstaPrikaza = 0;
                popuni_listaVremenaBox();
            }
        }
        #endregion

        #region Rukovanje odabirom biranja rasporeda po dvoranama (promjena vrijednosti u radio gumbu)
        private void odabirPoDvoranamaRadioGumb_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                // Pritisnuli smo odabir po dvoranama 
                panelZaOdabirDvorane.Location = new Point(356, 23);
                panelZaOdabirVremena.Location = new Point(356, 308);
                vrstaPrikaza = 1;
                popuni_listaDvoranaBox();
            }
        }
        #endregion

        #region Popunjavanje liste sa ispisom vremena kolokvija
        private void popuni_listaVremenaBox()
        {
            if (vrstaPrikaza == 0)
            {
                //Ovdje dođemo kad se dogodi izmjena u radioButtonu odabirPoVremenuRadioGumb_CheckedChanged
                // Prvo se odabire vrijeme
                panelZaOdabirDvorane.Visible = false;
                panelZaOdabirVremena.Visible = true;                
                // Dohvati podatke o (svim) vremenima iz baze i stavi ih u DataTable tip podatka
                using (connection = new SqlConnection(connectionString))
                using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT DISTINCT Vrijeme FROM Dvorane ", connection))
                {
                    DataTable vremena = new DataTable();
                    adapter.Fill(vremena);

                    // Prikaži sva vremena u listaVremenaBox
                    listaVremenaBox.DisplayMember = "Vrijeme";
                    listaVremenaBox.ValueMember = "Vrijeme";
                    listaVremenaBox.DataSource = vremena;

                    // Onemogući da je neko vrijeme defaultno selektirano
                    listaVremenaBox.ClearSelected();
                    vrijemeKolokvija = 0;
                }
            }
            else if( vrstaPrikaza == 1 && !string.IsNullOrEmpty(brojDvorane) )
            {
                // Ovdje dođemo iz listaDvoranaBox_Click (kad odaberemo dvoranu)
                // Prvo se odabrala dvorana (morali smo provjeriti da je varijabla brojDvorane neprazna)
                panelZaOdabirDvorane.Visible = true;
                panelZaOdabirVremena.Visible = true;
                vidiRasporedGumb.Visible = true;
                // Dohvati podatke o vremenima za odabranu dvoranu iz baze i stavi ih u DataTable tip podatka
                using (connection = new SqlConnection(connectionString))
                using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT DISTINCT Vrijeme FROM Dvorane WHERE BrojDvorane = '" + brojDvorane +"'", connection))
                {
                    DataTable vremena = new DataTable();
                    adapter.Fill(vremena);

                    // Prikaži sva moguća vremena u listaVremenaBox
                    listaVremenaBox.DisplayMember = "Vrijeme";
                    listaVremenaBox.ValueMember = "Vrijeme";
                    listaVremenaBox.DataSource = vremena;

                    // Onemogući da je neko vrijeme defaultno selektirano
                    listaVremenaBox.ClearSelected();
                    vrijemeKolokvija = 0;
                }

            }
        }
        #endregion

        #region Popunjavanje liste sa ispisom dvorana za kolokviji
        private void popuni_listaDvoranaBox()
        {
            if (vrstaPrikaza == 0 && vrijemeKolokvija != 0)
            {
                //Ovdje dođemo kada smo odabrali vrijeme - nakon listaVremenaBox_Click
                // Prvo se odabiralo vrijeme i sad treba popuniti dvorane s odabranim vremenom (provjereno da varijabla vrijemeKolokvija nije neprazna)
                panelZaOdabirDvorane.Visible = true;
                panelZaOdabirVremena.Visible = true;
                vidiRasporedGumb.Visible = true;
                // Dohvati podatke o dvoranama u određenom vremenu iz baze i stavi ih u DataTable tip podatka
                using (connection = new SqlConnection(connectionString))
                using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT DISTINCT BrojDvorane FROM Dvorane WHERE Vrijeme = " + vrijemeKolokvija, connection))
                {
                    DataTable dvorane = new DataTable();
                    adapter.Fill(dvorane);

                    // Prikaži sve dvorane u listaDvoranaBox
                    listaDvoranaBox.DisplayMember = "BrojDvorane";
                    listaDvoranaBox.ValueMember = "BrojDvorane";
                    listaDvoranaBox.DataSource = dvorane;

                    // Onemogući da je neka dvorana defaultno selektirana
                    listaDvoranaBox.ClearSelected();
                    brojDvorane = "";
                }

            }
            else if (vrstaPrikaza == 1 )
            {
                // Ovdje dođemo nakon promjene radioButtona - odabirPoDvoranamaRadioGumb_CheckedChanged 
                // Prvo se odabire dvorana
                panelZaOdabirDvorane.Visible = true;
                panelZaOdabirVremena.Visible = false;
                // Dohvati podatke o (svim) dvoranama iz baze i stavi ih u DataTable tip podatka
                using (connection = new SqlConnection(connectionString))
                using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT DISTINCT BrojDvorane FROM Dvorane ", connection))
                {
                    DataTable dvorane = new DataTable();
                    adapter.Fill(dvorane);

                    // Prikaži sve moguće dvorane u listaDvoranaBox
                    listaDvoranaBox.DisplayMember = "BrojDvorane";
                    listaDvoranaBox.ValueMember = "BrojDvorane";
                    listaDvoranaBox.DataSource = dvorane;

                    // Onemogući da je neka dvorana defaultno selektirana
                    listaDvoranaBox.ClearSelected();
                    brojDvorane = "";
                }
            }
        }
        #endregion

        #region Rukovanje pritiska na gumb za prelazak u formu s prikazom rasporeda s odabranim vremenom i dvoranom
        private void vidiRasporedGumb_Click(object sender, EventArgs e)
        {
            // Ako nije odabrano vrijeme ili dvorana
            if (vrijemeKolokvija == 0 || string.IsNullOrEmpty(brojDvorane))
            {
                MessageBox.Show("Niste odabrali i vrijeme i dvoranu održavanja kolokvija.", "Greška");
            }
            else
            {
                // Sakriji trenutnu formu  
                this.Hide();
                // Otvori formu za prikaz rasporeda u određenoj dvorani
                // Potrebno je poslati broj odabrane dvorane i vrijeme događanja kolokvija
                var form4 = new formaZaPrikazRaporeda(brojDvorane, vrijemeKolokvija, vrstaKorisnika);
                form4.Closed += (s, args) => this.Close();
                form4.Show();
            }
        }
        #endregion

        #region Povratak na prethodnu formu
        private void natragNaPocetnuFormuGumb_Click(object sender, EventArgs e)
        {
            this.Hide();
            pocetnaForma form2 = new pocetnaForma();
            form2.FormClosed += (s, args) => this.Close();
            form2.Show();
        }
        #endregion
    }
}
