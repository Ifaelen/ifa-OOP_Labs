using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Lab10_ClassesLib
{
    public class Worker : Person
    {
        protected int workExperience;

        public override int Age
        {
            get => base.Age;
            set
            {
                if(value < 18)
                {
                    throw new Exception("Стать рабочим можно только с 18 лет");
                }

                base.Age = value;
            }
            
        }

        public virtual int WorkExperience
        {
            get { return workExperience; }
            set
            {
                if(value > Age - 18 || value < 0)
                {
                    throw new Exception($"Рабочий стаж не может быть больше разницы нынешнего возраста и 18 и меньше 0");
                }
                else
                {
                    workExperience = value;
                }
            }
        }

        public Worker() { }

        public Worker(string name, int age, int workExperience)
        {
            Name = name;
            Age = age;
            WorkExperience = workExperience;
        }

        public Worker(Worker w)
        {
            Name = w.Name;
            Age = w.Age;
        }

        public override void Init()
        {
            Console.WriteLine("Ручной ввод данных (Worker)");
            Name = Console.ReadLine();
            Age = int.Parse(Console.ReadLine()); //
            WorkExperience = int.Parse(Console.ReadLine()); //
        }

        public override void RandomInit()
        {
            Random rand = new Random();

            Name = Person.namesList[rand.Next(0, Person.namesList.Length - 1)];
            Age = rand.Next(18, 79);
            WorkExperience = rand.Next(0, age - 18); //
        }

        public override bool Equals(object obj)
        {
            return obj is Worker w &&
                   name == w.name &&
                   age == w.age &&
                   workExperience == w.workExperience;
        }

        public override void Show()
        {
            Console.WriteLine($"Рабочий. Имя: {Name}, возраст: {Age} лет, стаж: {WorkExperience}");
        }

        public override int CompareTo(object obj)
        {
            return String.Compare(this.Name, (obj as Worker).Name);
        }

        public override object Clone()
        {
            return new Worker("Клон. "+this.Name, this.Age, this.WorkExperience);
        }

        public override Person ShallowCopy()
        {
            return (Person)this.MemberwiseClone();
        }

        public override int GetHashCode()
        {
            int hashCode = -93365974;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + Age.GetHashCode();
            hashCode = hashCode * -1521134295 + WorkExperience.GetHashCode();
            return hashCode;
        }
    }
}
