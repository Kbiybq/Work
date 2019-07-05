using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    /// <summary>
    /// Описание допустимой токовой нагрузки оборудования (сегмента линии)
    /// </summary>
    public class TCurrentDepend : DataBase
    {
        /// <summary>
        /// Уникальный идентификационный номер оборудования (сегмента линии)
        /// </summary>
        public int IdEquipment { get; set; }

        /// <summary>
        /// Температура
        /// </summary>
        public int Temp { get; set; }

        /// <summary>
        /// Токовое ограничение
        /// </summary>
        public int I { get; set; }

        /// <summary>
        /// Поправочный коэффициент (отношение текущего значения тока к значению тока при 25 градусах)
        /// </summary>
        public int Kcorr { get; set; }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="id"></param>
        /// <param name="typeOfCurrentLoad"></param>
        /// <param name="allowTime"></param>
        public TCurrentDepend(int id, int idEquipment, int temp, int i, int kcorr)
            : base(id)
        {
            Id = id;
            IdEquipment = idEquipment;
            Temp = temp;
            I = i;
            Kcorr = kcorr;
        }
    }
}
