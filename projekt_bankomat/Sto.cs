using System;
using System.Collections.Generic;
using System.Text;

namespace projekt_bankomat
{
    class Sto:Pieniadze_strategia
    {

        public int Pieniadzenakocie(int stan)
        {

            return stan - 50;
        }

        public string Menupieniedzy(int stan)
        {
            string tekst;
            if (stan < 100)
            {
                tekst = "Masz za mało pieniędzy na koncie";
            }
            else
            {
                tekst = "Wypłacam";
            }
            return tekst;

        }

        public bool Czymampieniadze(int stan)
        {
            if (stan < 100)
                return false;
            return true;
        }
    }
}
