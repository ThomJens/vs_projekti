using System.Windows.Forms;
using System;
using System.Drawing;

namespace WindowsFormsApp1
{
    partial class PaaValikko
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
        ///
        private void InitializeComponent()
        {
            this.aikaNappi = new Button();
            this.pisteNappi = new Button();
            this.loputonNappi = new Button();
            this.virheetonNappi = new Button();
            this.kuvausLoota = new TextBox();
            this.ohjeLoota = new TextBox();
            this.SuspendLayout();
            // 
            // aikaNappi
            // 
            this.aikaNappi.Anchor = AnchorStyles.None;
            this.aikaNappi.BackColor = Color.Red;
            this.aikaNappi.FlatAppearance.BorderColor = Color.Yellow;
            this.aikaNappi.FlatStyle = FlatStyle.Flat;
            this.aikaNappi.Location = new Point(this.Size.Width + aikaNappi.Size.Width / 3, 75);
            this.aikaNappi.Margin = new Padding(4);
            this.aikaNappi.Name = "1";
            this.aikaNappi.Size = new Size(150, 72);
            this.aikaNappi.TabIndex = 0;
            this.aikaNappi.Click += new EventHandler(Klikkaus);
            this.aikaNappi.Text = "Aika";
            this.aikaNappi.MouseHover += new EventHandler(Kuvaus);
            this.aikaNappi.MouseLeave += new EventHandler(KursorinLahto);
            // 
            // pisteNappi
            // 
            this.pisteNappi.Anchor = AnchorStyles.None;
            this.pisteNappi.BackColor = Color.Red;
            this.pisteNappi.FlatAppearance.BorderColor = Color.Yellow;
            this.pisteNappi.FlatStyle = FlatStyle.Flat;
            this.pisteNappi.Location = new Point(this.Size.Width + pisteNappi.Size.Width / 3, 150);
            this.pisteNappi.Margin = new Padding(4);
            this.pisteNappi.Name = "2";
            this.pisteNappi.Size = new Size(150, 72);
            this.pisteNappi.TabIndex = 0;
            this.pisteNappi.Click += new EventHandler(Klikkaus);
            this.pisteNappi.Text = "Piste";
            this.pisteNappi.MouseHover += new EventHandler(Kuvaus);
            this.pisteNappi.MouseLeave += new EventHandler(KursorinLahto);
            // 
            // loputonNappi
            // 
            this.loputonNappi.Anchor = AnchorStyles.None;
            this.loputonNappi.BackColor = Color.Red;
            this.loputonNappi.FlatAppearance.BorderColor = Color.Yellow;
            this.loputonNappi.FlatStyle = FlatStyle.Flat;
            this.loputonNappi.Location = new Point(this.Size.Width + loputonNappi.Size.Width / 3, 225);
            this.loputonNappi.Margin = new Padding(4);
            this.loputonNappi.Name = "3";
            this.loputonNappi.Size = new Size(150, 72);
            this.loputonNappi.TabIndex = 0;
            this.loputonNappi.Click += new EventHandler(Klikkaus);
            this.loputonNappi.Text = "Loputon";
            this.loputonNappi.MouseHover += new EventHandler(Kuvaus);
            this.loputonNappi.MouseLeave += new EventHandler(KursorinLahto);
            // 
            // virheetonNappi
            // 
            this.virheetonNappi.Anchor = AnchorStyles.None;
            this.virheetonNappi.BackColor = Color.Red;
            this.virheetonNappi.FlatAppearance.BorderColor = Color.Yellow;
            this.virheetonNappi.FlatStyle = FlatStyle.Flat;
            this.virheetonNappi.Location = new Point(this.Size.Width + virheetonNappi.Size.Width / 3, 300);
            this.virheetonNappi.Margin = new Padding(4);
            this.virheetonNappi.Name = "4";
            this.virheetonNappi.Size = new Size(150, 72);
            this.virheetonNappi.TabIndex = 0;
            this.virheetonNappi.Click += new EventHandler(Klikkaus);
            this.virheetonNappi.Text = "Virheeton";
            this.virheetonNappi.MouseHover += new EventHandler(Kuvaus);
            this.virheetonNappi.MouseLeave += new EventHandler(KursorinLahto);
            //
            // kuvausLoota
            //
            this.kuvausLoota.Anchor = AnchorStyles.None;
            this.kuvausLoota.Location = new Point(this.Size.Width + kuvausLoota.Size.Width / 4, 400);
            this.kuvausLoota.Multiline = true;
            this.kuvausLoota.Size = new Size(150, 35);
            this.kuvausLoota.ForeColor = Color.White;
            this.kuvausLoota.BackColor = Color.Red;
            this.kuvausLoota.TextAlign = HorizontalAlignment.Center;
            //
            // ohjeLoota
            //
            this.ohjeLoota.Anchor = AnchorStyles.None;
            this.ohjeLoota.Multiline = true;
            this.ohjeLoota.Size = new Size(200 ,235);
            this.ohjeLoota.Location = new Point(50, this.Size.Height - ohjeLoota.Height);
            this.ohjeLoota.BackColor = Color.Red;
            this.ohjeLoota.ForeColor = Color.White;
            this.ohjeLoota.TextAlign = HorizontalAlignment.Center;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(0,0,0);
            this.ClientSize = new Size(800, 450);
            this.Margin = new Padding(4);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);

            this.Controls.Add(this.aikaNappi);
            this.Controls.Add(this.pisteNappi);
            this.Controls.Add(this.loputonNappi);
            this.Controls.Add(this.virheetonNappi);
            this.Controls.Add(this.kuvausLoota);
            this.Controls.Add(this.ohjeLoota);

        }

        #endregion

        private Button aikaNappi;
        private Button pisteNappi;
        private Button loputonNappi;
        private Button virheetonNappi;
        private TextBox kuvausLoota;
        private TextBox ohjeLoota;
    }
}