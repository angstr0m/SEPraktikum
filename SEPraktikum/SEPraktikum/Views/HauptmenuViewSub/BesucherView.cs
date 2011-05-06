using System;
using System.Windows.Forms;
using TicketOperations.Views.Besucher;

namespace SEPraktikum.Views.HauptmenuViewSub.Views.HauptmenuViewSub
{
    public partial class BesucherView : Form
    {
        BesucherKinokartenOnlineReservieren kinokartenReservieren;

        public BesucherView()
        {
            InitializeComponent();
        }

        private void BesucherView_Load(object sender, EventArgs e)
        {

        }

        private void buttonKinokarteOnlineReservieren_Click(object sender, EventArgs e)
        {
            if (kinokartenReservieren == null)
            {
                kinokartenReservieren = new BesucherKinokartenOnlineReservieren();
            }

            //this.Hide();
            //kinosaalEditieren.Show();
            kinokartenReservieren.ShowDialog(this);
        }
    }
}
