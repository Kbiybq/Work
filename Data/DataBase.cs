using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    /// <summary>
    /// базовый класс для всех данных
    /// </summary>
    public class DataBase
    {
        /// <summary>
        /// Уникальный идентификационный номер
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="id"></param>
        public DataBase (int id)
        {
            Id = id;
        }
    }
}
