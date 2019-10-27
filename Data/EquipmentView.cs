using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    /// <summary>
    /// Класс для представления оборудования
    /// </summary>
    public class EquipmentView
    {
        #region Свойства

        /// <summary>
        /// Уникальный идентификационный номер
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// назавние энергообъекта, на котором установлено оборудование
        /// </summary>
        public string PowerFacility { get; set; }

        /// <summary>
        /// Класс оборудования
        /// </summary>
        public string ClassName { get; set; }

        /// <summary>
        /// Тип (марки) оборудования (провода)
        /// </summary>
        public string TypeName { get; set; }

        /// <summary>
        /// Диспетчерское наименование оборудования
        /// </summary>
        public string DispatchName { get; set; }

        /// <summary>
        /// Уникальный идентификационный номер ЛЭП к которой привязано
        /// </summary>
        public int PowerLineID { get; set; }

        /// <summary>
        /// Диспетчерское наименование ЛЭП
        /// </summary>
        public string PowerLineDispatchName { get; set; }

        #endregion

        #region Конструкторы

        public EquipmentView(int id, string powerFacility, string className, string typeName,
            string dispatchName, int powerLineID, string powerLineDispatchName)
        {
            ID = id;
            PowerFacility = powerFacility;
            ClassName = className;
            TypeName = typeName;
            DispatchName = dispatchName;
            PowerLineID = powerLineID;
            PowerLineDispatchName = powerLineDispatchName;
        }
        #endregion
    }
}
