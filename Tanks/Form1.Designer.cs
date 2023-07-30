namespace Tanks
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Player1Label = new System.Windows.Forms.Label();
            this.Player2Label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Player1Label
            // 
            this.Player1Label.AutoSize = true;
            this.Player1Label.Location = new System.Drawing.Point(814, 21);
            this.Player1Label.Name = "Player1Label";
            this.Player1Label.Size = new System.Drawing.Size(0, 22);
            this.Player1Label.TabIndex = 0;
            // 
            // Player2Label
            // 
            this.Player2Label.AutoSize = true;
            this.Player2Label.Location = new System.Drawing.Point(814, 320);
            this.Player2Label.Name = "Player2Label";
            this.Player2Label.Size = new System.Drawing.Size(0, 22);
            this.Player2Label.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1184, 600);
            this.Controls.Add(this.Player2Label);
            this.Controls.Add(this.Player1Label);
            this.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1200, 639);
            this.MinimumSize = new System.Drawing.Size(1200, 639);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "Tanks";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label Player1Label;
        private Label Player2Label;
    }
}