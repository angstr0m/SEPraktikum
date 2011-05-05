using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Models;

namespace SEPraktikum.Views.HauptmenuViewSub.BesucherViewSub
{
    public partial class ReservierungsUebersicht : Form
    {
        private Ticket selectedTicket;
        private int time;

        public ReservierungsUebersicht(Ticket selectedTicket)
        {
            InitializeComponent();
            this.selectedTicket = selectedTicket;
            time = 90;
            timer1.Interval = 1000; // 1 Sekunde
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Start();
        }

        void timer1_Tick(object sender, EventArgs e)
        {
            time -= 1;
            this.label_timeRemaining.Text = "Sie haben " + time + " Sekunden Zeit Ihre Angaben zu bestätigen.";
            if (time == 0)
            {
                timer1.Stop();
                selectedTicket.Show.ReturnTicket(selectedTicket);
                this.Close();
            }
        }

        private void ReservierungsUebersicht_Load(object sender, EventArgs e)
        {
            this.textBox_Uebersicht.Text = "Name des Films: " + selectedTicket.Show.Name + "\r\n" + "Sitzplatz: " + selectedTicket.Seat.ToString() + "\r\n" + "Startzeit: " + selectedTicket.Show.StartTime.ToString() + "\r\n" + "Preis: " + selectedTicket.Price;
        }

        private void button_Weiter_Click(object sender, EventArgs e)
        {
            
        }

        private void button_Zurueck_Click(object sender, EventArgs e)
        {
            selectedTicket.Show.ReturnTicket(selectedTicket);
            this.Close();
        }

        private void ReservierungsUebersicht_FormClosing(object sender, FormClosingEventArgs e)
        {
            selectedTicket.Show.ReturnTicket(selectedTicket);
        }
    }
}
