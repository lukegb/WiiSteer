namespace WiiSteer
{
    partial class Form1
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
            this.connectBtn = new System.Windows.Forms.Button();
            this.logArea = new System.Windows.Forms.TextBox();
            this.rotationLabelLabel = new System.Windows.Forms.Label();
            this.rotationLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // connectBtn
            // 
            this.connectBtn.Enabled = false;
            this.connectBtn.Location = new System.Drawing.Point(12, 12);
            this.connectBtn.Name = "connectBtn";
            this.connectBtn.Size = new System.Drawing.Size(487, 23);
            this.connectBtn.TabIndex = 0;
            this.connectBtn.Text = "Connect";
            this.connectBtn.UseVisualStyleBackColor = true;
            this.connectBtn.Click += new System.EventHandler(this.connectBtn_Click);
            // 
            // logArea
            // 
            this.logArea.Location = new System.Drawing.Point(12, 144);
            this.logArea.Multiline = true;
            this.logArea.Name = "logArea";
            this.logArea.ReadOnly = true;
            this.logArea.Size = new System.Drawing.Size(487, 105);
            this.logArea.TabIndex = 1;
            // 
            // rotationLabelLabel
            // 
            this.rotationLabelLabel.AutoSize = true;
            this.rotationLabelLabel.Location = new System.Drawing.Point(12, 38);
            this.rotationLabelLabel.Name = "rotationLabelLabel";
            this.rotationLabelLabel.Size = new System.Drawing.Size(53, 13);
            this.rotationLabelLabel.TabIndex = 2;
            this.rotationLabelLabel.Text = "Rotation: ";
            // 
            // rotationLabel
            // 
            this.rotationLabel.AutoSize = true;
            this.rotationLabel.Location = new System.Drawing.Point(72, 38);
            this.rotationLabel.Name = "rotationLabel";
            this.rotationLabel.Size = new System.Drawing.Size(53, 13);
            this.rotationLabel.TabIndex = 3;
            this.rotationLabel.Text = "Unknown";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 261);
            this.Controls.Add(this.rotationLabel);
            this.Controls.Add(this.rotationLabelLabel);
            this.Controls.Add(this.logArea);
            this.Controls.Add(this.connectBtn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button connectBtn;
        private System.Windows.Forms.TextBox logArea;
        private System.Windows.Forms.Label rotationLabelLabel;
        private System.Windows.Forms.Label rotationLabel;
    }
}

