using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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

namespace ZooManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection conn;
        public MainWindow()
        {
            InitializeComponent();

            string connectionString = ConfigurationManager.ConnectionStrings["ZooManager.Properties.Settings.PanjutorialsDBConnectionString"].ConnectionString;
            conn = new SqlConnection(connectionString);

            ShowZoos();
            ShowAllAnimals();
        }
        private void ShowZoos()
        {
            try
            {
                string query = "select * from Zoo";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);

                using (adapter)
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    listZoos.ItemsSource = dt.DefaultView;
                    listZoos.DisplayMemberPath = "Location";
                    listZoos.SelectedValuePath = "Id";
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void ShowAssociatedAnimals()
        {
            try
            {
                string query = "select * from Animal a inner join ZooAnimal za on a.Id=za.AnimalId where za.ZooId=@ZooId";
                SqlCommand command = new SqlCommand(query, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                using (adapter)
                {
                    command.Parameters.AddWithValue("@ZooId", listZoos.SelectedValue);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    listAssociatedAnimals.ItemsSource = dt.DefaultView;
                    listAssociatedAnimals.DisplayMemberPath = "Name";
                    listAssociatedAnimals.SelectedValuePath = "AnimalId";
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void ShowAllAnimals()
        {
            try
            {
                string query = "select * from Animal";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);

                using (adapter)
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    listAllAnimals.ItemsSource = dt.DefaultView;
                    listAllAnimals.DisplayMemberPath = "Name";
                    listAllAnimals.SelectedValuePath = "Id";
                }
            }
            catch (System.Exception ex)
            {

            }
        }

        private void listZoos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ShowAssociatedAnimals();
            ShowSelectedZooInTextBox();
        }

        private void DeleteZoo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string query = "delete from Zoo where Id=@ZooId";
                SqlCommand command = new SqlCommand(query, conn);
                conn.Open();
                command.Parameters.AddWithValue("@ZooId", listZoos.SelectedValue);
                command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
                ShowZoos();
            }
        }

        private void AddZoo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string query = "insert into Zoo values (@Location)";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                cmd.Parameters.AddWithValue("@Location", tbInput.Text);
                cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();
                ShowZoos();
            }
        }
        private void AddZooAnimal_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string query = "insert into ZooAnimal values (@ZooId, @AnimalId)";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                cmd.Parameters.AddWithValue("@ZooId", listZoos.SelectedValue);
                cmd.Parameters.AddWithValue("@AnimalId", listAllAnimals.SelectedValue);
                cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();
                ShowAssociatedAnimals();
            }
        }
        private void ShowSelectedZooInTextBox()
        {
            string query = "select * from Zoo where Id = @ZooId";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            using (adapter)
            {
                cmd.Parameters.AddWithValue("@ZooId", listZoos.SelectedValue);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                tbInput.Text = dt.Rows[0]["Location"].ToString();

            }
        }

        private void listAnimals_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ShowSelectedAnimalInTextBox();
        }

        private void ShowSelectedAnimalInTextBox()
        {
            string query = "select * from Animal where Id = @AnimalId";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            using (adapter)
            {
                cmd.Parameters.AddWithValue("@AnimalId", listAllAnimals.SelectedValue);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                tbInput.Text = dt.Rows[0]["Name"].ToString();
            }
        }

        private void UpdateZoo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string query = "update Zoo set Location=@Location where Id=@ZooId";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                cmd.Parameters.AddWithValue("@Location", tbInput.Text);
                cmd.Parameters.AddWithValue("@ZooId", listZoos.SelectedValue);
                cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();
                ShowZoos();
            }

        }
    }

}
