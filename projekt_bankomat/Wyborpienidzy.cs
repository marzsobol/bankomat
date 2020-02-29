using System;
using System.Collections.Generic;
using System.Text;

namespace projekt_bankomat
{
    class Wyborpienidzy
    {
        public int Pieniadz(Pieniadze_strategia pieniadze, int stan)
        {
            return pieniadze.Pieniadzenakocie(stan);
        }
        public string Pieniadztekst(Pieniadze_strategia pieniadze, int stan)
        {
            return pieniadze.Menupieniedzy(stan);
        }

        public bool PieniadzeCzySaNaKoncie(Pieniadze_strategia pieniadze, int stan)
        {
            return pieniadze.Czymampieniadze(stan);
        }
    }
}
