using System;
using System.Windows.Forms;
using Database.Models;
using TicketOperations.Models;
using TicketOperations.Views.Besucher.BesucherKinokartenOnlineReservierenViewSub;

namespace TicketOperations.Views.Besucher
{
    /// <summary>
    /// Provides an interface for a customer to select a show out of the current movie program, that he wishes to reserve tickets for.
    /// </summary>
    /// <remarks></remarks>
    public partial class BesucherKinokartenOnlineReservieren : Form, Base.Interfaces.Observer
    {
        /// <summary>
        /// The show the user has selected out of the list of available shows.
        /// </summary>
        Show selectedShow;
        /// <summary>
        /// A link to the database which provides access to all MoviePrograms.
        /// </summary>
        private EntityManager<MovieProgram> database;

        /// <summary>
        /// Instance of a dialog which allows to choose a specific ticket to reserve for the selected show.
        /// </summary>
        Sitzplatzauswahl sitzplatzAuswahl;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Windows.Forms.Form"/> class.
        /// </summary>
        /// <remarks></remarks>
        public BesucherKinokartenOnlineReservieren()
        {
            InitializeComponent();
            database = new EntityManager<MovieProgram>();
            
            this.listBox_Shows.DataSource = database.GetElements()[0].Shows;
            this.listBox_Shows.DisplayMember = "Name";

            ValidateInput();
        }

        /// <summary>
        /// Validates the user input.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        private bool ValidateInput()
        {
            bool valid = false;

            if (listBox_Shows.SelectedIndex != -1)
            {
                valid = true;
            }

            this.button_chooseSelectedShow.Enabled = valid;

            return valid;
        }

        /// <summary>
        /// Handles the Load event of the BesucherKinokartenOnlineReservieren control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        /// <remarks></remarks>
        private void BesucherKinokartenOnlineReservieren_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// When the user changes his selection in the listbox field containing the shows:
        /// - the informations about the current show are updated in this form.
        /// - the input of the user is validated.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        /// <remarks></remarks>
        private void listBox_Shows_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateShowInformations();
            ValidateInput();
        }

        /// <summary>
        /// Updates the form with the informations about the currently selected show.
        /// </summary>
        /// <remarks></remarks>
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

            selectedShow = database.GetElements()[0].Shows[listBox_Shows.SelectedIndex];
            selectedShow.AddObserver(this);

            this.textBox_numberOfAvalableTickets.Text = selectedShow.GetNumberOfFreeSeats() + "";
            this.textBox_ShowDuration.Text = selectedShow.Duration + "";
            this.textBox_ShowStart.Text = selectedShow.StartTime.ToString();
        }

        /// <summary>
        /// Updates this view, when the selected show changes. For example, when another customer reserves or buys a ticket.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="subject">The subject.</param>
        /// <remarks></remarks>
        public void UpdateObserver<T>(T subject) where T : Base.AbstractClasses.Subject
        {
            this.textBox_numberOfAvalableTickets.Text = selectedShow.GetNumberOfFreeSeats() + "";
            this.textBox_ShowDuration.Text = selectedShow.Duration + "";
            this.textBox_ShowStart.Text = selectedShow.StartTime.ToString();
        }

        /// <summary>
        /// Closes this dialog.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        /// <remarks></remarks>
        private void button_back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Shows the dialog for choosing a specific ticket for the selected show.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        /// <remarks></remarks>
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
