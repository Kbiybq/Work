using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    /// <summary>
    /// Описание типов токового ограничения
    /// </summary>
    public class CurrentDepend : DataBase
    {
        /// <summary>
        /// Тип токового ограничения
        /// </summary>
        public string TypeOfCurrentLoad { get; set; }

        /// <summary>
        /// Время допустимой токовой нагрузки
        /// </summary>
        public string AllowTime { get; set; }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="id"></param>
        /// <param name="typeOfCurrentLoad"></param>
        /// <param name="allowTime"></param>
        public CurrentDepend(int id, string typeOfCurrentLoad, string allowTime)
            : base(id)
        {
            TypeOfCurrentLoad = typeOfCurrentLoad;
            AllowTime = allowTime;
        }
    }
}
