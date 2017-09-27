namespace cleaner3._0
{
    partial class cleaningCommplete
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
            this.closeButton = new System.Windows.Forms.Button();
            this.successMessageLable = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(85, 106);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(203, 23);
            this.closeButton.TabIndex = 0;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // successMessageLable
            // 
            this.successMessageLable.AutoSize = true;
            this.successMessageLable.Location = new System.Drawing.Point(12, 9);
            this.successMessageLable.Name = "successMessageLable";
            this.successMessageLable.Size = new System.Drawing.Size(198, 39);
            this.successMessageLable.TabIndex = 1;
            this.successMessageLable.Text = "Cleaning complete.\r\n\r\nCheck the following folder for the results:";
            // 
            // cleaningCommplete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 141);
            this.Controls.Add(this.successMessageLable);
            this.Controls.Add(this.closeButton);
            this.Name = "cleaningCommplete";
            this.Text = "cleaningCommplete";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button closeButton;
        internal System.Windows.Forms.Label successMessageLable;
    }
}