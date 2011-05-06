using System;
using System.Windows.Forms;
using Database.Models;
using TicketOperations.Models;
using TicketOperations.Views.Besucher.BesucherKinokartenOnlineReservierenViewSub;

namespace TicketOperations.Views.Besucher
{
    public partial class BesucherKinokartenOnlineReservieren : Form, Base.Interfaces.Observer
    {
        Show selectedShow;
        private EntityManager<MovieProgram> database;

        Sitzplatzauswahl sitzplatzAuswahl;

        public BesucherKinokartenOnlineReservieren()
        {
            InitializeComponent();
            database = new EntityManager<MovieProgram>();
            
            this.listBox_Shows.DataSource = database.GetElements()[0].Shows;
            this.listBox_Shows.DisplayMember = "Name";

            ValidateInput();
        }

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

        private void BesucherKinokartenOnlineReservieren_Load(object sender, EventArgs e)
        {

        }

        private void listBox_Shows_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateShowInformations();
            ValidateInput();
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

            selectedShow = database.GetElements()[0].Shows[listBox_Shows.SelectedIndex];
            selectedShow.AddObserver(this);

            this.textBox_numberOfAvalableTickets.Text = selectedShow.GetNumberOfFreeSeats() + "";
            this.textBox_ShowDuration.Text = selectedShow.Duration + "";
            this.textBox_ShowStart.Text = selectedShow.StartTime.ToString();
        }

        public void UpdateObserver<T>(T subject) where T : Base.AbstractClasses.Subject
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
