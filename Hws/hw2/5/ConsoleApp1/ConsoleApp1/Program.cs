using System;
namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n=int.Parse(Console.ReadLine());
            int[] ball = new int[n];
            string b = Console.ReadLine();
            string[] bb = b.Split();
            for(int i=0;i<bb.Length;i++)
            {
                ball[i] = int.Parse(bb[i]);
            }
            int step = 0;
            if (n%2==0 || n==1)
            {
                Console.WriteLine("-1");
            }
            else
            {
                ball[2] = ball[2] - ball[1];
                ball[3] = ball[3] - ball[1];
                if(ball[2]<=0)
                {
                    ball[2] = 0;
                }
                if(ball[3]<=0)
                {
                    ball[3] = 0;
                }
                step += ball[1];
                ball[1] = 0;
                double x = n;
                while (x > 2)
                {
                    for (double i = Math.Ceiling((x + 1) / 2); i <= x; i++)
                    {
                        if (i % 2 == 0)
                        {

                        }
                        else
                        {

                        }
                    }
                    x = Math.Ceiling(x / 2);
                }

                }
            }
        }
    }
}
