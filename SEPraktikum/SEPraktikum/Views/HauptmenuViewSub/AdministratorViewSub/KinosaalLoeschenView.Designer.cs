namespace SEPraktikum.Views.HauptmenuViewSub.AdministratorViewSub
{
    partial class KinosaalLoeschen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KinosaalLoeschen));
            this.button_zurueck = new System.Windows.Forms.Button();
            this.list_kinosaal = new System.Windows.Forms.ListBox();
            this.button_kinosaalLoeschen = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_zurueck
            // 
            this.button_zurueck.Location = new System.Drawing.Point(97, 430);
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
            this.list_kinosaal.Size = new System.Drawing.Size(160, 381);
            this.list_kinosaal.TabIndex = 1;
            this.list_kinosaal.SelectedIndexChanged += new System.EventHandler(this.list_kinosaal_SelectedIndexChanged);
            // 
            // button_kinosaalLoeschen
            // 
            this.button_kinosaalLoeschen.Location = new System.Drawing.Point(12, 399);
            this.button_kinosaalLoeschen.Name = "button_kinosaalLoeschen";
            this.button_kinosaalLoeschen.Size = new System.Drawing.Size(160, 23);
            this.button_kinosaalLoeschen.TabIndex = 11;
            this.button_kinosaalLoeschen.Text = "Kinosaal Löschen";
            this.button_kinosaalLoeschen.UseVisualStyleBackColor = true;
            this.button_kinosaalLoeschen.Click += new System.EventHandler(this.button_kinosaalLoeschen_Click);
            // 
            // KinosaalLoeschen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(181, 465);
            this.Controls.Add(this.button_kinosaalLoeschen);
            this.Controls.Add(this.list_kinosaal);
            this.Controls.Add(this.button_zurueck);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "KinosaalLoeschen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kinosaal editieren";
            this.Load += new System.EventHandler(this.KinosaalverwaltungView_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_zurueck;
        private System.Windows.Forms.ListBox list_kinosaal;
        private System.Windows.Forms.Button button_kinosaalLoeschen;
    }
}