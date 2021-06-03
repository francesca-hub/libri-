using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplibri
{
  public abstract  class Libri //non fa niente ma costring e i figli ad implementare
    {
        public string Titolo { get; set; }
        public  string Autore { get; set; }
        public int ISBN { get; set; }

        public Libri(string titolo, string autore, int isbn)
        {
            Titolo = titolo;
            Autore = autore;
            ISBN = isbn;
        }


    }
}
