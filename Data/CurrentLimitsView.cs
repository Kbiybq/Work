using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    /// <summary>
    /// Класс для представления токовых ограничений по оборудованию
    /// </summary>
    public class CurrentLimitsView
    {
        /// <summary>
        /// Уникальный идентификационный номер
        /// </summary>
        public int IDEquipment { get; set; }
        /// <summary>
        /// Назваине оборудования (сегмента линии)
        /// </summary>
        public string EquipmentDispatchName { get; set; }

        /// <summary>
        /// АЙДИ токового ограничения
        /// </summary>
        public int IDCurrentDepend { get; set; }

        /// <summary>
        /// Тип токового ограничения
        /// </summary>
        public string TypeOfCurrentLoad { get; set; }

        /// <summary>
        /// Время допустимой токовой нагрузки
        /// </summary>
        public string AllowTime { get; set; }

        /// <summary>
        /// Температура
        /// </summary>
        public int Temp { get; set; }

        /// <summary>
        /// Токовое ограничение
        /// </summary>
        public int Current { get; set; }

        /// <summary>
        /// Поправочный коэффициент (отношение текущего значения тока к значению тока при 25 градусах)
        /// </summary>
        public double Kcorr { get; set; }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="id"></param>
        /// <param name="equipmentDispatchName"></param>
        /// <param name="typeOfCurrentLoad"></param>
        /// <param name="allowTime"></param>
        /// <param name="temp"></param>
        /// <param name="current"></param>
        /// <param name="kcorr"></param>
        public CurrentLimitsView(int id, string equipmentDispatchName, int iDCurrentDepend, string typeOfCurrentLoad,
            string allowTime, int temp, int current, double kcorr)
        {
            IDEquipment = id;
            EquipmentDispatchName = equipmentDispatchName;
            IDCurrentDepend = iDCurrentDepend;
            TypeOfCurrentLoad = typeOfCurrentLoad;
            AllowTime = allowTime;
            Temp = temp;
            Current = current;
            Kcorr = kcorr;
        }
    }
}
