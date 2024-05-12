using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calcolator
{
    internal class Operator : Element
    {
        Equation equation;

        Equation Equations { get { return equation; } set { equation = value; } }

        public Operator(int index) { Index = index; }
        public Operator(Equation equation) {  Equations = equation; }
        public Operator(int index, Equation equation) : this(index) {  Equations = equation; }
        public Operator(string op) {  Str = op; }
        public Operator(string op, int index) : this(index) { Str = op; }
        public Operator(string op, int index, Equation equation) :this (op, index) {  Equations = equation; }


        public int GetPrioruty()
        {
            if (Str == "^")
                return 0;
            else if (Str == "*" || Str == "/")
                return 1;
            return 2;
        }
    }
}
