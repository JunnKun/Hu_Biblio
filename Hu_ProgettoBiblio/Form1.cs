using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hu_ProgettoBiblio
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void LibraryButton_Click(object sender, EventArgs e)
        {
            bibliotecario biblio = new bibliotecario();
            biblio.ShowDialog();
        }

        private void LibraryButton_MouseHover(object sender, EventArgs e)
        {

            LibraryButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
        }

        private void LibraryButton_MouseLeave(object sender, EventArgs e)
        {

            LibraryButton.BackColor = System.Drawing.SystemColors.Control;
        }

        private void UserButton_Click(object sender, EventArgs e)
        {
            
        }

        private void UserButton_MouseHover(object sender, EventArgs e)
        {
            UserButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
        }

        private void UserButton_MouseLeave(object sender, EventArgs e)
        {
            UserButton.BackColor = System.Drawing.SystemColors.Control;
        }
    }
}
