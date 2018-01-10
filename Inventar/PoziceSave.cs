using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileHelpers;


namespace Inventar
{
    [DelimitedRecord(",")]
    class PoziceSave
    {
        public int x;
        public int y;
        public string name;
    }
}
