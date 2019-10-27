using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    /// <summary>
    /// Класс для представления типов оборудования
    /// </summary>
    public class EquipmentTypeView
    {
        #region Свойства

        /// <summary>
        /// Уникальный идентификационный номер
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Название класса оборудования
        /// </summary>
        public string ClassName { get; set; }

        /// <summary>
        /// Название типа (марки) оборудования (провода)
        /// </summary>
        public string TypeName { get; set; }

        /// <summary>
        /// Уровень напряжения
        /// </summary>
        public int VoltageLevel { get; set; }

        /// <summary>
        /// Номинальный ток 
        /// </summary>
        public int Inom { get; set; }

        #endregion

        #region Конструкторы


        public EquipmentTypeView(int id, string className, string typeName,
            int voltageLevel, int inom)
        {
            ID = id;
            ClassName = className;
            TypeName = typeName;
            VoltageLevel = voltageLevel;
            Inom = inom;
        }
        #endregion
    }
}
