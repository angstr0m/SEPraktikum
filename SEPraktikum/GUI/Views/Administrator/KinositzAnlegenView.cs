using System;
using System.Linq;
using System.Windows.Forms;
using Cinema.Models;

namespace Cinema.Views.Administrator
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks></remarks>
    public partial class KinositzAnlegenView : Form
    {
        /// <summary>
        /// 
        /// </summary>
        char row;
        /// <summary>
        /// 
        /// </summary>
        int number;
        /// <summary>
        /// 
        /// </summary>
        char[] alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Windows.Forms.Form"/> class.
        /// </summary>
        /// <remarks></remarks>
        public KinositzAnlegenView()
        {
            InitializeComponent();
            errorProvider1.BlinkRate = 0;
        }

        /// <summary>
        /// Handles the Click event of the button1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        /// <remarks></remarks>
        private void button1_Click(object sender, EventArgs e)
        {
            ((KinosaalEditierenView)this.Owner).SelectedTheatre.AddSeat(new Sitz(row, number));
            ValidateInput();
        }

        /// <summary>
        /// Handles the TextChanged event of the textBox_number control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        /// <remarks></remarks>
        private void textBox_number_TextChanged(object sender, EventArgs e)
        {
            ValidateInput();
        }

        /// <summary>
        /// Validates the input.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        private bool ValidateInput()
        {
            bool valid = true;

            #region textbox_number prüfen
            
            int temp_int;
            if (!int.TryParse(this.textBox_number.Text, out temp_int))
            {
                
                errorProvider1.SetError(textBox_number, "Bitte geben Sie eine ganze natürliche Zahl ein.");
                valid = false;
            }
            else
            {
                number = temp_int;
                
                errorProvider1.SetError(textBox_number, "");

                if (number < 0)
                {
                    errorProvider1.SetError(textBox_number, "Die Nummer des Sitzes darf < 0 sein!");
                    valid = false;
                }
            }
            #endregion

            #region textbox_rank prüfen

            if (textBox_rank.Text.Length > 1 || textBox_rank.Text.Length == 0)
            {
                errorProvider1.SetError(textBox_rank, "Bitte geben Sie einen Großbuchstaben von A-Z ein.");
                valid = false;
            }
            else
            {
                errorProvider1.SetError(textBox_rank, "");

                if (!(alphabet.Contains(textBox_rank.Text.ToCharArray()[0])))
                {
                    errorProvider1.SetError(textBox_rank, "Bitte geben Sie einen Großbuchstaben von A-Z ein.");
                    valid = false;
                }
                else
                {
                    row = textBox_rank.Text.ToCharArray()[0];
                }
            }
            #endregion

            if (valid == true)
            {
                foreach (Sitz s in ((KinosaalEditierenView)this.Owner).SelectedTheatre.GetSeats())
                {
                    if (s.GetNr() == number && s.GetRow() == row)
                    {
                        errorProvider1.SetError(textBox_rank, "Es ist bereits ein Sitz mit dieser Nummer und Reihe vorhanden!");
                        errorProvider1.SetError(textBox_number, "Es ist bereits ein Sitz mit dieser Nummer und Reihe vorhanden!");
                        valid = false;
                        break;
                    }
                }
            }

            button_Ok.Enabled = valid;

            return valid;
        }

        /// <summary>
        /// Handles the Load event of the KinositzAnlegenView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        /// <remarks></remarks>
        private void KinositzAnlegenView_Load(object sender, EventArgs e)
        {
            ValidateInput();
        }

        /// <summary>
        /// Handles the Click event of the button_Cancel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        /// <remarks></remarks>
        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }

        /// <summary>
        /// Handles the TextChanged event of the textBox_rank control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        /// <remarks></remarks>
        private void textBox_rank_TextChanged(object sender, EventArgs e)
        {
            ValidateInput();
        }

    }
}
