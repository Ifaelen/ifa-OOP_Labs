using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Lab10_ClassesLib
{
    public class SortByAge : IComparer
    {
        public int Compare(object o1, object o2)
        {
            Person p1 = o1 as Person;
            Person p2 = o2 as Person;

            if (p1.Age > p2.Age)
            {
                return 1;
            }
            else if (p1.Age == p2.Age)
            {
                return 0;
            }

            return -1;
        }
    }
}
