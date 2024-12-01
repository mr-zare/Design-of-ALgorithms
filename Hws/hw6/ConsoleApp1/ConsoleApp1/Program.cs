using System;
using System.Collections.Generic;
namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int mabda= int.Parse(Console.ReadLine());
            int maqsad= int.Parse(Console.ReadLine());
            string a = Console.ReadLine();
            string[] a1 = a.Split();
            int a11 = int.Parse(a1[0]);
            List<Edge> cc = new List<Edge>();
            while (a11!=-1)
            {
                Edge c = new Edge(int.Parse(a1[0]), int.Parse(a1[1]), int.Parse(a1[2]));
                cc.Add(c);
                a = Console.ReadLine();
                a1 = a.Split();
                a11 = int.Parse(a1[0]);
            }
            int mm = cc.Count;
            int[,] aa = new int[n,n];
            GraphMaker(aa, cc);
            var m=ResGraphMaker(aa, n);
            foreach(var i in m)
            {
                Console.WriteLine(i);
            }
        }
        private static int[,] ResGraphMaker(int[,] table, int verticesCount)
        {
            var ResGraph = new int[verticesCount, verticesCount];
            for (int i = 0; i < verticesCount; i++)
            {
                for (int j = 0; j < verticesCount; j++)
                {
                    ResGraph[i, j] = table[i, j];
                }
            }
            return ResGraph;
        }

        private static void GraphMaker(int[,] table, List<Edge> edges)
        {
            foreach (var edge in edges)
            {
                table[edge.Source, edge.Destination] = edge.Capacity;
            }
        }
        public class Edge
        {
            public int Source;
            public int Destination;
            public int Capacity;

            public Edge(int source, int destination, int capacity)
            {
                Source = source;
                Destination = destination;
                Capacity = capacity;
            }
        }
    }
}
