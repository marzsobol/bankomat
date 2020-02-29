using System;
using System.Collections.Generic;
using System.Text;

namespace projekt_bankomat
{
   public class Wyplata:  Strategia
    {
        public string tekst;
        public string Opcja()
        {
            tekst = "Proszę wybrać ile pięniedzy\nchce Pan wypłacić";
            return tekst;
        }
    }
}
