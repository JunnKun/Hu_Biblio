using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hu_ProgettoBiblio
{
    static class Program
    {
        public static List<Libro> BookList = new List<Libro>();
        public static List<Utente> UserList = new List<Utente>();
        public static List<Prestiti> LoansList = new List<Prestiti>();
        public static List<Blocco> BlockList = new List<Blocco>();

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
