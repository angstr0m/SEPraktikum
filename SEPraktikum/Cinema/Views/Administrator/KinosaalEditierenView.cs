using System;
using System.Windows.Forms;
using Base.AbstractClasses;
using Base.Interfaces;
using Cinema.Models;
using Database.Models;

namespace Cinema.Views.Administrator
{
    public partial class KinosaalEditierenView : Form, Observer, Base.Interfaces.View
    {
        private EntityManager<MovieTheatre> database;
        private Base.Interfaces.View view;
        private bool initialized = false;
        private MovieTheatre selectedTheatre;

        public MovieTheatre SelectedTheatre
        {
            get { return selectedTheatre; }
        }

        public KinosaalEditierenView()
        {
            InitializeComponent();
            Initialize();
        }

        public void Initialize()
        {
            if (!initialized)
            {
                initialized = true;
                database = new EntityManager<MovieTheatre>();
                database.AddObserver(this);
                this.list_kinosaal.DataSource = database.GetElements();
                this.list_kinosaal.DisplayMember = "Name";
                System.Console.WriteLine(list_seats.SelectedIndex);
                if (list_seats.SelectedIndex >= 0 && list_seats.SelectedIndex < database.GetElements().Count)
                {
                    selectedTheatre = database.GetElements()[list_seats.SelectedIndex];
                    UpdateSeatsList();
                }
            }
        }

        private void KinosaalverwaltungView_Load(object sender, EventArgs e)
        {
            Initialize();
            UpdateSelectedTheatre();
            UpdateSeatsList();

            if (list_kinosaal.SelectedIndex == -1)
            {
                button_addSeat.Enabled = false;
                button_removeSeat.Enabled = false;
            }
            else
            {
                button_addSeat.Enabled = true;
                button_removeSeat.Enabled = true;
            }
        }

        private void button_zurueck_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Owner.Show();
        }

        public void UpdateObserver<T>(T subject) where T : Subject
        {
            this.list_kinosaal.DataSource = database.GetElements();
            this.list_kinosaal.DisplayMember = "Name";
            ((CurrencyManager)this.list_kinosaal.BindingContext[this.list_kinosaal.DataSource]).Refresh();

            UpdateSelectedTheatre();
            UpdateSeatsList();
        }

        private void list_kinosaal_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            UpdateSelectedTheatre();
            UpdateSeatsList();    
        }

        private void UpdateSelectedTheatre()
        {
            if (list_kinosaal.SelectedIndex == -1)
            {
                if (selectedTheatre != null)
                {
                    selectedTheatre.RemoveObserver(this);
                }
                this.textBox_name.Text = "";
                this.textBox_seatsNumber.Text = "";
                return;
            }

            if (selectedTheatre != null)
            {
                selectedTheatre.RemoveObserver(this);
            }

            selectedTheatre = database.GetElements()[list_kinosaal.SelectedIndex];
            selectedTheatre.AddObserver(this);

            this.textBox_name.Text = selectedTheatre.Name;
            this.textBox_seatsNumber.Text = "" + selectedTheatre.SeatCount;
            
        }

        private void UpdateSeatsList()
        {
            if (selectedTheatre == null || list_kinosaal.SelectedIndex == -1)
            {
                this.list_seats.DataSource = null;
                this.list_seats.Items.Clear();
                return;
            }
            this.list_seats.DataSource = selectedTheatre.GetSeats();
            this.list_seats.DisplayMember = "Identifier";
            ((CurrencyManager)this.list_seats.BindingContext[this.list_seats.DataSource]).Refresh();
        }

        private void list_seats_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button_addSeat_Click(object sender, EventArgs e)
        {
            KinositzAnlegenView kinositzAnlegenView = new KinositzAnlegenView();

            kinositzAnlegenView.ShowDialog(this);
        }

        private void button_removeSeat_Click(object sender, EventArgs e)
        {
            if (list_seats.SelectedIndex != -1)
            {
                if (MessageBox.Show("Sitz wirklich löschen?", "Löschen Bestätigen", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    selectedTheatre.RemoveSeat(selectedTheatre.GetSeats()[list_seats.SelectedIndex]);
                }
            }
        }
    }
}
