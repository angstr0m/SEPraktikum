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
    public partial class KinosaalLoeschen : Form, Observer
    {
        /// <summary>
        /// 
        /// </summary>
        private EntityManager<Kinosaal> database;
        /// <summary>
        /// 
        /// </summary>
        private bool initialized = false;
        /// <summary>
        /// 
        /// </summary>
        private Kinosaal selectedTheatre;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Windows.Forms.Form"/> class.
        /// </summary>
        /// <remarks></remarks>
        public KinosaalLoeschen()
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
                database = new EntityManager<Kinosaal>();
                database.AddObserver(this);
                this.list_kinosaal.DataSource = database.GetElements();
                this.list_kinosaal.DisplayMember = "Name";
                System.Console.WriteLine(list_kinosaal.SelectedIndex);
                if (list_kinosaal.SelectedIndex >= 0 && list_kinosaal.SelectedIndex < database.GetElements().Count)
                {
                    selectedTheatre = database.GetElements()[list_kinosaal.SelectedIndex];
                    
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
        }

        /// <summary>
        /// Updates the selected theatre.
        /// </summary>
        /// <remarks></remarks>
        private void UpdateSelectedTheatre()
        {
            System.Console.WriteLine("Selected Index: " + list_kinosaal.SelectedIndex);
            if (list_kinosaal.SelectedIndex >= 0 && list_kinosaal.SelectedIndex < database.GetElements().Count)
            {
                selectedTheatre = database.GetElements()[list_kinosaal.SelectedIndex];
            }
        }

        /// <summary>
        /// Handles the Click event of the button_kinosaalLoeschen control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        /// <remarks></remarks>
        private void button_kinosaalLoeschen_Click(object sender, EventArgs e)
        {
            if (list_kinosaal.SelectedIndex == -1)
            {
                return;
            }

            if (MessageBox.Show("Kinosaal wirklich löschen?", "Löschen Bestätigen", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                database.RemoveElement(database.GetElements()[list_kinosaal.SelectedIndex]);
            }
        }
    }
}
