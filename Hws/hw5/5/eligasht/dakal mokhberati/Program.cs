using System;
using System.Linq;
public class eligasht
{
    static int djtra(int[] fasele, int[,] g, int[] tempp, bool[] booli, int k, int manba, int maqsd)
    {
        int d = fasele.Length;
        int boli = booli.Length;
        int tt = manba;
        for (int i = 0; i < boli; i++)
            booli[i] = false;
        for (int i = 1; i < d; i++)
            fasele[i] = int.MaxValue;
        fasele[manba] = 0;
        for (int i = 0; i < d- 1; i++)
        {
            int mnt = -1;
            int min1 = int.MaxValue;
            for (int j = 0; j < d; j++)
                if (booli[j] == false && fasele[j] <= min1)
                {
                    mnt = j;
                    min1 = fasele[j];
                    if (manba != mnt)
                        tempp[mnt] = tempp[tt] + 1;
                    tt = j;
                }
            booli[mnt] = true;
            for (int j = 0; j < fasele.Length; j++)
                if (booli[j]==false && fasele[mnt] != int.MaxValue && g[mnt, j] != 0 && fasele[j] > fasele[mnt] + g[mnt, j]  &&  k >= tempp[mnt])
                    fasele[j] =g[mnt, j] + fasele[mnt] ;
        }
        for (int i = 0; i < d; i++)
            if (fasele[maqsd] == int.MaxValue)
                return -1;
        return fasele[maqsd];
    }
    public static void Main()
    {
        string a = Console.ReadLine();
        string b = Console.ReadLine();
        string[] a1 = a.Split();
        string[] b1 = b.Split();
        int m = int.Parse(a1[1]);
        int n = int.Parse(a1[0]);
        bool[] booli = new bool[n];
        int[] d = new int[n];
        int[] temp = new int[n];
        int[,] g = new int[n, n];
        int u = int.Parse(b1[0]);
        int v = int.Parse(b1[1]);
        int k = int.Parse(b1[2]);
        for (int i = 0; i < m; i++)
        {
            string tem = Console.ReadLine();
            string[] tem2 = tem.Split();
            int bb = int.Parse(tem2[1]);
            int aa = int.Parse(tem2[0]);
            g[aa,bb] = int.Parse(tem2[2]);
        }
        Console.WriteLine(djtra(d,g,temp,booli,k,u,v));
    }
}