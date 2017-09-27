namespace cleaner3._0
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.chooseFileButton = new System.Windows.Forms.Button();
            this.cleanFileButton = new System.Windows.Forms.Button();
            this.sourceLabel = new System.Windows.Forms.Label();
            this.acceptedLabel = new System.Windows.Forms.Label();
            this.configLabel = new System.Windows.Forms.Label();
            this.GenericContentLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // chooseFileButton
            // 
            this.chooseFileButton.Location = new System.Drawing.Point(12, 27);
            this.chooseFileButton.Name = "chooseFileButton";
            this.chooseFileButton.Size = new System.Drawing.Size(84, 23);
            this.chooseFileButton.TabIndex = 0;
            this.chooseFileButton.Text = "Select Source";
            this.chooseFileButton.UseVisualStyleBackColor = true;
            this.chooseFileButton.Click += new System.EventHandler(this.chooseFileButton_Click);
            // 
            // cleanFileButton
            // 
            this.cleanFileButton.Location = new System.Drawing.Point(12, 165);
            this.cleanFileButton.Name = "cleanFileButton";
            this.cleanFileButton.Size = new System.Drawing.Size(75, 23);
            this.cleanFileButton.TabIndex = 1;
            this.cleanFileButton.Text = "Clean File";
            this.cleanFileButton.UseVisualStyleBackColor = true;
            this.cleanFileButton.Click += new System.EventHandler(this.cleanFileButton_Click);
            // 
            // sourceLabel
            // 
            this.sourceLabel.AutoSize = true;
            this.sourceLabel.Location = new System.Drawing.Point(114, 27);
            this.sourceLabel.Name = "sourceLabel";
            this.sourceLabel.Size = new System.Drawing.Size(124, 13);
            this.sourceLabel.TabIndex = 2;
            this.sourceLabel.Text = "Source: Not selected yet";
            // 
            // acceptedLabel
            // 
            this.acceptedLabel.AutoSize = true;
            this.acceptedLabel.Location = new System.Drawing.Point(114, 80);
            this.acceptedLabel.Name = "acceptedLabel";
            this.acceptedLabel.Size = new System.Drawing.Size(132, 13);
            this.acceptedLabel.TabIndex = 3;
            this.acceptedLabel.Text = "Accepted Characters File: ";
            // 
            // configLabel
            // 
            this.configLabel.AutoSize = true;
            this.configLabel.Location = new System.Drawing.Point(114, 58);
            this.configLabel.Name = "configLabel";
            this.configLabel.Size = new System.Drawing.Size(59, 13);
            this.configLabel.TabIndex = 4;
            this.configLabel.Text = "Config File:";
            // 
            // GenericContentLabel
            // 
            this.GenericContentLabel.AutoSize = true;
            this.GenericContentLabel.Location = new System.Drawing.Point(114, 102);
            this.GenericContentLabel.Name = "GenericContentLabel";
            this.GenericContentLabel.Size = new System.Drawing.Size(109, 13);
            this.GenericContentLabel.TabIndex = 5;
            this.GenericContentLabel.Text = "Generic Content File: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 200);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(659, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Will remove any line containing a value not found in the accepted charecters file" +
    " and the generic content file. Removes Duplicates as well.";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 289);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.GenericContentLabel);
            this.Controls.Add(this.configLabel);
            this.Controls.Add(this.acceptedLabel);
            this.Controls.Add(this.sourceLabel);
            this.Controls.Add(this.cleanFileButton);
            this.Controls.Add(this.chooseFileButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button chooseFileButton;
        private System.Windows.Forms.Button cleanFileButton;
        private System.Windows.Forms.Label sourceLabel;
        private System.Windows.Forms.Label acceptedLabel;
        private System.Windows.Forms.Label configLabel;
        private System.Windows.Forms.Label GenericContentLabel;
        private System.Windows.Forms.Label label1;
    }
}

