using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Lab9
{
    public class TriangleArray
    {
        private Triangle[] arr;

        public Triangle this[int index]
        {
            set
            {
                if(index < arr.Length && index >= 0)
                {
                    arr[index] = value;
                }
                else
                {
                    throw new ArgumentException($"Индекс не входит в диапазон: [0;{arr.Length-1}]");
                }
            }

            get
            {
                if (index < arr.Length && index >= 0)
                {
                    return arr[index];
                }

                throw new ArgumentException($"Индекс не входит в диапазон: [{0};{arr.Length - 1}]");
            }
        }

        public int Length { get { return arr.Length; } }

        public TriangleArray()
        {

        }

        //random enter
        public TriangleArray(Random rand, int n)
        {
            if (n <= 0)
            {
                throw new ArgumentException("Длина массива не может быть меньше или равной 0");
            }

            arr = new Triangle[n];

            for (int i = 0; i < n; i++)
            {
                double a = Math.Round(rand.NextDouble() * (11.0 - 0.0) + 0.0, 4);
                double b = Math.Round(rand.NextDouble() * (11.0 - 0.0) + 0.0, 4);
                double c = Math.Round(rand.NextDouble() * (11.0 - 0.0) + 0.0, 4);

                arr[i] = new Triangle(a, b, c);
            }
        }

        //manual enter
        public TriangleArray(int n)
        {
            if (n <= 0)
            {
                throw new ArgumentException("Длина массива не может быть меньше или равной 0");
            }

            arr = new Triangle[n];

            for (int i = 0; i < n; i++)
            {
                arr[i].EnterValues();
            }
        }

        public TriangleArray(Triangle[] arr)
        {
            this.arr = arr;
        }

        public void PrintArray()
        {
            for(int i = 0; i < arr.Length; i++)
            {
                Console.Write($"{i + 1}: {arr[i].TriangleToString()}\n");
            }

            Console.WriteLine();
        }

        public int GetIndexMinTriangleSquare()
        {
            int ind = 0;
            double min = 1000000;

            for(int i = 0; i < arr.Length; i++)
            {
                if (arr[i].TriangleSquare() < min)
                {
                    ind = i;
                    min = arr[i].TriangleSquare();
                }
            }

            return ind;
        }
    }
}
