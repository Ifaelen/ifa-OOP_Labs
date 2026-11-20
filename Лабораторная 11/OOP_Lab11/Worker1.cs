using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Lab11
{
    public class Worker1 : Person1
    {
        public override int Age
        {
            get
            {
                return age;
            }

            set
            {
                if (value < 18)
                {
                    throw new Exception("Работать можно только с 18 лет");
                }

                age = value;
            }
        }

        public Person1 BasePerson1
        {
            get
            {
                return new Person1(name, age);
            }
        }

        public Worker1()
        {

        }

        public Worker1(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public override void Init()
        {
            Console.WriteLine("Ручной ввод данных (Worker1)");
            Name = Console.ReadLine();
            Age = int.Parse(Console.ReadLine()); //
        }

        public override void RandomInit()
        {
            Random rand = new Random();

            Name = Person1.namesList[rand.Next(0, Person1.namesList.Length - 1)];
            Age = rand.Next(18, 79);
        }

        public override bool Equals(object obj)
        {
            return obj is Worker1 w &&
                   name == w.name &&
                   age == w.age;
        }

        public override void Show()
        {
            Console.WriteLine($"Рабочий (Worker1). Имя: {Name}, возраст: {Age} лет");
        }

        public override int CompareTo(object obj)
        {
            return String.Compare(this.Name, (obj as Worker1).Name);
        }

        public override string ToString()
        {
            return $"Worker1{Name}{Age}";
        }

        public override int GetHashCode()
        {
            int hashCode = -928918728;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + Age.GetHashCode();
            return hashCode;
        }
    }
}
