using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Models;
using SEPraktikum.Views.HauptmenuViewSub.BesucherViewSub;

namespace SEPraktikum.Views.HauptmenuViewSub.BesucherViewSub
{
    public partial class BesucherKinokartenOnlineReservieren : Form, Interfaces.Observer
    {
        Show selectedShow;
        Sitzplatzauswahl sitzplatzAuswahl;

        public BesucherKinokartenOnlineReservieren()
        {
            InitializeComponent();
            this.listBox_Shows.DataSource = Database.Instance.getMovieProgramForThisWeek().Shows;
            this.listBox_Shows.DisplayMember = "Name";
        }

        private void BesucherKinokartenOnlineReservieren_Load(object sender, EventArgs e)
        {

        }

        private void listBox_Shows_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateShowInformations();
        }

        void UpdateShowInformations()
        {
            if (listBox_Shows.SelectedIndex == -1)
            {
                if (selectedShow != null)
                {
                    selectedShow.RemoveObserver(this);
                }
                this.textBox_numberOfAvalableTickets.Text = "";
                this.textBox_ShowDuration.Text = "";
                this.textBox_ShowStart.Text = "";
                return;
            }

            if (selectedShow != null)
            {
                selectedShow.RemoveObserver(this);
            }

            selectedShow = Database.Instance.getMovieProgramForThisWeek().Shows[listBox_Shows.SelectedIndex];
            selectedShow.AddObserver(this);

            this.textBox_numberOfAvalableTickets.Text = selectedShow.GetNumberOfFreeSeats() + "";
            this.textBox_ShowDuration.Text = selectedShow.Duration + "";
            this.textBox_ShowStart.Text = selectedShow.StartTime.ToString();
        }

        public void UpdateObserver<T>(T subject) where T : Interfaces.Subject
        {
            this.textBox_numberOfAvalableTickets.Text = selectedShow.GetNumberOfFreeSeats() + "";
            this.textBox_ShowDuration.Text = selectedShow.Duration + "";
            this.textBox_ShowStart.Text = selectedShow.StartTime.ToString();
        }

        private void button_back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_chooseSelectedShow_Click(object sender, EventArgs e)
        {
            if (sitzplatzAuswahl == null)
            {
                sitzplatzAuswahl = new Sitzplatzauswahl(selectedShow);
            }

            this.Hide();
            sitzplatzAuswahl.ShowDialog(this);
        }
    }
}
