using System;
using System.Windows.Forms;
using SEPraktikum.Views.HauptmenuViewSub.Views.HauptmenuViewSub;

namespace SEPraktikum.Views.HauptmenuViewSub.Views
{
    public partial class SEPraktikum : Form
    {
        private AdministratorView adminView;
        private KundeView kundeView;
        private MitarbeiterView mitarbeiterView;

        public SEPraktikum()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SplashScreen splashScreen = new SplashScreen();

            splashScreen.ShowDialog(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (adminView == null)
            {
                adminView = new AdministratorView();
            }

            this.Hide();
            //adminView.Location = this.Location;
            adminView.ShowDialog(this);
        }

        private void button_Kunde_Click(object sender, EventArgs e)
        {
            if (kundeView == null)
            {
                kundeView = new KundeView();
            }

            kundeView.Show();
        }

        private void button_Mitarbeiter_Click(object sender, EventArgs e)
        {
            MitarbeiterView mitarbeiterView = new MitarbeiterView();

            mitarbeiterView.Show();
        }

        private void button_besucher_Click(object sender, EventArgs e)
        {
            BesucherView besucherView = new BesucherView();

            besucherView.Show();
        }
    }
}
