using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventar
{
    class Spotreba : AItem
    {
        public int hp;
        public Spotreba(string name, int x, int y, int sirka, int vyska, int hp) : base(name, x, y, sirka, vyska) { }
    }
}
