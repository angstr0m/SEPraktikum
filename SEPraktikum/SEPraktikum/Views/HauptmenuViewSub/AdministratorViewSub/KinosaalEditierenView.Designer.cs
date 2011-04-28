namespace SEPraktikum.Views.HauptmenuViewSub.AdministratorViewSub
{
    partial class KinosaalEditierenView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KinosaalEditierenView));
            this.button_zurueck = new System.Windows.Forms.Button();
            this.list_kinosaal = new System.Windows.Forms.ListBox();
            this.textBox_name = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_seatsNumber = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.list_seats = new System.Windows.Forms.ListBox();
            this.button_removeSeat = new System.Windows.Forms.Button();
            this.button_addSeat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_zurueck
            // 
            this.button_zurueck.Location = new System.Drawing.Point(329, 430);
            this.button_zurueck.Name = "button_zurueck";
            this.button_zurueck.Size = new System.Drawing.Size(75, 23);
            this.button_zurueck.TabIndex = 0;
            this.button_zurueck.Text = "Abbrechen";
            this.button_zurueck.UseVisualStyleBackColor = true;
            this.button_zurueck.Click += new System.EventHandler(this.button_zurueck_Click);
            // 
            // list_kinosaal
            // 
            this.list_kinosaal.FormattingEnabled = true;
            this.list_kinosaal.Location = new System.Drawing.Point(12, 12);
            this.list_kinosaal.Name = "list_kinosaal";
            this.list_kinosaal.Size = new System.Drawing.Size(160, 407);
            this.list_kinosaal.TabIndex = 1;
            this.list_kinosaal.SelectedIndexChanged += new System.EventHandler(this.list_kinosaal_SelectedIndexChanged);
            // 
            // textBox_name
            // 
            this.textBox_name.Location = new System.Drawing.Point(274, 9);
            this.textBox_name.Name = "textBox_name";
            this.textBox_name.ReadOnly = true;
            this.textBox_name.Size = new System.Drawing.Size(130, 20);
            this.textBox_name.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(178, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Name:";
            // 
            // textBox_seatsNumber
            // 
            this.textBox_seatsNumber.Location = new System.Drawing.Point(274, 36);
            this.textBox_seatsNumber.Name = "textBox_seatsNumber";
            this.textBox_seatsNumber.ReadOnly = true;
            this.textBox_seatsNumber.Size = new System.Drawing.Size(130, 20);
            this.textBox_seatsNumber.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(178, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Anzahl Sitzplätze:";
            // 
            // list_seats
            // 
            this.list_seats.FormattingEnabled = true;
            this.list_seats.Location = new System.Drawing.Point(274, 63);
            this.list_seats.Name = "list_seats";
            this.list_seats.Size = new System.Drawing.Size(130, 290);
            this.list_seats.TabIndex = 7;
            this.list_seats.SelectedIndexChanged += new System.EventHandler(this.list_seats_SelectedIndexChanged);
            // 
            // button_removeSeat
            // 
            this.button_removeSeat.Location = new System.Drawing.Point(274, 396);
            this.button_removeSeat.Name = "button_removeSeat";
            this.button_removeSeat.Size = new System.Drawing.Size(99, 23);
            this.button_removeSeat.TabIndex = 8;
            this.button_removeSeat.Text = "Sitz löschen";
            this.button_removeSeat.UseVisualStyleBackColor = true;
            this.button_removeSeat.Click += new System.EventHandler(this.button_removeSeat_Click);
            // 
            // button_addSeat
            // 
            this.button_addSeat.Location = new System.Drawing.Point(274, 367);
            this.button_addSeat.Name = "button_addSeat";
            this.button_addSeat.Size = new System.Drawing.Size(99, 23);
            this.button_addSeat.TabIndex = 9;
            this.button_addSeat.Text = "Sitz hinzufügen";
            this.button_addSeat.UseVisualStyleBackColor = true;
            this.button_addSeat.Click += new System.EventHandler(this.button_addSeat_Click);
            // 
            // KinosaalEditierenView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 465);
            this.Controls.Add(this.button_addSeat);
            this.Controls.Add(this.button_removeSeat);
            this.Controls.Add(this.list_seats);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_seatsNumber);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_name);
            this.Controls.Add(this.list_kinosaal);
            this.Controls.Add(this.button_zurueck);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "KinosaalEditierenView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kinosaal editieren";
            this.Load += new System.EventHandler(this.KinosaalverwaltungView_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_zurueck;
        private System.Windows.Forms.ListBox list_kinosaal;
        private System.Windows.Forms.TextBox textBox_name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_seatsNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox list_seats;
        private System.Windows.Forms.Button button_removeSeat;
        private System.Windows.Forms.Button button_addSeat;
    }
}