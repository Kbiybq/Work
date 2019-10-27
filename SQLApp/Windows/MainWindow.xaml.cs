using System;
using System.Windows;


namespace SQLApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowVM();
        }

        private void StackPanel_GotFocus(object sender, RoutedEventArgs e)
        {

        }

        private void DataTab_GotFocus(object sender, RoutedEventArgs e)
        {

        }
    }
}
