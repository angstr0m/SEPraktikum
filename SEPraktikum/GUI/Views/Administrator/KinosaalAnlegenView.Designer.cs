namespace Cinema.Views.Administrator
{
    partial class KinosaalAnlegenView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KinosaalAnlegenView));
            this.textBox_name = new System.Windows.Forms.TextBox();
            this.button_abbrechen = new System.Windows.Forms.Button();
            this.button_ok = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_ranks = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_seatsPerRank = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox_name
            // 
            this.textBox_name.Location = new System.Drawing.Point(162, 15);
            this.textBox_name.Name = "textBox_name";
            this.textBox_name.Size = new System.Drawing.Size(130, 20);
            this.textBox_name.TabIndex = 0;
            this.textBox_name.TextChanged += new System.EventHandler(this.textBox_name_TextChanged);
            // 
            // button_abbrechen
            // 
            this.button_abbrechen.Location = new System.Drawing.Point(217, 92);
            this.button_abbrechen.Name = "button_abbrechen";
            this.button_abbrechen.Size = new System.Drawing.Size(75, 23);
            this.button_abbrechen.TabIndex = 4;
            this.button_abbrechen.Text = "Abbrechen";
            this.button_abbrechen.UseVisualStyleBackColor = true;
            this.button_abbrechen.Click += new System.EventHandler(this.button_abbrechen_Click);
            // 
            // button_ok
            // 
            this.button_ok.Location = new System.Drawing.Point(136, 92);
            this.button_ok.Name = "button_ok";
            this.button_ok.Size = new System.Drawing.Size(75, 23);
            this.button_ok.TabIndex = 3;
            this.button_ok.Text = "Ok";
            this.button_ok.UseVisualStyleBackColor = true;
            this.button_ok.Click += new System.EventHandler(this.button_ok_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Name des Kinosaals:";
            // 
            // textBox_ranks
            // 
            this.textBox_ranks.Location = new System.Drawing.Point(162, 40);
            this.textBox_ranks.Name = "textBox_ranks";
            this.textBox_ranks.Size = new System.Drawing.Size(130, 20);
            this.textBox_ranks.TabIndex = 1;
            this.textBox_ranks.TextChanged += new System.EventHandler(this.textBox_ranks_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Anzahl Reihen des Kinosaals";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(141, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Anzahl von Sitzen pro Reihe";
            // 
            // textBox_seatsPerRank
            // 
            this.textBox_seatsPerRank.Location = new System.Drawing.Point(162, 66);
            this.textBox_seatsPerRank.Name = "textBox_seatsPerRank";
            this.textBox_seatsPerRank.Size = new System.Drawing.Size(130, 20);
            this.textBox_seatsPerRank.TabIndex = 2;
            this.textBox_seatsPerRank.TextChanged += new System.EventHandler(this.textBox_seatsPerRank_TextChanged);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // KinosaalAnlegen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 123);
            this.Controls.Add(this.textBox_seatsPerRank);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_ranks);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_ok);
            this.Controls.Add(this.button_abbrechen);
            this.Controls.Add(this.textBox_name);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "KinosaalAnlegen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KinosaalAnlegen";
            this.Load += new System.EventHandler(this.KinosaalAnlegen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_name;
        private System.Windows.Forms.Button button_abbrechen;
        private System.Windows.Forms.Button button_ok;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_ranks;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_seatsPerRank;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}