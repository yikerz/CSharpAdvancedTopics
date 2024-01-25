### Setup Project

1. Create new WPF project with main window: height 450 width 525
2. create `DataGrid`
   1. horizontal align: left
   2. vertical align: top
   3. height 400
   4. margin 10
   5. width 500
3. open server explorer
4. create new table `University`
   1. id
   2. Name
5. Create new table `Student`
   1. id
   2. Name
   3. Gender
   4. UniversityId
   5. set up foreign key for university id (with on delete cascade)
6. create new table `Lecture`
   1. id
   2. Name
7. create new table `StudentLecture`
   1. id
   2. StudentId
   3. LectureId
   4. foreign keys for studentid and lectureid (on delete cascade)
8. Add new data source for the project
9. instantiate connectionString
10. Add new Linq to sql classes: LinqToSqlDataClasses.dbml
11. instantiate LinqToSqlDataClassesDataContext for the connnectionString

### Inserting Objects into DB

12. drag university class from solution explorer to dbml
13. create void method InsertUniversities in code behind
14. instantiate new university and its props
15. insert data using `dataContext.Universities.InsertOnSubmit()`
16. save data using `dataContext.SubmitChanges()`
17. set `ItemsSource` for the data grid to `dataContext.Universities`
18. run `InsertUniversities` method after initialize components in the constructor
19. add another university
20. at the beginning of the insert method, run delete query first `dataContext.ExecuteCommand("delete from University")`
21. create method `InsertStudent`
22. use `dataContext.Universities.First(lambda expression)` to find the first university matching the name
23. instantiate a list of student (remember to drag the student class into LinqToSQL class)
24. create a few students and add into the list
25. add into data context similar to step 15 but using `InsertAllOnSubmit`
26. save change as step 16 and set item source like step 17
27. create void method `InsertLectures`
28. drag lecture into LinqToSQLDataClasses and add a few lectures, insert to db, save changes and display to data grid

### Associative Table with Linq

29. drag and drop `StudentLecture` table
30. create void method `InsertStudentLectureAssociations`
31. get students and lectures similar to step 22
32. insert data into `dataContext.StudentLecture` using `InsertOnSubmit`
33. save change using `SubmitChanges` and set `ItemsSource`
34. create void method `DisplayUniversityByStudentName`
35. use step 22 to get student
36. instantiate universities list and add `student.University` into it
37. set the list as the `ItemsSource` (it only takes `IEnumerable)
38. create void method `DisplayLectureByStudentName` and try to use Linq command this time

### Join Table

39. create method `GetAllUniversitiesWithTransgenders` (use join...on...)
40. create method `GetAllLecturesFromMonash`

### Deleting and Updating

41. create method `UpdateStudent`
    1.  get `student` using step 22 (use `FirstOrDefault` instead of `First)
    2.  change the name of the student
    3.  use `SubmitChanges` to save the update
42. create method `DeleteStudent`
    1.  repeat step 41.1
    2.  use `dataContext.Students.DeleteOnSubmit(student)`
    3.  repeat step 41.3
    4.  set data grid. reset connection string before it if the student still exists (step 11)
