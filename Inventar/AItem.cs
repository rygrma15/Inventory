using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventar
{
    public abstract class AItem
    {
        public string name;
        public int x;
        public int y;
        public int sirka;
        public int vyska;

        protected AItem(string name,int x, int y, int sirka, int vyska)
        {

        }
    }
}
