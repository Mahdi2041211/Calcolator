using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Calcolator
{
    internal class Equation
    {
        public Equation() 
        {
            for (int i = 0; i < 3; i++)
                Priority[i] = new int[0];
        }
        Equation(Equation eq) : this()
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < eq.Priority[i].Length; j++)
                    AddPriority(eq.Priority[i][j], i);
            for (int i = 0; i < eq.Elements.Length; i++)
            {
                Add(eq.Elements[i], i);
                Elements[i].Index = i;
            }
        }

        int[][] priority = new int[3][];
        Element[]Element = new Element[0];
        int[] indexer = new int[0];

        public int[][] Priority { get => priority; set => priority = value; }
        public int[] Indexer { get => indexer; set => indexer = value; }
        internal Element[] Elements { get => Element; set => Element = value; }
    
        public void Add(Element element, int index)
        {
            Element[] New = new Element[Elements.Length + 1];
            for (int i = 0, j = 0; i < New.Length;)
            {
                if (i == index)
                {
                    New[i] = element;
                    i++;
                    continue;
                }
                New[i] = Elements[j];
                i++; j++;
            }
            Elements = New;
            for (int i = index + 1; i < Elements.Length; i++)
                Elements[i].Index += 1;
        }
        public void Add(int index)
        {
            int[] New = new int[Indexer.Length + 1];
            for(int i = 0, j = 0; i < New.Length;)
            {
                if (i == index)
                {
                    i++;
                    continue;
                }
                New[i++] = Indexer[j++];
            }
            Indexer = New;
        }
        public void Add(int index, int loc)
        {
            Add(index);
            Indexer[index] = loc;
        }
        public void RemoveIndex(int index)
        {
            int[] New = new int[Indexer.Length - 1];
            for (int i = 0, j = 0; i < Indexer.Length;)
            {
                if (i == index)
                {
                    i++;
                    continue;
                }
                New[j++] = Indexer[i++];
                if (i > index)
                    New[j - 1]--;
            }
            Indexer = New;
        }
        public void NewIndex(int index)
        {
            for(int i = index + 1; i < Indexer.Length; i++)
            {
                Indexer[i] += 1;
            }
        }
        public void AddPriority(int index, int ThePriority)
        {
            int[] New = new int[Priority[ThePriority].Length + 1];
            for (int i = 0; i < Priority[ThePriority].Length; i++)
                New[i] = Priority[ThePriority][i];
            New[Priority[ThePriority].Length] = index;
            Priority[ThePriority] = New;
        }
        public void RemovePriority(int index, int ThePriority)
        {
            int[] New = new int[Priority[ThePriority].Length - 1];
            for (int i = 0, j = 0; i < Priority[ThePriority].Length;)
            {
                if (Priority[ThePriority][i] == index)
                {
                    i++;
                    continue;
                }
                New[j++] = Priority[ThePriority][i++];
            }
            Priority[ThePriority] = New;
        }
        public void ReplacePriority(int index, int NewPriority, int LastPriority)
        {
            RemovePriority(index, LastPriority);
            AddPriority(index, NewPriority);
        }
        public void RemoveElement(int index)
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < Priority[i].Length; j++)
                    if (Priority[i][j] == index)
                        RemovePriority(Indexer[index], i);
            Element[] New = new Element[Element.Length - 1];
            for (int i = 0, j = 0; i < Elements.Length;)
            {
                if (i == Indexer[index])
                {
                    i++;
                    continue;
                }
                New[j++] = Elements[i++];
            }
            Elements = New;
            for (int i = index; i < Indexer.Length; i++)
                Indexer[i] -= 1;
        }
        void RemoveToClc(int index)
        {
            Element[] New = new Element[Elements.Length - 2];
            for (int i = 0, j = 0; i < Element.Length;)
            {
                if (i == index || i == index + 1)
                {
                    i++;
                    continue;
                }
                New[j++] = Elements[i++];
                if (i > index)
                    New[j - 1].Index -= 2;
            }
            Elements = New;
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < Priority[i].Length; j++)
                    if (Priority[i][j] > index)
                        Priority[i][j] -= 2;
        }
        public void Clc()
        {
            if (Elements[Elements.Length - 1] is Operator)
                MessageBox.Show("لقد استخدمت تنسيقا خاطئا", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (
                Elements[Elements.Length - 1].Str == "+" ||
                Elements[Elements.Length - 1].Str == "-")
                MessageBox.Show("لقد استخدمت تنسيقا خاطئا", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            else
            {
                Equation eq = new Equation(this);
                for (int i = 0; i < 3; i++)
                    for (int j = 0; j < eq.Priority[i].Length; j++)
                    {
                        Operator op = eq.Elements[eq.Priority[i][j]] as Operator;
                        Number n1 = eq.Elements[eq.Priority[i][j] - 1] as Number;
                        Number n2 = eq.Elements[eq.Priority[i][j] + 1] as Number;
                        switch (op.Str)
                        {
                            case "+":
                                eq.Elements[eq.Priority[i][j] - 1] = n1 + n2;
                                break;
                            case "-":
                                eq.Elements[eq.Priority[i][j] - 1] = n1 - n2;
                                break;
                            case "*":
                                eq.Elements[eq.Priority[i][j] - 1] = n1 * n2;
                                break;
                            case "/":
                                eq.Elements[eq.Priority[i][j] - 1] = n1 / n2;
                                break;
                            case "^":
                                eq.Elements[eq.Priority[i][j] - 1] = n1 ^ n2;
                                break;
                        }
                        eq.RemoveToClc(op.Index);
                    }
                ClearPriority();
                Indexer = new int[0];
                for (int i = 0; i < Elements[0].Str.Length; i++)
                    Add(0, 0);
                Elements = eq.Elements;
            }
        }
        void ClearPriority()
        {
            Priority[0] = new int[0];
            Priority[1] = new int[0];
            Priority[2] = new int[0];
        }
    }
}
