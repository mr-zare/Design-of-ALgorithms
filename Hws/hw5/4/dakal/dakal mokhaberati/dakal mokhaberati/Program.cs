using System;
using System.Linq;
namespace ConsoleApp4
{
    class Program
    {
        private static int minin_res(int ss, Tuple<int, bool>[] rr)
        {
            int miniindex = -1;
            int javab = int.MaxValue;
            int trr = rr.Length;
            for (int i = 0; i < trr; i++)
            {
                if (rr[i].Item2 == false && javab > rr[i].Item1 && ss != i + 1)
                {
                    javab = rr[i].Item1;
                    miniindex = i;
                }
            }
            if (int.MaxValue == javab)
            {
                return -1;
            }

            return miniindex;
        }
        private static void djstra(Tuple<int, bool>[] rr, int[,] gg, int yal, int n, int ss)
        {
            int maxi = 0;
            bool f = true;
            int nn = rr.Length;
            for (int i = 0; i < n - 1; i++)
            {
                int mini = minin_res(ss, rr);
                if (mini == -1)
                {
                    f = false;
                    maxi = -1;
                    break;
                }
                rr[mini] = new Tuple<int, bool>(rr[mini].Item1, true);
                for (int j = 0; j <= n - 1; j++)
                {
                    if (!rr[j].Item2 && rr[mini].Item1 + gg[mini, j] < rr[j].Item1 && gg[mini, j] != 0)
                    {
                        rr[j] = new Tuple<int, bool>(gg[mini, j] + rr[mini].Item1, false);
                    }
                }
            }
            if (f == true)
            {
                for (int i = 0; i < nn; i++)
                {
                    if (rr[i].Item2 == true && rr[i].Item1 >= maxi)
                    {
                        maxi = rr[i].Item1;
                    }
                }
            }
            Console.WriteLine(maxi);
        }
        static void Main(string[] args)
        {
            string a = Console.ReadLine();
            string[] aa = a.Split();
            int yal = int.Parse(aa[2]);
            int ss = int.Parse(aa[1]);
            int n = int.Parse(aa[0]);
            int[,] gg = new int[n, n];
            Tuple<int,bool>[] rr = new Tuple<int,bool>[n];
            int trr = rr.Length;
            for (int i = 0; i < trr; i++)
            {
                Tuple<int,bool> b1 = new Tuple<int,bool>(int.MaxValue, false);
                rr[i] = b1;
            }
            for (int i = 0; i < yal; i++)
            {
                string c = Console.ReadLine();
                string[] cc = c.Split();
                int w = int.Parse(cc[2]);
                int dest = int.Parse(cc[1]);
                int source = int.Parse(cc[0]);
                if (ss==source)
                {
                    Tuple<int,bool> b = new Tuple<int,bool>(w,false);
                    rr[dest - 1] = b;
                }
                gg[source - 1, dest - 1] = w;
            }
            djstra( rr, gg, yal, n, ss);
        }
    }
}
