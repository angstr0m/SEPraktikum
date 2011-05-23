using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Cinema.Models;
using Database.Models;

namespace Cinema.Views.Administrator
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks></remarks>
    public partial class KinosaalAnlegenView : Form
    {
        /// <summary>
        /// 
        /// </summary>
        private EntityManager<Kinosaal> database; 
        // Data needed for the creation of a new Kinosaal.
        /// <summary>
        /// 
        /// </summary>
        private string movieTheatreName;
        /// <summary>
        /// 
        /// </summary>
        private int number_of_seats;
        /// <summary>
        /// 
        /// </summary>
        private int seats_per_rank;
        /// <summary>
        /// 
        /// </summary>
        private int ranks;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Windows.Forms.Form"/> class.
        /// </summary>
        /// <remarks></remarks>
        public KinosaalAnlegenView()
        {
            InitializeComponent();
            errorProvider1.BlinkRate = 0;
            database = new EntityManager<Kinosaal>();
            ValidateThis();
        }

        /// <summary>
        /// Sets the controller.
        /// </summary>
        /// <remarks></remarks>
        public void SetController() {
            
        }

        /// <summary>
        /// Handles the Click event of the button_abbrechen control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        /// <remarks></remarks>
        private void button_abbrechen_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }

        // If the input provided by the user is valid, generate a new Kinosaal and add it to the database.
        /// <summary>
        /// Handles the Click event of the button_ok control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        /// <remarks></remarks>
        private void button_ok_Click(object sender, EventArgs e)
        {
            number_of_seats = ranks * seats_per_rank;
            char[] alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            List<Sitz> seats = new List<Sitz>();

            // Generate the needed number of seats.
            for (int i = 0; i < ranks; i++)
			{
                char rank = alphabet[i];
			    for (int j = 0; j < seats_per_rank; j++)
			    {
			        Sitz tempSitz = new Sitz(rank, j);
                    seats.Add(tempSitz);
			    }
			}

            Kinosaal kinosaal = new Kinosaal(movieTheatreName,seats);

            database.AddElement(kinosaal); // Add the movie theatre to the database.

            this.Close();
        }

        /// <summary>
        /// Handles the TextChanged event of the textBox_name control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        /// <remarks></remarks>
        private void textBox_name_TextChanged(object sender, EventArgs e)
        {
            ValidateThis(); // Validate the Input as soon as the user inputs new data.
        }

        /// <summary>
        /// Handles the Load event of the KinosaalAnlegen control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        /// <remarks></remarks>
        private void KinosaalAnlegen_Load(object sender, EventArgs e)
        {
            ValidateThis(); // Validate the Input as soon as the user inputs new data.
        }

        /// <summary>
        /// Handles the TextChanged event of the textBox_ranks control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        /// <remarks></remarks>
        private void textBox_ranks_TextChanged(object sender, EventArgs e)
        {
            ValidateThis(); // Validate the Input as soon as the user inputs new data.
        }

        /// <summary>
        /// Handles the TextChanged event of the textBox_seatsPerRank control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        /// <remarks></remarks>
        private void textBox_seatsPerRank_TextChanged(object sender, EventArgs e)
        {
            ValidateThis(); // Validate the Input as soon as the user inputs new data.
        }

        // Validate the form
        /// <summary>
        /// Validates the this.
        /// </summary>
        /// <remarks></remarks>
        private void ValidateThis()
        {
            bool valid = true;

            valid = ValidateInput();
            // Do additional validations here!
            
            this.button_ok.Enabled = valid;
        }

        // Validate the input of the user
        /// <summary>
        /// Validates the input.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        private bool ValidateInput()
        {
            bool valid = true; // Will be set false if any of the validations fail. Is returned at the end of this method.

            #region textbox_name prüfen
            // Validate TextBox_name
            if (this.textBox_name.Text.Length == 0)
            {
                errorProvider1.SetError(textBox_name, "Bitte geben Sie einen Namen ein.");
                valid = false;
            }
            else
            {
                movieTheatreName = textBox_name.Text;
                errorProvider1.SetError(textBox_name, "");

                if (movieTheatreName.StartsWith(" "))
                {
                    errorProvider1.SetError(textBox_name, "Der Name des Kinosaals muss mit einem Buchstaben oder einer Zahl beginnen.");
                    valid = false;
                }
                else
                {
                    if (movieTheatreName.EndsWith(" "))
                    {
                        errorProvider1.SetError(textBox_name, "Der Name des Kinosaals muss mit einem Buchstaben oder einer Zahl enden.");
                        valid = false;
                    }
                    else
                    {
                        foreach (Kinosaal theatre in database.GetElements())
                        {
                            if (theatre.Name == movieTheatreName)
                            {
                                errorProvider1.SetError(textBox_name, "Ein Kinosaal mit dem angegebenen Namen existiert bereits.");
                                valid = false;
                            }
                        }
                    }
                }
            }
            #endregion

            #region textbox_ranks prüfen
            
            // Validate TextBox_seatsnumber
            int temp_int;
            if (!int.TryParse(this.textBox_ranks.Text, out temp_int))
            {
                errorProvider1.SetError(textBox_ranks, "Bitte geben Sie eine ganze natürliche Zahl ein.");
                valid = false;
            }
            else
            {
                ranks = temp_int;
                errorProvider1.SetError(textBox_ranks, "");

                if (ranks <= 0)
                {
                    errorProvider1.SetError(textBox_ranks, "Die Anzahl der Reihen darf nicht <= 0 sein!");
                    valid = false;
                }

                if (ranks > 26)
                {
                    errorProvider1.SetError(textBox_ranks, "Die Anzahl der Reihen darf 26 nicht überschreiten!");
                    valid = false;
                }
            }
            #endregion

            #region seatsPerRank prüfen
            // Validate TextBox_seatsnumber
            if (!int.TryParse(this.textBox_seatsPerRank.Text, out temp_int))
            {
                errorProvider1.SetError(textBox_seatsPerRank, "Bitte geben Sie eine ganze natürliche Zahl ein.");
                valid = false;
            }
            else
            {
                seats_per_rank = temp_int;
                errorProvider1.SetError(textBox_seatsPerRank, "");

                if (seats_per_rank <= 0)
                {
                    errorProvider1.SetError(textBox_seatsPerRank, "Die Anzahl der Sitze pro Reihen darf nicht <= 0 sein!");
                    valid = false;
                }
            }
            #endregion

            return valid;
        }
    }
}
