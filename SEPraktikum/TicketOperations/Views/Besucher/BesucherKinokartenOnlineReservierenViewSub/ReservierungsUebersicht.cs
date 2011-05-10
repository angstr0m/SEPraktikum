using System;
using System.Windows.Forms;
using TicketOperations.Models;

namespace TicketOperations.Views.Besucher.BesucherKinokartenOnlineReservierenViewSub
{
    /// <summary>
    /// This form provides a overview of the reservation for the user.
    /// The user can then confirm or decline the reservation. However he has only 90 seconds to do so.
    /// In these 90 seconds the ticket will be reserved for the user.
    /// If he doesn't make a choice within these 90 seconds the form will close and the selected ticket will become unreserved again.
    /// </summary>
    /// <remarks></remarks>
    public partial class ReservierungsUebersicht : Form
    {
        /// <summary>
        /// The ticket the user has selected.
        /// </summary>
        private Ticket selectedTicket;
        /// <summary>
        /// Passed time counter used internally.
        /// </summary>
        private int time;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReservierungsUebersicht"/> class.
        /// </summary>
        /// <param name="selectedTicket">The selected ticket.</param>
        /// <remarks></remarks>
        public ReservierungsUebersicht(Ticket selectedTicket)
        {
            InitializeComponent();
            this.selectedTicket = selectedTicket;
            time = 90;
            timer1.Interval = 1000; // 1 Sekunde
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Start();
        }

        /// <summary>
        /// Counts down from 90 seconds to zero. In this time the user has time to reserve the ticket.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        /// <remarks></remarks>
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

        /// <summary>
        /// Handles the Load event of the ReservierungsUebersicht control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        /// <remarks></remarks>
        private void ReservierungsUebersicht_Load(object sender, EventArgs e)
        {
            this.textBox_Uebersicht.Text = "Name des Films: " + selectedTicket.Show.Name + "\r\n" + "Sitzplatz: " + selectedTicket.Seat.ToString() + "\r\n" + "Startzeit: " + selectedTicket.Show.StartTime.ToString() + "\r\n" + "Preis: " + selectedTicket.Price;
        }

        /// <summary>
        /// The user confirms his reservation.
        /// The ticket is reserved.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        /// <remarks></remarks>
        private void button_Weiter_Click(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// The user discards his reservation.
        /// The ticket is unlocked.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        /// <remarks></remarks>
        private void button_Zurueck_Click(object sender, EventArgs e)
        {
            selectedTicket.Show.ReturnTicket(selectedTicket);
            this.Close();
        }

        /// <summary>
        /// Makes sure the ticket is unblocked when the form closes.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.FormClosingEventArgs"/> instance containing the event data.</param>
        /// <remarks></remarks>
        private void ReservierungsUebersicht_FormClosing(object sender, FormClosingEventArgs e)
        {
            selectedTicket.Show.ReturnTicket(selectedTicket);
        }
    }
}
