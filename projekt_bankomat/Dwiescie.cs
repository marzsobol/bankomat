using System;
using System.Collections.Generic;
using System.Text;

namespace projekt_bankomat
{
    public class Dwiescie:Pieniadze_strategia
    {
        public int Pieniadzenakocie(int stan)
        {
             return stan - 200;
        }

        public string Menupieniedzy(int stan)
        {
            string tekst;
            if (stan < 200)
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
            if (stan < 200)
                return false;
            return true;
        }
    }
}
