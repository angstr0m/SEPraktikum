namespace TicketOperations.Views.Besucher
{
    partial class BesucherKinokartenOnlineReservieren
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
            this.button_chooseSelectedShow = new System.Windows.Forms.Button();
            this.listBox_Shows = new System.Windows.Forms.ListBox();
            this.textBox_ShowStart = new System.Windows.Forms.TextBox();
            this.label_startTime = new System.Windows.Forms.Label();
            this.textBox_ShowDuration = new System.Windows.Forms.TextBox();
            this.label_dauer = new System.Windows.Forms.Label();
            this.textBox_numberOfAvalableTickets = new System.Windows.Forms.TextBox();
            this.label_numberOfAvailableTickets = new System.Windows.Forms.Label();
            this.button_back = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_chooseSelectedShow
            // 
            this.button_chooseSelectedShow.Location = new System.Drawing.Point(410, 351);
            this.button_chooseSelectedShow.Name = "button_chooseSelectedShow";
            this.button_chooseSelectedShow.Size = new System.Drawing.Size(75, 23);
            this.button_chooseSelectedShow.TabIndex = 0;
            this.button_chooseSelectedShow.Text = "Weiter >";
            this.button_chooseSelectedShow.UseVisualStyleBackColor = true;
            this.button_chooseSelectedShow.Click += new System.EventHandler(this.button_chooseSelectedShow_Click);
            // 
            // listBox_Shows
            // 
            this.listBox_Shows.FormattingEnabled = true;
            this.listBox_Shows.Location = new System.Drawing.Point(13, 13);
            this.listBox_Shows.Name = "listBox_Shows";
            this.listBox_Shows.Size = new System.Drawing.Size(206, 329);
            this.listBox_Shows.TabIndex = 1;
            this.listBox_Shows.SelectedIndexChanged += new System.EventHandler(this.listBox_Shows_SelectedIndexChanged);
            // 
            // textBox_ShowStart
            // 
            this.textBox_ShowStart.Enabled = false;
            this.textBox_ShowStart.Location = new System.Drawing.Point(337, 13);
            this.textBox_ShowStart.Name = "textBox_ShowStart";
            this.textBox_ShowStart.Size = new System.Drawing.Size(148, 20);
            this.textBox_ShowStart.TabIndex = 2;
            // 
            // label_startTime
            // 
            this.label_startTime.AutoSize = true;
            this.label_startTime.Location = new System.Drawing.Point(225, 16);
            this.label_startTime.Name = "label_startTime";
            this.label_startTime.Size = new System.Drawing.Size(105, 13);
            this.label_startTime.TabIndex = 3;
            this.label_startTime.Text = "Start der Vorstellung:";
            // 
            // textBox_ShowDuration
            // 
            this.textBox_ShowDuration.Enabled = false;
            this.textBox_ShowDuration.Location = new System.Drawing.Point(337, 40);
            this.textBox_ShowDuration.Name = "textBox_ShowDuration";
            this.textBox_ShowDuration.Size = new System.Drawing.Size(148, 20);
            this.textBox_ShowDuration.TabIndex = 6;
            // 
            // label_dauer
            // 
            this.label_dauer.AutoSize = true;
            this.label_dauer.Location = new System.Drawing.Point(225, 47);
            this.label_dauer.Name = "label_dauer";
            this.label_dauer.Size = new System.Drawing.Size(91, 13);
            this.label_dauer.TabIndex = 7;
            this.label_dauer.Text = "Dauer in Minuten:";
            // 
            // textBox_numberOfAvalableTickets
            // 
            this.textBox_numberOfAvalableTickets.Enabled = false;
            this.textBox_numberOfAvalableTickets.Location = new System.Drawing.Point(337, 67);
            this.textBox_numberOfAvalableTickets.Name = "textBox_numberOfAvalableTickets";
            this.textBox_numberOfAvalableTickets.Size = new System.Drawing.Size(148, 20);
            this.textBox_numberOfAvalableTickets.TabIndex = 8;
            // 
            // label_numberOfAvailableTickets
            // 
            this.label_numberOfAvailableTickets.AutoSize = true;
            this.label_numberOfAvailableTickets.Location = new System.Drawing.Point(225, 74);
            this.label_numberOfAvailableTickets.Name = "label_numberOfAvailableTickets";
            this.label_numberOfAvailableTickets.Size = new System.Drawing.Size(96, 13);
            this.label_numberOfAvailableTickets.TabIndex = 9;
            this.label_numberOfAvailableTickets.Text = "Verfügbare Karten:";
            // 
            // button_back
            // 
            this.button_back.Location = new System.Drawing.Point(13, 350);
            this.button_back.Name = "button_back";
            this.button_back.Size = new System.Drawing.Size(75, 23);
            this.button_back.TabIndex = 10;
            this.button_back.Text = "Abbrechen";
            this.button_back.UseVisualStyleBackColor = true;
            this.button_back.Click += new System.EventHandler(this.button_back_Click);
            // 
            // BesucherKinokartenOnlineReservieren
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 384);
            this.Controls.Add(this.button_back);
            this.Controls.Add(this.label_numberOfAvailableTickets);
            this.Controls.Add(this.textBox_numberOfAvalableTickets);
            this.Controls.Add(this.label_dauer);
            this.Controls.Add(this.textBox_ShowDuration);
            this.Controls.Add(this.label_startTime);
            this.Controls.Add(this.textBox_ShowStart);
            this.Controls.Add(this.listBox_Shows);
            this.Controls.Add(this.button_chooseSelectedShow);
            this.Name = "BesucherKinokartenOnlineReservieren";
            this.Text = "BesucherKinokartenOnlineReservieren";
            this.Load += new System.EventHandler(this.BesucherKinokartenOnlineReservieren_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_chooseSelectedShow;
        private System.Windows.Forms.ListBox listBox_Shows;
        private System.Windows.Forms.TextBox textBox_ShowStart;
        private System.Windows.Forms.Label label_startTime;
        private System.Windows.Forms.TextBox textBox_ShowDuration;
        private System.Windows.Forms.Label label_dauer;
        private System.Windows.Forms.TextBox textBox_numberOfAvalableTickets;
        private System.Windows.Forms.Label label_numberOfAvailableTickets;
        private System.Windows.Forms.Button button_back;
    }
}