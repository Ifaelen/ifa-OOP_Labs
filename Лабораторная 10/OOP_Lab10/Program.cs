using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOP_Lab10_ClassesLib;

namespace OOP_Lab10
{
    class Program
    {
        static void Main(string[] args)
        {
            //1
            Console.WriteLine("Ввести длину массива");

            int n = int.Parse(Console.ReadLine());

            Person[] persons = new Person[n];

            string s = "";
            int k = 0;

            Console.WriteLine("Добавление объектов в список:\n" +
                              " 1 - Worker\n" +
                              " 2 - Enginner\n" +
                              " 3 - Administrator");

            do
            {
                s = Console.ReadLine();

                switch (s)
                {
                    case "1":
                        Worker w = new Worker();
                        w.RandomInit();
                        persons[k] = w;
                        k++;
                        break;
                    case "2":
                        Engineer e = new Engineer();
                        e.RandomInit();
                        persons[k] = e;
                        k++;
                        break;
                    case "3":
                        Administrator a = new Administrator();
                        a.RandomInit();
                        persons[k] = a;
                        k++;
                        break;
                    default:
                        //
                        break;
                }
            } while (!s.Equals("end") && k != n);

            Console.WriteLine("Полученный массив:");

            PrintArray(persons);

            Console.WriteLine();

            //2
            Console.WriteLine("Запрос 1. Имена служащик инженеров со стажем не менее 5 лет");

            foreach (Person p in persons)
            {
                if(p is Engineer e)
                {
                    if (e.WorkExperience >= 5)
                    {
                        Console.WriteLine($"Имя: {e.Name}, стаж: {e.WorkExperience}");
                    }
                }
            }

            Console.WriteLine("\nЗапрос 2. Имена всех администраторов");

            foreach (Person p in persons)
            {
                if(p is Administrator)
                {
                    Console.WriteLine($"{p.Name}");
                }
            }

            Console.WriteLine("\nЗапрос 3. Количество всех простых рабочих (Worker)");

            int count3 = 0;

            foreach (Person p in persons)
            {
                if (p.GetType() == typeof(Worker))
                {
                    p.Show();
                    count3++;
                }
            }

            Console.WriteLine(count3);

            //3
            //Сортировка
            Console.WriteLine("\nСортировка по имени\n");
            Array.Sort(persons);
            PrintArray(persons);

            Console.WriteLine("\nСортировка по возрасту\n");
            Array.Sort(persons, new SortByAge());
            PrintArray(persons);

            //Бинарный поиск
            int ageTarget = 0;

            Console.WriteLine("\nБинарный поиск по возрасту. Ввести цель.");

            ageTarget = int.Parse(Console.ReadLine());

            int ind = BinarySearch(persons, ageTarget);

            if (ind < 0)
            {
                Console.WriteLine("Нет позиции с таким возрастом");
            }
            else
            {
                Console.WriteLine($"Найдено, индекс = {ind}, Данные:");
                persons[ind].Show();
            }

            //IInit
            Console.WriteLine("\nПроверка массива IInit");

            IInit[] iinitPersons = new IInit[6];
            Worker w1 = new Worker();
            w1.RandomInit();
            iinitPersons[0] = w1;
            Engineer e2 = new Engineer();
            e2.RandomInit();
            iinitPersons[1] = e2;
            Administrator a3 = new Administrator();
            a3.RandomInit();
            iinitPersons[2] = w1;
            Engineer e4 = new Engineer();
            e4.Init();
            iinitPersons[3] = e4;
            Worker w5 = new Worker();
            w5.Init();
            iinitPersons[4] = w5;
            Rectangle r6 = new Rectangle();
            r6.RandomInit();
            iinitPersons[5] = r6;

            PrintArray(iinitPersons);

            Console.WriteLine();

            //клонирование
            CloneCheck();
        }

        public static void CloneCheck()
        {
            Person[] mas = new Person[5] { new Worker("Алексей", 25, 6), new Engineer("Василий", 28, 7), new Administrator("Борис", 37, 12), new Engineer("Александра", 28, 8), new Worker("Евгения", 26, 6) };

            PrintArray(mas);

            Console.WriteLine();

            Worker w1sc = new Worker();
            w1sc = (Worker)mas[0];
            w1sc.Show();
            Console.Write(w1sc.GetType());

            Console.WriteLine();

            w1sc = (Worker)mas[1].ShallowCopy();
            w1sc.Show();
            Console.Write(w1sc.GetType());

            Console.WriteLine();

            w1sc = (Worker)mas[1].Clone();
            w1sc.Show();
            Console.Write(w1sc.GetType());

            Console.WriteLine();
        }

        public static void PrintArray(Person[] arr)
        {
            foreach(Person p in arr)
            {
                p.Show();
            }
        }

        //Бинарный поиск по возрасту
        public static int BinarySearch(Person[] arr, int ageTarget)
        {
            int left = 0;
            int right = arr.Length - 1;
            int mid;

            while (left <= right)
            {
                mid = (left + right) / 2;

                if(arr[mid].Age == ageTarget)
                {
                    return mid;
                }
                else if(arr[mid].Age > ageTarget)
                {
                    right = mid - 1;
                }
                else if(arr[mid].Age < ageTarget)
                {
                    left = mid + 1;
                }
            }

            return -1;

        }

        public static void PrintArray(IInit[] arr)
        {
            foreach(IInit o in arr)
            {
                o.Show();
            }
        }
    }
}
