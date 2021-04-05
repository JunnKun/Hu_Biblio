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
        public bibliotecario()
        {
            InitializeComponent();
        }

        private void bibliotecario_Load(object sender, EventArgs e)
        {
            panel2.Show();
            panel4.Hide();
            panel5.Hide();
            panel6.Hide();
            library.BookLoad("../../Gestione/archivio.json");

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
                panel2.Hide();
                panel4.Hide();
                panel6.Hide();
                panel5.Show();
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
            panel2.Hide();
            panel4.Hide();
            panel5.Hide();
            panel6.Show();
            prezzoButton.Hide();
            RimuoviButton.Show();
            listView1.Show();
            BookLoader();
        }
        private void AggiungiLibro_Click(object sender, EventArgs e)
        {
            panel2.Hide();
            panel6.Hide();
            panel5.Hide();
            panel4.Show();
            listView1.Show();
            BookLoader();
        }
        private void AggiornaPrezzo_Click(object sender, EventArgs e)
        {
            panel2.Hide();
            panel4.Hide();
            panel5.Hide();
            RimuoviButton.Hide();
            panel6.Show();
            prezzoButton.Show();
            listView1.Show();
            BookLoader();
        }

        private void GestionePrestiti_Click(object sender, EventArgs e)
        {
            
        }

        private void BookLoader()
        {
            listView1.Items.Clear();
            foreach (Libro libro in Program.BookList)
            {
                string[] all = { libro.TitoloAutore, libro.casaEditrice, libro.genere, libro.id, libro.nCopie.ToString(), libro.prezzo.ToString() };
                listView1.Items.Add(new ListViewItem(all));
                //listView2.Items.Add(new ListViewItem(all));
                //listView3.Items.Add(new ListViewItem(all));
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (check())
            {
                Libro book = new Libro(titleText.Text, csText.Text, isbnText.Text, genreText.Text, Convert.ToInt32(cText.Text), Convert.ToDouble(prezzoValue.Value));
                Program.BookList.Add(book);
                BookLoader();
                library.BookSave("../../Gestione/archivio.json");
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
    }
}
