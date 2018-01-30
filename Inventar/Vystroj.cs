using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventar
{
    class Vystroj : AItem
    {
        public int armor;
        public Vystroj(string name, int x, int y, int sirka, int vyska, int armor) : base(name, x, y, sirka, vyska) { }

    }
}
