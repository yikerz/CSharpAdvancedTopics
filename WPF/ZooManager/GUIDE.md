### Setup VS For Database work

1. Open `View -> Server Explorer`
2. Create `New SQL Server Database` using `Data connections`
3. Copy and paste the server name from `Server Properties` in SSMS
4. Create new database name

### Setup Dataset and Table

5. In `Server Explorer`, select `Add New Table` under `Tables`
6. Create table `Zoo`:
   1. `Id`: Set `is Identity=True` in `Properties`
   2. `Location`: `nvarchar(50)`
7. Select `Show Table Data` and create new entries
8. Open `Data Sources` window for the new project
9. `Add New Data Source... -> Database -> Dataset`
10. Choose the database created in the last section as the data connection
11. Select `Yes, include sensitive data in the connection string`
12. Copy the connection string for later use
13. Include all tables in the Database objects
14. In `Data Sources` window, choose `Edit DataSet with Designer` to inspect the ERD
15. Right click `References` -> Add References -> `System.Configuration`
16. Include following lines in `MainWindow.xaml.cs`

```
public partial class MainWindow : Window
{
	SqlConnection conn;
	public MainWindow()
	{
		InitializeComponent();

		string connectionString = ConfigurationManager.ConnectionString[
					"<ProjectName>.Properties.Settings.<StringCopied>"]
					.ConnectionString;
		conn = new SqlConnection(connectionString);
	}
}
```

### Relationship Between Tables

14. Create new table `Animal` following the steps 5-7
15. Create connection table `ZooAnimal` (`Id, ZooId, AnimalId`)
16. Right click `Open Table Definition` under `ZooAnimal` table and create Foreign Keys for `ZooId` and `AnimalId`
17. Add entries into `ZooAnimal`
18. In `Data Sources`, Right click DataSet -> `Configure Data Source with Wizard` -> Include new tables

### Show Data In ListBox

19. Create `Label` and `ListBox` in `MainWindow`
20. Create new private method `ShowZoos()` in `MainWindow`
    1.  Create string instance `query`
    2.  Create new `SqlDataAdapter` intake `query` and `conn` (Interface to make tables usable by C#)
    3.  Create `DataTable` and fill data using `SqlDataAdapter`

```
using(adapter)
{
	DataTable zooTable = new DataTable();
	adapter.fill(zooTable);

	<ListBoxName>.ItemsSource = zooTable.DefaultView; // source to be used
	<ListBoxName>.DisplayMemberPath = "Location"; // what to display
	<ListBoxName>.SelectedValuePath = "Id"; // value behind the scene
}
```

21. Run `ShowZoos()` in `MainWindow` constructor
22. (Optional but recommended) Wrap everything in `ShowZoos` with `try...catch...`

### Show Associated Data

23. In `MainWindow.xaml`, create another set of label (Associated Animals List) and list box
24. Create new private method `ShowAssociatedAnimals` similar to `ShowZoos`
25. Modify the query to get all animal for a specific zoo (Hint: `za.ZooId=@ZooId`)
26. Since we use variable `@ZooId` in the query, we need to convert the string into `SqlCommand` object before passing to the adapter
27. Inside `using(adapter)`, we need to add parameter value to `@ZooId`:
    `sqlCommand.Parameters.AddWithValue("@ZooId", listZoos.SelectedValue)`
28. Implement event handler for `listZoos` selection change -> run `ShowAssociatedAnimals`

### Show All Animals

29. Add another `ListBox` to display all animals

### Create Delete Button

30. Create buttons `Delete Zoo`, `Remove Animal`, `Add Zoo`, `Add Animal`, `Update Zoo`, `Update Animal Zoo`, `Delete Animal`, `Add Animal to Zoo`
31. Define string query for deletion and create `SqlCommand` object (similar to step 25-26)
32. Try using another method instead of `adapter` to run query

```
conn.Open();
command.Parameters.AddWithValue("@ZooId", listZoos.SelectedValue);
command.ExecuteScalar();
conn.Close();
ShowZoos(); // re-render the zoo list after deletion
```

33. In Table definition of `ZooAnimal`, add `ON DELETE CASCADE` to the foreign keys (remember to update the database)
34. Put everything inside `try...catch...finally...` and make sure that `conn.close` should be in the `finally` block

### Create Add Button

##### Add Zoo Click

35. Replicate step 30-34 for `AddZoo_Click`
36. Change query to `insert into Zoo values (@Location);`
37. Modify `command.Parameters.AddWithValue` with proper params

##### Add Animal To Zoo

38. Replicate step 30-34 for `AddAnimalToZoo_Click`
39. Change query to `insert into ZooAnimal values (@ZooId, @AnimalId);`
40. Modify `command.Parameters.AddWithValue` with proper params
41. Run `ShowAssociatedAnimals` in the `finally` block

##### Add All Delete buttons

42. Do the similar things for all deletion buttons

### Updating Entries In Table

##### Selection Change for Zoo List

43. Implement method`ShowSelectedZooInTextBox` (display text in text box when selected change in zoo list)
44. Create SQL query `select * from Zoo where Id=@ZooId`
45. Use either `adapter` or `conn.Open()` to send query to DB
46. Update text in the text box
    `tbInput.Text = dt.Rows[0]["Location"].ToString();`
47. Run `ShowSelectedZooInTextBox` in `listZoos_SelectionChanged`

##### Selection Change for Animal List

48. Replicate the step above for animal list

##### Update Zoo Click

49. Create method `UpdateZoo_Click` by replicating `AddZoo_Click`
50. Change the query to `update Zoo Set Location=@Location where Id=@ZooId`
51. Change the parameters to proper values
52. Run `ShowZoos()` in the `finally` block
