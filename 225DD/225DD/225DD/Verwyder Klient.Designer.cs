namespace _225DD
{
    partial class Verwyder_Klient
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Verwyder_Klient));
            this.btnAanvaar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.btnKanseleer = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAanvaar
            // 
            this.btnAanvaar.Location = new System.Drawing.Point(326, 147);
            this.btnAanvaar.Name = "btnAanvaar";
            this.btnAanvaar.Size = new System.Drawing.Size(98, 23);
            this.btnAanvaar.TabIndex = 0;
            this.btnAanvaar.Text = "Aanvaar";
            this.btnAanvaar.UseVisualStyleBackColor = true;
            this.btnAanvaar.Click += new System.EventHandler(this.btnAanvaar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(210, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Klient ID: ";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(275, 57);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(149, 20);
            this.txtID.TabIndex = 2;
            // 
            // btnKanseleer
            // 
            this.btnKanseleer.Location = new System.Drawing.Point(213, 147);
            this.btnKanseleer.Name = "btnKanseleer";
            this.btnKanseleer.Size = new System.Drawing.Size(98, 23);
            this.btnKanseleer.TabIndex = 3;
            this.btnKanseleer.Text = "Kanseleer";
            this.btnKanseleer.UseVisualStyleBackColor = true;
            this.btnKanseleer.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(208, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Verwyder Kliënt";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::_225DD.Properties.Resources.church1600;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(170, 158);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // Verwyder_Klient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(437, 188);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnKanseleer);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAanvaar);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Verwyder_Klient";
            this.Text = "Verwyder_Klient";
            this.Load += new System.EventHandler(this.Verwyder_Klient_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAanvaar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Button btnKanseleer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}