using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Calcolator
{
    internal class Number : Element
    {
        public Number() { }
        public Number(int index) { Index = index; }
        public Number(char ch) { Str += ch; }
        public Number(char ch, int index) : this(index) {  Str += ch; }
        public Number(string ch)
        {
            Str = ch;
            StrToNum();
        }
        public Number(string ch, int index) : this(ch)
        {
            Index = index;
        }

        public double Num { get; set; }
        public void StrToNum()
        {
            Num = Convert.ToDouble(Str);
            if (Num == Convert.ToInt64(Num))
                Num = Convert.ToInt64(Num);
        }
        public void NumToStr()
        {
            Str = Convert.ToString(Num);
        }
        public void Replace(string op)
        {
            if (Str == "")
                Str = op;
            else if (Str[0] == '+' || Str[0] == '-')
            {
                string s = op;
                for (int i = 1; i < Str.Length; i++)
                    s += Str[i];
                Str = s;
            }
            else
                Str = op + Str;
            StrToNum();
        }
        public void Insert(string txt, int index)
        {
            string s = "";
            for (int i = 0; i < Str.Length + 1; i++)
            {
                if (i == index)
                    s += txt;
                try { s += Str[i]; }
                catch { }
            }
            Str = s;
            StrToNum();
        }
        public void Remove(int index)
        {
            string s = "";
            for(int i = 0; i < Str.Length;)
            {
                if (i == index)
                {
                    i++;
                    continue;
                }
                s += Str[i++]; 
            }
            Str = s;
        }
        public bool Comed()
        {
            if (Str.Contains('.'))
                return true;
            else return false;
        }

        public static Number operator +(Number n1, Number n2)
        {
            n1.Num += n2.Num;
            n1.NumToStr();
            return n1;
        }
        public static Number operator -(Number n1, Number n2)
        {
            n1.Num -= n2.Num;
            n1.NumToStr();
            return n1;
        }
        public static Number operator *(Number n1, Number n2)
        {
            n1.Num *= n2.Num;
            n1.NumToStr();
            return n1;
        }
        public static Number operator /(Number n1, Number n2)
        {
            n1.Num /= n2.Num;
            n1.NumToStr();
            return n1;
        }
        public static Number operator ^(Number n1, Number n2)
        {
            n1.Num = Math.Pow(n1.Num, n2.Num);
            n1.NumToStr();
            return n1;
        }
        public static Number operator +(Number n, string s)
        {
            n.Str += s;
            n.StrToNum();
            return n;
        }
        public static bool operator ==(Number n, double d)
        {
            if (n.Num == d) return true;
            return false;
        }
        public static bool operator !=(Number n, double d)
        {
            if (n.Num != d) return true;
            return false;
        }
        public static bool operator >=(Number n, double d)
        {
            if (n.Num >= d) return true;
            return false;
        }
        public static bool operator <=(Number n, double d)
        {
            if (n.Num <= d) return true;
            return false;
        }
    }
}
