using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLApp.ViewModel
{
    /// <summary>
    /// Описание места установки оборудования в ЛЭП
    /// </summary>
    public class PositionInPowerLineVM
    {
        /// <summary>
        /// Имя элемента
        /// </summary>
        public static string Name { get; set; }

        /// <summary>
        /// Id места елемента
        /// </summary>
        public static int ElementPositionId { get; set; }

        /// <summary>
        /// Id места оборудования
        /// </summary>
        public static int EquipmentPositionId { get; set; }

        public PositionInPowerLineVM(string name, int elementPositionId, int equipmentPositionId)
        {
            Name = name;
            ElementPositionId = elementPositionId;
            EquipmentPositionId = equipmentPositionId;
        }
    }
}
