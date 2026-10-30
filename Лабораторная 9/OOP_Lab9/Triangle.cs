using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Lab9
{
    public class Triangle
    {
        private double a;
        private double b;
        private double c;

        public double A
        {
            get { return a; }
            set
            {
                if(value <= 0)
                    throw new Exception("Длина стороны треугольника не может быть меньше или равно 0");
                else
                    a = value;
            }
        }

        public double B
        {
            get { return b; }
            set
            {
                if (value <= 0)
                    throw new Exception("Длина стороны треугольника не может быть меньше или равно 0");
                else
                    b = value;
            }
        }

        public double C
        {
            get { return c; }
            set
            {
                if(value <= 0)
                    throw new Exception("Длина стороны треугольника не может быть меньше или равно 0");
                else
                    c = value;
            }
        }

        private static int count = 0;

        public Triangle()
        {

        }

        public Triangle(Triangle t)
        {
            this.A = t.A;
            this.B = t.B;
            this.C = t.C;

            count++;
        }

        public Triangle(double a, double b, double c)
        {
            this.A = a;
            this.B = b;
            this.C = c;

            count++;
        }

        public static int GetCount()
        {
            return count;
        }

        public static double TriangleSquareStatic(Triangle t)
        {
            return t.TriangleSquare();
        }

        public double TriangleSquare()
        {
            double p = (a + b + c) / 2;

            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }

        public void EnterValues()
        {
            Console.WriteLine("A:");
            A = EnterDouble();

            Console.WriteLine("B:");
            B = EnterDouble();

            Console.WriteLine("C:");
            C = EnterDouble();
        }

        private double EnterDouble()
        {
            double x;

            while (!double.TryParse(Console.ReadLine(), out x) || x <= 0)
            {
                Console.WriteLine("некорректный ввод данных/значение меньше или равно 0");
            }

            return x;
        }

        public void Print()
        {
            Console.WriteLine(this.TriangleToString());
        }

        public string TriangleToString()
        {
            return $"A = {A}, B = {B}, C = {C}, Square = {TriangleSquare()}";
        }

        public static Triangle operator ++(Triangle t)
        {
            t.A++;
            t.B++;
            t.C++;

            return t;
        }

        public static Triangle operator --(Triangle t)
        {
            t.A--;
            t.B--;
            t.C--;

            return t;
        }

        public static explicit operator double(Triangle t)
        {
            if(t.A < t.B + t.C &&
               t.B < t.A + t.C &&
               t.C < t.A + t.B)
            {
                return t.TriangleSquare();
            }

            return -1;
        }

        public static implicit operator bool(Triangle t)
        {
            if (t.A < t.B + t.C &&
                t.B < t.A + t.C &&
                t.C < t.A + t.B)
            {
                return true;
            }

            return false;
        }

        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Triangle t = (Triangle)obj;
                return t.A == t.A &&
                       t.B == t.B &&
                       t.C == t.C;
            }
        }

        public static bool operator !=(Triangle t1, Triangle t2)
        {
            return t1.A != t2.A ||
                   t1.B != t2.B ||
                   t1.C != t2.C;
        }

        public static bool operator ==(Triangle t1, Triangle t2)
        {
            return t1.A == t2.A &&
                   t1.B == t2.B &&
                   t1.C == t2.C;
        }

        public static bool operator >=(Triangle t1, Triangle t2)
        {
            return t1.TriangleSquare() >= t2.TriangleSquare();
        }

        public static bool operator <=(Triangle t1, Triangle t2)
        {
            return t1.TriangleSquare() <= t2.TriangleSquare();
        }
    }
}
