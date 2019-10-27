using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SQLApp
{
    /// <summary>
    /// Класс для ввода информации
    /// </summary>
    public static class Enter
    {
        /// <summary>
        /// Ввод только цифр в поле
        /// </summary>
        /// <param name="e"></param>
        public static void EnterOnlyNumber(TextCompositionEventArgs e)
        {
            if (!(Char.IsDigit(e.Text, 0)))
            {
                e.Handled = true;
            }
        }
    }
}
