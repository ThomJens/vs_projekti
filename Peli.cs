using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Shapes;
using Rectangle = System.Drawing.Rectangle;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;

namespace WindowsFormsApp1
{
    public partial class Peli : Form
    {
        int tunnus;
        private static readonly Random random = new Random();

        public static class Vakiot
        {
            public static byte aloitusTikit;
            public static byte tikit;
            public static int osuma;
            public static int painallukset;
            public static float suurin = 0.0f;
            public static float pienin = 100.0f;
            public static int keltainenNappula;
            public static byte keltainenNappulaSisa = 10;
            public static int punainenNappula;
            public static byte punainenNappulaSisa = 10;

            public static double alkaa = DateTime.Now.TimeOfDay.TotalMilliseconds;
            public static double aloitus = DateTime.Now.TimeOfDay.TotalMilliseconds;

            public static bool pinkkiNukkuu = true;
            public static readonly int piste = 25;
            public static readonly int minimi = 10;
            public static readonly int maximi = 380;
            public static readonly int kerroin = 2;

            public static string Lause1()
            {
                int yhteensa = painallukset + osuma;
                return $"Osumia :{osuma} / {yhteensa}";
            }
            public static double Tarkkuus()
            {
                double yhteensa = painallukset + osuma;
                double tarkkuus = (Convert.ToDouble(osuma) / yhteensa * 100);
                return Math.Round(tarkkuus, 1);
            }
            public static string Lause2()
            {
                return $"Tarkkuutesi: {Tarkkuus()} %";
            }
            public static string Lause3(string tekstia)
            {
                int yhteensa = painallukset + osuma;
                int ka_pisteet = yhteensa == 0 ? 1 : Convert.ToInt16(tekstia) / yhteensa;
                return $"Osuman keskiarvo: {ka_pisteet}";
            }
            public static string Lause4()
            {
                pienin = pienin == 100 ? 0 : pienin;
                return $"Suurin pisteesi: {suurin}\nPienin pisteesi: {pienin}";
            }
            public static double Aika(byte a = 2)
            {
                return Math.Round(((DateTime.Now.TimeOfDay.TotalMilliseconds - aloitus) / 1000), a);
            }
            public static string Lause5()
            {
                return $"Aikasi: {Aika(3)} sekuntia";
            }
        }

        List<Button> nappiLista = new List<Button>();

        public Peli(int numero)
        {
            InitializeComponent();
            tunnus = numero;
            AjastinKaynnistys();
            Laskenta();
        }

        public void AjastinKaynnistys()
        {
            ajastin1 = new Timer();
            ajastin1.Tick += new EventHandler(Ajastin1_Tick);
            ajastin1.Interval = 100;

            ajastin2 = new Timer();
            ajastin2.Tick += new EventHandler(Ajastin2_Tick);
            ajastin2.Interval = 1000;

            laskenta = new Timer();
            laskenta.Tick += new EventHandler(Aloitus_Tick);
            laskenta.Interval = 1000;
        }

        public void Pysaytys()
        {
            ajastin1.Stop();
            ajastin2.Stop();

            Controls.Remove(vihreaNappi);
            Controls.Remove(keltainenNappi);
            Controls.Remove(punainenNappi);
            Controls.Remove(pinkkiNappi);
        }

        public void TekstiTyhjennys()
        {
            pisteBox.Text = "0";
            aikaBox.Text = "0.00";
            osumaBox.Text = "100%";
        }

        public void Nollaus()
        {
            Vakiot.aloitusTikit = 0;
            Vakiot.tikit = 0;
            Vakiot.osuma = 0;
            Vakiot.painallukset = 0;
            Vakiot.suurin = 0.0f;
            Vakiot.pienin = 100f;
            Vakiot.keltainenNappula = 0;
            Vakiot.keltainenNappulaSisa = 10;
            Vakiot.punainenNappula = 0;
            Vakiot.punainenNappulaSisa = 10;

            nappiLista = new List<Button>();
            
            this.TekstiTyhjennys();
            NappiSijainti(vihreaNappi, nappiLista);

            Vakiot.alkaa = DateTime.Now.TimeOfDay.TotalMilliseconds;
            Vakiot.aloitus = DateTime.Now.TimeOfDay.TotalMilliseconds;

            ajastin1.Start();            
        }

        private void LoppuLoota()
        {
            bool loppu = false;
            int syy = 0;

            switch (tunnus)
            {
                case 1:
                    if (Vakiot.Aika() >= 60)
                    {
                        syy = 4;
                        loppu = true;
                    }
                    break;
                case 2:
                    if (Convert.ToInt16(pisteBox.Text) >= 3000)
                    {
                        syy = 2;
                        loppu = true;
                    }
                    break;
                case 3:
                    if (Convert.ToInt16(pisteBox.Text) <= -200)
                    {
                        syy = 1;
                        loppu = true;
                    }
                    break;
                case 4:
                    if (Vakiot.painallukset > 0)
                    {
                        syy = 3;
                        loppu = true;
                    }
                    break;
            }

            /*
            if (Convert.ToInt16(pisteBox.Text) <= -200) {
                syy = 1;
                loppu = true;
            }
            if (Convert.ToInt16(pisteBox.Text) >= 3000) {
                syy = 2;
                loppu = true;
            }
            if (Vakiot.painallukset > 20) {
                syy = 3;
                loppu = true;
            }
            if (Vakiot.Aika() >= 120) {
                syy = 4;
                loppu = true;
            }
            */
            if (loppu) {
                Lopetus(syy);
            }
        }

        private void Lopetus(int x)
        {
            this.Pysaytys();

            aikaBox.Text = Convert.ToString(Vakiot.Aika());
            osumaBox.Text = Convert.ToString(Vakiot.Tarkkuus()) + " %";
            string viesti = $"Pisteesi: {pisteBox.Text}\n\n{Vakiot.Lause1()}\n{Vakiot.Lause2()}\n{Vakiot.Lause3(pisteBox.Text)}\n{Vakiot.Lause4()}\n{Vakiot.Lause5()}\n\nAloitetaanko Alusta?";

            string syy = "";

            switch (x) {
                case 1:
                    syy = "Liian alhainen piste määrä.";
                    break;
                case 2:
                    syy = "Sait vähintään 3000 pistettä.";
                    break;
                case 3:
                    syy = "Painoit ohi nappulan.";
                    break;
                case 4:
                    syy = "60 sekunttia tuli täyteen.";
                    break;
                case 5:
                    syy = "Loppu. Pinkki pääsi karkuun";
                    break;
            }

            AnimtedMsgBox.Show(viesti, syy);

            if (AnimtedMsgBox.nappulaTulos == DialogResult.Yes)
            {
                this.Controls.Add(ajastinBox);
                this.TekstiTyhjennys();
                this.Laskenta();
                pisteBox.Text = "0";
            }
            else if (AnimtedMsgBox.nappulaTulos == DialogResult.Abort)
            {
                this.Hide();
                PaaValikko paaValikko1 = new PaaValikko();
                paaValikko1.Show();
            }
            else
            {
                Application.Exit();
            }
        }

        void Form_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (ajastin1.Enabled && (e.Button == MouseButtons.Right | e.Button == MouseButtons.Left))
            {
                short x = Convert.ToInt16(pisteBox.Text);
                pisteBox.Text = Convert.ToString(x - Vakiot.piste);

                Vakiot.painallukset++;
                LoppuLoota();
            }
        }

        private void NappulaNollaus(int nappulaNumero)
        {
            Vakiot.osuma++;
            short y = Convert.ToInt16(pisteBox.Text);
            double aikaEro = DateTime.Now.TimeOfDay.TotalMilliseconds - Vakiot.alkaa;
            byte jakoNumero = Convert.ToByte(8 / Math.Pow(2, nappulaNumero));
            float pisteet = float.Parse(Convert.ToString(Math.Floor(100 * Math.Pow(aikaEro / 1000, -1) / jakoNumero)));
            Vakiot.pienin = Math.Min(Vakiot.pienin, pisteet);
            Vakiot.suurin = Math.Max(Vakiot.suurin, pisteet);
            pisteBox.Text = Convert.ToString(y + pisteet);

            switch (nappulaNumero)
            {
                case 1:
                    nappiLista.Remove(vihreaNappi);
                    NappiSijainti(vihreaNappi, nappiLista);
                    nappiLista.Add(vihreaNappi);
                    Vakiot.alkaa = DateTime.Now.TimeOfDay.TotalMilliseconds;
                    Vakiot.tikit = 0;
                    Vakiot.keltainenNappula++;
                    break;
                case 2:
                    Vakiot.keltainenNappula = 0;
                    Vakiot.keltainenNappulaSisa = 10;
                    Controls.Remove(keltainenNappi);
                    nappiLista.Remove(keltainenNappi);

                    break;
                case 3:
                    Vakiot.punainenNappula = 0;
                    Vakiot.punainenNappulaSisa = 10;
                    Controls.Remove(punainenNappi);
                    nappiLista.Remove(vihreaNappi);
                    break;
            }
            LoppuLoota();
        }

        private void VihreaNappi_Click(object sender, EventArgs e)
        {
            Invalidate();
            NappulaNollaus(1);
            Update();
            /*var rand = new Random();
            Rectangle luukku = new Rectangle(600, 350, 800, 450);
            Pen blackPen = new Pen(Color.Red, 3);
            Graphics g = CreateGraphics();
            g.DrawPolygon(blackPen, RandomMuoto(10, luukku));*/
        }

        private void KeltainenNappi_Click(object sender, EventArgs e)
        {
            Invalidate();
            NappulaNollaus(2);
            Update();
        }

        private void PunainenNappi_Click(object sender, EventArgs e)
        {
            Invalidate();
            NappulaNollaus(3);
            Update();
        }

        private void PinkkiNappi_Click(object sender, EventArgs e)
        {
            Invalidate();
            Vakiot.osuma++;
            ajastin2.Stop();
            Vakiot.pinkkiNukkuu = true;
            Controls.Remove(pinkkiNappi);
            nappiLista.Remove(pinkkiNappi);
            LoppuLoota();
            Update();
        }

        private void PisteBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void OsumaBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void AikaBox_TextChanged(object sender, EventArgs e)
        {

        }

        public void Laskenta()
        {
            ajastinBox.Text = "3";
            laskenta.Start();
        }

        private void AikaTikki(int valinta, int nappi)
        {
            switch (valinta)
            {
                case 1:
                    switch (nappi)
                    {
                        case 1:
                            break;
                        case 2:
                            NappiSijainti(keltainenNappi, nappiLista);
                            Vakiot.keltainenNappulaSisa--;
                            nappiLista.Add(keltainenNappi);
                            break;
                        case 3:
                            NappiSijainti(punainenNappi, nappiLista);
                            Vakiot.punainenNappulaSisa--;
                            nappiLista.Add(punainenNappi);
                            break;
                    }
                    break;
                case 2:
                    switch (nappi)
                    {
                        case 1:
                            Vakiot.painallukset++;
                            nappi = 4;
                            nappiLista.Remove(vihreaNappi);
                            NappiSijainti(vihreaNappi, nappiLista);
                            nappiLista.Add(vihreaNappi);
                            Vakiot.alkaa = DateTime.Now.TimeOfDay.TotalMilliseconds;
                            Vakiot.tikit = 0;
                            break;
                        case 2:
                            Controls.Remove(keltainenNappi);
                            Vakiot.painallukset++;
                            Vakiot.keltainenNappulaSisa = 10;
                            Vakiot.keltainenNappula = 0;
                            nappiLista.Remove(keltainenNappi);
                            break;
                        case 3:
                            Controls.Remove(punainenNappi);
                            Vakiot.painallukset++;
                            Vakiot.punainenNappulaSisa = 10;
                            Vakiot.punainenNappula = 0;
                            nappiLista.Remove(punainenNappi);
                            break;
                    }
                    int x = Convert.ToInt16(pisteBox.Text);
                    pisteBox.Text = Convert.ToString(x - Vakiot.piste * nappi);
                    LoppuLoota();
                    break;
                case 3:
                    break;
            }
        }

        private void Ajastin1_Tick(object sender, EventArgs e)
        {
            aikaBox.Text = Convert.ToString(Vakiot.Aika());
            osumaBox.Text = Convert.ToString(Vakiot.Tarkkuus()) + " %";

            if (Vakiot.tikit >= 20)
            {
                AikaTikki(2, 1);
            }
            else
            {
                Vakiot.tikit++;
            }

            LoppuLoota();
            Vakiot.keltainenNappula += random.Next(0, 5);
            Vakiot.punainenNappula += random.Next(1, 3);

            if (Vakiot.keltainenNappula >= 100 && Vakiot.keltainenNappulaSisa == 10)
            {
                AikaTikki(1, 2);
            }
            if (Vakiot.punainenNappula >= 100 && Vakiot.punainenNappulaSisa == 10)
            {
                AikaTikki(1, 3);
            }
            if (Vakiot.keltainenNappulaSisa < 10)
            {
                Vakiot.keltainenNappulaSisa--;
                if (Vakiot.keltainenNappulaSisa <= 0)
                {
                    AikaTikki(2, 2);
                }
            }
            if (Vakiot.punainenNappulaSisa < 10)
            {
                Vakiot.punainenNappulaSisa--;
                if (Vakiot.punainenNappulaSisa <= 0)
                {
                    AikaTikki(2, 3);
                }
            }

            if (random.Next(1, 100) == 1 && Vakiot.pinkkiNukkuu)
            {
                Vakiot.pinkkiNukkuu = false;
                NappiSijainti(pinkkiNappi, nappiLista);
                nappiLista.Add(pinkkiNappi);
                ajastin2.Start();
            }
        }

        private void Aloitus_Tick(object sender, EventArgs e)
        {
            Vakiot.aloitusTikit++;
            switch (Vakiot.aloitusTikit)
            {
                case 1:
                    ajastinBox.Text = "2";
                    break;
                case 2:
                    ajastinBox.Text = "1";
                    break;
                case 3:
                    laskenta.Stop();
                    this.Controls.Remove(ajastinBox);
                    Nollaus();
                    break;
            }
        }

        private void Ajastin2_Tick(object sender, EventArgs e)
        {
            Vakiot.painallukset++;
            Lopetus(5);
        }

        private void NappiSijainti(Button nappi, List<Button> lista)
        {
            bool leikkaa = true;
            if (lista.Count > 0)
            {
                while (leikkaa)
                {
                    
                    int nappi_x_low = random.Next(Vakiot.minimi, Vakiot.maximi * Vakiot.kerroin) - (nappi.Width / 2);
                    int nappi_y_low = random.Next(Vakiot.minimi * Vakiot.kerroin, Vakiot.maximi) - (nappi.Height / 2);
                    int nappi_x_high = nappi_x_low + nappi.Width + (nappi.Width / 2);
                    int nappi_y_high = nappi_y_low + nappi.Height + (nappi.Height / 2);

                    bool tarkistus = true;

                    foreach (Button b in lista)
                    {
                        int b_x_low = b.Location.X - (b.Width / 2);
                        int b_y_low = b.Location.Y - (b.Height / 2);
                        int b_x_high = b_x_low + b.Width + (b.Width / 2);
                        int b_y_high = b_y_low + b.Height + (b.Height / 2);

                        if (b.Width >= nappi.Width)
                        {
                            if (((((nappi_x_low >= b_x_low) & (nappi_x_low <= b_x_high)) & ((nappi_y_low >= b_y_low) & (nappi_y_low <= b_y_high))) | (((nappi_x_high >= b_x_low) & (nappi_x_high <= b_x_high)) & ((nappi_y_high >= b_y_low) & (nappi_y_high <= b_y_high)))))
                            {
                                tarkistus = false;
                            }
                        }
                        else
                        {
                            if (((((b_x_low >= nappi_x_low) & (b_x_low <= nappi_x_high)) & ((b_y_low >= nappi_y_low) & (b_y_low <= nappi_y_high))) | (((b_x_high >= nappi_x_low) & (b_x_high <= nappi_x_high)) & ((b_y_high >= nappi_y_low) & (b_y_high <= nappi_y_high)))))
                            {
                                tarkistus = false;
                            }
                        }
                        if ((b == lista.Last()) & tarkistus)
                        {
                            leikkaa = false;
                            nappi.Location = new Point(nappi_x_low + (nappi.Width / 2), nappi_y_low + (nappi.Width / 2));
                        }
                    }
                }
            }
            else
            {
                nappi.Location = new System.Drawing.Point(random.Next(Vakiot.minimi, Vakiot.maximi * Vakiot.kerroin), random.Next(Vakiot.minimi * Vakiot.kerroin, Vakiot.maximi));
            }
            Controls.Add(nappi);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Application.Exit();
        }

        /*public static PointF[] RandomMuoto(int pisteet, Rectangle rajat)
        {
            Random rand = new Random();

            // Pick random radii.
            double[] radii = new double[pisteet];
            const double min_radius = 0.5;
            const double max_radius = 1.0;
            for (int i = 0; i < pisteet; i++)
            {
                radii[i] = rand.NextDouble() * (max_radius - min_radius) + max_radius;
            }

            // Pick random angle weights.
            double[] angle_weights = new double[pisteet];
            const double min_weight = 1.0;
            const double max_weight = 10.0;
            double total_weight = 0;
            for (int i = 0; i < pisteet; i++)
            {
                angle_weights[i] = rand.NextDouble() * (max_weight -min_weight) + max_weight;
                total_weight += angle_weights[i];
            }

            // Convert the weights into fractions of 2 * Pi radians.
            double[] angles = new double[pisteet];
            double to_radians = 2 * Math.PI / total_weight;
            for (int i = 0; i < pisteet; i++)
            {
                angles[i] = angle_weights[i] * to_radians;
            }

            // Calculate the points' locations.
            PointF[] points = new PointF[pisteet];
            float rx = rajat.Width / 2f;
            float ry = rajat.Height / 2f;
            float cx = rajat.X;
            float cy = rajat.Y;
            double theta = 0;
            for (int i = 0; i < pisteet; i++)
            {
                points[i] = new PointF(
                    cx + (int)(rx * radii[i] * Math.Cos(theta)),
                    cy + (int)(ry * radii[i] * Math.Sin(theta)));
                theta += angles[i];
            }

            // Return the points.
            return points;
        }*/

        class AnimtedMsgBox : Form
        {
            //private const int CS_DROPSHADOW = 0x00020000;
            private static AnimtedMsgBox tulokset;
            private Panel pnPaa = new Panel();
            private Panel pnJalka = new Panel();
            private Panel pnIkoni = new Panel();
            private PictureBox kuvaLoota = new PictureBox();
            private FlowLayoutPanel flNappi = new FlowLayoutPanel();
            private Label lbOtsikko;
            private Label lbViesti;
            private List<Button> nappulaLista = new List<Button>();
            public static DialogResult nappulaTulos = new DialogResult();
            private static Point hiiraSijainti;

            [DllImport("user32.dll", CharSet = CharSet.Auto)]
            private static extern bool MessageBeep(uint type);

            private AnimtedMsgBox()
            {
                FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                BackColor = Color.FromArgb(150, 150, 150);
                StartPosition = FormStartPosition.CenterParent;
                Padding = new System.Windows.Forms.Padding(3);
                Width = 200;

                lbOtsikko = new Label();
                lbOtsikko.ForeColor = Color.Red;
                lbOtsikko.Font = new System.Drawing.Font("Segoe UI", 18);
                lbOtsikko.Dock = DockStyle.Top;
                lbOtsikko.Height = 50;

                lbViesti = new Label();
                lbViesti.ForeColor = Color.Black;
                lbViesti.Font = new System.Drawing.Font("Segoe UI", 10);
                lbViesti.Dock = DockStyle.Fill;

                flNappi.FlowDirection = FlowDirection.RightToLeft;
                flNappi.Dock = DockStyle.Fill;

                pnPaa.Dock = DockStyle.Fill;
                pnPaa.Padding = new Padding(20);
                pnPaa.Controls.Add(lbViesti);
                pnPaa.Controls.Add(lbOtsikko);

                pnJalka.Dock = DockStyle.Bottom;
                pnJalka.Padding = new Padding(20);
                pnJalka.BackColor = Color.FromArgb(37, 90, 38);
                pnJalka.Height = 100;
                pnJalka.Controls.Add(flNappi);

                kuvaLoota.Width = 32;
                kuvaLoota.Height = 16;
                kuvaLoota.Location = new Point(30, 50);

                pnIkoni.Dock = DockStyle.Right;
                pnIkoni.Padding = new Padding(20);
                pnIkoni.Width = 70;
                pnIkoni.Controls.Add(kuvaLoota);

                List<Control> controlCollection = new List<Control> {
                    this,
                    lbOtsikko,
                    lbViesti,
                    flNappi,
                    pnPaa,
                    pnJalka,
                    pnIkoni,
                    kuvaLoota
                };

                foreach (Control control in controlCollection)
                {
                    control.MouseDown += AnimtedMsgBox_MouseDown;
                    control.MouseMove += AnimtedMsgBox_MouseMove;
                }

                Controls.Add(pnPaa);
                Controls.Add(pnIkoni);
                Controls.Add(pnJalka);
            }

            public static DialogResult Show(string message, string title)
            {
                tulokset = new AnimtedMsgBox();
                tulokset.lbViesti.Text = message;
                tulokset.lbOtsikko.Text = title;
                tulokset.pnIkoni.Hide();

                tulokset.InitButtons();

                foreach (Button btn in tulokset.nappulaLista)
                {
                    btn.ForeColor = Color.FromArgb(170, 170, 170);
                    btn.Font = new System.Drawing.Font("Segoe UI", 12);
                    btn.Padding = new Padding(3);
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.Height = 45;
                    btn.Width = 100;
                    btn.FlatAppearance.BorderColor = Color.FromArgb(99, 0, 98);
                    //btn.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                    tulokset.flNappi.Controls.Add(btn);
                }

                tulokset.Size = AnimtedMsgBox.MessageSize(message);
                tulokset.ShowDialog();
                MessageBeep(0);
                return nappulaTulos;
            }

            private static void AnimtedMsgBox_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
            {
                if (e.Button == MouseButtons.Left)
                {
                    hiiraSijainti = new Point(e.X, e.Y);
                }
            }

            private static void AnimtedMsgBox_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
            {
                if (e.Button == MouseButtons.Left)
                {
                    tulokset.Left += e.X - hiiraSijainti.X;
                    tulokset.Top += e.Y - hiiraSijainti.Y;
                }
            }

            private static Size MessageSize(string message)
            {
                Graphics g = tulokset.CreateGraphics();
                int width = 400;
                int height = 300;

                SizeF size = g.MeasureString(message, new System.Drawing.Font("Segoe UI", 10));

                /*if (message.Length < 150)
                {
                    if ((int)size.Width > 350)
                    {
                        width = (int)size.Width;
                    }
                }
                else
                {
                    //string[] groups = (from Match m in Regex.Matches(message, ".{1,180}") select m.Value).ToArray();
                    //int lines = groups.Length;
                    width = 490;
                    height += (int)(size.Height);// * lines;
                }*/
                width = 490;
                height += (int)(size.Height);
                return new Size(width, height);
            }

            private void ButtonClick(object sender, EventArgs e)
            {
                Button btn = (Button)sender;

                switch (btn.Text)
                {
                    case "Kyllä":
                        nappulaTulos = DialogResult.Yes;
                        break;

                    case "Lopeta":
                        nappulaTulos = DialogResult.No;
                        break;
                    case "Päävalikko":
                        nappulaTulos = DialogResult.Abort;
                        break;
                }

                tulokset.Dispose();
            }

            private void InitButtons()
            {
                Button btnNo = new Button();
                btnNo.Text = "Lopeta";
                btnNo.Click += ButtonClick;
                
                Button btnYes = new Button();
                btnYes.Text = "Kyllä";
                btnYes.Click += ButtonClick;

                Button btnMenu = new Button();
                btnMenu.Text = "Päävalikko";
                btnMenu.Click += ButtonClick;

                nappulaLista.Add(btnYes);
                nappulaLista.Add(btnNo);
                nappulaLista.Add(btnMenu);
            }
        }
    }
}
