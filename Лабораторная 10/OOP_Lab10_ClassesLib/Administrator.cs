using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Lab10_ClassesLib
{
    public class Administrator : Worker
    {
        public override int Age
        {
            get => base.Age;
            set
            {
                if (value < 27)
                {
                    throw new Exception("Стать администратором можно только с 27 лет");
                }

                base.Age = value;
            }
        }

        public Administrator() { }

        public Administrator(string name, int age, int workExperience)
        {
            Name = name;
            Age = age;
            WorkExperience = workExperience;
        }

        public Administrator(Engineer a)
        {
            Name = a.Name;
            Age = a.Age;
            WorkExperience = a.WorkExperience;
        }

        public override void Init()
        {
            Console.WriteLine("Ручной ввод данных (Administrator)");
            Name = Console.ReadLine();
            Age = int.Parse(Console.ReadLine()); //
            WorkExperience = int.Parse(Console.ReadLine()); //
        }

        public override void RandomInit()
        {
            Random rand = new Random();

            Name = Person.namesList[rand.Next(0, Person.namesList.Length - 1)];
            Age = rand.Next(27, 79); //
            WorkExperience = rand.Next(1, age - 27); //
        }

        public override bool Equals(object obj)
        {
            return obj is Administrator a &&
                   name == a.name &&
                   age == a.age &&
                   workExperience == a.workExperience;
        }

        public override void Show()
        {
            Console.WriteLine($"Администратор. Имя: {Name}, возраст: {Age} лет, стаж: {WorkExperience}");
        }

        public override int GetHashCode()
        {
            int hashCode = 292637772;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + Age.GetHashCode();
            hashCode = hashCode * -1521134295 + WorkExperience.GetHashCode();
            return hashCode;
        }
    }
}
