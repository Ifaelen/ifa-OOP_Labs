using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Lab11
{
    public class Person1 : IComparable
    {
        public static string[] namesList = new string[] { "Алексей", "Александр", "Александра", "Борис", "Василиса", "Григорий", "Даниил", "Денис", "Екатерина", "Игорь", "Илья", "Константин", "Людмила", "Максим" };

        protected string name;
        protected int age;

        public virtual string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public virtual int Age
        {
            get
            {
                return age;
            }

            set
            {
                if (value < 0)
                {
                    throw new Exception("Возраст не может быть отрицательным");
                }

                age = value;
            }
        }

        public Person1()
        {

        }

        public Person1(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public virtual void Init()
        {
            Console.WriteLine("Ручной ввод данных (Person1)");
            Name = Console.ReadLine();
            Age = int.Parse(Console.ReadLine()); //
        }

        public virtual void RandomInit()
        {
            Random rand = new Random();

            Name = Person1.namesList[rand.Next(0, Person1.namesList.Length - 1)];
            Age = rand.Next(0, 79);
        }

        public override bool Equals(object obj)
        {
            return obj is Person1 w &&
                   name == w.name &&
                   age == w.age;
        }

        public virtual void Show()
        {
            Console.WriteLine($"Персона (Person1). Имя: {Name}, возраст: {Age} лет");
        }

        public virtual int CompareTo(object obj)
        {
            return String.Compare(this.Name, (obj as Person1).Name);
        }

        public override string ToString()
        {
            return $"Person1{Name}{Age}";
        }

        public override int GetHashCode()
        {
            int hashCode = -1360180430;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + Age.GetHashCode();
            return hashCode;
        }
    }
}
