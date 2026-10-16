using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Lab5
{
    class Program
    {
        private static Random rand = new Random();

        private static int[,] matrix;
        private static int N1, M1;

        private static int[][] ragArr;
        private static int N2;

        static void Main(string[] args)
        {
            string s1 = "";

            Console.WriteLine("Формирование двумерного массива:\n" +
                              " 1 - случайно\n" +
                              " 2 - вручную\n" +
                              " end - завершить формирование (не завершит пока массив пуст)\n");

            do
            {
                s1 = Console.ReadLine();

                switch (s1)
                {
                    case "1":
                        CreateMatrixRand();
                        break;
                    case "2":
                        CreateMatrix();
                        break;
                    case "end":
                        break;
                    default:
                        Console.WriteLine("неверный ввод номера действия");
                        break;
                }
            } while (!s1.Equals("end") || matrix == null);

            Console.WriteLine("Формирование рваного массива:\n" +
                              " 1 - случайно\n" +
                              " 2 - вручную\n" +
                              " end - завершить формирование (не завершит пока массив пуст\n");

            do
            {
                s1 = Console.ReadLine();

                switch (s1)
                {
                    case "1":
                        CreateRaggedArrayRand();
                        break;
                    case "2":
                        CreateRaggedArray();
                        break;
                    case "end":
                        break;
                    default:
                        Console.WriteLine("неверный ввод номера действия");
                        break;
                }
            } while (!s1.Equals("end") || ragArr == null);

            string str = "";

            do
            {
                Console.WriteLine("Ввести номер задания\n" +
                                  "1 - удалить строку в которой находится наибольший элемент матрицы (двумерный массив),\n" +
                                  "2 - вставить строку в начало массива (рваный массив),\n" +
                                  "end - выйти.\n");

                str = Console.ReadLine();

                switch (str)
                {
                    case "1":
                        Task1();
                        break;
                    case "2":
                        Task2();
                        break;
                    case "end":
                        break;
                    default:
                        Console.WriteLine("неверный ввод номера задания");
                        break;
                }

            } while (!str.Equals("end"));
        }

        //создать двумерный массив с рандомным заполнением
        public static void CreateMatrixRand()
        {
            Console.WriteLine("ФОРМИРОВАНИЕ ДВУМЕРНОГО МАССИВА С СЛУЧАЙНЫМ ЗАПОЛНЕНИЕМ");

            Console.WriteLine("Кол-во строк:");

            N1 = EnterCorrectValue();

            Console.WriteLine("Кол-во столбцов:");

            M1 = EnterCorrectValue();

            matrix = new int[N1, M1];

            for (int i = 0; i < N1; i++)
            {
                for (int j = 0; j < M1; j++)
                {
                    matrix[i, j] = rand.Next(0, 51);
                }
            }

            Console.WriteLine("Двумерный массив:");

            Print(matrix);
        }

        //создать двумерный массив с ручным заполнением
        public static void CreateMatrix()
        {
            Console.WriteLine("ФОРМИРОВАНИЕ ДВУМЕРНОГО МАССИВА С РУЧНЫМ ЗАПОЛНЕНИЕМ");

            Console.WriteLine("Кол-во строк:");

            N1 = EnterCorrectValue();

            Console.WriteLine("Кол-во столбцов:");

            M1 = EnterCorrectValue();

            matrix = new int[N1, M1];

            for (int i = 0; i < N1; i++)
            {
                for (int j = 0; j < M1; j++)
                {
                    matrix[i, j] = EnterCorrectValue();
                }
            }

            Console.WriteLine("Двумерный массив:");

            Print(matrix);
        }

        //создать рваный массив с рандомным заполнением
        public static void CreateRaggedArrayRand()
        {
            Console.WriteLine("ФОРМИРОВАНИЕ РВАНОГО МАССИВА С СЛУЧАЙНЫМ ЗАПОЛНЕНИЕМ");

            Console.WriteLine("Кол-во строк:");

            N2 = EnterCorrectValue();

            ragArr = new int[N2][];

            for (int i = 0; i < N2; i++)
            {
                ragArr[i] = new int[rand.Next(1, 11)];
                ragArr[i] = CreateArrayRand(ragArr[i].Length);
            }

            Console.WriteLine("Рваный массив:");

            Print(ragArr);
        }

        //создать рваный массив ручным заполнением
        public static void CreateRaggedArray()
        {
            Console.WriteLine("ФОРМИРОВАНИЕ РВАНОГО МАССИВА С РУЧНЫМ ЗАПОЛНЕНИЕМ");

            Console.WriteLine("Кол-во строк:");

            N2 = EnterCorrectValue();

            ragArr = new int[N2][];

            for (int i = 0; i < N2; i++)
            {
                ragArr[i] = new int[rand.Next(1, 11)];
                ragArr[i] = CreateArray(ragArr[i].Length);
            }

            Console.WriteLine("Рваный массив:");

            Print(ragArr);
        }

        //двумерный массив, удаление строки с наибольшим значением
        public static void Task1()
        {
            int maxN = 0, maxI = 0;

            FindMax(out maxN, out maxI);

            Console.WriteLine($"маскимальное число = {maxN}, в строке = {maxI + 1}");

            int[,] newArr = new int[N1 - 1, M1];

            for (int i = 0; i < maxI; i++)
            {
                for (int j = 0; j < M1; j++)
                {
                    newArr[i, j] = matrix[i, j];
                }
            }

            for (int i = maxI + 1; i < N1; i++)
            {
                for (int j = 0; j < M1; j++)
                {
                    newArr[i - 1, j] = matrix[i, j];
                }
            }

            matrix = newArr;

            Console.WriteLine("Полученный двумерный массив:");

            Print(matrix);
        }

        //нахождение максимального числа и индекса его строки в двумерном массиве
        private static void FindMax(out int max, out int im)
        {
            im = 0;
            max = -1000000;

            for(int i = 0; i < N1; i++)
            {
                for(int j = 0; j < M1; j++)
                {
                    if(matrix[i,j] > max)
                    {
                        max = matrix[i, j];
                        im = i;
                    }
                }
            }
        }

        //рваный массив, добавление новой строки в начало массива
        public static void Task2()
        {
            int[] arr = CreateArrayRand(rand.Next(1, 11));

            Console.WriteLine("Вставляем строку:");

            Print(arr);

            int[][] tempRagArray = new int[N2 + 1][];

            tempRagArray[0] = arr;

            for(int i = 1; i < N2 + 1; i++)
            {
                tempRagArray[i] = ragArr[i-1];
            }

            ragArr = tempRagArray;

            Console.WriteLine("Полученный рваный массив:");

            Print(ragArr);
        }

        //проверка на корректный ввод
        private static int EnterCorrectValue()
        {
            int num;

            while (!int.TryParse(Console.ReadLine(), out num) || num <= 0)
            {
                Console.WriteLine("некорректный ввод данных");
            }

            return num;
        }

        //формирование одномерного массива длины n типа int с рандомными значениями
        private static int[] CreateArrayRand(int n)
        {
            int[] a = new int[n];
            for (int i = 0; i < n; i++)
            {
                a[i] = rand.Next(0, 51);
            }

            return a;
        }

        //формирование одномерного массива длины n типа int с ручным значениями
        private static int[] CreateArray(int n)
        {
            int[] a = new int[n];
            for (int i = 0; i < n; i++)
            {
                a[i] = EnterCorrectValue();
            }

            return a;
        }

        //принт под одномерный массив
        public static void Print(int[] arr)
        {
            for(int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + "\t");
            }
            Console.WriteLine();
        }

        //принт под двумерный массив
        public static void Print(int[,] arr)
        {
            int n = arr.GetUpperBound(0) + 1;
            int m = arr.GetUpperBound(1) + 1;

            if(n == 0)
            {
                Console.WriteLine("Двумерный массив пуст");
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write(arr[i, j] + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        //принт под рваный массив
        public static void Print(int[][] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    Console.Write(arr[i][j] + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
