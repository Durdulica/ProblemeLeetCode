using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace probleme
{
    public class ProblemeSiruri
    {
        public bool Ex1(string s)
        {//se da un sir care contine caracterele '(', ')' , '{', '}', '[' si ']', sa se determine daca stringul are parantezele intr-o ordine corecta
            Stack<char> stack = new Stack<char>();
            s = s.Trim();

            if (s.Length < 2)
            {
                return false;
            }

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(' || s[i] == '[' || s[i] == '{')
                {
                    stack.Push(s[i]);
                }
                else
                {
                    char c = stack.Pop();
                    if (s[i] == ')')
                    {
                        if (c != '(')
                        {
                            return false;
                        }
                    }

                    if (s[i] == ']')
                    {
                        if (c != '[')
                        {
                            return false;
                        }
                    }

                    if (s[i] == '}')
                    {
                        if (c != '{')
                        {
                            return false;
                        }
                    }
                }
            }

            if (stack.Count == 0)
            {
                return true;
            }
            return false;
        }

        public int Ex2(string haystack, string needle)
        {   //se dau 2 siruri, sa se returneze indexul primei aparitii a sirului "needle" in sirul "haystack" sau -1 daca nu exista

            for (int i = 0; i < haystack.Length - needle.Length; i++)
            {

                while (i < haystack.Length - needle.Length && haystack[i + needle.Length] != needle[needle.Length])
                {
                    i++;
                }
                int j = 0;
                while (i + j < haystack.Length && j < needle.Length && haystack[i + j] == needle[j]) {
                    j++;
                }
                if (j == needle.Length)
                {
                    return i;
                }
                i += j;
            }

            return -1;
        }

        public int Ex3(string s)
        {   //se da un sir format din cuvinte si spatii, sa se returneze dimensiunea ultimului cuvant din sir
            string[] cuv = s.Split(' ');
            int index = cuv.Length - 1;
            while (cuv[index] == "")
            {
                index--;
            }
            return cuv[index].Length;
        }


    }
}
