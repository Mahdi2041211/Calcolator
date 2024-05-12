using System;
using System.Net.Http.Headers;
using System.Reflection;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.LinkLabel;

namespace Calcolator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            list.Items.AddRange(File.ReadAllLines(Mem));
        }
        Equation Equations = new Equation();
        string memory = @"d:\Desktop\Calcolator\memory.txt";
        public string Mem { get { return memory; } }

        void Replace(Number number, string op, int index)
        {
            if (number.Str[0] == '+' || number.Str[0] == '-')
            {
                Remove(number.Index, 1);
                index--;
            }
            number.Replace(op);
            Insert(op, index);
            Equations.Add(index, Equations.Indexer[number.Index]);
            screen.SelectionStart = index + 1;
        }
        void Replace(Operator op, string txt)
        {
            int last = op.GetPrioruty();
            op.Str = txt;
            Equations.ReplacePriority(Equations.Indexer[op.Index], op.GetPrioruty(), last);
            Equations.Add(op.Index, Equations.Indexer[op.Index]);
            Remove(op.Index, 1);
            Insert(txt, op.Index);
        }
        void Insert(string txt, int index)
        {
            string s = "";
            for (int i = 0; i < screen.Text.Length + 1; i++)
            {
                if (i == index)
                    s += txt;
                try { s += screen.Text[i]; }
                catch { }
            }
            screen.Text = s;
        }
        void Remove(int index, int count)
        {
            string s = "";
            for (int i = 0; i < screen.Text.Length; i++)
            {
                if (i >= index && i < index + count)
                    continue;
                s += screen.Text[i];
            }
            screen.Text = s;
            for (int i = 0; i < count; i++)
                Equations.RemoveIndex(index);
        }
        void Add(Element element, int index, int loc)
        {
            Equations.Add(element, loc);
            Equations.Add(index, loc);
            Equations.NewIndex(index);
        }
        private void ClickNum(object sender, EventArgs e)
        {
            int index = screen.SelectionStart;
            screen.Focus();
            Button btn = (Button)sender;
            if (index == 0)
            {
                if (screen.Text == "")
                {
                    Number number = new Number(btn.Text, 0);
                    Add(number, 0, 0);
                    Insert(btn.Text, 0);
                    screen.SelectionStart = index + 1;
                }
                else
                {
                    Number number = Equations.Elements[0] as Number;
                    number.Insert(btn.Text, 0);
                    Equations.Add(0, 0);
                    Insert(btn.Text, 0);
                    screen.SelectionStart = 1;
                }
            }
            else if (index == screen.Text.Length)
            {
                if (Equations.Elements[Equations.Elements.Length - 1] is Operator)
                {
                    Number number = new Number(btn.Text, index);
                    Add(number, index, Equations.Elements.Length);
                    Insert(btn.Text, index);
                    screen.SelectionStart = index + 1;
                }
                else
                {
                    Number number = Equations.Elements[Equations.Elements.Length - 1] as Number;
                    number.Str += btn.Text;
                    number.StrToNum();
                    Equations.Add(index, Equations.Elements.Length - 1);
                    Insert(btn.Text, index);
                    screen.SelectionStart = index + 1;
                }
            }
            else
            {
                if (Equations.Elements[Equations.Indexer[index - 1]] is Operator)
                {
                    Number number = Equations.Elements[Equations.Indexer[index]] as Number;
                    number.Str = btn.Text + number.Str;
                    number.StrToNum();
                    Insert(btn.Text, index);
                    Equations.Add(index, Equations.Indexer[number.Index]);
                    screen.SelectionStart = index + 1;
                }
                else
                {
                    Number number = Equations.Elements[Equations.Indexer[index - 1]] as Number;
                    number.Insert(btn.Text, index - number.Index);
                    Insert(btn.Text, index);
                    Equations.Add(index, Equations.Indexer[number.Index]);
                    screen.SelectionStart = index + 1;
                }
            }
        }
        private void ClickOp(object sender, EventArgs e)
        {
            screen.Focus();
            int index = screen.SelectionStart;
            Button btn = (Button)sender;
            if (index == 0)
            {
                if (btn.Text == "+" || btn.Text == "-")
                {
                    if (screen.Text == "")
                    {
                        Number number = new Number(0);
                        number.Str = btn.Text;
                        Add(number, 0, 0);
                        Insert(btn.Text, 0);
                        screen.SelectionStart = 1;
                    }
                    else
                    {
                        Number number = Equations.Elements[0] as Number;
                        if (number.Str[0] == '+' || number.Str[0] == '-')
                            Replace(number, btn.Text, 1);
                        else Replace(number, btn.Text, 0);
                    }
                }
                else MessageBox.Show("áÇ íãßäß ÇáÈÏÁ ÈÝÇÕáÉ Ãæ ÚãáíÉ ÛíÑ ÇáÌãÚ Ãæ ÇáØÑÍ.", "ÎØÃ ÝÇÏÍ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (screen.Text.Length == index)
            {
                if (Equations.Elements[Equations.Elements.Length - 1] is Operator op)
                {
                    if ((op.Str != "+" || op.Str == "-") && btn.Text == "-")
                    {
                        Number number = new Number(index);
                        number.Str = btn.Text;
                        Add(number, index, Equations.Indexer[op.Index] + 1);
                        Insert(btn.Text, index);
                        screen.SelectionStart = index + 1;
                    }
                    else
                    {
                        Replace(op, btn.Text);
                        screen.SelectionStart = index;
                    }
                }
                else
                    Add(btn.Text, index, Equations.Indexer[index - 1] + 1);
            }
            else
            {
                if (Equations.Elements[Equations.Indexer[index - 1]] is Operator op)
                    if ((op.Str != "+" || op.Str == "-") && btn.Text == "-")
                    {
                        Number number = Equations.Elements[Equations.Indexer[index]] as Number;
                        if (number.Str[0] == '+' || number.Str[0] == '-')
                            Replace(number, btn.Text, index + 1);
                        else Replace(number, btn.Text, index);
                    }
                    else
                    {
                        Replace(op, btn.Text);
                        screen.SelectionStart = index;
                    }
                else
                {
                    Number number = Equations.Elements[Equations.Indexer[index - 1]] as Number;
                    if (Equations.Elements[Equations.Indexer[index]] is Operator ope)
                    {
                        Replace(ope, btn.Text);
                        screen.SelectionStart = index + 1;
                    }
                    else
                    {
                        if (screen.Text[index] == '.')
                            MessageBox.Show("áÞÏ ÇÓÊÎÏãÊ ÊäÓíÞÇ ÎÇØÆÇ", "ÎØÃ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
                        {
                            string s1 = "", s2 = "";
                            for (int i = number.Index; i < number.Index + number.Str.Length; i++)
                            {
                                if (i < index)
                                    s1 += screen.Text[i];
                                else
                                {
                                    s2 += screen.Text[i];
                                    Equations.Indexer[i]++;
                                }
                            }
                            number.Str = s1;
                            number.StrToNum();
                            Number num = new Number(s2, index);
                            Equations.Add(num, Equations.Indexer[num.Index]);
                            Add(btn.Text, index, Equations.Indexer[num.Index]);
                        }
                    }
                }
            }
        }
        void Add(string op, int index, int loc)
        {
            Operator Op = new Operator(op, index, Equations);
            Add(Op, index, loc);
            Equations.AddPriority(loc, Op.GetPrioruty());
            Insert(op, index);
            screen.SelectionStart = index + 1;
        }
        private void clickClear(object sender, EventArgs e)
        {
            Equations = new Equation();
            screen.Text = "";
        }
        private void ClickComa(object sender, EventArgs e)
        {
            screen.Focus();
            int index = screen.SelectionStart;
            if (index == 0)
            {
                if (screen.Text == "")
                {
                    Number number = new Number("0.", 0);
                    Add(number, 0, 0);
                    Equations.Add(0, 0);
                    Insert("0.", 0);
                    screen.SelectionStart = 2;
                }
                else
                {
                    Number number = Equations.Elements[0] as Number;
                    if (number.Comed())
                        MessageBox.Show("áÇ íãßäß æÖÚ ÝÇÕáÊíä áÚÏÏ æÇÍÏ.", "ÎØÃ", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    else
                    {
                        Equations.Add(0, 0);
                        Equations.Add(0, 0);
                        Insert("0.", 0);
                        number.Insert("0.", 0);
                        screen.SelectionStart = 2;
                    }
                }
            }
            else if (index == screen.Text.Length)
            {
                if (Equations.Elements[Equations.Elements.Length - 1] is Operator)
                {
                    Number number = new Number("0.", index);
                    Add(number, index, Equations.Elements.Length);
                    Equations.Add(index, Equations.Elements.Length - 1);
                    Insert("0.", index);
                    screen.SelectionStart = screen.Text.Length;
                }
                else
                {
                    Number number = Equations.Elements[Equations.Elements.Length - 1] as Number;
                    if (number.Comed())
                        MessageBox.Show("áÇ íãßäß æÖÚ ÝÇÕáÊíä áÚÏÏ æÇÍÏ", "ÎØÃ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        number.Str += '.';
                        number.StrToNum();
                        Equations.Add(index, Equations.Elements.Length - 1);
                        Insert(".", index);
                        screen.SelectionStart = index + 1;
                    }
                }
            }
            else
            {
                if (Equations.Elements[Equations.Indexer[index - 1]] is Operator)
                {
                    Number number = Equations.Elements[Equations.Indexer[index]] as Number;
                    if (number.Comed())
                        MessageBox.Show("áÇ íãßäß æÖÚ ÝÇÕáÊíä áÚÏÏ æÇÍÏ", "ÎØÃ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        number.Insert("0.", 0);
                        Equations.Add(index, Equations.Indexer[number.Index]);
                        Equations.Add(index, Equations.Indexer[number.Index]);
                        Insert("0.", index);
                        screen.SelectionStart = index + 2;
                    }
                }
                else
                {
                    Number number = Equations.Elements[Equations.Indexer[index - 1]] as Number;
                    if (number.Comed())
                        MessageBox.Show("áÇ íãßäß æÖÚ ÝÇÕáÊíä áÚÏÏ æÇÍÏ", "ÎØÃ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        Insert(".", index);
                        number.Insert(".", index - number.Index);
                        screen.SelectionStart = index + 1;
                    }
                }
            }
        }
        void Remove(int index)
        {
            for (int i = Equations.Indexer[index] + 1; i < Equations.Elements.Length; i++)
                Equations.Elements[i].Index--;
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < Equations.Priority[i].Length; j++)
                    if (Equations.Priority[i][j] > Equations.Indexer[index])
                        Equations.Priority[i][j]--;
            if (Equations.Elements[Equations.Indexer[index]].Str.Length <= 1)
                Equations.RemoveElement(index);
            Remove(index, 1);
        }
        private void ClickEqual(object sender, EventArgs e)
        {
            screen.Focus();
            try { Equations.Clc(); }
            catch (DivideByZeroException)
            {
                MessageBox.Show("áÇ íãßäß ÇáÞÓãÉ Úáì ÕÝÑ", "ÎØÃ ÝÇÏÍ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                screen.Text = "";
                Equations = new Equation();
            }
            if (Equations.Elements.Length == 1)
            {
                string data = screen.Text + "\n" + File.ReadAllText(Mem);
                File.WriteAllText(Mem, data);
                list.Items.AddRange(File.ReadAllLines(Mem));
                screen.Text = Equations.Elements[0].Str;
                Equations.Elements[0].Index = 0;
                screen.SelectionStart = screen.Text.Length;
            }
        }

        private void KeyPress(object sender, KeyPressEventArgs e)
        {
            char pressed = e.KeyChar;
            if (char.IsDigit(e.KeyChar) || e.KeyChar == '+' || e.KeyChar == '-' ||
                e.KeyChar == '*' || e.KeyChar == '/' || e.KeyChar == '^' ||
                e.KeyChar == '.' || e.KeyChar == 'c' || e.KeyChar == '=')
            {
                e.Handled = false;
            }
            else
                e.Handled = true;

            if (!e.Handled)
            {
                if (char.IsDigit(pressed))
                {
                    Button btn = new Button();
                    btn.Text = pressed.ToString();
                    ClickNum(btn, e);
                }
                else if (e.KeyChar == '+' || e.KeyChar == '-' ||
                e.KeyChar == '*' || e.KeyChar == '/' || e.KeyChar == '^')
                {
                    Button btn = new Button();
                    btn.Text = pressed.ToString();
                    ClickOp(btn, e);
                }
                else if (pressed == '.')
                    ClickComa(sender, e);
                else if (pressed == 'c')
                    clickClear(sender, e);
                else if (pressed == '=')
                    ClickEqual(sender, e);
                e.Handled = true;
            }
        }

        private void clickList(object sender, EventArgs e)
        {
            string[] m = File.ReadAllLines(Mem);
            for (int i = 0; i < m.Length; i++)
            {
                list.Items.Add(m[i]);
            }
        }

        private void chose(object sender, EventArgs e)
        {
            clickClear(sender, e);
            string s = list.SelectedItem.ToString();
            for (int i = 0; i < s.Length; i++)
            {
                if (char.IsDigit(s[i]))
                {
                    Button btn = new Button();
                    btn.Text = s[i].ToString();
                    ClickNum(btn, e);
                }
                else if (s[i] == '.')
                    ClickComa(sender, e);
                else
                {
                    Button btn = new Button();
                    btn.Text = s[i].ToString();
                    ClickOp(btn, e);
                }
            }
        }
    }
}