namespace SEPraktikum.Views.HauptmenuViewSub.Views.HauptmenuViewSub.BesucherViewSub
{
    partial class BesucherUebersichtVorstellungen
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
            this.button_zurueck = new System.Windows.Forms.Button();
            this.button_VorstellungWaehlen = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // button_zurueck
            // 
            this.button_zurueck.Location = new System.Drawing.Point(12, 401);
            this.button_zurueck.Name = "button_zurueck";
            this.button_zurueck.Size = new System.Drawing.Size(75, 23);
            this.button_zurueck.TabIndex = 1;
            this.button_zurueck.Text = "Abbrechen";
            this.button_zurueck.UseVisualStyleBackColor = true;
            // 
            // button_VorstellungWaehlen
            // 
            this.button_VorstellungWaehlen.Location = new System.Drawing.Point(151, 401);
            this.button_VorstellungWaehlen.Name = "button_VorstellungWaehlen";
            this.button_VorstellungWaehlen.Size = new System.Drawing.Size(121, 23);
            this.button_VorstellungWaehlen.TabIndex = 2;
            this.button_VorstellungWaehlen.Text = "Vorstellung wählen";
            this.button_VorstellungWaehlen.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(13, 13);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(259, 381);
            this.listBox1.TabIndex = 3;
            // 
            // BesucherUebersichtVorstellungen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 436);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.button_VorstellungWaehlen);
            this.Controls.Add(this.button_zurueck);
            this.Name = "BesucherUebersichtVorstellungen";
            this.Text = "BesucherUebersichtVorstellungen";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_zurueck;
        private System.Windows.Forms.Button button_VorstellungWaehlen;
        private System.Windows.Forms.ListBox listBox1;
    }
}