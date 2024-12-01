using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string input1 = Console.ReadLine();
            string[] inp = input1.Split();
            int n = int.Parse(inp[0]);
            int p = int.Parse(inp[1]);
            long[] a1 = new long[n];
            long[] a2 = new long[n];
            string input2 = Console.ReadLine();
            string input3 = Console.ReadLine();
            string[] inp2 = input2.Split();
            string[] inp3 = input3.Split();
            for (int i = 0; i < n; i++)
            {
                a1[i] = int.Parse(inp2[i]);
                a2[i] = int.Parse(inp3[i]);
            }

            long[,] jadval = new long[2, n];
            jadval[0, 0] = a1[0];
            jadval[1, 0] = a2[0];
            for (int i = 1; i < n; i++)
            {
                long price11 = jadval[0, i - 1] + a1[i];
                long price12 = jadval[0, i - 1] + a2[i] - p;
                long price21 = jadval[1, i - 1] + a1[i] - p;
                long price22 = jadval[1, i - 1] + a2[i];
                if (price22 > price12)
                {
                    jadval[1, i] = price22;
                }
                else
                {
                    jadval[1, i] = price12;
                }
                if (price11 > price21)
                {
                    jadval[0, i] = price11;
                }
                else
                {
                    jadval[0, i] = price21;
                }
            }

            if (jadval[0, n - 1] > jadval[1, n - 1])
            {
                Console.WriteLine(jadval[0, n - 1]);
            }
            else
            {
                Console.WriteLine(jadval[1, n - 1]);
            }

        }
    }
}