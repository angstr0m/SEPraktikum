using System;
using System.Windows.Forms;
using Base.AbstractClasses;
using Base.Interfaces;
using Cinema.Models;
using Database.Models;

namespace Cinema.Views.Administrator
{
    public partial class KinosaalLoeschen : Form, Observer
    {
        private EntityManager<MovieTheatre> database;
        private bool initialized = false;
        private MovieTheatre selectedTheatre;

        public KinosaalLoeschen()
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
                System.Console.WriteLine(list_kinosaal.SelectedIndex);
                if (list_kinosaal.SelectedIndex >= 0 && list_kinosaal.SelectedIndex < database.GetElements().Count)
                {
                    selectedTheatre = database.GetElements()[list_kinosaal.SelectedIndex];
                    
                }
            }
        }

        private void KinosaalverwaltungView_Load(object sender, EventArgs e)
        {
            Initialize();
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
        }

        private void list_kinosaal_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateSelectedTheatre(); 
        }

        private void UpdateSelectedTheatre()
        {
            System.Console.WriteLine("Selected Index: " + list_kinosaal.SelectedIndex);
            if (list_kinosaal.SelectedIndex >= 0 && list_kinosaal.SelectedIndex < database.GetElements().Count)
            {
                selectedTheatre = database.GetElements()[list_kinosaal.SelectedIndex];
            }
        }

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
