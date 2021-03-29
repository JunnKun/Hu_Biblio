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
        public bibliotecario()
        {
            InitializeComponent();
        }

        /*public void fillData()
        {
            listView1.Clear();
            listView1.Columns.Add("TitoloAutore", 250);
            listView1.Columns.Add("genere", 250);
            listView1.Columns.Add("casaEditrice", 250);
            listView1.Columns.Add("nCopie", 250);
            listView1.Columns.Add("Disponibilità", 250);
            listView1.Columns.Add("TitoloAutore", 250);
            listView1.Columns.Add("TitoloAutore", 250);
        }*/

        private void bibliotecario_Load(object sender, EventArgs e)
        {
            /*Libro book = new Libro()
            {
                TitoloAutore = "George Orwell 1984",
                casaEditrice = "HarperCollins",
                genere = "Romanzo",
                nCopie = 10,
                disponibile = true
            };

            string strResultJson = JsonConvert.SerializeObject(book);
            File.WriteAllText(@"archivio.json", strResultJson);*/

            
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
        private void Opzioni_MouseHover(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            panel1.Height += 10;
            if (panel1.Size == panel1.MaximumSize)
            {
                timer1.Stop();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            panel1.Height -= 10;
            if (panel1.Size == panel1.MinimumSize)
            {
                timer2.Stop();
            }
        }

        private void Opzioni_Click(object sender, EventArgs e)
        {
            timer2.Start();
        }
    }
}
