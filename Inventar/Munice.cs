using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventar
{
    class Munice : AItem
    {
        
        public string kalibr;
        public int pocet;
        public Munice(string name, int x, int y, int sirka, int vyska,string kalibr, int pocet) : base(name,x,y,sirka,vyska) { }
    }
}
