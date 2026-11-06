using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Lab10_ClassesLib
{
    public class Rectangle : IInit, IComparable, ICloneable
    {
        private double a;
        private double b;

        public double A
        {
            get { return a; }
            set
            {
                if(value > 0)
                {
                    a = value;
                }
            }
        }

        public double B
        {
            get { return b; }
            set
            {
                if (value > 0)
                {
                    b = value;
                }
            }
        }

        public double Square
        {
            get { return a * b; }
        }

        public Rectangle()
        {

        }

        public Rectangle(double a, double b)
        {
            A = a;
            B = b;
        }

        public void Init()
        {
            Console.WriteLine("Ручной ввод Прямоугольник (Rectangle)");

            A = double.Parse(Console.ReadLine());
            B = double.Parse(Console.ReadLine());
        }

        public void RandomInit()
        {
            Random rand = new Random();

            A = Math.Round(rand.NextDouble() * (11.0 - 0.0) + 0.0, 4);
            B = Math.Round(rand.NextDouble() * (11.0 - 0.0) + 0.0, 4);
        }

        public void Show()
        {
            Console.WriteLine($"Прямоугольник. а = {A}, b = {B}, Площадь = {Square}");
        }

        public int CompareTo(object obj)
        {
            return this.Square.CompareTo((obj as Rectangle).Square);
        }

        public object Clone()
        {
            return new Rectangle(this.a, this.b);
        }
    }
}
