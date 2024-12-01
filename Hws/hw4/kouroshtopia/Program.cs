using System;
using System.Collections;
using System.Collections.Generic;

namespace kourosh_topia
{


    class edge
    {
        public int L;
        public int v1;
        public int v2;

        public edge(int l, int v1, int v2)
        {
            L = l;
            this.v1 = v1;
            this.v2 = v2;
        }
    }

    class Program
    {
        static bool Connected(int[,] Graph, int size, int v1)
        {
            int x = 0;
            bool[] isChecked = new bool[size];
            Queue<int> bfsList = new Queue<int>();
            bfsList.Enqueue(v1);
            isChecked[0] = true;
            while (bfsList.Count != 0)
            {
                int c = bfsList.Dequeue();
                x++;
                for (int i = 0; i < size; i++)
                {
                    if (Graph[c, i] == 1)
                    {
                        if (!isChecked[i])
                        {
                            bfsList.Enqueue(i);
                            isChecked[i] = true;
                        }
                    }
                }
            }
            if (x == size)
            {
                return true;

            }
            else
            {
                return false;
            }
        }
        static bool numberOfConnected(int[,] Graph, int size, int v1, int v2)
        {
            bool ans = false;
            bool[] isChecked = new bool[size];
            Queue<int> bfsList = new Queue<int>();
            bfsList.Enqueue(v1);
            while (bfsList.Count != 0)
            {
                int c = bfsList.Dequeue();
                if (c == v2)
                {
                    ans = true;
                    break;
                }
                isChecked[c] = true;
                for (int i = 0; i < size; i++)
                {
                    if (Graph[c, i] == 1)
                    {
                        if (!isChecked[i])
                        {
                            bfsList.Enqueue(i);
                        }
                    }
                }
            }
            return ans;
        }
        static bool allChecked(bool[] Nodes)
        {
            bool ans = true;
            for (int i = 0; i < Nodes.Length; i++)
            {
                if (!Nodes[i])
                {
                    ans = false;
                    break;
                }
            }
            return ans;
        }



        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int n = int.Parse(input.Split(' ')[0]);
            int[,] newGraph = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    newGraph[i, j] = 0;
                }
            }
            List<edge> edges = new List<edge>();
            int m = int.Parse(input.Split(' ')[1]);
            for (int i = 0; i < m; i++)
            {
                string inp = Console.ReadLine();
                if (int.Parse(inp.Split(' ')[1]) != int.Parse(inp.Split(' ')[0]))
                {
                    edges.Add(new edge(int.Parse(inp.Split(' ')[2]), int.Parse(inp.Split(' ')[0]) - 1, int.Parse(inp.Split(' ')[1]) - 1));
                }
            }
            m = int.Parse(input.Split(' ')[2]);
            for (int i = 0; i < m; i++)
            {
                string inp = Console.ReadLine();
                if (int.Parse(inp.Split(' ')[1]) != int.Parse(inp.Split(' ')[0]))
                {
                    newGraph[int.Parse(inp.Split(' ')[0]) - 1, int.Parse(inp.Split(' ')[1]) - 1] = 1;
                    newGraph[int.Parse(inp.Split(' ')[1]) - 1, int.Parse(inp.Split(' ')[0]) - 1] = 1;
                }
            }

            for (int i = edges.Count - 1; i >= 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (edges[j].L > edges[j + 1].L)
                    {
                        edge t = edges[j];
                        edges[j] = edges[j + 1];
                        edges[j + 1] = t;
                    }
                }
            }

            int ans = 0;

            for (int i = 0; i < edges.Count; i++)
            {
                if (!numberOfConnected(newGraph, n, edges[i].v1, edges[i].v2))
                {
                    ans += edges[i].L;
                    newGraph[edges[i].v1, edges[i].v2] = 1;
                    newGraph[edges[i].v2, edges[i].v1] = 1;
                }

            }



            if (Connected(newGraph, n, 0))
            {
                Console.WriteLine(ans);
            }
            else
            {
                Console.WriteLine("-1");
            }

        }
    }
}
