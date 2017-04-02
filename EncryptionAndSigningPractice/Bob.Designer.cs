namespace EncryptionAndSigningPractice
{
    partial class Bob
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.GetKButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.getAESButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Recieved Alice\'s private key";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 1;
            // 
            // GetKButton
            // 
            this.GetKButton.Location = new System.Drawing.Point(13, 30);
            this.GetKButton.Name = "GetKButton";
            this.GetKButton.Size = new System.Drawing.Size(75, 23);
            this.GetKButton.TabIndex = 2;
            this.GetKButton.Text = "Get k";
            this.GetKButton.UseVisualStyleBackColor = true;
            this.GetKButton.Click += new System.EventHandler(this.GetKButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(95, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "label3";
            this.label3.Visible = false;
            // 
            // getAESButton
            // 
            this.getAESButton.Location = new System.Drawing.Point(13, 60);
            this.getAESButton.Name = "getAESButton";
            this.getAESButton.Size = new System.Drawing.Size(75, 23);
            this.getAESButton.TabIndex = 4;
            this.getAESButton.Text = "Get AES";
            this.getAESButton.UseVisualStyleBackColor = true;
            this.getAESButton.Visible = false;
            this.getAESButton.Click += new System.EventHandler(this.getAESButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(95, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "label4";
            this.label4.Visible = false;
            // 
            // Bob
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(685, 261);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.getAESButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.GetKButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Bob";
            this.Text = "Bob";
            this.Load += new System.EventHandler(this.Bob_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button GetKButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button getAESButton;
        private System.Windows.Forms.Label label4;
    }
}