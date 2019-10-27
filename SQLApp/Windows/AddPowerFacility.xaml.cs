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
    /// Логика взаимодействия для AddPowerFacility.xaml
    /// </summary>
    public partial class AddPowerFacility : Window
    {
        public AddPowerFacility()
        {
            InitializeComponent();
            var vm = new AddPowerFacilityVM();
            this.DataContext = vm;
            this.Loaded += (o, e) => vm.LoadData();
        }

        private void TextBoxID_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Enter.EnterOnlyNumber(e);
        }
    }
}
