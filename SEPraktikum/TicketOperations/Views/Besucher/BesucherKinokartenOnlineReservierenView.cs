using System;
using System.Windows.Forms;
using Database.Models;
using TicketOperations.Models;
using TicketOperations.Views.Besucher.BesucherKinokartenOnlineReservierenViewSub;

namespace TicketOperations.Views.Besucher
{
    /// <summary>
    /// Provides an interface for a customer to select a vorstellung out of the current movie program, that he wishes to reserve tickets for.
    /// </summary>
    /// <remarks></remarks>
    public partial class BesucherKinokartenOnlineReservieren : Form, Base.Interfaces.Observer
    {
        /// <summary>
        /// The vorstellung the user has selected out of the list of available shows.
        /// </summary>
        Vorstellung _selectedVorstellung;
        /// <summary>
        /// A link to the database which provides access to all MoviePrograms.
        /// </summary>
        private EntityManager<Filmprogramm> database;

        /// <summary>
        /// Instance of a dialog which allows to choose a specific ticket to reserve for the selected vorstellung.
        /// </summary>
        Sitzplatzauswahl sitzplatzAuswahl;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Windows.Forms.Form"/> class.
        /// </summary>
        /// <remarks></remarks>
        public BesucherKinokartenOnlineReservieren()
        {
            InitializeComponent();
            database = new EntityManager<Filmprogramm>();
            
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
        /// - the informations about the current vorstellung are updated in this form.
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
        /// Updates the form with the informations about the currently selected vorstellung.
        /// </summary>
        /// <remarks></remarks>
        void UpdateShowInformations()
        {
            if (listBox_Shows.SelectedIndex == -1)
            {
                if (_selectedVorstellung != null)
                {
                    _selectedVorstellung.RemoveObserver(this);
                }
                this.textBox_numberOfAvalableTickets.Text = "";
                this.textBox_ShowDuration.Text = "";
                this.textBox_ShowStart.Text = "";
                return;
            }

            if (_selectedVorstellung != null)
            {
                _selectedVorstellung.RemoveObserver(this);
            }

            _selectedVorstellung = database.GetElements()[0].Shows[listBox_Shows.SelectedIndex];
            _selectedVorstellung.AddObserver(this);

            this.textBox_numberOfAvalableTickets.Text = _selectedVorstellung.GetNumberOfFreeSeats() + "";
            this.textBox_ShowDuration.Text = _selectedVorstellung.Duration + "";
            this.textBox_ShowStart.Text = _selectedVorstellung.StartTime.ToString();
        }

        /// <summary>
        /// Updates this view, when the selected vorstellung changes. For example, when another customer reserves or buys a ticket.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="subject">The subject.</param>
        /// <remarks></remarks>
        public void UpdateObserver<T>(T subject) where T : Base.AbstractClasses.Subject
        {
            this.textBox_numberOfAvalableTickets.Text = _selectedVorstellung.GetNumberOfFreeSeats() + "";
            this.textBox_ShowDuration.Text = _selectedVorstellung.Duration + "";
            this.textBox_ShowStart.Text = _selectedVorstellung.StartTime.ToString();
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
        /// Shows the dialog for choosing a specific ticket for the selected vorstellung.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        /// <remarks></remarks>
        private void button_chooseSelectedShow_Click(object sender, EventArgs e)
        {
            if (sitzplatzAuswahl == null)
            {
                sitzplatzAuswahl = new Sitzplatzauswahl(_selectedVorstellung);
            }

            this.Hide();
            sitzplatzAuswahl.ShowDialog(this);
        }
    }
}
