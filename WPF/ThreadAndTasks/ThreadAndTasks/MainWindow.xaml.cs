using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
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

namespace ThreadAndTasks
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

        /*
        Since there is no await for the download statement, it is run synchronously, which means 
        the UI-thread is frozen and wait until the download is done.
        */
        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            HttpClient client = new HttpClient();
            /*
            Asynchronous method that involves different thread (non-UI thread)
            Since there is no await, the thread will not return back to the calling thread (UI-thread)
            To make sure `MyButton.Content="Downloaded"` is run in UI-thread, we need
            MyButton.Dispatcher.Invoke to make sure that the code inside is run in the MyButton thread
            */
            string url = client.GetStringAsync("https://link.testfile.org/PDF20MB").Result;
            MyButton.Dispatcher.Invoke(() =>
            {
                MyButton.Content = "Downloaded";
            });

        }

        private async void Button_Click2(object sender, RoutedEventArgs e)
        {
            HttpClient client = new HttpClient();
            /*
            With await, the thread will return to caller (UI-thread) after the state is done.
            In this case, we do not need Dispatcher.Invoke.
             */
            string url = await client.GetStringAsync("https://link.testfile.org/PDF20MB");
           
            MyButton.Content = "Downloaded";

        }

        private async void Button_Click3(object sender, RoutedEventArgs e)
        {
            /*
            Same as the above method, but this time we wrap the code with await Task. 
            */
            await Task.Run(() =>
            {
                HttpClient client = new HttpClient();
                string url = client.GetStringAsync("https://link.testfile.org/PDF20MB").Result;
            });
            
            MyButton.Content = "Downloaded";

        }
    }
}
