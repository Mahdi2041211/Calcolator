using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calcolator
{
    internal abstract class Element
    {
        int index;
        string str;
        public int Index { get { return index; } set { index = value; } }

        public string Str { get => str; set => str = value; }
    }
}
