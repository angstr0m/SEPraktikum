namespace TicketOperations.Views.Besucher.BesucherKinokartenOnlineReservierenViewSub
{
    partial class Sitzplatzauswahl
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
            this.list_sitzplatz = new System.Windows.Forms.ListBox();
            this.dateTimePicker_birthDate = new System.Windows.Forms.DateTimePicker();
            this.label_bithDate = new System.Windows.Forms.Label();
            this.checkBox_rentner = new System.Windows.Forms.CheckBox();
            this.checkBox_Schueler = new System.Windows.Forms.CheckBox();
            this.checkBox_Student = new System.Windows.Forms.CheckBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // button_Zurueck
            // 
            this.button_Zurueck.Location = new System.Drawing.Point(13, 487);
            this.button_Zurueck.Name = "button_Zurueck";
            this.button_Zurueck.Size = new System.Drawing.Size(75, 23);
            this.button_Zurueck.TabIndex = 0;
            this.button_Zurueck.Text = "< Zurück";
            this.button_Zurueck.UseVisualStyleBackColor = true;
            this.button_Zurueck.Click += new System.EventHandler(this.button_Zurueck_Click);
            // 
            // button_Weiter
            // 
            this.button_Weiter.Location = new System.Drawing.Point(217, 487);
            this.button_Weiter.Name = "button_Weiter";
            this.button_Weiter.Size = new System.Drawing.Size(75, 23);
            this.button_Weiter.TabIndex = 1;
            this.button_Weiter.Text = "Weiter >";
            this.button_Weiter.UseVisualStyleBackColor = true;
            this.button_Weiter.Click += new System.EventHandler(this.button_Weiter_Click);
            // 
            // list_sitzplatz
            // 
            this.list_sitzplatz.FormattingEnabled = true;
            this.list_sitzplatz.Location = new System.Drawing.Point(13, 13);
            this.list_sitzplatz.Name = "list_sitzplatz";
            this.list_sitzplatz.Size = new System.Drawing.Size(279, 368);
            this.list_sitzplatz.TabIndex = 2;
            this.list_sitzplatz.SelectedIndexChanged += new System.EventHandler(this.list_sitzplatz_SelectedIndexChanged);
            // 
            // dateTimePicker_birthDate
            // 
            this.dateTimePicker_birthDate.Location = new System.Drawing.Point(92, 396);
            this.dateTimePicker_birthDate.Name = "dateTimePicker_birthDate";
            this.dateTimePicker_birthDate.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker_birthDate.TabIndex = 3;
            this.dateTimePicker_birthDate.ValueChanged += new System.EventHandler(this.dateTimePicker_birthDate_ValueChanged);
            // 
            // label_bithDate
            // 
            this.label_bithDate.AutoSize = true;
            this.label_bithDate.Location = new System.Drawing.Point(12, 402);
            this.label_bithDate.Name = "label_bithDate";
            this.label_bithDate.Size = new System.Drawing.Size(76, 13);
            this.label_bithDate.TabIndex = 4;
            this.label_bithDate.Text = "Geburtsdatum:";
            // 
            // checkBox_rentner
            // 
            this.checkBox_rentner.AutoSize = true;
            this.checkBox_rentner.Location = new System.Drawing.Point(15, 418);
            this.checkBox_rentner.Name = "checkBox_rentner";
            this.checkBox_rentner.Size = new System.Drawing.Size(64, 17);
            this.checkBox_rentner.TabIndex = 5;
            this.checkBox_rentner.Text = "Rentner";
            this.checkBox_rentner.UseVisualStyleBackColor = true;
            // 
            // checkBox_Schueler
            // 
            this.checkBox_Schueler.AutoSize = true;
            this.checkBox_Schueler.Location = new System.Drawing.Point(15, 464);
            this.checkBox_Schueler.Name = "checkBox_Schueler";
            this.checkBox_Schueler.Size = new System.Drawing.Size(62, 17);
            this.checkBox_Schueler.TabIndex = 6;
            this.checkBox_Schueler.Text = "Schüler";
            this.checkBox_Schueler.UseVisualStyleBackColor = true;
            this.checkBox_Schueler.CheckedChanged += new System.EventHandler(this.checkBox_Schueler_CheckedChanged);
            // 
            // checkBox_Student
            // 
            this.checkBox_Student.AutoSize = true;
            this.checkBox_Student.Location = new System.Drawing.Point(15, 441);
            this.checkBox_Student.Name = "checkBox_Student";
            this.checkBox_Student.Size = new System.Drawing.Size(63, 17);
            this.checkBox_Student.TabIndex = 7;
            this.checkBox_Student.Text = "Student";
            this.checkBox_Student.UseVisualStyleBackColor = true;
            this.checkBox_Student.CheckedChanged += new System.EventHandler(this.checkBox_Student_CheckedChanged);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // Sitzplatzauswahl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 522);
            this.Controls.Add(this.checkBox_Student);
            this.Controls.Add(this.checkBox_Schueler);
            this.Controls.Add(this.checkBox_rentner);
            this.Controls.Add(this.label_bithDate);
            this.Controls.Add(this.dateTimePicker_birthDate);
            this.Controls.Add(this.list_sitzplatz);
            this.Controls.Add(this.button_Weiter);
            this.Controls.Add(this.button_Zurueck);
            this.Name = "Sitzplatzauswahl";
            this.Text = "Sitzplatzauswahl";
            this.Load += new System.EventHandler(this.Sitzplatzauswahl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Zurueck;
        private System.Windows.Forms.Button button_Weiter;
        private System.Windows.Forms.ListBox list_sitzplatz;
        private System.Windows.Forms.DateTimePicker dateTimePicker_birthDate;
        private System.Windows.Forms.Label label_bithDate;
        private System.Windows.Forms.CheckBox checkBox_rentner;
        private System.Windows.Forms.CheckBox checkBox_Schueler;
        private System.Windows.Forms.CheckBox checkBox_Student;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}