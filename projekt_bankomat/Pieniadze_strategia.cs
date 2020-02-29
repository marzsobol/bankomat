using System;
using System.Collections.Generic;
using System.Text;

namespace projekt_bankomat
{
    interface Pieniadze_strategia
    {
        int Pieniadzenakocie(int stan);
        string Menupieniedzy(int stan);
        bool Czymampieniadze(int stan);
    }
}
