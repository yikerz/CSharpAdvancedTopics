using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqToObjects
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public int UniversityId { get; set; }

        public void Print()
        {
            Console.WriteLine("Student {0} is a {1} year-old {2} studying in university with Id: {3}", Name, Age, Gender, UniversityId);
        }

    }
}
