using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Lab3
{
    class Program
    {
        private static double a = 0.1, b = 1;
        private static int n = 20;

        private static double eps = 0.0001;

        static void Main(string[] args)
        {

        }

        public static void Task()
        {
            double step = (b - a) / 10;

            for (double x = a; x <= b; x += step)
            {
                double sumN = 0, sumE = 0;
                double exprN = 1, exprE = 1;
                int i = 0, j = 0;

                while (i <= n)
                {
                    exprN = Math.Round(Math.Pow(2 * x, i) / fact(i), 4);
                    sumN += exprN;

                    i++;
                }

                while (exprE > eps)
                {
                    exprE = Math.Round(Math.Pow(2 * x, j) / fact(j), 4);
                    sumE += exprE;

                    j++;
                }

                Console.WriteLine($"x = {x}, sumN = {sumN}, sumE = {sumE}, y = {f(x)}\n");
            }
        }

        public static double f(double x)
        {
            return Math.Round(Math.Pow(Math.E, 2 * x), 4);
        }

        public static int fact(int n)
        {
            int fact = 1;
            for (int i = 1; i <= n; i++)
            {
                fact *= i;
            }

            return fact;
        }
    }
}
