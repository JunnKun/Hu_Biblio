using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Hu_ProgettoBiblio
{
    class Libro
    {
        public string TitoloAutore { get; set; }
        public string casaEditrice { get; set; }
        public string genere { get; set; }
        public string id { get; set; }
        public int nCopie { get; set; }
        public bool disponibile { get; set; }
        public double prezzo { get; set; }

        public Libro()
        {
            TitoloAutore = "";
            casaEditrice = "";
            genere = "";
            id = "";
            nCopie = 1;
            disponibile = true;
            prezzo = 0;
        }
        public Libro(string _ta, string _cs, string _gn, string _id, int _cp, double _prz)
        {
            TitoloAutore = _ta;

            casaEditrice = _cs;

            genere = _gn;

            id = _id;

            if (nCopie > 0) nCopie = _cp;
            else nCopie = 1;

            if (nCopie > 0) disponibile = true;
            else disponibile = false;

            prezzo = _prz;
        }

    }

    class Blocco
    {
        public string email { get; set; }
        public DateTime dBlocco { get; set; }

        public Blocco(string _eml, DateTime _db)
        {
            email = _eml;
            dBlocco = _db;
        }
    }

    class Library
    {
        public string nameBiblio { get; set; }
        public string passwordBiblio { get; set; }

        public Library()
        {
            nameBiblio = "bibliotecario1234";
            passwordBiblio = "ciaomondo";
        }

        public Library(string _eb, string _psw)
        {
            nameBiblio = _eb;
            passwordBiblio = _psw;  
        }

        public bool login(Library library)
        {
            if (nameBiblio.Equals(library.nameBiblio) && passwordBiblio.Equals(library.passwordBiblio))
                return true;
            else
                return false;

        }

        public void BookLoad(string fileJson)
        {
            StreamReader sr = new StreamReader(fileJson);
            string rte = sr.ReadToEnd();
            Program.BookList = JsonConvert.DeserializeObject<List<Libro>>(rte);
            sr.Close();
        }

        public void BookSave(string fileJson)
        {
            StreamWriter sw = new StreamWriter(fileJson);
            string jsonConv = JsonConvert.SerializeObject(Program.BookList);
            sw.WriteLine(jsonConv);
            sw.Close();
        }

        public void BookControl()
        {
            foreach(Blocco block in Program.BlockList) 
            {
                if ((DateTime.Today - block.dBlocco).Days > 30)
                {
                    Program.BlockList.Remove(block);
                    break;
                }
            }

        }
        public void aggiornaDisponibilità(Libro libro)
        {
            if (libro.nCopie <= 0)
            {
                libro.disponibile = false;
            }
        }

        public void UserLoad(string fileJson)
        {
            StreamReader sr = new StreamReader(fileJson);
            string rte = sr.ReadToEnd();
            Program.UserList = JsonConvert.DeserializeObject<List<Utente>>(rte);
            sr.Close();
        }
        public void UserSave(string fileJson)
        {
            StreamWriter sw = new StreamWriter(fileJson);
            string jsonConv = JsonConvert.SerializeObject(Program.UserList);
            sw.WriteLine(jsonConv);
            sw.Close();
        }
        public void LoansLoad(string fileJson)
        {
            StreamReader sr = new StreamReader(fileJson);
            string rte = sr.ReadToEnd();
            Program.LoansList = JsonConvert.DeserializeObject<List<Prestiti>>(rte);
            sr.Close();
        }
        public void BlockLoad(string fileJson)
        {
            StreamReader sr = new StreamReader(fileJson);
            string rte = sr.ReadToEnd();
            Program.BlockList = JsonConvert.DeserializeObject<List<Blocco>>(rte);
            sr.Close();
        }

        public void BlockSave(string fileJson)
        {
            StreamWriter sw = new StreamWriter(fileJson);
            string jsonConv = JsonConvert.SerializeObject(Program.BlockList);
            sw.WriteLine(jsonConv);
            sw.Close();
        }
    }

    class Prestiti
    {
        public string idUtente { get; set; }
        public string idLibro { get; set; }
        public DateTime gPrestito { get; set; }
        public DateTime gReso { get; set; }

        public Prestiti(string _iu, string _il, DateTime _gp, DateTime _gr)
        {
            idUtente = _iu;
            idLibro = _il;
            gPrestito = _gp;
            gReso = _gr;
        }
    }

    class Utente
    {
        public string nome { get; set; }
        public string cognome { get; set; }
        public int ritardi { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string id { get; set; }

        public Utente()
        {
            nome = "";
            cognome = "";
            ritardi = 0;
            email = "";
            password = "";
            id = "";
        }
        public Utente(string _nm, string _cn, int _rt, string _eml, string _psw, string _id)
        {
            nome = _nm;
            cognome = _cn;
            ritardi = _rt;
            email = _eml;
            password = _psw;
            id = _id;
        }
        public Utente(string _nm, string _cn, string _eml, string _psw)
        {
            nome = _nm;
            cognome = _cn;
            ritardi = 0;
            email = _eml;
            password = _psw;
            id = generatoreID();
        }

        private string generatoreID()
        {
            Guid g = Guid.NewGuid();
            string GuidString = Convert.ToBase64String(g.ToByteArray());
            GuidString = GuidString.Replace("=", "");
            GuidString = GuidString.Replace("+", "");
            return GuidString;
        }

        public void bloccoUtente()
        {
            if(ritardi == 3)
            {

            }

        }
    }

}
