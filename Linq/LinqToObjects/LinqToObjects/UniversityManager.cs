using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqToObjects
{
    public class UniversityManager
    {
        List<University> universities;
        List<Student> students;

        public UniversityManager()
        {
            universities = new List<University>();
            students = new List<Student>();

            universities.Add(new University { Id = 0, Name = "Melbourne University" });
            universities.Add(new University { Id = 1, Name = "Victoria University" });
            universities.Add(new University { Id = 2, Name = "Monash University" });

            students.Add(new Student{ Id=0, Name="Travis", Age=22, Gender="male", UniversityId=0 });
            students.Add(new Student{ Id=1, Name="Jazz", Age=20, Gender="female", UniversityId=0 });
            students.Add(new Student{ Id=2, Name="Harrison", Age=21, Gender="male", UniversityId=1 });
            students.Add(new Student{ Id=3, Name="Nick", Age=23, Gender="male", UniversityId=2 });
        }

        // example of where clause
        public void MaleStudents()
        {
            IEnumerable<Student> maleStudents = from student in students
                                                where student.Gender == "male"
                                                select student;
            foreach (Student student in maleStudents)
            {
                Console.WriteLine(student.Name);
            }
        }

        // example of where clause
        public void FemaleStudents()
        {
            IEnumerable<Student> femaleStudents = from student in students
                                                  where student.Gender == "female"
                                                  select student;
            foreach(Student student in femaleStudents)
            {
                Console.WriteLine(student.Name);
            }
        }

        // example of order by clause
        public void SortedStudentsByAge()
        {
            var sortedStudents = from student in students
                                 orderby student.Age
                                 select student;
            foreach (Student student in sortedStudents)
            {
                student.Print();
            }
        }

        // example of join table
        public void MelbUniStudents()
        {
            var melbStudents = from student in students
                               join university in universities
                               on student.UniversityId equals university.Id
                               where university.Name == "Melbourne University"
                               select student;
            foreach (Student student in melbStudents)
            {
                student.Print();
            }
        }

        public void StudentsByUniId(int uniId)
        {
            IEnumerable<Student> studentsByUni = from student in students
                                                 where student.UniversityId == uniId
                                                 select student;
            foreach (Student student in  studentsByUni)
            {
                student.Print();
            }
        }

        // example of creating new collection with two tables
        public void StudentWithUniversityName()
        {
            var studentAndUni = from student in students
                                join university in universities
                                on student.UniversityId equals university.Id
                                select new
                                {
                                    StudentName = student.Name,
                                    UniversityName = university.Name
                                };
            foreach (var dr in studentAndUni)
            {
                Console.WriteLine("{0} is in {1}", dr.StudentName, dr.UniversityName);
            }

        }
    }
}
