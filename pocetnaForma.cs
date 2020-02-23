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
    public partial class pocetnaForma : Form
    {
        SqlConnection connection;
        string connectionString;
        // Varijabla koja nam govori radi li se o običnom korisniku, ili korisniku s višim pristupom
        int visi_pristup = 0;

        #region Inicijalizacija početne forme
        public pocetnaForma()
        {
            InitializeComponent();
            //connectionString = ConfigurationManager.ConnectionStrings["Kolokviji.Properties.Settings.Database1ConnectionString"].ConnectionString;
            connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Lucija\PMF\5.godina\RP3\Projekt4\-rp3-kolokviji\Database1.mdf;Integrated Security=True";
        }
        #endregion

        #region Rukovanje pritiska na gumb za prikaz rasporeda za obične korisnike
        private void pogledajRasporedGumb_Click(object sender, EventArgs e)
        {
            // sakriji trenutnu formu
            this.Hide();
            // otvori novu formu za odabir vremena pisanja kolokvija
            var form2 = new formaZaOdabirVremenaIDvorane(visi_pristup);
            form2.Closed += (s, args) => this.Close();
            form2.Show();
        }
        #endregion

        #region Rukovanje pritiska na gumb za prikaz rasporeda za više korisnike
        private void prijaviSeGumb_Click(object sender, EventArgs e)
        {
            // Povezivanje s bazom radi provjere je li korisnik s unesenim podacima uistinu u bazi podataka
            string query = "SELECT username, password FROM Admini WHERE username = @username AND password = @password";

            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                command.Parameters.AddWithValue("@username", korisnickoImeText.Text);
                command.Parameters.AddWithValue("@password", lozinkaText.Text);

                DataTable Admin = new DataTable();
                adapter.Fill(Admin);

                if (Admin.Rows.Count == 0)
                {
                    // Korisnik nije u bazi
                    MessageBox.Show("Neispravni podaci!", "Greška");
                }
                else
                {
                    // Dobra prijava
                    visi_pristup = 1;
                    this.Hide();
                    var form2 = new formaZaOdabirVremenaIDvorane(visi_pristup);
                    form2.Closed += (s, args) => this.Close();
                    form2.Show();
                }
            }
        }
        #endregion

        #region Prikaz opcije za prijavu višeg korisnika
        private void unHidePanelaZaPrijavuGumb_Click(object sender, EventArgs e)
        {
            this.prijavaAdminaPanel.Visible = true;
        }
        #endregion
    }
}
