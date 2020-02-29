using System;
using System.Collections.Generic;
using System.Text;

namespace projekt_bankomat
{
    class Wyloguj: Strategia
    {
        public string Opcja()
        {
            string tekst = "Proszę wyciągnąć kartę.";
            return tekst;
        }
    }
}
