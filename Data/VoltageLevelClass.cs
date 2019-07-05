using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class VoltageLevelClass : DataBase
    {
        /// <summary>
        /// Уровень напряжения
        /// </summary>
        public int VoltageLevel { get; set; }

        #region Конструкторы
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="id"></param>
        /// <param name="NameDispatchingCenter"></param>
        public VoltageLevelClass(int id, int voltageLevel)
            : base(id)
        {
            VoltageLevel = voltageLevel;
        }

        #endregion

    }
}
