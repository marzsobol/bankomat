using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
//using System.Threading.Tasks;

namespace projekt_bankomat
{
    class Karta
    {
        private string PIN;
        private string numerkarty;
        private bool blokada;
        private int kwotanakoncie;



        public Karta(string PIN, string numerkarty, int kwotanakoncie)
        {
            this.PIN = PIN;
            this.numerkarty = numerkarty;
            this.blokada = false;
            this.kwotanakoncie = kwotanakoncie;

        }

        ~Karta()
        {
        }

        public bool Czydobrynumerkarty(string _numerkarty)
        {
            if (_numerkarty == numerkarty)
                return true;
            return false;
        }

        public bool CzydobrynumerPinu(string _PIN)
        {
            for (int i = 0; i < 4; i++)
            {
                if (_PIN == PIN)
                    return true;

            }
            return false;
        }

        public void Kartazablokowana()
        {
            blokada = true;
        }

        public bool Czykartazablokowana()
        {
            if (blokada == true)
                return true;
            return false;
        }

        public string Wyswietlnumer()
        {
            //cout << numerkarty << endl;
            return numerkarty;

        }

        public int pieniadzenakoncie()
        {

            return kwotanakoncie;
        }

        public int wybraniepieniedzy(int kwota)
        {
            kwotanakoncie = kwotanakoncie - kwota;
            return kwotanakoncie;
        }


    }
}
