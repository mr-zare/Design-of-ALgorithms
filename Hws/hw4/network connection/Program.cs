using System;
using System.Collections.Generic;

namespace mpst

{
    class MST
    {
        int vertex;
        int[] parent;
        double[] value_min;
        bool[] ismsp;

        public MST(int vertex)
        {
            this.vertex = vertex;
            this.parent = new int[vertex];
            this.value_min = new double[vertex];
            this.ismsp = new bool[vertex];
            for (int i = 0; i < vertex; i++)
            {
                value_min[i] = int.MaxValue;
                ismsp[i] = false;
            }
            value_min[0] = 0;
            parent[0] = -1;
        }

        int GetmeMinimumWeightiIndex()
        {
            double minimumWeight = double.MaxValue;
            int index = 0;
            for (int i = 0; i < vertex; i++)
            {
                if (ismsp[i] == false && value_min[i] < minimumWeight)
                {
                    minimumWeight = value_min[i];
                    index = i;
                }
            }
            return index;
        }
        public double mst(double[,] maingraph)
        {
            double p = 0;
            for (int i = 0; i < vertex - 1; i++)
            {
                int index = GetmeMinimumWeightiIndex();
                ismsp[index] = true;
                for (int j = 0; j < vertex; j++)
                {
                    if (maingraph[index, j] > 0 && ismsp[j] == false && maingraph[index, j] < value_min[j])
                    {
                        value_min[j] = maingraph[index, j];
                        parent[j] = index;
                    }
                }
            }
            for (int i = 1; i < vertex; i++)
            {
                p += maingraph[i, parent[i]];
            }
            return p;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            Tuple<int, int>[] point = new Tuple<int, int>[num];
            double[,] matrix_adj = new double[num, num];
            for (int i = 0; i < num; i++)
            {
                string[] poin = Console.ReadLine().Split(' ');
                int x = int.Parse(poin[0]);
                int y = int.Parse(poin[1]);
                point[i] = new Tuple<int, int>(x, y);
            }
            for (int i = 0; i < num; i++)
            {
                for (int j = 0; j < num; j++)
                {
                    matrix_adj[i, j] = manhaManhattan_Distance(point[i], point[j]);
                }
            }

            MST pro = new MST(num);
            Console.WriteLine(pro.mst(matrix_adj));
        }
        static double manhaManhattan_Distance(Tuple<int, int> point1, Tuple<int, int> point2)
        {
            return Math.Abs(point1.Item1 - point2.Item1) + Math.Abs(point1.Item2 - point2.Item2);
        }
    }
}