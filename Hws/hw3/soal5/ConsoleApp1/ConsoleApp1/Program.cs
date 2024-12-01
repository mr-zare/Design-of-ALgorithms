using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class node
    {
        public string name;
        public bool isvisitd;
        public int n = 1;
        public List<node> listadj;
        public bool isfinal = false;

        public node(string name)
        {
            this.listadj = new List<node>();
            this.isvisitd = false;
            this.name = name;
        }
    }
    class graph
    {
        static public node final;
        static public List<node> star = new List<node>();

        static public List<node> nodes = new List<node>();
        public void start(node node1, node start)
        {
            for (int i = 0; i < nodes.Count(); i++)
            {
                nodes[i].isvisitd = false;
            }
            dfs(node1, start);
        }
        static void dfs(node node1, node start)
        {
            node1.isvisitd = true;
            Stack<node> stacks = new Stack<node>();
            stacks.Push(node1);
            while (stacks.Count != 0)
            {
                node1 = stacks.Pop();
                if (!node1.isvisitd)
                {
                    node1.isvisitd = true;
                }

                else
                {
                    foreach (var item in node1.listadj)
                    {
                        if (!item.isvisitd && item.name != '*'.ToString())
                        {
                            start.n++;
                            stacks.Push(item);
                        }
                        else
                        {
                            item.isvisitd = true;
                        }
                    }
                }
            }
        }

    }
    class Program
    {
        static void Main(string[] args)
        {

            string[] inp = Console.ReadLine().Split(' ');
            long n = long.Parse(inp[0]);
            long m = long.Parse(inp[1]);
            node[,] Graph = new node[n, m];
            node temp;
            for (int i = 0; i < n; i++)
            {
                string ch = Console.ReadLine();
                char[] iswall = ch.ToCharArray();
                for (int j = 0; j < m; j++)
                {
                    temp = new node(iswall[j].ToString());
                    Graph[i, j] = temp;
                    graph.nodes.Add(temp);
                    if (i - 1 >= 0)
                    {
                        Graph[i - 1, j].listadj.Add(Graph[i, j]);
                        Graph[i, j].listadj.Add(Graph[i - 1, j]);
                    }
                    if (j - 1 >= 0)
                    {
                        Graph[i, j - 1].listadj.Add(Graph[i, j]);
                        Graph[i, j].listadj.Add(Graph[i, j - 1]);

                    }
                    if (iswall[j] == '*')
                    {
                        graph.star.Add(temp);
                    }
                }
            }
            Graph[n - 1, m - 1].isfinal = true;
            graph.final = Graph[n - 1, m - 1];
            graph pro = new graph();
            for (int i = 0; i < graph.star.Count(); i++)
            {
                pro.start(graph.star[i], graph.star[i]);
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (Graph[i, j].name != '*'.ToString())
                    {
                        Console.Write(Graph[i, j].name);
                    }
                    else if (Graph[i, j].name == '*'.ToString())
                    {
                        Console.Write((Graph[i, j].n % 10));
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
