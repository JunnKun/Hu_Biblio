
namespace Hu_ProgettoBiblio
{
    partial class bibliotecario
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.GestioneRitardi = new System.Windows.Forms.Button();
            this.GestionePrestiti = new System.Windows.Forms.Button();
            this.GestioneLibri = new System.Windows.Forms.Button();
            this.Opzioni = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.GestioneRitardi);
            this.panel1.Controls.Add(this.GestionePrestiti);
            this.panel1.Controls.Add(this.GestioneLibri);
            this.panel1.Controls.Add(this.Opzioni);
            this.panel1.Location = new System.Drawing.Point(25, 34);
            this.panel1.MaximumSize = new System.Drawing.Size(202, 285);
            this.panel1.MinimumSize = new System.Drawing.Size(202, 72);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(202, 72);
            this.panel1.TabIndex = 1;
            // 
            // GestioneRitardi
            // 
            this.GestioneRitardi.Location = new System.Drawing.Point(0, 213);
            this.GestioneRitardi.Name = "GestioneRitardi";
            this.GestioneRitardi.Size = new System.Drawing.Size(202, 72);
            this.GestioneRitardi.TabIndex = 4;
            this.GestioneRitardi.Text = "Gestione Ritardi";
            this.GestioneRitardi.UseVisualStyleBackColor = true;
            this.GestioneRitardi.Click += new System.EventHandler(this.button4_Click);
            // 
            // GestionePrestiti
            // 
            this.GestionePrestiti.Location = new System.Drawing.Point(0, 142);
            this.GestionePrestiti.Name = "GestionePrestiti";
            this.GestionePrestiti.Size = new System.Drawing.Size(202, 72);
            this.GestionePrestiti.TabIndex = 4;
            this.GestionePrestiti.Text = "Gestione Prestiti";
            this.GestionePrestiti.UseVisualStyleBackColor = true;
            // 
            // GestioneLibri
            // 
            this.GestioneLibri.Location = new System.Drawing.Point(0, 71);
            this.GestioneLibri.Name = "GestioneLibri";
            this.GestioneLibri.Size = new System.Drawing.Size(202, 72);
            this.GestioneLibri.TabIndex = 4;
            this.GestioneLibri.Text = "Gestione Libri";
            this.GestioneLibri.UseVisualStyleBackColor = true;
            // 
            // Opzioni
            // 
            this.Opzioni.Location = new System.Drawing.Point(0, 0);
            this.Opzioni.Name = "Opzioni";
            this.Opzioni.Size = new System.Drawing.Size(202, 72);
            this.Opzioni.TabIndex = 3;
            this.Opzioni.Text = "OPZIONI";
            this.Opzioni.UseVisualStyleBackColor = true;
            this.Opzioni.Click += new System.EventHandler(this.Opzioni_Click);
            this.Opzioni.MouseHover += new System.EventHandler(this.Opzioni_MouseHover);
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 10;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // bibliotecario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(817, 427);
            this.Controls.Add(this.panel1);
            this.Name = "bibliotecario";
            this.Text = "bibliotecario";
            this.Load += new System.EventHandler(this.bibliotecario_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button GestioneRitardi;
        private System.Windows.Forms.Button GestionePrestiti;
        private System.Windows.Forms.Button GestioneLibri;
        private System.Windows.Forms.Button Opzioni;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
    }
}