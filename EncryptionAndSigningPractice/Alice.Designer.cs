﻿namespace EncryptionAndSigningPractice
{
    partial class Alice
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
            this.createKeysButton = new System.Windows.Forms.Button();
            this.shareKeysButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.AESButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.HMACButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.DigiSigButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // createKeysButton
            // 
            this.createKeysButton.Location = new System.Drawing.Point(12, 12);
            this.createKeysButton.Name = "createKeysButton";
            this.createKeysButton.Size = new System.Drawing.Size(128, 23);
            this.createKeysButton.TabIndex = 0;
            this.createKeysButton.Text = "Create Keys";
            this.createKeysButton.UseVisualStyleBackColor = true;
            this.createKeysButton.Click += new System.EventHandler(this.CreateKeys_Click);
            // 
            // shareKeysButton
            // 
            this.shareKeysButton.Location = new System.Drawing.Point(12, 41);
            this.shareKeysButton.Name = "shareKeysButton";
            this.shareKeysButton.Size = new System.Drawing.Size(128, 23);
            this.shareKeysButton.TabIndex = 1;
            this.shareKeysButton.Text = "Send K to Bob";
            this.shareKeysButton.UseVisualStyleBackColor = true;
            this.shareKeysButton.Visible = false;
            this.shareKeysButton.Click += new System.EventHandler(this.SendK_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(147, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "No keys generated";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(147, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "label2";
            this.label2.Visible = false;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // AESButton
            // 
            this.AESButton.Location = new System.Drawing.Point(13, 71);
            this.AESButton.Name = "AESButton";
            this.AESButton.Size = new System.Drawing.Size(127, 23);
            this.AESButton.TabIndex = 4;
            this.AESButton.Text = "Send with AES";
            this.AESButton.UseVisualStyleBackColor = true;
            this.AESButton.Visible = false;
            this.AESButton.Click += new System.EventHandler(this.AESButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(147, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "label3";
            this.label3.Visible = false;
            // 
            // HMACButton
            // 
            this.HMACButton.Location = new System.Drawing.Point(13, 101);
            this.HMACButton.Name = "HMACButton";
            this.HMACButton.Size = new System.Drawing.Size(127, 23);
            this.HMACButton.TabIndex = 6;
            this.HMACButton.Text = "Send with HMAC";
            this.HMACButton.UseVisualStyleBackColor = true;
            this.HMACButton.Visible = false;
            this.HMACButton.Click += new System.EventHandler(this.HMACButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(147, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "label4";
            this.label4.Visible = false;
            // 
            // DigiSigButton
            // 
            this.DigiSigButton.Location = new System.Drawing.Point(12, 131);
            this.DigiSigButton.Name = "DigiSigButton";
            this.DigiSigButton.Size = new System.Drawing.Size(128, 23);
            this.DigiSigButton.TabIndex = 8;
            this.DigiSigButton.Text = "Send with DigiSig";
            this.DigiSigButton.UseVisualStyleBackColor = true;
            this.DigiSigButton.Visible = false;
            this.DigiSigButton.Click += new System.EventHandler(this.DigiSigButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(147, 131);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "label5";
            this.label5.Visible = false;
            // 
            // Alice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(894, 565);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.DigiSigButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.HMACButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.AESButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.shareKeysButton);
            this.Controls.Add(this.createKeysButton);
            this.Name = "Alice";
            this.Text = "Alice";
            this.Load += new System.EventHandler(this.Alice_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button createKeysButton;
        private System.Windows.Forms.Button shareKeysButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button AESButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button HMACButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button DigiSigButton;
        private System.Windows.Forms.Label label5;
    }
}

