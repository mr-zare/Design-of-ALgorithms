using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] f = new int[n];
            f[0] = 1;
            if (n >= 2)
            {
                f[1] = 1;
            }
            int sum= 2;
            for (int i=2;i<n;i++)
            {
                f[i] =(f[i - 1]%10) +(f[i - 2]%10);
                sum += f[i];
            }
            if(n>=2)
            Console.WriteLine(sum%10);
            else
            {
                Console.WriteLine("1");
            }
        } 
    }
}





