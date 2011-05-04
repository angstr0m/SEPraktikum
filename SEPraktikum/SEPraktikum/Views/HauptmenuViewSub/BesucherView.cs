using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SEPraktikum.Views.HauptmenuViewSub.BesucherViewSub;

namespace SEPraktikum.Views.HauptmenuViewSub
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
