using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace OOP_Lab11
{
    class TestCollections
    {
        public Queue<Worker1> queueWorker1 = new Queue<Worker1>();

        public Queue<string> queueString = new Queue<string>();

        public SortedDictionary<Person1, Worker1> sortedDictionaryPerson1Worker1 = new SortedDictionary<Person1, Worker1>();

        public SortedDictionary<string, Worker1> sortedDictionaryStringWorker1 = new SortedDictionary<string, Worker1>();

        public int count = 0;

        public TestCollections()
        {
            Console.WriteLine("Введите число элементов:");

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Worker1 w1 = new Worker1();

                do
                {
                    w1.RandomInit();
                } while (!Add(w1));
            }
        }

        public bool Add(Worker1 w1)
        {
            if (!sortedDictionaryPerson1Worker1.ContainsValue(w1))
            {
                Person1 p1 = w1.BasePerson1;

                string s = w1.ToString();

                queueWorker1.Enqueue(w1);

                queueString.Enqueue(s);

                sortedDictionaryPerson1Worker1.Add(p1, w1);

                sortedDictionaryStringWorker1.Add(s, w1);

                count++;

                return true;
            }

            return false;
        }

        public void Remove(Worker1 w1)
        {
            Queue<Worker1> tqw1 = new Queue<Worker1>();

            for(int i = 0; i < queueWorker1.Count; i++)
            {
                if (!(queueWorker1.Peek() == w1))
                {
                    tqw1.Enqueue(queueWorker1.Dequeue());
                }
            }

            queueWorker1 = tqw1;

            Queue<string> tqs = new Queue<string>();

            for (int i = 0; i < queueWorker1.Count; i++)
            {
                if (!(queueString.Peek() == w1.ToString()))
                {
                    tqs.Enqueue(queueString.Dequeue());
                }
            }

            queueString = tqs;

            sortedDictionaryPerson1Worker1.Remove(w1.BasePerson1);

            sortedDictionaryStringWorker1.Remove(w1.ToString());

            count = sortedDictionaryPerson1Worker1.Count;
        }

        public void QueueWorker1Find(Worker1 w1)
        {
            Stopwatch stopWatch = new Stopwatch();

            stopWatch.Start();

            if (!queueWorker1.Contains(w1))
            {
                Console.WriteLine("Не найдено");
            }

            stopWatch.Stop();

            TimeSpan ts = stopWatch.Elapsed;

            Console.WriteLine($"Поиск элемента в Queue<Worker1> занял {ts.TotalMilliseconds} миллисекунд");
        }

        public void QueueStringFind(string s)
        {
            Stopwatch stopWatch = new Stopwatch();

            stopWatch.Start();

            if (!queueString.Contains(s))
            {
                Console.WriteLine("Не найдено");
            }

            stopWatch.Stop();

            TimeSpan ts = stopWatch.Elapsed;

            Console.WriteLine($"Поиск элемента в Queue<string> занял {ts.TotalMilliseconds} миллисекунд");
        }

        public void SortedDictionaryPerson1Worker1Find(Person1 p1)
        {
            Stopwatch stopWatch = new Stopwatch();

            stopWatch.Start();

            if (!sortedDictionaryPerson1Worker1.ContainsKey(p1))
            {
                Console.WriteLine("Не найдено");
            }

            stopWatch.Stop();

            TimeSpan ts = stopWatch.Elapsed;

            Console.WriteLine($"Поиск элемента в SortedDictionary<Person1, Worker1> по ключу занял {ts.TotalMilliseconds} миллисекунд");
        }

        public void SortedDictionaryPerson1Worker1Find(Worker1 w1)
        {
            Stopwatch stopWatch = new Stopwatch();

            stopWatch.Start();

            if(!sortedDictionaryPerson1Worker1.ContainsValue(w1))
            {
                Console.WriteLine("Не найдено");
            }

            stopWatch.Stop();

            TimeSpan ts = stopWatch.Elapsed;

            Console.WriteLine($"Поиск элемента в SortedDictionary<Person1, Worker1> по значению занял {ts.TotalMilliseconds} миллисекунд");
        }

        public void SortedDictionaryStringWorker1Find(string s)
        {
            Stopwatch stopWatch = new Stopwatch();

            stopWatch.Start();

            if (!sortedDictionaryStringWorker1.ContainsKey(s))
            {
                Console.WriteLine("Не найдено");
            }

            stopWatch.Stop();

            TimeSpan ts = stopWatch.Elapsed;

            Console.WriteLine($"Поиск элемента в SortedDictionary<string, Worker1> по ключу занял {ts.TotalMilliseconds} миллисекунд");
        }
    }
}
