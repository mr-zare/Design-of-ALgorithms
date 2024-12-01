using System;

namespace ConsoleApp6
{
    class Program
    {
        static void Main()
        {
            string a = Console.ReadLine();
            string a1 = Console.ReadLine();
            string[] b = a.Split(' ');
            int K = int.Parse(b[1]);
            int N = int.Parse(b[0]);
            int[] aa = new int[N];
            string[] Temp = a1.Split(' ');

            for (int i = 0; i < N; i++)
            {
                aa[i] = int.Parse(Temp[i]);
            }
            int javab = MinCostPath(K, aa);
            Console.WriteLine(javab);
        }
        static int MinCostPath(int K, int[] aa )
        {
            int n = aa.Length;
            int[] t = new int[n];
            t[0] = 0;
            for (int i = 1; i < n; i++)
            {
                t[i] = int.MaxValue;
            }
            int j;
            for (int i = 0; i < n; i++)
            {
                j = i + 1;
                while (j <= i + K && j < aa.Length)
                {
                    int m = Math.Abs(aa[i] - aa[j]);
                    t[j] = Math.Min(t[j], t[i] + m);
                    j++;
                }
            }
            return t[n - 1];
        }
    }
}
