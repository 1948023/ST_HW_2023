namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.ResultLabel = new System.Windows.Forms.Label();
            this.SimulateButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ResultLabel
            // 
            this.ResultLabel.AutoSize = true;
            this.ResultLabel.Location = new System.Drawing.Point(12, 20);
            this.ResultLabel.Name = "ResultLabel";
            this.ResultLabel.Size = new System.Drawing.Size(41, 16);
            this.ResultLabel.TabIndex = 0;
            this.ResultLabel.Text = "Label";
            this.ResultLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // SimulateButton
            // 
            this.SimulateButton.Location = new System.Drawing.Point(15, 49);
            this.SimulateButton.Name = "SimulateButton";
            this.SimulateButton.Size = new System.Drawing.Size(75, 23);
            this.SimulateButton.TabIndex = 1;
            this.SimulateButton.Text = "Button";
            this.SimulateButton.UseVisualStyleBackColor = true;
            this.SimulateButton.Click += new System.EventHandler(this.SimulateButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.SimulateButton);
            this.Controls.Add(this.ResultLabel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ResultLabel;
        private System.Windows.Forms.Button SimulateButton;
    }
}

