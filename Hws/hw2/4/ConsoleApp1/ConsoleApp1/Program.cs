using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n =int.Parse(Console.ReadLine());
            int p = 0;
            List<int> l = new List<int>();
            int sh = 1;
            do
            {
                l.Add(sh);
                p++;
                n -= sh;
                sh++;

            } while (sh <= n);
            if(n!=0)
            {
                l[l.Count - 1] += n;
            }
            Console.WriteLine(p);
            for(int i=0;i<l.Count;i++)
            {
                Console.Write(l[i]+" ");
            }

        }
    }
}
