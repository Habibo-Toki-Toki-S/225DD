namespace _225DD
{
    partial class Verwyder_Gebruiker
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Verwyder_Gebruiker));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnKanseleer = new System.Windows.Forms.Button();
            this.txtK_ID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAanvaar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::_225DD.Properties.Resources.church1600;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(170, 158);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(208, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(191, 25);
            this.label2.TabIndex = 10;
            this.label2.Text = "Verwyder Gerbruiker";
            // 
            // btnKanseleer
            // 
            this.btnKanseleer.Location = new System.Drawing.Point(213, 147);
            this.btnKanseleer.Name = "btnKanseleer";
            this.btnKanseleer.Size = new System.Drawing.Size(98, 23);
            this.btnKanseleer.TabIndex = 9;
            this.btnKanseleer.Text = "Kanseleer";
            this.btnKanseleer.UseVisualStyleBackColor = true;
            // 
            // txtK_ID
            // 
            this.txtK_ID.Location = new System.Drawing.Point(289, 57);
            this.txtK_ID.Name = "txtK_ID";
            this.txtK_ID.Size = new System.Drawing.Size(135, 20);
            this.txtK_ID.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(210, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Gebruiker ID: ";
            // 
            // btnAanvaar
            // 
            this.btnAanvaar.Location = new System.Drawing.Point(326, 147);
            this.btnAanvaar.Name = "btnAanvaar";
            this.btnAanvaar.Size = new System.Drawing.Size(98, 23);
            this.btnAanvaar.TabIndex = 6;
            this.btnAanvaar.Text = "Aanvaar";
            this.btnAanvaar.UseVisualStyleBackColor = true;
            // 
            // Verwyder_Gebruiker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(448, 185);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnKanseleer);
            this.Controls.Add(this.txtK_ID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAanvaar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Verwyder_Gebruiker";
            this.Text = "Verwyder_Gebruiker";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnKanseleer;
        private System.Windows.Forms.TextBox txtK_ID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAanvaar;
    }
}