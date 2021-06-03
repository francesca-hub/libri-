using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplibri
{
  public  class LibriCartacei: Libri
    {
        public int NumPag { get; set; }
        public int Quantita { get; set; }

        public LibriCartacei(string titolo, string autore, int isbn, int numpag, int quantita)
            : base( titolo, autore, isbn)
        {
            NumPag = numpag;
            Quantita = quantita;
        }


    }
}
