using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class PowerFacility : DataBase
    {
        #region Свойства

        /// <summary>
        /// Диспетчерское наименование энергообъекта
        /// </summary>
        public string DispatchName { get; set; }

        #endregion

        #region Конструкторы
        
        public PowerFacility(int id, string dispatchName)
            : base(id)
        {
            DispatchName = dispatchName;
        }


        #endregion
    }
}
