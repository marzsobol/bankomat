using System;
using System.Collections.Generic;
using System.Text;

namespace projekt_bankomat
{
    class Piecdziesiat:Pieniadze_strategia
    {

        public int Pieniadzenakocie(int stan)
        {
            return stan - 50;

        }

        public string Menupieniedzy(int stan)
        {
            string tekst;
            if(stan<50)
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
            if (stan < 50)
                return false;
            return true;
        }
    }
}
