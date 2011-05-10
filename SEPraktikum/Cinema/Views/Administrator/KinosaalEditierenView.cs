using System;
using System.Windows.Forms;
using Base.AbstractClasses;
using Base.Interfaces;
using Cinema.Models;
using Database.Models;

namespace Cinema.Views.Administrator
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks></remarks>
    public partial class KinosaalEditierenView : Form, Observer, Base.Interfaces.View
    {
        /// <summary>
        /// 
        /// </summary>
        private EntityManager<MovieTheatre> database;
        /// <summary>
        /// 
        /// </summary>
        private Base.Interfaces.View view;
        /// <summary>
        /// 
        /// </summary>
        private bool initialized = false;
        /// <summary>
        /// 
        /// </summary>
        private MovieTheatre selectedTheatre;

        /// <summary>
        /// Gets the selected theatre.
        /// </summary>
        /// <remarks></remarks>
        public MovieTheatre SelectedTheatre
        {
            get { return selectedTheatre; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Windows.Forms.Form"/> class.
        /// </summary>
        /// <remarks></remarks>
        public KinosaalEditierenView()
        {
            InitializeComponent();
            Initialize();
        }

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        /// <remarks></remarks>
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

        /// <summary>
        /// Handles the Load event of the KinosaalverwaltungView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        /// <remarks></remarks>
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

        /// <summary>
        /// Handles the Click event of the button_zurueck control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        /// <remarks></remarks>
        private void button_zurueck_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Owner.Show();
        }

        /// <summary>
        /// Updates the observer.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="subject">The subject.</param>
        /// <remarks></remarks>
        public void UpdateObserver<T>(T subject) where T : Subject
        {
            this.list_kinosaal.DataSource = database.GetElements();
            this.list_kinosaal.DisplayMember = "Name";
            ((CurrencyManager)this.list_kinosaal.BindingContext[this.list_kinosaal.DataSource]).Refresh();

            UpdateSelectedTheatre();
            UpdateSeatsList();
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the list_kinosaal control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        /// <remarks></remarks>
        private void list_kinosaal_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            UpdateSelectedTheatre();
            UpdateSeatsList();    
        }

        /// <summary>
        /// Updates the selected theatre.
        /// </summary>
        /// <remarks></remarks>
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

        /// <summary>
        /// Updates the seats list.
        /// </summary>
        /// <remarks></remarks>
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

        /// <summary>
        /// Handles the SelectedIndexChanged event of the list_seats control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        /// <remarks></remarks>
        private void list_seats_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// Handles the Click event of the button_addSeat control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        /// <remarks></remarks>
        private void button_addSeat_Click(object sender, EventArgs e)
        {
            KinositzAnlegenView kinositzAnlegenView = new KinositzAnlegenView();

            kinositzAnlegenView.ShowDialog(this);
        }

        /// <summary>
        /// Handles the Click event of the button_removeSeat control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        /// <remarks></remarks>
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
