using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Models;

namespace SEPraktikum.Views.HauptmenuViewSub.BesucherViewSub.BesucherKinokartenOnlineReservierenViewSub
{
    public partial class Sitzplatzauswahl : Form, Interfaces.Observer
    {
        Show selectedShow;
        Ticket selectedTicket;
        DateTime birthDate;
        bool discount;

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
        }

        private void Sitzplatzauswahl_Load(object sender, EventArgs e)
        {
            CheckPermission();
        }

        private void checkBox_rentner_CheckedChanged(object sender, EventArgs e)
        {
            CheckDiscount();
        }

        private void checkBox_Student_CheckedChanged(object sender, EventArgs e)
        {
            CheckDiscount();
        }

        private void checkBox_Schueler_CheckedChanged(object sender, EventArgs e)
        {
            CheckDiscount();
        }

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

        private void dateTimePicker_birthDate_ValueChanged(object sender, EventArgs e)
        {
            birthDate = dateTimePicker_birthDate.Value;
            CheckPermission();
        }

        private void button_Zurueck_Click(object sender, EventArgs e)
        {
            selectedShow.RemoveObserver(this);
            this.Parent.Show();
            this.Close();
        }

        private void list_sitzplatz_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckPermission();
        }

        private void button_Weiter_Click(object sender, EventArgs e)
        {
            new ReservierungsUebersicht().ShowDialog(this);
            this.Hide();
        }

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

        public void UpdateObserver<T>(T subject) where T : Interfaces.Subject
        {
            this.list_sitzplatz.DataSource = selectedShow.GetAvailableTickets();
            this.list_sitzplatz.DisplayMember = "Seat";
            ((CurrencyManager)this.list_sitzplatz.BindingContext[this.list_sitzplatz.DataSource]).Refresh();

            CheckPermission();
        }
    }
}

struct Reservation
{

}

struct ErrorHelper
{
    public bool valid;
    public string errorMessage;
}