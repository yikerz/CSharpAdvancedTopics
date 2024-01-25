using System.Xml.Linq;

namespace LinqWithXML
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string studentsXML =
                        @"<Students>
                            <Student>
                                <Name>Toni</Name>
                                <Age>21</Age>
                                <University>Yale</University>
                                <Semester>6</Semester>
                            </Student>
                            <Student>
                                <Name>Carla</Name>
                                <Age>17</Age>
                                <University>Yale</University>
                                <Semester>1</Semester>
                            </Student>
                            <Student>
                                <Name>Leyla</Name>
                                <Age>19</Age>
                                <University>Beijing Tech</University>
                                <Semester>3</Semester>
                            </Student>
                            <Student>
                                <Name>Frank</Name>
                                <Age>25</Age>
                                <University>Beijing Tech</University>
                                <Semester>10</Semester>
                            </Student>
                        </Students>";

            XDocument xmlDoc = new XDocument();
            xmlDoc = XDocument.Parse(studentsXML);

            var students = from student in xmlDoc.Descendants("Student")
                           select new 
                           { 
                               Name = student.Element("Name").Value,
                               Age = student.Element("Age").Value,
                               University = student.Element("University").Value,
                               Semester = student.Element("Semester").Value
                           };
            foreach ( var student in students )
            {
                Console.WriteLine("Student {0} is {1} year-old studying in {2} in the {3} Semester.", 
                    student.Name, student.Age, student.University, student.Semester);
            }

            Console.WriteLine("-----------------------------------");

            var sortedStudents = from student in students
                                 orderby student.Age descending
                                 select student;
            foreach (var student in sortedStudents)
            {
                Console.WriteLine("Student {0} is {1} year-old studying in {2} in the {3} Semester.",
                    student.Name, student.Age, student.University, student.Semester);
            }

        }
    }
}
