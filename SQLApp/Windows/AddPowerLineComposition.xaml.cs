using SQLApp.ViewModel;
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
using System.Windows.Shapes;

namespace SQLApp.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddPowerLine.xaml
    /// </summary>
    public partial class AddPowerLineComposition : Window
    {
        public AddPowerLineComposition()
        {
            InitializeComponent();
            DataContext = new AddPowerLineCompositionVM();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
        }

        private void TextBoxID_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Enter.EnterOnlyNumber(e);
        }
    }
}
