using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    /// <summary>
    /// Класс описания диспетчерского центра
    /// </summary>
    public class DispatchingCenter : DataBase
    {

        /// <summary>
        /// Название ДЦ
        /// </summary>
        public string NameDispatchingCenter { get; set; }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="id"></param>
        /// <param name="NameDispatchingCenter"></param>
        public DispatchingCenter(int id, string nameDispatchingCenter)
            : base (id)
        {
            NameDispatchingCenter = nameDispatchingCenter;
        }
    }
}
