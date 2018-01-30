using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventar
{
    class Zbran : AItem
    {
        public int dmg;
        public Zbran(string name, int x, int y, int sirka, int vyska, int dmg) : base(name, x, y, sirka, vyska) { }
    }
}
