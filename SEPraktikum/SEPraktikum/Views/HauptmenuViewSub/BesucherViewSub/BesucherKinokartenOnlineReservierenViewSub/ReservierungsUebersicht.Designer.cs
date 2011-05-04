namespace SEPraktikum.Views.HauptmenuViewSub.BesucherViewSub
{
    partial class ReservierungsUebersicht
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button_Zurueck = new System.Windows.Forms.Button();
            this.button_Weiter = new System.Windows.Forms.Button();
            this.textBox_Uebersicht = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label_timeRemaining = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button_Zurueck
            // 
            this.button_Zurueck.Location = new System.Drawing.Point(13, 227);
            this.button_Zurueck.Name = "button_Zurueck";
            this.button_Zurueck.Size = new System.Drawing.Size(75, 23);
            this.button_Zurueck.TabIndex = 0;
            this.button_Zurueck.Text = "Abbrechen";
            this.button_Zurueck.UseVisualStyleBackColor = true;
            this.button_Zurueck.Click += new System.EventHandler(this.button_Zurueck_Click);
            // 
            // button_Weiter
            // 
            this.button_Weiter.Location = new System.Drawing.Point(217, 227);
            this.button_Weiter.Name = "button_Weiter";
            this.button_Weiter.Size = new System.Drawing.Size(75, 23);
            this.button_Weiter.TabIndex = 1;
            this.button_Weiter.Text = "Reservieren!";
            this.button_Weiter.UseVisualStyleBackColor = true;
            this.button_Weiter.Click += new System.EventHandler(this.button_Weiter_Click);
            // 
            // textBox_Uebersicht
            // 
            this.textBox_Uebersicht.Enabled = false;
            this.textBox_Uebersicht.Location = new System.Drawing.Point(13, 12);
            this.textBox_Uebersicht.Multiline = true;
            this.textBox_Uebersicht.Name = "textBox_Uebersicht";
            this.textBox_Uebersicht.Size = new System.Drawing.Size(279, 193);
            this.textBox_Uebersicht.TabIndex = 2;
            this.textBox_Uebersicht.WordWrap = false;
            // 
            // label_timeRemaining
            // 
            this.label_timeRemaining.AutoSize = true;
            this.label_timeRemaining.Location = new System.Drawing.Point(13, 208);
            this.label_timeRemaining.Name = "label_timeRemaining";
            this.label_timeRemaining.Size = new System.Drawing.Size(279, 13);
            this.label_timeRemaining.TabIndex = 3;
            this.label_timeRemaining.Text = "Sie haben 90 Sekunden Zeit Ihre Angaben zu bestätigen.";
            // 
            // ReservierungsUebersicht
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 262);
            this.Controls.Add(this.label_timeRemaining);
            this.Controls.Add(this.textBox_Uebersicht);
            this.Controls.Add(this.button_Weiter);
            this.Controls.Add(this.button_Zurueck);
            this.Name = "ReservierungsUebersicht";
            this.Text = "ReservierungsUebersicht";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ReservierungsUebersicht_FormClosing);
            this.Load += new System.EventHandler(this.ReservierungsUebersicht_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Zurueck;
        private System.Windows.Forms.Button button_Weiter;
        private System.Windows.Forms.TextBox textBox_Uebersicht;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label_timeRemaining;
    }
}