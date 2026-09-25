using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Lab1
{
    class Program
    {
		static void Main(string[] args)
		{
			string str = "";

			do
			{
				Console.WriteLine("Ввести номер задания\n" +
								  "1 - задание 1,\n" +
								  "2 - задание 2,\n" +
								  "3 - задание 3,\n" +
								  "end - выйти.\n");

				str = Console.ReadLine();

				Console.WriteLine();

				switch (str)
				{
					case "1":
						TaskOne();
						break;
					case "2":
						TaskTwo();
						break;
					case "3":
						TaskThree();
						break;
					case "end":
						break;
					default:
						Console.WriteLine("неверный ввод номера задания");
						break;
				}

				Console.WriteLine();

			} while (!str.Equals("end"));


		}

		public static void TaskOne()
		{
			Console.WriteLine("n:");
			int n = EnterInt();
			int tn = n;

			Console.WriteLine("m:");
			int m = EnterInt();
			int tm = m;

			int a = (n++ / --m); a++;

			Console.WriteLine($"n={n}, m={m} (n++ / --m)++ = {a}");

			n = tn; m = tm;

			bool b = ++m > n--;

			Console.WriteLine($"n={n}, m={m} ++m > n-- = {b}");

			n = tn; m = tm;

			bool c = --m > ++n;

			Console.WriteLine($"n={n}, m={m} --m > ++n = {c}");

			Console.WriteLine("x:");
			double x = EnterDouble();

			double d = 7 * Math.Atan(x * x);

			Console.WriteLine($"7arctg(x^2) = {d}");
		}

		public static void TaskTwo()
		{
			Console.WriteLine("x:");
			int x = EnterInt();

			Console.WriteLine("y:");
			int y = EnterInt();

			if (Math.Abs(x / 5) + Math.Abs(y / 5) <= 1 && !(x < 0 && y > 0))
			{
				Console.WriteLine("true");
			}
			else
			{
				Console.WriteLine("false");
			}
		}

		public static void TaskThree()
		{
			float af = 1000;
			float bf = 0.0001f;

			float kf = (float)(Math.Pow(af + bf, 2) - (af * af + 2 * af * bf)) / (bf * bf);

			double ad = 1000;
			double bd = 0.0001;

			double kd = (Math.Pow(ad + bd, 2) - (ad * ad + 2 * ad * bd)) / (bd * bd);

			Console.WriteLine($"((a+b)^2 - (a^2 + 2ab)) / b^2");
			Console.WriteLine($"a = {af}, b = {bf}, float: {kf}");
			Console.WriteLine($"a = {ad}, b = {bd}, double: {kd}");
		}

		private static int EnterInt()
		{
			int x;

			while (!int.TryParse(Console.ReadLine(), out x))
			{
				Console.WriteLine("некорректный ввод данных");
			}

			return x;
		}

		private static double EnterDouble()
		{
			double x;

			while (!double.TryParse(Console.ReadLine(), out x))
			{
				Console.WriteLine("некорректный ввод данных");
			}

			return x;
		}
	}
}