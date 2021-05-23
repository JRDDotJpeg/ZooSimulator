namespace ZooSimulator.InterfaceLayer
{
    partial class MainDisplay
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
            this.FeedButton = new System.Windows.Forms.Button();
            this.DataDisplay = new System.Windows.Forms.Label();
            this.TimeDisplay = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // FeedButton
            // 
            this.FeedButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FeedButton.Location = new System.Drawing.Point(571, 264);
            this.FeedButton.Name = "FeedButton";
            this.FeedButton.Size = new System.Drawing.Size(205, 134);
            this.FeedButton.TabIndex = 0;
            this.FeedButton.Text = "Feed all animals";
            this.FeedButton.UseVisualStyleBackColor = true;
            this.FeedButton.Click += new System.EventHandler(this.FeedButton_Click);
            // 
            // DataDisplay
            // 
            this.DataDisplay.AutoSize = true;
            this.DataDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DataDisplay.Location = new System.Drawing.Point(96, 91);
            this.DataDisplay.Name = "DataDisplay";
            this.DataDisplay.Size = new System.Drawing.Size(145, 25);
            this.DataDisplay.TabIndex = 1;
            this.DataDisplay.Text = "Data goes here";
            // 
            // TimeDisplay
            // 
            this.TimeDisplay.AutoSize = true;
            this.TimeDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimeDisplay.Location = new System.Drawing.Point(96, 36);
            this.TimeDisplay.Name = "TimeDisplay";
            this.TimeDisplay.Size = new System.Drawing.Size(148, 25);
            this.TimeDisplay.TabIndex = 1;
            this.TimeDisplay.Text = "Time at the Zoo";
            // 
            // MainDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 637);
            this.Controls.Add(this.TimeDisplay);
            this.Controls.Add(this.DataDisplay);
            this.Controls.Add(this.FeedButton);
            this.Name = "MainDisplay";
            this.Text = "The Zoo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button FeedButton;
        private System.Windows.Forms.Label DataDisplay;
        private System.Windows.Forms.Label TimeDisplay;
    }
}

