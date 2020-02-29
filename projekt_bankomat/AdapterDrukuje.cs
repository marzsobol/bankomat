using System;
using System.Collections.Generic;
using System.Text;

namespace projekt_bankomat
{
    public class AdapterDrukuje: Drukuje
    {
        private NieDrukuje niedruk = new NieDrukuje();
        public string Operacja(int kwota)
        {
            return niedruk.NieDrukuj(kwota);
        }
    }
}
