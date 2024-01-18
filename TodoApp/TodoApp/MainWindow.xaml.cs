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

namespace TodoApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddTodoButton_Click(object sender, RoutedEventArgs e)
        {
            string TodoInput = tbToDoInput.Text;
            TextBlock newTodoItem = new TextBlock
            {
                Text = TodoInput,
                Foreground = new SolidColorBrush(Colors.White),
                Margin = new Thickness(10)
            };
            spTodoList.Children.Add(newTodoItem);
            tbToDoInput.Clear();
        }
    }
}
