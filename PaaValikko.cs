using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class PaaValikko : Form
    {
        public PaaValikko()
        {
            InitializeComponent();
            String rivinVaihto = Environment.NewLine + Environment.NewLine;
            ohjeLoota.Text = $"{Lauseet.yleinenLause}{rivinVaihto}{Lauseet.vihreaLause}{rivinVaihto}{Lauseet.punainenLause}{rivinVaihto}{Lauseet.keltainenaLause}{rivinVaihto}{Lauseet.pinkkiLause}";
        }

        public static class Lauseet
        {
            public static string yleinenLause = "Paina nappeja sitä mukaan kun ne ilmestyvät ruudulle. Mitä nopeammin painat, sitä enemmän saat pisteitä. Menetät 25 pistettä joka kerta kun et osu nappulaan.";
            public static string vihreaLause = "Vihreä nappi antaa vähiten pisteitä ja vie eniten pisteitä, jos sitä ei paina.";
            public static string punainenLause = "Punainen nappi antaa eniten pisteitä ja siitä menettää vähiten, jos sitä ei paina.";
            public static string keltainenaLause = "Keltainen nappi on vihreän ja punaisen napin välimuoto";
            public static string pinkkiLause = "Pinkki nappi ei anna pisteitä ja lopettaa pelin, jos sitä ei paina.";
        }

        private void NappiSulku()
        {
            aikaNappi.Enabled = false;
            pisteNappi.Enabled = false;
            loputonNappi.Enabled = false;
            virheetonNappi.Enabled = false;
        }

        private void Klikkaus(object sender, EventArgs e)
        {
            NappiSulku();
            this.Hide();
            Button nappi = sender as Button;
            short nappiNumero = Convert.ToInt16(nappi.Name);
            Peli peli1 = new Peli(nappiNumero);
            peli1.Show();
        }

        private void Kuvaus(object sender, EventArgs e)
        {
            Button nappi = sender as Button;
            short nappiNumero = Convert.ToInt16(nappi.Name);
            switch (nappiNumero)
            {
                case 1:
                    kuvausLoota.Text = "60 sekunttia aikaa kerätä niin paljon pisteitä kuin pystyt.";
                    break;
                case 2:
                    kuvausLoota.Text = "Kerää 3000 pistettä niin nopeasti kuin voit.";
                    break;
                case 3:
                    kuvausLoota.Text = "Pelaa niin kauan kuin jaksat.";
                    break;
                case 4:
                    kuvausLoota.Text = "Pelaa niin kauan, kunnes painat ohi.";
                    break;
            }
        }

        private void KursorinLahto(object sender, EventArgs e)
        {
            kuvausLoota.Text = "";
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
