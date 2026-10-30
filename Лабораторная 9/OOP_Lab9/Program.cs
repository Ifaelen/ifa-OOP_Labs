using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Lab9
{
    class Program
    {
        static void Main(string[] args)
        {
			FirstAndSecondParts();

			ThirdPart();
		}

		public static void FirstAndSecondParts()
        {
			Console.WriteLine("Проверка первой и второй части лабораторной:\n");

			Triangle t1 = new Triangle(3, 4, 5);

			Console.WriteLine($"Количество созданных объектов: {Triangle.GetCount()}");

			Triangle t2 = new Triangle(6, 6, 7);

			Console.WriteLine($"Количество созданных объектов: {Triangle.GetCount()}");

			Console.WriteLine("Проверка ++ и -- на: " + t1.TriangleToString());

			t1++;

			Console.WriteLine(t1.TriangleToString());

			t1--;

			Console.WriteLine(t1.TriangleToString());

			Console.WriteLine("Проверка (double) и (bool) на: " + t1.TriangleToString());

			Console.WriteLine((double)t1);

			Console.WriteLine(t1);

			Console.WriteLine("Проверка >= и <= на: " + t1.TriangleToString() + " и: " + t2.TriangleToString());

			Console.WriteLine(t1 >= t2);

			Console.WriteLine(t1 <= t2);
		}

		public static void ThirdPart()
        {
			Random rand = new Random();

			Console.WriteLine("Проверка третьей части лабораторной:\n");

			TriangleArray tArr = new TriangleArray();

			string str = "";

			Console.WriteLine("Ввести длину массива и способ формирования:\n" +
							  " 1 - случайно\n" +
							  " 2 - вручную\n");

			int n;
			int.TryParse(Console.ReadLine(), out n);

			string k = Console.ReadLine();

			do
			{
				switch (k)
				{
					case "1":

						tArr = new TriangleArray(rand, n);
						break;
					case "2":
						tArr = new TriangleArray(n);
						break;
					default:
						Console.WriteLine("Ошибка ввода");
						break;
				}
			}
			while (!k.Equals("end"));

			do
			{
				Console.WriteLine("Действия:\n" +
								  " 1 - Вывести все элементы\n" +
								  "	2 - Найти минимальный элемент и его номер\n");

				str = Console.ReadLine();

				Console.WriteLine();

				switch (str)
				{
					case "1":
						tArr.PrintArray();
						break;
					case "2":
						FindMinTriangleSquareElementNumber(tArr);
						break;
					default:
						Console.WriteLine("Ошибка ввода");
						break;
				}

				Console.WriteLine();

			} while (!str.Equals("end"));
		}

		public static void FindMinTriangleSquareElementNumber(TriangleArray arr)
        {
            Console.WriteLine(arr.GetIndexMinTriangleSquare() + 1);
        }
    }
}
