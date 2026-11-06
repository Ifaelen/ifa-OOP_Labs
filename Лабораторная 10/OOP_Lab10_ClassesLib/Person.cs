using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Lab10_ClassesLib
{
    public abstract class Person : IInit, IComparable, ICloneable
    {
        public static string[] namesList = new string[] { "Алексей", "Александр", "Александра", "Борис", "Василиса", "Григорий", "Даниил", "Денис", "Екатерина", "Игорь", "Илья", "Константин", "Людмила", "Максим" };

        protected string name;
        protected int age;

        public virtual string Name
        {
            get { return name; }
            set
            {
                name = value;
            }
        }

        public virtual int Age
        {
            get { return age; }
            set
            {
                if(value < 0)
                {
                    throw new Exception("Возраст не может быть отрицательным");
                }

                age = value;
            }

        }

        public abstract void Init();

        public abstract void RandomInit();

        public abstract int CompareTo(object obj);

        public abstract void Show();

        public abstract object Clone();

        public abstract Person ShallowCopy();
    }
}
