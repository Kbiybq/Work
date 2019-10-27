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

namespace SQLApp
{
    /// <summary>
    /// Логика взаимодействия для AddEquipmentType.xaml
    /// </summary>
    public partial class AddEquipmentType : Window
    {
        public AddEquipmentType()
        {
            InitializeComponent();
            var vm = new AddEquipmentTypeVM();
            this.DataContext = vm;
            this.Loaded += (o, e) => vm.LoadData();
        }

        private void TextBoxIDType_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Enter.EnterOnlyNumber(e);
        }

        private void TextBoxInom_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Enter.EnterOnlyNumber(e);
        }


    }
}
