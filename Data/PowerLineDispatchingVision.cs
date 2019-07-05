using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    /// <summary>
    /// Описание у каких ДЦ в ведении находится ЛЭП
    /// </summary>
    public class PowerLineDispatchingVision : DataBase
    {
        #region Свойства

        /// <summary>
        /// Диспетчерское наименование оборудования
        /// </summary>
        public int IdDispatchingCenterVision { get; set; }

        #endregion

        #region Конструкторы
        
        public PowerLineDispatchingVision(int id, int idDispatchingCenterVision)
            : base(id)
        {
            IdDispatchingCenterVision = idDispatchingCenterVision;
        }

        #endregion

    }
}
