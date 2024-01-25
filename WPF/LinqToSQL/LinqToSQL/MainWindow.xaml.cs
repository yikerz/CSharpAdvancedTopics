using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Configuration;

namespace LinqToSQL
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        LinqToSqlDataClassesDataContext dataContext;
        public MainWindow()
        {
            InitializeComponent();
            string connectionString = ConfigurationManager.ConnectionStrings["LinqToSQL.Properties.Settings.PanjutorialsDBConnectionString"].ConnectionString;
            dataContext = new LinqToSqlDataClassesDataContext(connectionString);

            InsertUniversities();
            InsertStudents();
            InsertLectures();
            InsertStudentLectureAssociations();
            DisplayUniversityByStudentName("Travis");
            DisplayLecturesByStudentName("Travis");
            GetAllUniversitiesWithTransgenders();
            GetAllLecturesFromMonash();
            UpdateStudent();
            DeleteStudent();
        }
        // use DataContext object to insert data one by one
        public void InsertUniversities()
        {
            dataContext.ExecuteCommand("delete from University");
            University yale = new University
            {
                Name = "Yale",
            };
            University monash = new University
            {
                Name = "Monash"
            };
            University deakin = new University
            {
                Name = "Deakin"
            };
            dataContext.Universities.InsertOnSubmit(yale);
            dataContext.Universities.InsertOnSubmit(monash);
            dataContext.Universities.InsertOnSubmit(deakin);
            dataContext.SubmitChanges();

            myDataGrid.ItemsSource = dataContext.Universities;
        }
        // use DataContext object to insert list of data
        public void InsertStudents()
        {
            dataContext.ExecuteCommand("delete from Student");

            University yale = dataContext.Universities.First(uni => uni.Name.Equals("Yale"));
            University monash = dataContext.Universities.First(uni => uni.Name.Equals("Monash"));
            University deakin = dataContext.Universities.First(uni => uni.Name.Equals("Deakin"));

            List<Student> students = new List<Student>();
            students.Add(new Student{ Name = "Travis", Gender = "male", UniversityId = monash.Id });
            students.Add(new Student{ Name = "Peter", Gender = "male", UniversityId = yale.Id });
            students.Add(new Student{ Name = "Carmen", Gender = "female", UniversityId = monash.Id });
            students.Add(new Student{ Name = "Nick", Gender = "male", UniversityId = yale.Id });
            students.Add(new Student{ Name = "Chris", Gender = "transgender", UniversityId = deakin.Id });
            students.Add(new Student{ Name = "Nat", Gender = "transgender", UniversityId = deakin.Id });
            students.Add(new Student{ Name = "Horvath", Gender = "transgender", UniversityId = deakin.Id });

            dataContext.Students.InsertAllOnSubmit(students);
            dataContext.SubmitChanges();
            myDataGrid.ItemsSource = students;
        }
        // use DataContext object to insert data
        public void InsertLectures()
        {
            dataContext.ExecuteCommand("delete from Lecture");
            
            dataContext.Lectures.InsertOnSubmit(new Lecture { Name = "Math" });
            dataContext.Lectures.InsertOnSubmit(new Lecture { Name = "Physics" });
            dataContext.Lectures.InsertOnSubmit(new Lecture { Name = "English" });
            dataContext.SubmitChanges();

            myDataGrid.ItemsSource = dataContext.Lectures;
        }
        // use DataContext object to insert data for associative table
        public void InsertStudentLectureAssociations()
        {
            Student travis = dataContext.Students.First(st => st.Name.Equals("Travis"));
            Student peter = dataContext.Students.First(st => st.Name.Equals("Peter"));
            Student carmen = dataContext.Students.First(st => st.Name.Equals("Carmen"));
            Student nick = dataContext.Students.First(st => st.Name.Equals("Nick"));
            Student chris = dataContext.Students.First(st => st.Name.Equals("Chris"));
            Student nat = dataContext.Students.First(st => st.Name.Equals("Nat"));
            Student horvath = dataContext.Students.First(st => st.Name.Equals("Horvath"));

            Lecture math = dataContext.Lectures.First(lec => lec.Name.Equals("Math"));
            Lecture physics = dataContext.Lectures.First(lec => lec.Name.Equals("Physics"));
            Lecture english = dataContext.Lectures.First(lec => lec.Name.Equals("English"));

            dataContext.StudentLectures.InsertOnSubmit(new StudentLecture { Student=travis, Lecture=physics });
            dataContext.StudentLectures.InsertOnSubmit(new StudentLecture { Student= carmen, Lecture=physics });
            dataContext.StudentLectures.InsertOnSubmit(new StudentLecture { Student= peter, Lecture= math });
            dataContext.StudentLectures.InsertOnSubmit(new StudentLecture { Student= nick, Lecture= math });
            dataContext.StudentLectures.InsertOnSubmit(new StudentLecture { Student= chris, Lecture= english });
            dataContext.StudentLectures.InsertOnSubmit(new StudentLecture { Student= nat, Lecture= english });
            dataContext.StudentLectures.InsertOnSubmit(new StudentLecture { Student= horvath, Lecture= english });

            dataContext.SubmitChanges();
            myDataGrid.ItemsSource = dataContext.StudentLectures;
        }
        // use DataContext object to get the first element matching a given condition
        public void DisplayUniversityByStudentName(string studentName)
        {
            Student student = dataContext.Students.First(st => st.Name.Equals(studentName));
            University university = student.University;

            List<University> universities = new List<University>() { university };
            myDataGrid.ItemsSource = universities;
        }
        // use Linq to DataContext
        public void DisplayLecturesByStudentName(string studentName)
        {
            var lectures = from sl in dataContext.StudentLectures
                           where sl.Student.Name.Equals(studentName)
                           select sl.Lecture;
            myDataGrid.ItemsSource = lectures;
        }
        // join table in Linq
        public void GetAllUniversitiesWithTransgenders()
        {
            var universities = from student in dataContext.Students
                               join university in dataContext.Universities
                               on student.University equals university
                               where student.Gender.Equals("transgender")
                               select university;
            myDataGrid.ItemsSource = universities;
        }
        // join multiple tables in Linq
        public void GetAllLecturesFromMonash()
        {
            var lectures = from student in dataContext.Students
                           join university in dataContext.Universities
                           on student.University equals university
                           join sl in dataContext.StudentLectures
                           on student.Id equals sl.StudentId
                           join lecture in dataContext.Lectures
                           on sl.Lecture equals lecture
                           where university.Name.Equals("Monash")
                           select lecture;

            myDataGrid.ItemsSource = lectures;
        }
        // use DataContext to update database
        public void UpdateStudent()
        {
            Student travis = dataContext.Students.FirstOrDefault(st => st.Name.Equals("Travis"));
            travis.Name = "Darren";
            dataContext.SubmitChanges();

            myDataGrid.ItemsSource = dataContext.Students;
        }
        // use DataContext to delete database
        public void DeleteStudent()
        {
            Student darren = dataContext.Students.FirstOrDefault(st => st.Name.Equals("Darren"));
            dataContext.Students.DeleteOnSubmit(darren);
            dataContext.SubmitChanges();

            string connectionString = ConfigurationManager.ConnectionStrings["LinqToSQL.Properties.Settings.PanjutorialsDBConnectionString"].ConnectionString;
            dataContext = new LinqToSqlDataClassesDataContext(connectionString);

            myDataGrid.ItemsSource = dataContext.Students;
        }
    }
}
