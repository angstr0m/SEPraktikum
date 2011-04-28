using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SEPraktikum.Views.HauptmenuViewSub.AdministratorViewSub;

namespace SEPraktikum.Views.HauptmenuViewSub
{
    public partial class AdministratorView : Form
    {
        private KinosaalAnlegenView kinosaalAnlegen;
        private KinosaalEditierenView kinosaalEditieren;
        private KinosaalLoeschen kinosaalLoeschen;

        public AdministratorView()
        {
            InitializeComponent();
        }

        private void AdministratorView_Load(object sender, EventArgs e)
        {

        }

        private void button_Zurueck_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Owner.Show();
        }

        private void button_kinosaalEditieren_Click(object sender, EventArgs e)
        {
            if (kinosaalEditieren == null)
            {
                kinosaalEditieren = new KinosaalEditierenView();
            }

            //this.Hide();
            //kinosaalEditieren.Show();
            kinosaalEditieren.ShowDialog(this);
        }

        private void button_kinosaalAnlegen_Click(object sender, EventArgs e)
        {
            if (kinosaalAnlegen == null)
            {
                kinosaalAnlegen = new KinosaalAnlegenView();
            }

            //this.Hide();
            //kinosaalEditieren.Show();
            kinosaalAnlegen.ShowDialog(this);
        }

        private void button_kinosaalLoeschen_Click(object sender, EventArgs e)
        {
            if (kinosaalLoeschen == null)
            {
                kinosaalLoeschen = new KinosaalLoeschen();
            }

            //this.Hide();
            //kinosaalEditieren.Show();
            kinosaalLoeschen.ShowDialog(this);
        }
    }
}
