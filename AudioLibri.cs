using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplibri
{
  public  class AudioLibri:Libri
    {
        public double Durata { get; set; }

        public AudioLibri(string titolo, string autore, int isbn, double durata)
            : base( titolo, autore, isbn)
        {
            Durata = durata;
        }


    }
}
