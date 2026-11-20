using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOP_Lab10_ClassesLib;

namespace OOP_Lab11
{
    class Program
    {
        static void Main(string[] args)
        {
            Task1();

            Task2();

            Task3();
        }

        public static void Task1()
        {
            SortedList<int, Person> sortedList = new SortedList<int, Person>();

            string sMain = "";

            int k = 0;

            do
            {
                Console.WriteLine("Sorted List. Введите действие:\n" +
                                  " 1 - Добавить \n" +
                                  " 2 - Удалить по ключу(индексу)\n" +
                                  " 3 - Удалить по имени\n" +
                                  " 4 - Имена всех инженеров со стажем не менее 5 лет\n" +
                                  " 5 - Имена всех администраторов\n" +
                                  " 6 - Количество всех простых рабочих\n" +
                                  " 7 - Вывести весь список\n" +
                                  " 8 - Клонировать список\n");

                sMain = Console.ReadLine();

                switch (sMain)
                {
                    case "1":

                        Console.WriteLine("1 - Worker\n" +
                                          "2 - Engineer\n" +
                                          "3 - Administrator\n");

                        string s_add = Console.ReadLine();

                        switch (s_add)
                        {
                            case "1":
                                Worker w = new Worker();
                                w.RandomInit();
                                sortedList.Add(k, w);
                                k++;
                                break;
                            case "2":
                                Engineer e = new Engineer();
                                e.RandomInit();
                                sortedList.Add(k, e);
                                k++;
                                break;
                            case "3":
                                Administrator a = new Administrator();
                                a.RandomInit();
                                sortedList.Add(k, a);
                                k++;
                                break;
                            default:
                                //
                                break;
                        }

                        break;

                    case "2":

                        int key = int.Parse(Console.ReadLine());

                        sortedList.Remove(key);

                        break;

                    case "3":

                        string name = Console.ReadLine();

                        for (int i = 0; i < sortedList.Count; i++)
                        {
                            if (sortedList.Values[i].Name == name)
                            {
                                sortedList.Remove(sortedList.Keys[i]);

                                break;
                            }
                        }

                        break;

                    case "4":

                        foreach(KeyValuePair<int, Person> p in sortedList)
                        {
                            if (p.Value is Engineer e)
                            {
                                if (e.WorkExperience >= 5)
                                {
                                    Console.WriteLine($"Имя: {e.Name}, стаж: {e.WorkExperience}");
                                }
                            }
                        }

                        break;

                    case "5":

                        foreach (KeyValuePair<int, Person> p in sortedList)
                        {
                            if (p.Value is Administrator a)
                            {
                                Console.WriteLine($"{a.Name}");
                            }
                        }

                        break;

                    case "6":

                        int count3 = 0;

                        foreach (KeyValuePair<int, Person> p in sortedList)
                        {
                            if (p.Value.GetType() == typeof(Worker))
                            {
                                p.Value.Show();
                                count3++;
                            }
                        }

                        Console.WriteLine(count3);

                        break;

                    case "7":

                        foreach (KeyValuePair<int, Person> p in sortedList)
                        {
                            p.Value.Show();
                        }

                        Console.WriteLine();

                        break;

                    case "8":

                        SortedList<int, Person> list = new SortedList<int, Person>();

                        foreach (KeyValuePair<int, Person> p in sortedList)
                        {
                            list.Add(p.Key, p.Value);
                        }

                        break;

                    default:
                        Console.WriteLine("Неизвестная команда");
                        break;
                }



            } while (!sMain.Equals("end"));
        }

        public static void Task2()
        {
            SortedDictionary<int, Person> sortedDictionary = new SortedDictionary<int, Person>();

            string sMain = "";

            int k = 0;

            do
            {
                Console.WriteLine("Sorted Dictionary. Введите действие:\n" +
                                  " 1 - Добавить \n" +
                                  " 2 - Удалить по ключу(индексу)\n" +
                                  " 3 - Удалить по имени\n" +
                                  " 4 - Имена всех инженеров со стажем не менее 5 лет\n" +
                                  " 5 - Имена всех администраторов\n" +
                                  " 6 - Количество всех простых рабочих\n" +
                                  " 7 - Вывести весь список\n" +
                                  " 8 - Клонировать список\n");

                sMain = Console.ReadLine();

                switch (sMain)
                {
                    case "1":

                        Console.WriteLine("1 - Worker\n" +
                                          "2 - Engineer\n" +
                                          "3 - Administrator\n");

                        string sAdd = Console.ReadLine();

                        switch (sAdd)
                        {
                            case "1":
                                Worker w = new Worker();
                                w.RandomInit();
                                sortedDictionary.Add(k, w);
                                k++;
                                break;
                            case "2":
                                Engineer e = new Engineer();
                                e.RandomInit();
                                sortedDictionary.Add(k, e);
                                k++;
                                break;
                            case "3":
                                Administrator a = new Administrator();
                                a.RandomInit();
                                sortedDictionary.Add(k, a);
                                k++;
                                break;
                            default:
                                //
                                break;
                        }

                        break;

                    case "2":

                        int key = int.Parse(Console.ReadLine());

                        sortedDictionary.Remove(key);

                        break;

                    case "3":

                        string name = Console.ReadLine();

                        for (int i = 0; i < sortedDictionary.Count; i++)
                        {
                            if (sortedDictionary[i].Name == name)
                            {
                                sortedDictionary.Remove(i);
                            }
                        }

                        break;

                    case "4":

                        foreach (KeyValuePair<int, Person> p in sortedDictionary)
                        {
                            if (p.Value is Engineer e)
                            {
                                if (e.WorkExperience >= 5)
                                {
                                    Console.WriteLine($"Имя: {e.Name}, стаж: {e.WorkExperience}");
                                }
                            }
                        }

                        break;

                    case "5":

                        foreach (KeyValuePair<int, Person> p in sortedDictionary)
                        {
                            if (p.Value is Administrator a)
                            {
                                Console.WriteLine($"{a.Name}");
                            }
                        }

                        break;

                    case "6":

                        int count3 = 0;

                        foreach (KeyValuePair<int, Person> p in sortedDictionary)
                        {
                            if (p.Value.GetType() == typeof(Worker))
                            {
                                p.Value.Show();
                                count3++;
                            }
                        }

                        Console.WriteLine(count3);

                        break;

                    case "7":

                        foreach (KeyValuePair<int, Person> p in sortedDictionary)
                        {
                            p.Value.Show();
                        }

                        break;

                    case "8":

                        SortedDictionary<int, Person> dictionary = new SortedDictionary<int, Person>();

                        foreach (KeyValuePair<int, Person> p in sortedDictionary)
                        {
                            dictionary.Add(p.Key, p.Value);
                        }

                        break;

                    default:
                        Console.WriteLine("Неизвестная команда");
                        break;
                }



            } while (!sMain.Equals("end"));
        }

        public static void Task3()
        {
            TestCollections tc = new TestCollections();

            Console.WriteLine("\nПервый элемент:");

            tc.QueueWorker1Find(tc.queueWorker1.Peek());
            tc.QueueStringFind(tc.queueString.Peek());
            tc.SortedDictionaryPerson1Worker1Find(tc.sortedDictionaryPerson1Worker1.Keys.First<Person1>());
            tc.SortedDictionaryPerson1Worker1Find(tc.sortedDictionaryPerson1Worker1.Values.First<Worker1>());
            tc.SortedDictionaryStringWorker1Find(tc.sortedDictionaryStringWorker1.Keys.First<string>());

            Console.WriteLine("\nЦентральный элемент:");

            tc.QueueWorker1Find(tc.queueWorker1.ElementAt<Worker1>(tc.count / 2));
            tc.QueueStringFind(tc.queueString.ElementAt<string>(tc.count / 2));
            tc.SortedDictionaryPerson1Worker1Find(tc.sortedDictionaryPerson1Worker1.Keys.ElementAt<Person1>(tc.count / 2));
            tc.SortedDictionaryPerson1Worker1Find(tc.sortedDictionaryPerson1Worker1.Values.ElementAt<Worker1>(tc.count / 2));
            tc.SortedDictionaryStringWorker1Find(tc.sortedDictionaryStringWorker1.Keys.ElementAt<string>(tc.count / 2));

            Console.WriteLine("\nПоследний элемент:");

            tc.QueueWorker1Find(tc.queueWorker1.ElementAt<Worker1>(tc.count));
            tc.QueueStringFind(tc.queueString.ElementAt<string>(tc.count));
            tc.SortedDictionaryPerson1Worker1Find(tc.sortedDictionaryPerson1Worker1.Keys.ElementAt<Person1>(tc.count - 1));
            tc.SortedDictionaryPerson1Worker1Find(tc.sortedDictionaryPerson1Worker1.Values.ElementAt<Worker1>(tc.count - 1));
            tc.SortedDictionaryStringWorker1Find(tc.sortedDictionaryStringWorker1.Keys.ElementAt<string>(tc.count - 1));

            Console.WriteLine("\nНесуществующий элемент:");

            Worker1 w1 = new Worker1("Э", 99);

            tc.QueueWorker1Find(w1);
            tc.QueueStringFind(w1.ToString());
            tc.SortedDictionaryPerson1Worker1Find(w1.BasePerson1);
            tc.SortedDictionaryPerson1Worker1Find(w1);
            tc.SortedDictionaryStringWorker1Find(w1.ToString());
        }
    }
}