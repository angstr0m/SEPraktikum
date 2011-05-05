using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SEPraktikum.Controller;
using Interfaces;
using Models;

namespace SEPraktikum.Views.HauptmenuViewSub.AdministratorViewSub
{
    public partial class KinosaalLoeschen : Form, Observer, Interfaces.View
    {
        private KinosaalVerwaltungController controller;
        private Database model;
        private Interfaces.View view;
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
                setModel(Database.Instance);
                model.AddObserver(this);
                this.list_kinosaal.DataSource = model.getMovieTheatres();
                this.list_kinosaal.DisplayMember = "Name";
                System.Console.WriteLine(list_kinosaal.SelectedIndex);
                if (list_kinosaal.SelectedIndex >= 0 && list_kinosaal.SelectedIndex < model.getMovieTheatres().Count)
                {
                    selectedTheatre = model.getMovieTheatres()[list_kinosaal.SelectedIndex];
                    
                }
            }
        }

        public void setModel(Database _model)
        {
            this.model = _model;
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
            this.list_kinosaal.DataSource = model.getMovieTheatres();
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
            if (list_kinosaal.SelectedIndex >= 0 && list_kinosaal.SelectedIndex < model.getMovieTheatres().Count)
            {
                selectedTheatre = model.getMovieTheatres()[list_kinosaal.SelectedIndex];
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
                model.removeMovieTheatre(model.getMovieTheatres()[list_kinosaal.SelectedIndex]);
            }
        }
    }
}
