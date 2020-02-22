namespace Kolokviji
{
    partial class pocetnaForma
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.kolokvijiLabel = new System.Windows.Forms.Label();
            this.prijaviSeLabel = new System.Windows.Forms.Label();
            this.korisnickoImeLabel = new System.Windows.Forms.Label();
            this.korisnickoImeText = new System.Windows.Forms.TextBox();
            this.lozinkaLabel = new System.Windows.Forms.Label();
            this.lozinkaText = new System.Windows.Forms.TextBox();
            this.prijaviSeGumb = new System.Windows.Forms.Button();
            this.pogledajRasporedGumb = new System.Windows.Forms.Button();
            this.prijavaAdminaPanel = new System.Windows.Forms.Panel();
            this.toolTipObjasnjenjePrijave = new System.Windows.Forms.ToolTip(this.components);
            this.unHidePanelaZaPrijavuGumb = new System.Windows.Forms.Button();
            this.toolTipObjasnjenjeZaObicneKorisnike = new System.Windows.Forms.ToolTip(this.components);
            this.prijavaAdminaPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // kolokvijiLabel
            // 
            this.kolokvijiLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.kolokvijiLabel.AutoSize = true;
            this.kolokvijiLabel.Font = new System.Drawing.Font("Monotype Corsiva", 27.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.kolokvijiLabel.Location = new System.Drawing.Point(386, 24);
            this.kolokvijiLabel.Name = "kolokvijiLabel";
            this.kolokvijiLabel.Size = new System.Drawing.Size(209, 45);
            this.kolokvijiLabel.TabIndex = 9;
            this.kolokvijiLabel.Text = "KOLOKVIJI";
            // 
            // prijaviSeLabel
            // 
            this.prijaviSeLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.prijaviSeLabel.AutoSize = true;
            this.prijaviSeLabel.Font = new System.Drawing.Font("Book Antiqua", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.prijaviSeLabel.Location = new System.Drawing.Point(251, 24);
            this.prijaviSeLabel.Name = "prijaviSeLabel";
            this.prijaviSeLabel.Size = new System.Drawing.Size(133, 32);
            this.prijaviSeLabel.TabIndex = 10;
            this.prijaviSeLabel.Text = "PRIJAVA";
            this.toolTipObjasnjenjePrijave.SetToolTip(this.prijaviSeLabel, "Za korisnike s višom razinom pristupa.");
            // 
            // korisnickoImeLabel
            // 
            this.korisnickoImeLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.korisnickoImeLabel.AutoSize = true;
            this.korisnickoImeLabel.Font = new System.Drawing.Font("Book Antiqua", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.korisnickoImeLabel.Location = new System.Drawing.Point(57, 96);
            this.korisnickoImeLabel.Name = "korisnickoImeLabel";
            this.korisnickoImeLabel.Size = new System.Drawing.Size(113, 20);
            this.korisnickoImeLabel.TabIndex = 12;
            this.korisnickoImeLabel.Text = "&korisničko ime";
            // 
            // korisnickoImeText
            // 
            this.korisnickoImeText.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.korisnickoImeText.Location = new System.Drawing.Point(199, 96);
            this.korisnickoImeText.Name = "korisnickoImeText";
            this.korisnickoImeText.Size = new System.Drawing.Size(253, 20);
            this.korisnickoImeText.TabIndex = 13;
            // 
            // lozinkaLabel
            // 
            this.lozinkaLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lozinkaLabel.AutoSize = true;
            this.lozinkaLabel.Font = new System.Drawing.Font("Book Antiqua", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lozinkaLabel.Location = new System.Drawing.Point(55, 145);
            this.lozinkaLabel.Name = "lozinkaLabel";
            this.lozinkaLabel.Size = new System.Drawing.Size(63, 20);
            this.lozinkaLabel.TabIndex = 14;
            this.lozinkaLabel.Text = "&lozinka";
            // 
            // lozinkaText
            // 
            this.lozinkaText.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lozinkaText.Location = new System.Drawing.Point(200, 145);
            this.lozinkaText.Name = "lozinkaText";
            this.lozinkaText.Size = new System.Drawing.Size(252, 20);
            this.lozinkaText.TabIndex = 15;
            this.lozinkaText.UseSystemPasswordChar = true;
            // 
            // prijaviSeGumb
            // 
            this.prijaviSeGumb.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.prijaviSeGumb.Font = new System.Drawing.Font("Book Antiqua", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.prijaviSeGumb.Location = new System.Drawing.Point(199, 200);
            this.prijaviSeGumb.Name = "prijaviSeGumb";
            this.prijaviSeGumb.Size = new System.Drawing.Size(254, 39);
            this.prijaviSeGumb.TabIndex = 16;
            this.prijaviSeGumb.Text = "Prijavi se";
            this.toolTipObjasnjenjePrijave.SetToolTip(this.prijaviSeGumb, "Za korisnike s višom razinom pristupa.");
            this.prijaviSeGumb.UseVisualStyleBackColor = true;
            this.prijaviSeGumb.Click += new System.EventHandler(this.prijaviSeGumb_Click);
            // 
            // pogledajRasporedGumb
            // 
            this.pogledajRasporedGumb.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pogledajRasporedGumb.Font = new System.Drawing.Font("Book Antiqua", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.pogledajRasporedGumb.Location = new System.Drawing.Point(315, 97);
            this.pogledajRasporedGumb.Name = "pogledajRasporedGumb";
            this.pogledajRasporedGumb.Size = new System.Drawing.Size(347, 42);
            this.pogledajRasporedGumb.TabIndex = 18;
            this.pogledajRasporedGumb.Text = "Pogledaj raspored po učionicama";
            this.toolTipObjasnjenjeZaObicneKorisnike.SetToolTip(this.pogledajRasporedGumb, "Za korisnike bez više razine pristupa.");
            this.pogledajRasporedGumb.UseVisualStyleBackColor = true;
            this.pogledajRasporedGumb.Click += new System.EventHandler(this.pogledajRasporedGumb_Click);
            // 
            // prijavaAdminaPanel
            // 
            this.prijavaAdminaPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.prijavaAdminaPanel.Controls.Add(this.prijaviSeGumb);
            this.prijavaAdminaPanel.Controls.Add(this.lozinkaText);
            this.prijavaAdminaPanel.Controls.Add(this.lozinkaLabel);
            this.prijavaAdminaPanel.Controls.Add(this.korisnickoImeText);
            this.prijavaAdminaPanel.Controls.Add(this.korisnickoImeLabel);
            this.prijavaAdminaPanel.Controls.Add(this.prijaviSeLabel);
            this.prijavaAdminaPanel.Location = new System.Drawing.Point(155, 328);
            this.prijavaAdminaPanel.Name = "prijavaAdminaPanel";
            this.prijavaAdminaPanel.Size = new System.Drawing.Size(637, 266);
            this.prijavaAdminaPanel.TabIndex = 19;
            this.prijavaAdminaPanel.Visible = false;
            // 
            // toolTipObjasnjenjePrijave
            // 
            this.toolTipObjasnjenjePrijave.ShowAlways = true;
            // 
            // unHidePanelaZaPrijavuGumb
            // 
            this.unHidePanelaZaPrijavuGumb.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.unHidePanelaZaPrijavuGumb.Font = new System.Drawing.Font("Book Antiqua", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.unHidePanelaZaPrijavuGumb.Location = new System.Drawing.Point(315, 168);
            this.unHidePanelaZaPrijavuGumb.Name = "unHidePanelaZaPrijavuGumb";
            this.unHidePanelaZaPrijavuGumb.Size = new System.Drawing.Size(347, 42);
            this.unHidePanelaZaPrijavuGumb.TabIndex = 20;
            this.unHidePanelaZaPrijavuGumb.Text = "Prijavi se";
            this.toolTipObjasnjenjePrijave.SetToolTip(this.unHidePanelaZaPrijavuGumb, "Za korisnike s višom razinom pristupa.");
            this.unHidePanelaZaPrijavuGumb.UseVisualStyleBackColor = true;
            this.unHidePanelaZaPrijavuGumb.Click += new System.EventHandler(this.unHidePanelaZaPrijavuGumb_Click);
            // 
            // toolTipObjasnjenjeZaObicneKorisnike
            // 
            this.toolTipObjasnjenjeZaObicneKorisnike.ShowAlways = true;
            // 
            // pocetnaForma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 661);
            this.Controls.Add(this.unHidePanelaZaPrijavuGumb);
            this.Controls.Add(this.prijavaAdminaPanel);
            this.Controls.Add(this.pogledajRasporedGumb);
            this.Controls.Add(this.kolokvijiLabel);
            this.MinimumSize = new System.Drawing.Size(1000, 700);
            this.Name = "pocetnaForma";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kolokviji";
            this.prijavaAdminaPanel.ResumeLayout(false);
            this.prijavaAdminaPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label kolokvijiLabel;
        private System.Windows.Forms.Label prijaviSeLabel;
        private System.Windows.Forms.Label korisnickoImeLabel;
        private System.Windows.Forms.TextBox korisnickoImeText;
        private System.Windows.Forms.Label lozinkaLabel;
        private System.Windows.Forms.TextBox lozinkaText;
        private System.Windows.Forms.Button prijaviSeGumb;
        private System.Windows.Forms.Button pogledajRasporedGumb;
        private System.Windows.Forms.Panel prijavaAdminaPanel;
        private System.Windows.Forms.ToolTip toolTipObjasnjenjePrijave;
        private System.Windows.Forms.ToolTip toolTipObjasnjenjeZaObicneKorisnike;
        private System.Windows.Forms.Button unHidePanelaZaPrijavuGumb;
    }
}

