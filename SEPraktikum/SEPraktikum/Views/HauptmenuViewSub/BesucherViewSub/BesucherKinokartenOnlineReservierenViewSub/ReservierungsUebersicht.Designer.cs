namespace SEPraktikum.Views.HauptmenuViewSub.BesucherViewSub.BesucherKinokartenOnlineReservierenViewSub
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
            this.button_Zurueck = new System.Windows.Forms.Button();
            this.button_Weiter = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button_Zurueck
            // 
            this.button_Zurueck.Location = new System.Drawing.Point(13, 227);
            this.button_Zurueck.Name = "button_Zurueck";
            this.button_Zurueck.Size = new System.Drawing.Size(75, 23);
            this.button_Zurueck.TabIndex = 0;
            this.button_Zurueck.Text = "< Zurück";
            this.button_Zurueck.UseVisualStyleBackColor = true;
            // 
            // button_Weiter
            // 
            this.button_Weiter.Location = new System.Drawing.Point(197, 227);
            this.button_Weiter.Name = "button_Weiter";
            this.button_Weiter.Size = new System.Drawing.Size(75, 23);
            this.button_Weiter.TabIndex = 1;
            this.button_Weiter.Text = "Weiter >";
            this.button_Weiter.UseVisualStyleBackColor = true;
            this.button_Weiter.Click += new System.EventHandler(this.button_Weiter_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(13, 12);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(259, 209);
            this.textBox1.TabIndex = 2;
            // 
            // ReservierungsUebersicht
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button_Weiter);
            this.Controls.Add(this.button_Zurueck);
            this.Name = "ReservierungsUebersicht";
            this.Text = "ReservierungsUebersicht";
            this.Load += new System.EventHandler(this.ReservierungsUebersicht_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Zurueck;
        private System.Windows.Forms.Button button_Weiter;
        private System.Windows.Forms.TextBox textBox1;
    }
}