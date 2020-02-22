using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kolokviji
{
    class Gumb : Button
    {
        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            Form mojaForma = this.FindForm();

            //Dodat ćemo label u formu i preko toga labela saznati koji gumb je stisnut za potrebe lakšeg razmještaja studenata
            Label myLabel = new Label();

            if (!string.IsNullOrEmpty(this.AccessibleName.ToString()))
            {
                // AccessibleName je oblika imePrezime_jmbag
                int found = this.AccessibleName.IndexOf('_');
                #region Greška 0x2
                if ( found == -1 )
                {
                    // Gumbu je opisano AccessibleName ali nije u dobrom formatu - bug
                    MessageBox.Show("Kod: 0x2 ", "Greška u aplikaciji");
                    throw new Exception();
                }
                #endregion

                string ime = this.AccessibleName.Substring(0, found);
                string jmbag = this.AccessibleName.Substring(found + 2);

                if ( !string.IsNullOrEmpty(this.AccessibleDescription.ToString()))
                {
                    MessageBox.Show("JMBAG: " + jmbag + "\nStudent: " + ime + "\nPredmet: " + this.AccessibleDescription.ToString());
                }
                else
                {
                    MessageBox.Show("Student: " + ime);
                }
                myLabel.AccessibleName = ime;
            }
            else
            {
                myLabel.AccessibleName = "";
            }

            myLabel.Name = "pritisnutJeGumbSaStudentom";
            myLabel.Text = "";
            mojaForma.Controls.Add(myLabel);
        }
    }
}
