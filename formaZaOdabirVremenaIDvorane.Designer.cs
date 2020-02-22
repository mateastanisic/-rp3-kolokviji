namespace Kolokviji
{
    partial class formaZaOdabirVremenaIDvorane
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
            this.listaDvoranaBox = new System.Windows.Forms.ListBox();
            this.listaVremenaBox = new System.Windows.Forms.ListBox();
            this.odaberiDvoranuLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.natragNaPocetnuFormuGumb = new System.Windows.Forms.Button();
            this.vidiRasporedGumb = new System.Windows.Forms.Button();
            this.panelZaOdabirVremena = new System.Windows.Forms.Panel();
            this.panelZaOdabirDvorane = new System.Windows.Forms.Panel();
            this.odabirPoVremenuRadioGumb = new System.Windows.Forms.RadioButton();
            this.odabirPoDvoranamaRadioGumb = new System.Windows.Forms.RadioButton();
            this.nacinOdabiraGroupBox = new System.Windows.Forms.GroupBox();
            this.panelZaOdabirVremena.SuspendLayout();
            this.panelZaOdabirDvorane.SuspendLayout();
            this.nacinOdabiraGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // listaDvoranaBox
            // 
            this.listaDvoranaBox.Font = new System.Drawing.Font("Book Antiqua", 14.25F, System.Drawing.FontStyle.Bold);
            this.listaDvoranaBox.FormattingEnabled = true;
            this.listaDvoranaBox.ItemHeight = 23;
            this.listaDvoranaBox.Location = new System.Drawing.Point(38, 63);
            this.listaDvoranaBox.Name = "listaDvoranaBox";
            this.listaDvoranaBox.Size = new System.Drawing.Size(264, 188);
            this.listaDvoranaBox.TabIndex = 1;
            this.listaDvoranaBox.Click += new System.EventHandler(this.listaDvoranaBox_Click);
            // 
            // listaVremenaBox
            // 
            this.listaVremenaBox.Font = new System.Drawing.Font("Book Antiqua", 14.25F, System.Drawing.FontStyle.Bold);
            this.listaVremenaBox.FormattingEnabled = true;
            this.listaVremenaBox.ItemHeight = 23;
            this.listaVremenaBox.Location = new System.Drawing.Point(37, 59);
            this.listaVremenaBox.Name = "listaVremenaBox";
            this.listaVremenaBox.Size = new System.Drawing.Size(264, 165);
            this.listaVremenaBox.TabIndex = 3;
            this.listaVremenaBox.Click += new System.EventHandler(this.listaVremenaBox_Click);
            // 
            // odaberiDvoranuLabel
            // 
            this.odaberiDvoranuLabel.AutoSize = true;
            this.odaberiDvoranuLabel.Font = new System.Drawing.Font("Book Antiqua", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.odaberiDvoranuLabel.Location = new System.Drawing.Point(22, 7);
            this.odaberiDvoranuLabel.Name = "odaberiDvoranuLabel";
            this.odaberiDvoranuLabel.Size = new System.Drawing.Size(294, 32);
            this.odaberiDvoranuLabel.TabIndex = 0;
            this.odaberiDvoranuLabel.Text = "ODABERI &DVORANU";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Book Antiqua", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label1.Location = new System.Drawing.Point(31, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(270, 32);
            this.label1.TabIndex = 2;
            this.label1.Text = "ODABERI &VRIJEME";
            // 
            // natragNaPocetnuFormuGumb
            // 
            this.natragNaPocetnuFormuGumb.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.natragNaPocetnuFormuGumb.Font = new System.Drawing.Font("Book Antiqua", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.natragNaPocetnuFormuGumb.Location = new System.Drawing.Point(832, 594);
            this.natragNaPocetnuFormuGumb.Name = "natragNaPocetnuFormuGumb";
            this.natragNaPocetnuFormuGumb.Size = new System.Drawing.Size(124, 37);
            this.natragNaPocetnuFormuGumb.TabIndex = 6;
            this.natragNaPocetnuFormuGumb.Text = "Natrag";
            this.natragNaPocetnuFormuGumb.UseVisualStyleBackColor = true;
            this.natragNaPocetnuFormuGumb.Click += new System.EventHandler(this.natragNaPocetnuFormuGumb_Click);
            // 
            // vidiRasporedGumb
            // 
            this.vidiRasporedGumb.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.vidiRasporedGumb.Font = new System.Drawing.Font("Book Antiqua", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.vidiRasporedGumb.Location = new System.Drawing.Point(393, 594);
            this.vidiRasporedGumb.Name = "vidiRasporedGumb";
            this.vidiRasporedGumb.Size = new System.Drawing.Size(264, 37);
            this.vidiRasporedGumb.TabIndex = 7;
            this.vidiRasporedGumb.Text = "Vidi raspored";
            this.vidiRasporedGumb.UseVisualStyleBackColor = true;
            this.vidiRasporedGumb.Visible = false;
            this.vidiRasporedGumb.Click += new System.EventHandler(this.vidiRasporedGumb_Click);
            // 
            // panelZaOdabirVremena
            // 
            this.panelZaOdabirVremena.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panelZaOdabirVremena.Controls.Add(this.label1);
            this.panelZaOdabirVremena.Controls.Add(this.listaVremenaBox);
            this.panelZaOdabirVremena.Location = new System.Drawing.Point(356, 23);
            this.panelZaOdabirVremena.Name = "panelZaOdabirVremena";
            this.panelZaOdabirVremena.Size = new System.Drawing.Size(338, 258);
            this.panelZaOdabirVremena.TabIndex = 8;
            this.panelZaOdabirVremena.Visible = false;
            // 
            // panelZaOdabirDvorane
            // 
            this.panelZaOdabirDvorane.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panelZaOdabirDvorane.Controls.Add(this.odaberiDvoranuLabel);
            this.panelZaOdabirDvorane.Controls.Add(this.listaDvoranaBox);
            this.panelZaOdabirDvorane.Location = new System.Drawing.Point(356, 308);
            this.panelZaOdabirDvorane.Name = "panelZaOdabirDvorane";
            this.panelZaOdabirDvorane.Size = new System.Drawing.Size(338, 269);
            this.panelZaOdabirDvorane.TabIndex = 9;
            this.panelZaOdabirDvorane.Visible = false;
            // 
            // odabirPoVremenuRadioGumb
            // 
            this.odabirPoVremenuRadioGumb.AutoSize = true;
            this.odabirPoVremenuRadioGumb.Font = new System.Drawing.Font("Book Antiqua", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.odabirPoVremenuRadioGumb.Location = new System.Drawing.Point(19, 36);
            this.odabirPoVremenuRadioGumb.Name = "odabirPoVremenuRadioGumb";
            this.odabirPoVremenuRadioGumb.Size = new System.Drawing.Size(114, 24);
            this.odabirPoVremenuRadioGumb.TabIndex = 10;
            this.odabirPoVremenuRadioGumb.TabStop = true;
            this.odabirPoVremenuRadioGumb.Text = "Po vremenu";
            this.odabirPoVremenuRadioGumb.UseVisualStyleBackColor = true;
            this.odabirPoVremenuRadioGumb.CheckedChanged += new System.EventHandler(this.odabirPoVremenuRadioGumb_CheckedChanged);
            // 
            // odabirPoDvoranamaRadioGumb
            // 
            this.odabirPoDvoranamaRadioGumb.AutoSize = true;
            this.odabirPoDvoranamaRadioGumb.Font = new System.Drawing.Font("Book Antiqua", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.odabirPoDvoranamaRadioGumb.Location = new System.Drawing.Point(19, 59);
            this.odabirPoDvoranamaRadioGumb.Name = "odabirPoDvoranamaRadioGumb";
            this.odabirPoDvoranamaRadioGumb.Size = new System.Drawing.Size(131, 24);
            this.odabirPoDvoranamaRadioGumb.TabIndex = 11;
            this.odabirPoDvoranamaRadioGumb.TabStop = true;
            this.odabirPoDvoranamaRadioGumb.Text = "Po dvoranama";
            this.odabirPoDvoranamaRadioGumb.UseVisualStyleBackColor = true;
            this.odabirPoDvoranamaRadioGumb.CheckedChanged += new System.EventHandler(this.odabirPoDvoranamaRadioGumb_CheckedChanged);
            // 
            // nacinOdabiraGroupBox
            // 
            this.nacinOdabiraGroupBox.Controls.Add(this.odabirPoDvoranamaRadioGumb);
            this.nacinOdabiraGroupBox.Controls.Add(this.odabirPoVremenuRadioGumb);
            this.nacinOdabiraGroupBox.Font = new System.Drawing.Font("Book Antiqua", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nacinOdabiraGroupBox.Location = new System.Drawing.Point(40, 23);
            this.nacinOdabiraGroupBox.Name = "nacinOdabiraGroupBox";
            this.nacinOdabiraGroupBox.Size = new System.Drawing.Size(266, 102);
            this.nacinOdabiraGroupBox.TabIndex = 12;
            this.nacinOdabiraGroupBox.TabStop = false;
            this.nacinOdabiraGroupBox.Text = "NAČIN ODABIRA RASPOREDA";
            // 
            // formaZaOdabirVremenaIDvorane
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 661);
            this.Controls.Add(this.nacinOdabiraGroupBox);
            this.Controls.Add(this.panelZaOdabirDvorane);
            this.Controls.Add(this.panelZaOdabirVremena);
            this.Controls.Add(this.vidiRasporedGumb);
            this.Controls.Add(this.natragNaPocetnuFormuGumb);
            this.MinimumSize = new System.Drawing.Size(1000, 700);
            this.Name = "formaZaOdabirVremenaIDvorane";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Odaberi vrijeme i dvoranu";
            this.panelZaOdabirVremena.ResumeLayout(false);
            this.panelZaOdabirVremena.PerformLayout();
            this.panelZaOdabirDvorane.ResumeLayout(false);
            this.panelZaOdabirDvorane.PerformLayout();
            this.nacinOdabiraGroupBox.ResumeLayout(false);
            this.nacinOdabiraGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listaDvoranaBox;
        private System.Windows.Forms.ListBox listaVremenaBox;
        private System.Windows.Forms.Label odaberiDvoranuLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button natragNaPocetnuFormuGumb;
        private System.Windows.Forms.Button vidiRasporedGumb;
        private System.Windows.Forms.Panel panelZaOdabirVremena;
        private System.Windows.Forms.Panel panelZaOdabirDvorane;
        private System.Windows.Forms.RadioButton odabirPoVremenuRadioGumb;
        private System.Windows.Forms.RadioButton odabirPoDvoranamaRadioGumb;
        private System.Windows.Forms.GroupBox nacinOdabiraGroupBox;
    }
}