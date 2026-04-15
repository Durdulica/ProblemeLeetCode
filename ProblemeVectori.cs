using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace probleme
{
    public class ProblemeVectori
    {
        public void Ex1()
        {
            //se da un vector de numere intregi si un numar target, sa se afiseze indicele celor doua numere din vector care adunate dau targetul
            //se presupune ca pentru oricare numere exista o singura solutie si nu se poate folosi acelasi element de doua ori
            int[] v = { 3, 3 };
            int target = 6;

            for (int i = 0; i < v.Length; i++)
            {
                for (int j = 1; j < v.Length; j++)
                {
                    if (v[i] + v[j] == target)
                    {
                        Console.WriteLine(i + " " + j);
                        return;
                    }
                }
            }
        }

        public void Ex2()
        {
            //se dau 2 vectori sortati crescator, sa se returneze media celor doi vectori, cu complexitatea O(log(n+m))
            int[] v1 = { 1, 2 };
            int[] v2 = { 3, 4 };
            int ind1 = 0, ind2 = 0;
            int totalLength = v1.Length + v2.Length;
            int current = 0, prev;
            if (totalLength % 2 == 0)
            {
                for (int k = 0; k < totalLength; k++)
                {
                    prev = current;
                    if (ind1 >= v1.Length)
                    {
                        current = v2[ind2++];
                    }
                    else if (ind2 >= v2.Length)
                    {
                        current = v1[ind1++];
                    }
                    else
                    {
                        if (v1[ind1] < v2[ind2])
                        {
                            current = v1[ind1++];
                        }
                        else
                        {
                            current = v2[ind2++];
                        }
                    }

                    if (k == totalLength / 2)
                    {
                        Console.WriteLine((double)(current + prev) / 2);
                        return;
                    }
                }
            }
            else
            {
                for (int k = 0; k < totalLength; k++)
                {
                    if (ind1 >= v1.Length)
                    {
                        current = v2[ind2++];
                    }
                    else if (ind2 >= v2.Length)
                    {
                        current = v1[ind1++];
                    }
                    else
                    {
                        if (v1[ind1] < v2[ind2])
                        {
                            current = v1[ind1++];
                        }
                        else
                        {
                            current = v2[ind2++];
                        }
                    }

                    if (k == totalLength / 2)
                    {
                        Console.WriteLine(current);
                        return;
                    }
                }
            }
        }

        public void Ex3()
        {
            //se da un string care trebuie transformat in int
            //se ignora spatiile si '0' de la inceputul sirului
            //semnul valorii int se determina verificand daca primul caracter nenul este '+' sau '-', si se considera pozitiv daca ambele semne lipsesc
            //daca nu s-a citit nicio cifra, rezultatul este 0
            string s;
            s = Console.ReadLine();
            s = s.Trim();
            int rez, dim = 0, semn = 1;
            if (s[dim] == '-')
            {
                semn = -1;
                dim++;
            }
            else if (s[dim] == '+')
            {
                dim++;
            }

            while (s[dim] == '0' && dim < s.Length)
            {
                dim++;
            }
            rez = 0;
            if (!char.IsDigit(s[dim]))
            {
                Console.WriteLine(rez);
                return;
            }

            int start = dim;
            while (char.IsDigit(s[dim]) && dim < s.Length - 1)
            {
                dim++;
            }
            for (int i = start; i <= dim; i++)
            {
                if (!char.IsDigit(s[i]))
                {
                    Console.WriteLine(rez * semn);
                    return;
                }
                rez = rez * 10 + (s[i] - '0');
                Console.WriteLine(rez);
            }

            Console.WriteLine(rez * semn);
        }

        public void Ex4()
        {
            //se da un numar, sa se verifice daca este palindrom sau nu
            //se poate rezolva problema fara sa se converteasca numarul in string?
            int x = Int32.Parse(Console.ReadLine());
            if (x < 0)
            {
                Console.WriteLine("False");
                return;
            }

            int o = 0, aux = x;
            while (aux != 0)
            {
                o = o * 10 + aux % 10;
                aux /= 10;
            }

            if (x == o)
            {
                Console.WriteLine("True");
            }
            else
            {
                Console.WriteLine("False");
            }
        }

        public void Ex5()
        {
            //se da un numar roman sub forma de string. Sa se transforme in int
            //se garanteaza ca inputul este un numar roman valid
            string s = Console.ReadLine();
            int rez = 0;
            for(int i  = 0; i < s.Length; i++)
            {
                if (s[i] == 'I')
                {
                    if (i + 1 < s.Length && s[i + 1] == 'V')
                    {
                        rez += 4;
                        i++;
                    }
                    else if(i + 1 < s.Length && s[i + 1] == 'X')
                    {
                        rez += 9;
                        i++;
                    }
                    else {
                        rez += 1;
                    }
                }

                else if (s[i] == 'V')
                {
                    rez += 5;
                }

                else if (s[i] == 'X')
                {
                    if (i + 1 < s.Length && s[i + 1] == 'L')
                    {
                        rez += 40;
                        i++;
                    }
                    else if(i + 1 < s.Length && s[i + 1] == 'C')
                    {
                        rez += 90;
                        i++;
                    }
                    else
                    {
                        rez += 10;
                    }
                }

                else if(s[i] == 'L')
                {
                    rez += 50;
                }

                else if (s[i] == 'C')
                {
                    if (i + 1 < s.Length && s[i + 1] == 'D')
                    {
                        rez += 400;
                        i++;
                    }
                    else if (i + 1 < s.Length && s[i + 1] == 'M')
                    {
                        rez += 900;
                        i++;
                    }
                    else
                    {
                        rez += 100;
                    }
                }

                else if (s[i] == 'D')
                {
                    rez += 500;
                }

                else if (s[i] == 'M')
                {
                    rez += 1000;
                }
            }

            Console.WriteLine(rez);
        }

        public void Ex6()
        {//se dau 2 liste sortate. Sa se combine listele intr-o singura lista sortata crescator
            List<int> list1 = new List<int>();
            list1.Capacity = 10;
            list1.Add(1); list1.Add(2); list1.Add(4);

            List<int> list2 = new List<int>();
            list2.Capacity = 10;
            list2.Add(1); list2.Add(3); list2.Add(4);

            List<int> result = new List<int>();
            result.Capacity = 20;

            int i = 0, j = 0;
            while (i < list1.Count && j < list2.Count)
            {
                if (list1[i] < list2[j])
                {
                    result.Add(list1[i++]);
                }
                else if (list1[i] > list2[j])
                {
                    result.Add(list2[j++]);
                }
                else
                {
                    result.Add(list1[i++]);
                    result.Add(list2[j++]);
                }
            }

            for (; i < list1.Count; i++)
            {
                result.Add(list1[i++]);
            }

            for (; j < list2.Count; j++)
            {
                result.Add(list2[j++]);
            }

            for (int k = 0; k < result.Count; k++) { 
                Console.Write(result[k] + " ");
            }
        }

        public int Ex7(int[] nums)
        {   //se da un vector sortat, sa se elimine toate dublurile a. i. fiecare element din vector sa fie unic si vectorul sa ramana in ordine cresc.
            //Dupa eliminarea dublurilor, sa se returneze numarul de elemente unice
            int index = 1;
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] != nums[i - 1])
                {
                    nums[index++] = nums[i];
                }
            }
            return index;
        }

        public int Ex8(int[] nums, int val)
        {   //se da un vector si o valoare, sa se elimine toate elementele egale cu acea valoare din vector si apoi sa se returneze dimensiunea vectorului
            int dim = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != val)
                {
                    nums[dim++] = nums[i];
                }
            }
            return dim;
        }

        public int Ex9(int[] nums, int target)
        {   //se da un vector sortat si o valoare, sa se returneze indexul la care este gasita valoarea sau indexul la care ar trebui pusa
            //in cazul in care valoarea nu se afla in vector

            int mij =-1, st = 0, dr = nums.Count() - 1;
            while (st < dr)
            {
                mij = (st + dr) / 2;
                if(nums[mij] < target) st = mij;
                if(nums[mij] > target) dr = mij;
            }

            return mij;
        }
    }
}
