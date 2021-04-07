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
    public partial class User : Form
    {
        Library library = new Library();
        Utente utent = new Utente();
        private bool isCollapsed;
        public User()
        {
            InitializeComponent();
        }

        private void User_Load(object sender, EventArgs e)
        {
            panel6.Hide();
            listView2.Hide();
            panel1.Hide();
            panel4.Hide();
            panelPrenota.Hide();
            flowLayoutPanel1.Hide();
            library.UserLoad("../../Gestione/user.json");
            library.BookLoad("../../Gestione/archivio.json");
            library.LoansLoad("../../Gestione/prestiti.json");
            library.BlockLoad("../../Gestione/blocco.json");
            update();
        }

        private void update()
        {
            foreach (Libro libro in Program.BookList)
            {
                if (libro.nCopie > 0) libro.disponibile = true;
                else libro.disponibile = false;
            }
            library.BookSave("../../Gestione/archivio.json");
        }

        private void Info_Click(object sender, EventArgs e)
        {
            panel6.Hide();
            listView2.Hide();
            panelPrenota.Hide();
            panel1.Show();
            listView1.Hide();
            textBox1.Text = utent.nome;
            textBox2.Text = utent.cognome;
            textBox3.Text = utent.email;
            textBox4.Text = utent.ritardi.ToString();
        }

        private void Prenotazione_Click(object sender, EventArgs e)
        {

        }

        private void Rinnovo_Click(object sender, EventArgs e)
        {

        }

        private void registrazione_Click(object sender, EventArgs e)
        {
            panel2.Hide();
            panel4.Show();
        }
        private void registrazione_MouseHover(object sender, EventArgs e)
        {
            registrazione.ForeColor = System.Drawing.SystemColors.MenuHighlight;
        }
        private void registrazione_MouseLeave(object sender, EventArgs e)
        {
            registrazione.ForeColor = System.Drawing.SystemColors.ControlText;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (login()) 
            {
                BookLoader();
                idLoader();
                panel2.Hide();
                flowLayoutPanel1.Show();
            }
            else
            {
                MessageBox.Show("Accesso Negato");
            }
        }

        private bool login()
        {
            library.UserLoad("../../Gestione/user.json");
            foreach (Utente utente in Program.UserList)
            {
                if (emailText.Text.Equals(utente.email) && passwordText.Text.Equals(utente.password))
                {
                    utent.nome = utente.nome;
                    utent.cognome = utente.cognome;
                    utent.email = utente.email;
                    utent.ritardi = utente.ritardi;
                    utent.id = utente.id;

                    return true;
                }
            }
            return false;
        }

        private void idLoader()
        {
            foreach (Utente utente in Program.UserList)
            {
                if (emailText.Text.Equals(utente.email) && passwordText.Text.Equals(utente.password))
                {
                    label10.Text = utente.id;
                    return;
                }
            }
        }

        private void BookLoader()
        {
            listView1.Items.Clear();
            foreach (Libro libro in Program.BookList)
            {
                string[] all = { libro.TitoloAutore, libro.casaEditrice, libro.genere, libro.id, libro.prezzo.ToString(), libro.disponibile.ToString() };
                listView1.Items.Add(new ListViewItem(all));
            }
        }

        private void LoanLoader()
        {
            listView2.Items.Clear();
            foreach (Prestiti prestiti in Program.LoansList)
            {
                if (utent.id.Equals(prestiti.idUtente))
                {
                    if (prestiti.gReso == Convert.ToDateTime("01/01/2000")) 
                    { 
                        string[] all = { prestiti.idLibro, prestiti.gPrestito.ToString(), "" };
                        listView2.Items.Add(new ListViewItem(all));
                    }
                    else 
                    {
                        string[] all = { prestiti.idLibro, prestiti.gPrestito.ToString(), prestiti.gReso.ToString() };
                        listView2.Items.Add(new ListViewItem(all));
                    }
                }
            }
        }

        private void registrati_Click(object sender, EventArgs e)
        {
            if (check())
            {
                Utente utente = new Utente(nameText.Text, surnameText.Text, email.Text, pswText.Text);
                Program.UserList.Add(utente);
                library.UserSave("user.json");
                panel4.Hide();
                panel2.Show();
            }
            else
            {
                MessageBox.Show("Compila tutti i campi");
            }
        }

        private bool check()
        {
            if (string.IsNullOrEmpty(nameText.Text) || string.IsNullOrEmpty(surnameText.Text) || string.IsNullOrEmpty(email.Text) || string.IsNullOrEmpty(pswText.Text)) return false;
            else return true;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listView1.SelectedItems.Count > 0)
            {
                TitoloText.Text = listView1.SelectedItems[0].SubItems[0].Text;
                csText.Text = listView1.SelectedItems[0].SubItems[1].Text;
                isbnText.Text = listView1.SelectedItems[0].SubItems[3].Text;
            }
        }

        private void Prenotazione_Click_1(object sender, EventArgs e)
        {
            panel6.Hide();
            listView2.Hide();
            panelPrenota.Show();
            panel1.Hide();
            listView1.Show();
            timer1.Start();
            BookLoader();
        }

        private void Prenotati_Click(object sender, EventArgs e)
        {
            panel6.Show();
            listView2.Show();
            panelPrenota.Hide();
            panel1.Hide();
            listView1.Hide();
            LoanLoader();
        }

        private void prenota()
        {
            foreach (Libro libro in Program.BookList)
            {
                if(TitoloText.Text.Equals(libro.TitoloAutore) && csText.Text.Equals(libro.casaEditrice) && isbnText.Text.Equals(libro.id))
                {
                    if (libro.disponibile)
                    {
                        libro.nCopie--;
                        MessageBox.Show("prestito effettuato");
                        library.aggiornaDisponibilità(libro);
                        prenota2();
                        library.BookSave("../../Gestione/archivio.json");
                        return;
                    }
                }
            }
        }
        private void prenota2()
        {
            foreach (Libro libro in Program.BookList)
            {
                if (TitoloText.Text.Equals(libro.TitoloAutore) && csText.Text.Equals(libro.casaEditrice) && isbnText.Text.Equals(libro.id))
                {
                    Prestiti prestito = new Prestiti(utent.id, libro.id, DateTime.Now, Convert.ToDateTime("01/01/2000"));
                    Program.LoansList.Add(prestito);
                    library.LoansSave("../../Gestione/prestiti.json");
                    return;
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isCollapsed)
            {
                Prenotazione.Image = global::Hu_ProgettoBiblio.Properties.Resources.collapse_arrow__1_;
                panel5.Height += 10;
                if (panel5.Size == panel5.MaximumSize)
                {
                    timer1.Stop();
                    isCollapsed = false;
                }
            }
            else
            {
                Prenotazione.Image = global::Hu_ProgettoBiblio.Properties.Resources.expand_arrow__1_;
                panel5.Height -= 10;
                if (panel5.Size == panel5.MinimumSize)
                {
                    timer1.Stop();
                    isCollapsed = true;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            prenota();
            BookLoader();
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView2.SelectedItems.Count > 0)
                textBox5.Text = listView2.SelectedItems[0].SubItems[0].Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listView2.SelectedItems.Count > 0)
            {
                if (listView2.SelectedItems[0].SubItems[2].Text.Equals(""))
                {
                    foreach (Prestiti prestiti in Program.LoansList)
                    {
                        if (prestiti.idUtente.Equals(utent.id) && prestiti.idLibro.Equals(listView2.SelectedItems[0].SubItems[0].Text) && prestiti.gPrestito.ToString().Equals(listView2.SelectedItems[0].SubItems[1].Text) && prestiti.gReso == Convert.ToDateTime("01/01/2000"))
                        {
                            Libro libro = bookSearcher(prestiti.idLibro);
                            if(libro != null)
                            {
                                libro.nCopie++;
                                prestiti.gReso = DateTime.Now;
                                MessageBox.Show("Restituzione Libro avvenuto con successo");
                                library.DelaysControl();
                                library.LoansSave("../../Gestione/prestiti.json");
                                update();
                                BookLoader();
                                LoanLoader();
                            }
                            else
                            {
                                MessageBox.Show("Errore nella restituzione del libro");
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Libro già restituito in precedenza");
                }
            }
        }

        private Libro bookSearcher(string id)
        {
            foreach(Libro libro in Program.BookList)
            {
                if (id.Equals(libro.id))
                {
                    return libro;
                }
            }
            return null;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (listView2.SelectedItems.Count > 0)
            {
                if (listView2.SelectedItems[0].SubItems[2].Text.Equals(""))
                {
                    foreach (Prestiti prestiti in Program.LoansList)
                    {
                        if(prestiti.idUtente.Equals(utent.id) && prestiti.idLibro.Equals(listView2.SelectedItems[0].SubItems[0].Text) && prestiti.gPrestito.ToString().Equals(listView2.SelectedItems[0].SubItems[1].Text))
                        {
                            prestiti.gPrestito = DateTime.Now;
                            MessageBox.Show("Tempo prolungato ad oggi");
                            library.LoansSave("../../Gestione/prestiti.json");
                            LoanLoader();
                        }
                    }
                }
            }
        }
    }
}
