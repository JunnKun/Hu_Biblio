
namespace Hu_ProgettoBiblio
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
            this.label1 = new System.Windows.Forms.Label();
            this.UserButton = new System.Windows.Forms.Button();
            this.LibraryButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Broadway", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(299, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(199, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "BIBLIOTECA";
            // 
            // UserButton
            // 
            this.UserButton.BackColor = System.Drawing.SystemColors.Control;
            this.UserButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UserButton.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.UserButton.Location = new System.Drawing.Point(418, 148);
            this.UserButton.Name = "UserButton";
            this.UserButton.Size = new System.Drawing.Size(141, 115);
            this.UserButton.TabIndex = 2;
            this.UserButton.Text = "ACCESSO UTENTE";
            this.UserButton.UseVisualStyleBackColor = false;
            this.UserButton.Click += new System.EventHandler(this.UserButton_Click);
            this.UserButton.MouseLeave += new System.EventHandler(this.UserButton_MouseLeave);
            this.UserButton.MouseHover += new System.EventHandler(this.UserButton_MouseHover);
            // 
            // LibraryButton
            // 
            this.LibraryButton.BackColor = System.Drawing.SystemColors.Control;
            this.LibraryButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LibraryButton.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.LibraryButton.Location = new System.Drawing.Point(235, 148);
            this.LibraryButton.Name = "LibraryButton";
            this.LibraryButton.Size = new System.Drawing.Size(141, 115);
            this.LibraryButton.TabIndex = 3;
            this.LibraryButton.Text = "ACCESSO RISERVATO";
            this.LibraryButton.UseVisualStyleBackColor = false;
            this.LibraryButton.Click += new System.EventHandler(this.LibraryButton_Click);
            this.LibraryButton.MouseLeave += new System.EventHandler(this.LibraryButton_MouseLeave);
            this.LibraryButton.MouseHover += new System.EventHandler(this.LibraryButton_MouseHover);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(817, 427);
            this.Controls.Add(this.LibraryButton);
            this.Controls.Add(this.UserButton);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button UserButton;
        private System.Windows.Forms.Button LibraryButton;
    }
}

