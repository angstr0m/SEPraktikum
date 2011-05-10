using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Base.Interfaces;
using TicketOperations.Models;

namespace TicketOperations.Views.Besucher.BesucherKinokartenOnlineReservierenViewSub
{
    /// <summary>
    /// Provides a interface for the user to select a ticket for a specific seat from a specific show.
    /// </summary>
    /// <remarks></remarks>
    public partial class Sitzplatzauswahl : Form, Observer
    {
        /// <summary>
        /// The show that was selected in a previous form.
        /// </summary>
        Show selectedShow;
        /// <summary>
        /// The ticket the user has currently selected.
        /// </summary>
        Ticket selectedTicket;
        /// <summary>
        /// The birthdate of the customer.
        /// </summary>
        DateTime birthDate;
        /// <summary>
        /// True if the user should get a 10% discount on the ticket price.
        /// </summary>
        bool discount;

        /// <summary>
        /// Initializes a new instance of the <see cref="Sitzplatzauswahl"/> class.
        /// </summary>
        /// <param name="selectedShow">The selected show.</param>
        /// <remarks></remarks>
        public Sitzplatzauswahl(Show selectedShow)
        {
            InitializeComponent();
            this.selectedShow = selectedShow;
            selectedShow.AddObserver(this);
            this.discount = false;

            this.list_sitzplatz.DataSource = selectedShow.GetAvailableTickets();
            this.list_sitzplatz.DisplayMember = "Seat";

            this.dateTimePicker_birthDate.MaxDate = DateTime.Today;

            errorProvider.BlinkRate = 0;

            CheckPermission();
        }

        /// <summary>
        /// Handles the Load event of the Sitzplatzauswahl control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        /// <remarks></remarks>
        private void Sitzplatzauswahl_Load(object sender, EventArgs e)
        {
            CheckPermission();
        }

        /// <summary>
        /// If the user checks/unchecks this checkbox, his discount will be updated to reflect this change.
        /// The user will activate this checkbox if he is a pensioneer.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        /// <remarks></remarks>
        private void checkBox_rentner_CheckedChanged(object sender, EventArgs e)
        {
            CheckDiscount();
        }

        /// <summary>
        /// If the user checks/unchecks this checkbox, his discount will be updated to reflect this change.
        /// The user will activate this checkbox if he is a student.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        /// <remarks></remarks>
        private void checkBox_Student_CheckedChanged(object sender, EventArgs e)
        {
            CheckDiscount();
        }

        /// <summary>
        /// If the user checks/unchecks this checkbox, his discount will be updated to reflect this change.
        /// The user will activate this checkbox if he is a pupil.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        /// <remarks></remarks>
        private void checkBox_Schueler_CheckedChanged(object sender, EventArgs e)
        {
            CheckDiscount();
        }

        /// <summary>
        /// Analyzes if the current user is viable for a discount.
        /// If he is a pupil, student and/or pensioneer he is viable.
        /// </summary>
        /// <remarks></remarks>
        void CheckDiscount()
        {
            if (this.checkBox_rentner.Checked || this.checkBox_Schueler.Checked || this.checkBox_Student.Checked)
            {
                discount = true;
            }
            else
            {
                discount = false;
            }
        }

        /// <summary>
        /// This method is called, when the user changes his birthdate. It is then checked if the user is actually old enough to see this movie.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        /// <remarks></remarks>
        private void dateTimePicker_birthDate_ValueChanged(object sender, EventArgs e)
        {
            birthDate = dateTimePicker_birthDate.Value;
            CheckPermission();
        }

        /// <summary>
        /// Closes the form and shows the form from which this form was created.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        /// <remarks></remarks>
        private void button_Zurueck_Click(object sender, EventArgs e)
        {
            selectedShow.RemoveObserver(this);
            this.Parent.Show();
            this.Close();
        }

        /// <summary>
        /// This method is called, when the user changes his wanted ticket.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        /// <remarks></remarks>
        private void list_sitzplatz_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedTicket = selectedShow.GetTicket(this.list_sitzplatz.SelectedIndex);
            CheckPermission();
        }

        /// <summary>
        /// The selected ticket is reserved.
        /// This option is only available if the user is old enough to actually watch the movie.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        /// <remarks></remarks>
        private void button_Weiter_Click(object sender, EventArgs e)
        {
            // Only to be sure nobody sold or reserved the ticket.
            if (selectedTicket.Reserved || selectedTicket.Sold)
            {
                return;
            }
            selectedTicket.Discount = discount;
            selectedTicket.Reserved = true;
            this.Hide();
            new ReservierungsUebersicht(selectedTicket).ShowDialog(this);
        }

        /// <summary>
        /// Checks the input of the user.
        /// Checks if the user is actually old enough to watch the the selected movie, based on his birthdate.
        /// If the user isn't old enough to watch the selected movie, or he has made a non valid input, a error message is shown using the error provider from this form.
        /// </summary>
        /// <remarks></remarks>
        private void CheckPermission()
        {
            ErrorHelper helper = ValidateInput();

            if (helper.valid)
            {
                this.button_Weiter.Enabled = true;
                errorProvider.SetError(this.button_Weiter, "");
            }
            else
            {
                this.button_Weiter.Enabled = false;
                errorProvider.SetError(this.button_Weiter, helper.errorMessage);
            }
        }

        /// <summary>
        /// Validates the input the user made, and checks if the user is actually old enough to watch the movie.
        /// </summary>
        /// <returns>ErrorHelper - Struct that contains information about the error that occured.</returns>
        /// <remarks></remarks>
        private ErrorHelper ValidateInput()
        {
            ErrorHelper helper = new ErrorHelper();
            helper.valid = false;

            if (this.list_sitzplatz.SelectedIndex == -1)
            {
                helper.errorMessage = "Bitte wählen Sie einen Sitzplatz aus.";
                return helper;
            }

            if ((DateTime.Now.Subtract(birthDate).Days / 356) < selectedShow.MovieRating)
            {
                helper.errorMessage = "Sie sind zu jung um diesen Film zu sehen.";
                return helper;
            }

            helper.valid = true;
            return helper;
        }

        /// <summary>
        /// Updates the observer, when the tickets of the currently selected show change.
        /// This happens, for example, when another user buys or reservs a ticket contained in the currently selected show.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="subject">The subject.</param>
        /// <remarks></remarks>
        public void UpdateObserver<T>(T subject) where T : Base.AbstractClasses.Subject
        {
            this.list_sitzplatz.DataSource = selectedShow.GetAvailableTickets();
            this.list_sitzplatz.DisplayMember = "Seat";
            ((CurrencyManager)this.list_sitzplatz.BindingContext[this.list_sitzplatz.DataSource]).Refresh();

            CheckPermission();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <remarks></remarks>
    struct Reservation
    {

    }

    /// <summary>
    /// Struct for providing information about an error.
    /// Meant for internal use only.
    /// </summary>
    /// <remarks></remarks>
    struct ErrorHelper
    {
        /// <summary>
        /// 
        /// </summary>
        public bool valid;
        /// <summary>
        /// 
        /// </summary>
        public string errorMessage;
    }
}