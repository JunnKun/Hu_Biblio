using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Hu_ProgettoBiblio
{  
    public partial class bibliotecario : Form
    {
        Library library = new Library();
        private bool isCollapsed;
        private int choose = 0;
        public bibliotecario()
        {
            InitializeComponent();
        }

        private void bibliotecario_Load(object sender, EventArgs e)
        {
            listView2.Hide();
            panel2.Show();
            panel4.Hide();
            panel5.Hide();
            panel6.Hide();
            panel7.Hide();
            library.BookLoad("../../Gestione/archivio.json");
            library.LoansLoad("../../Gestione/prestiti.json");
        }

        private void bibliotecario_FormClosing(object sender, FormClosingEventArgs e)
        {
            library.BookSave("../../Gestione/archivio.json");
        }

        private void GestioneLibri_MouseHover(object sender, EventArgs e)
        {
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isCollapsed)
            {
                GestioneLibri.Image = global::Hu_ProgettoBiblio.Properties.Resources.collapse_arrow__1_;
                panel1.Height += 10;
                if (panel1.Size == panel1.MaximumSize)
                {
                    timer1.Stop();
                    isCollapsed = false;
                }
            }
            else
            {
                GestioneLibri.Image = global::Hu_ProgettoBiblio.Properties.Resources.expand_arrow__1_;
                panel1.Height -= 10;
                if (panel1.Size == panel1.MinimumSize)
                {
                    timer1.Stop();
                    isCollapsed = true;
                }
            }
        }

        private void GestioneLibri_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Library bibliotecario = new Library(utenteText.Text, passwordText.Text);
            if (library.login(bibliotecario))
            {
                flowLayoutPanel1.Visible = true;
                listView1.Visible = true;
                listView2.Hide();
                panel2.Hide();
                panel4.Hide();
                panel6.Hide();
                panel5.Show();
                panel7.Hide();
                library.BookLoad("../../Gestione/archivio.json");
                BookLoader();
            }
            else
            {
                MessageBox.Show("Password / Nome utente errato");
            }
        }
        private void RimuoviLibro_Click(object sender, EventArgs e)
        {
            choose = 1;
            numericUpDown1.Hide();
            listView2.Hide();
            panel2.Hide();
            panel4.Hide();
            panel5.Hide();
            panel6.Show();
            panel7.Hide();
            prezzoButton.Hide();
            RimuoviButton.Show();
            listView1.Show();
            BookLoader();
        }
        private void AggiungiLibro_Click(object sender, EventArgs e)
        {
            choose = 2;
            listView2.Hide();
            panel2.Hide();
            panel6.Hide();
            panel5.Hide();
            panel7.Hide();
            panel4.Show();
            listView1.Show();
            BookLoader();
        }
        private void AggiornaPrezzo_Click(object sender, EventArgs e)
        {
            choose = 3;
            numericUpDown1.Show();
            listView2.Hide();
            panel2.Hide();
            panel4.Hide();
            panel5.Hide();
            panel7.Hide();
            RimuoviButton.Hide();
            panel6.Show();
            prezzoButton.Show();
            listView1.Show();
            BookLoader();
        }

        private void GestionePrestiti_Click(object sender, EventArgs e)
        {
            listView2.Show();
            panel2.Hide();
            panel4.Hide();
            panel5.Hide();
            panel7.Hide();
            RimuoviButton.Hide();
            panel6.Hide();
            prezzoButton.Hide();
            listView1.Hide();
        }

        private void BookLoader()
        {
            listView1.Items.Clear();
            foreach (Libro libro in Program.BookList)
            {
                string[] all = { libro.TitoloAutore, libro.casaEditrice, libro.genere, libro.id, libro.nCopie.ToString(), libro.prezzo.ToString() };
                listView1.Items.Add(new ListViewItem(all));
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (check())
            {
                Libro book = new Libro(titleText.Text, csText.Text, genreText.Text, isbnText.Text, Convert.ToInt32(cText.Text), Convert.ToDouble(prezzoValue.Value));
                Program.BookList.Add(book);
                BookLoader();
                // library.BookSave("../../Gestione/archivio.json");
                clear();
                MessageBox.Show("Libro Inserito");
            }
            else
            {
                MessageBox.Show("Compilare tutti i campi");
            }
        }
        private void clear()
        {
            titleText.Clear();
            csText.Clear();
            isbnText.Clear();
            genreText.Clear();
            cText.Clear();
            deleteBook.Clear();
            prezzoValue.Value = 0;
        }

        private bool check()
        {
            if (string.IsNullOrEmpty(titleText.Text) || string.IsNullOrEmpty(csText.Text) || string.IsNullOrEmpty(isbnText.Text) || string.IsNullOrEmpty(genreText.Text) || string.IsNullOrEmpty(cText.Text) || string.IsNullOrEmpty(prezzoValue.Text)) return false;
            else return true;
        }

        private void RimuoviButton_Click(object sender, EventArgs e)
        {
            rimozione();
            BookLoader();
            clear();
        }

        public void rimozione()
        {
            foreach (Libro libro in Program.BookList)
            {
                if (deleteBook.Text.Equals(libro.id))
                {
                    Program.BookList.Remove(libro);
                    MessageBox.Show("Rimozione libro avvenuto con successo");
                    return;
                }

            }
            MessageBox.Show("Libro non esistente");
        }

        private void AumentoCopie_Click(object sender, EventArgs e)
        {
            choose = 4;
            panel7.Show();
            listView2.Hide();
            panel2.Hide();
            panel4.Hide();
            panel5.Hide();
            RimuoviButton.Hide();
            panel6.Hide();
            listView1.Show();
            BookLoader();
        }

        private void AggiornaCopie_Click(object sender, EventArgs e)
        {
            copyupdate();
            BookLoader();
            clear();
        }

        private void copyupdate()
        {
            foreach (Libro libro in Program.BookList)
            {
                if (textBox1.Text.Equals(libro.id))
                {
                    libro.nCopie = Convert.ToInt32(numeriCopy.Value);
                    MessageBox.Show("Aggiornamento delle copie avvenuto con successo");
                    return;
                }
            }
            MessageBox.Show("Libro non esistente");
        }
        private void prezzoButton_Click(object sender, EventArgs e)
        {
            priceUpdate();
            BookLoader();
            clear();
        }

        private void priceUpdate()
        {
            foreach(Libro libro in Program.BookList)
            {
                if (deleteBook.Text.Equals(libro.id))
                {
                    libro.prezzo = Convert.ToDouble(numericUpDown1.Value);
                    MessageBox.Show("Aggiornamento del prezzo avvenuto con successo");
                    return;
                }
            }
            MessageBox.Show("Libro non esistente");
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (choose)
            {
                case 1:
                    if (listView1.SelectedItems.Count > 0)
                        deleteBook.Text = listView1.SelectedItems[0].SubItems[3].Text;
                    break;
                case 2:
                    // deleteBook.Text = listView1.SelectedItems[0].SubItems[3].Text;
                    break;
                case 3:
                    if (listView1.SelectedItems.Count > 0) {
                        numericUpDown1.Value = Convert.ToDecimal(listView1.SelectedItems[0].SubItems[5].Text);
                        deleteBook.Text = listView1.SelectedItems[0].SubItems[3].Text;
                    }
                    break;
                case 4:
                    if (listView1.SelectedItems.Count > 0)
                    {
                        numeriCopy.Value = Convert.ToInt32(listView1.SelectedItems[0].SubItems[4].Text);
                        textBox1.Text = listView1.SelectedItems[0].SubItems[3].Text;
                    }
                    break;
            }
        }
    }
}
