using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SEPraktikum.Views.HauptmenuViewSub.AdministratorViewSub;
using Models;

namespace SEPraktikum.Views.HauptmenuViewSub.AdministratorViewSub.KinosaalEditierenViewSub
{
    public partial class KinositzAnlegenView : Form
    {
        char row;
        int number;
        char[] alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

        public KinositzAnlegenView()
        {
            InitializeComponent();
            errorProvider1.BlinkRate = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ((KinosaalEditierenView)this.Owner).SelectedTheatre.AddSeat(new Seat(row, number));
            ValidateInput();
        }

        private void textBox_number_TextChanged(object sender, EventArgs e)
        {
            ValidateInput();
        }

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
                foreach (Seat s in ((KinosaalEditierenView)this.Owner).SelectedTheatre.GetSeats())
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

        private void KinositzAnlegenView_Load(object sender, EventArgs e)
        {
            ValidateInput();
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }

        private void textBox_rank_TextChanged(object sender, EventArgs e)
        {
            ValidateInput();
        }

    }
}
