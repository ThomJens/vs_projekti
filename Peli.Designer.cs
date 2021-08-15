using System.Windows.Forms;
using System;
using System.Drawing;

namespace WindowsFormsApp1
{
    partial class Peli
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
            Panel ylaTausta = new Panel();
            ylaTausta.Dock = DockStyle.Top;
            ylaTausta.BackColor = Color.FromArgb(0, 255, 100);
            ylaTausta.Height = 15;

            this.components = new System.ComponentModel.Container();
            this.vihreaNappi = new Button();
            this.keltainenNappi = new Button();
            this.punainenNappi = new Button();
            this.pinkkiNappi = new Button();
            this.pisteBox = new TextBox();
            this.osumaBox = new TextBox();
            this.aikaBox = new TextBox();
            this.ajastinBox = new TextBox();
            this.vihje = new ToolTip(this.components);
            this.ajastin1 = new Timer(this.components);
            this.ajastin2 = new Timer(this.components);
            this.laskenta = new Timer(this.components);
            this.SuspendLayout();
            // 
            // vihreaNappi
            // 
            this.vihreaNappi.BackColor = Color.Green;
            this.vihreaNappi.FlatStyle = FlatStyle.Flat;
            this.vihreaNappi.FlatAppearance.BorderColor = Color.Green;
            var rand = new Random();
            //this.vihreaNappi.Location = new Point(rand.Next(10, 720), rand.Next(20, 390));
            this.vihreaNappi.Name = "vihreaNappi";
            this.vihreaNappi.Size = new Size(100, 100);
            this.vihreaNappi.TabIndex = 0;
            this.vihreaNappi.Text = "";
            this.vihreaNappi.UseVisualStyleBackColor = false;
            this.vihreaNappi.Click += new EventHandler(this.VihreaNappi_Click);
            //this.vihreaNappi.MouseHover += new System.EventHandler(this.MouseHover1);
            // 
            // keltainenNappi
            // 
            this.keltainenNappi.BackColor = Color.Yellow;
            this.keltainenNappi.FlatStyle = FlatStyle.Flat;
            this.keltainenNappi.FlatAppearance.BorderColor = Color.Yellow;
            this.keltainenNappi.Name = "keltainenNappi";
            this.keltainenNappi.Size = new Size(50, 50);
            this.keltainenNappi.TabIndex = 0;
            this.keltainenNappi.Text = "";
            this.keltainenNappi.UseVisualStyleBackColor = false;
            this.keltainenNappi.Click += new EventHandler(this.KeltainenNappi_Click);
            // 
            // punainenNappi
            // 
            this.punainenNappi.BackColor = Color.Red;
            this.punainenNappi.FlatStyle = FlatStyle.Flat;
            this.punainenNappi.FlatAppearance.BorderColor = Color.Red;
            this.punainenNappi.Name = "punainenNappi";
            this.punainenNappi.Size = new Size(25, 25);
            this.punainenNappi.TabIndex = 0;
            this.punainenNappi.Text = "";
            this.punainenNappi.UseVisualStyleBackColor = false;
            this.punainenNappi.Click += new EventHandler(this.PunainenNappi_Click);
            //
            // pinkkiNappi
            // 
            this.pinkkiNappi.BackColor = Color.DeepPink;
            this.pinkkiNappi.FlatStyle = FlatStyle.Flat;
            this.pinkkiNappi.FlatAppearance.BorderColor = Color.DeepPink;
            this.pinkkiNappi.Name = "punainenNappi";
            this.pinkkiNappi.Size = new Size(40, 40);
            this.pinkkiNappi.TabIndex = 0;
            this.pinkkiNappi.Text = "";
            this.pinkkiNappi.UseVisualStyleBackColor = false;
            this.pinkkiNappi.Click += new EventHandler(this.PinkkiNappi_Click);
            // 
            // pisteBox
            // 
            this.pisteBox.Location = new Point(350, 0);
            this.pisteBox.Name = "pisteBox";
            this.pisteBox.ReadOnly = true;
            this.pisteBox.Size = new Size(35, 20);
            this.pisteBox.TabIndex = 1;
            this.pisteBox.Text = "0";
            this.pisteBox.TextChanged += new EventHandler(this.PisteBox_TextChanged);
            this.pisteBox.TextAlign = HorizontalAlignment.Center;
            // 
            // osumaBox
            // 
            this.osumaBox.Location = new Point(300, 0);
            this.osumaBox.Name = "osumaBox";
            this.osumaBox.ReadOnly = true;
            this.osumaBox.Size = new Size(30, 20);
            this.osumaBox.TabIndex = 1;
            this.osumaBox.Text = "0";
            this.osumaBox.TextChanged += new EventHandler(this.OsumaBox_TextChanged);
            this.osumaBox.TextAlign = HorizontalAlignment.Center;
            // 
            // aikaBox
            // 
            this.aikaBox.Location = new Point(405, 0);
            this.aikaBox.Name = "aikaBox";
            this.aikaBox.ReadOnly = true;
            this.aikaBox.Size = new Size(30, 20);
            this.aikaBox.TabIndex = 1;
            this.aikaBox.Text = "0";
            this.aikaBox.TextChanged += new EventHandler(this.AikaBox_TextChanged);
            this.aikaBox.TextAlign = HorizontalAlignment.Center;
            //
            // ajastinBox
            //
            this.ajastinBox.Location = new Point(this.Size.Width + ajastinBox.Size.Width / 2, this.Size.Height );
            this.ajastinBox.Name = "ajastinBox";
            this.ajastinBox.ReadOnly = true;
            this.ajastinBox.Font = new Font(ajastinBox.Font.FontFamily, 56);
            this.ajastinBox.ForeColor = Color.White;
            this.ajastinBox.Size = new Size(35, 20);
            this.ajastinBox.BackColor = Color.Black;
            this.ajastinBox.TabIndex = 1;
            this.ajastinBox.Text = "";
            this.ajastinBox.TextChanged += new EventHandler(this.PisteBox_TextChanged);
            this.ajastinBox.TextAlign = HorizontalAlignment.Center;
            // 
            // Form1
            // 
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            BackColor = Color.FromArgb(0, 0, 0);
            StartPosition = FormStartPosition.CenterParent;
            Padding = new Padding(3);
            this.AutoScaleDimensions = new SizeF(4F, 9F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(800, 450);
            this.Controls.Add(this.pisteBox);
            this.Controls.Add(this.osumaBox);
            this.Controls.Add(this.aikaBox);
            this.Controls.Add(this.ajastinBox);
            ylaTausta.SendToBack();
            this.Name = "Form1";
            this.Text = "Form1";
            this.MouseDown += new MouseEventHandler(this.Form_MouseDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button vihreaNappi;
        private Button keltainenNappi;
        private Button punainenNappi;
        private Button pinkkiNappi;
        private TextBox pisteBox;
        private TextBox osumaBox;
        private TextBox aikaBox;
        private TextBox ajastinBox;
        private ToolTip vihje;
        //private ListBox listBox1;
        private Timer ajastin1;
        private Timer ajastin2;
        private Timer laskenta;
    }
}

