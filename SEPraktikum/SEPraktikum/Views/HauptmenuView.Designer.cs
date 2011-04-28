namespace SEPraktikum.Views.HauptmenuViewSub
{
    partial class SEPraktikum
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SEPraktikum));
            this.button_Administrator = new System.Windows.Forms.Button();
            this.button_Kunde = new System.Windows.Forms.Button();
            this.button_Mitarbeiter = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_Administrator
            // 
            this.button_Administrator.Location = new System.Drawing.Point(12, 12);
            this.button_Administrator.Name = "button_Administrator";
            this.button_Administrator.Size = new System.Drawing.Size(177, 23);
            this.button_Administrator.TabIndex = 0;
            this.button_Administrator.Text = "Administrator";
            this.button_Administrator.UseVisualStyleBackColor = true;
            this.button_Administrator.Click += new System.EventHandler(this.button1_Click);
            // 
            // button_Kunde
            // 
            this.button_Kunde.Location = new System.Drawing.Point(12, 41);
            this.button_Kunde.Name = "button_Kunde";
            this.button_Kunde.Size = new System.Drawing.Size(177, 23);
            this.button_Kunde.TabIndex = 1;
            this.button_Kunde.Text = "Kunde";
            this.button_Kunde.UseVisualStyleBackColor = true;
            this.button_Kunde.Click += new System.EventHandler(this.button_Kunde_Click);
            // 
            // button_Mitarbeiter
            // 
            this.button_Mitarbeiter.Location = new System.Drawing.Point(12, 70);
            this.button_Mitarbeiter.Name = "button_Mitarbeiter";
            this.button_Mitarbeiter.Size = new System.Drawing.Size(177, 23);
            this.button_Mitarbeiter.TabIndex = 2;
            this.button_Mitarbeiter.Text = "Mitarbeiter";
            this.button_Mitarbeiter.UseVisualStyleBackColor = true;
            this.button_Mitarbeiter.Click += new System.EventHandler(this.button_Mitarbeiter_Click);
            // 
            // SEPraktikum
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(195, 108);
            this.Controls.Add(this.button_Mitarbeiter);
            this.Controls.Add(this.button_Kunde);
            this.Controls.Add(this.button_Administrator);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SEPraktikum";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hauptmenü";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_Administrator;
        private System.Windows.Forms.Button button_Kunde;
        private System.Windows.Forms.Button button_Mitarbeiter;
    }
}

