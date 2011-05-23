namespace SEPraktikum.Views.HauptmenuViewSub.Views.HauptmenuViewSub
{
    partial class BesucherView
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
            this.buttonKinokarteOnlineReservieren = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonKinokarteOnlineReservieren
            // 
            this.buttonKinokarteOnlineReservieren.Location = new System.Drawing.Point(13, 13);
            this.buttonKinokarteOnlineReservieren.Name = "buttonKinokarteOnlineReservieren";
            this.buttonKinokarteOnlineReservieren.Size = new System.Drawing.Size(259, 23);
            this.buttonKinokarteOnlineReservieren.TabIndex = 0;
            this.buttonKinokarteOnlineReservieren.Text = "Kinokarte Online Reservieren";
            this.buttonKinokarteOnlineReservieren.UseVisualStyleBackColor = true;
            this.buttonKinokarteOnlineReservieren.Click += new System.EventHandler(this.buttonKinokarteOnlineReservieren_Click);
            // 
            // BesucherView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.buttonKinokarteOnlineReservieren);
            this.Name = "BesucherView";
            this.Text = "Besucher";
            this.Load += new System.EventHandler(this.BesucherView_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonKinokarteOnlineReservieren;
    }
}