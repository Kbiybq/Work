using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    /// <summary>
    /// Класс для представления ЛЭП
    /// </summary>
    public class PowerLineView
    {
        #region Свойства

        /// <summary>
        /// Уникальный идентификационный номер
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Диспетчерское наименование оборудования
        /// </summary>
        public string DispatchName { get; set; }

        /// <summary>
        /// Уровень напряжения
        /// </summary>
        public int VoltageLevel { get; set; }

        /// <summary>
        /// Филиал в чьём управлении находится
        /// </summary>
        public string DispatchingCenterControl { get; set; }

        /// <summary>
        /// Филиал/филиалы в чьём ведении находится
        /// </summary>
        public List<string> DispatchingCenterVision { get; set; }

        /// <summary>
        /// Энергообъект начала
        /// </summary>
        public string PowerFacilityStart { get; set; }

        /// <summary>
        /// Энергообъект конца
        /// </summary>
        public string PowerFacilityEnd { get; set; }

        /// <summary>
        /// Данные пользователя, который внёс информацию
        /// </summary>
        public string UserItem { get; set; }

        #endregion

        #region Конструкторы
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dispatchName"></param>
        /// <param name="voltageLevel"></param>
        /// <param name="dispatchingCenterControl"></param>
        /// <param name="powerFacilityStart"></param>
        /// <param name="powerFacilityEnd"></param>
        /// <param name="userItem"></param>
        public PowerLineView(int id, string dispatchName, int voltageLevel, string dispatchingCenterControl,
            List<string> dispatchingCenterVision,
            string powerFacilityStart, string powerFacilityEnd, string userItem)
        {
            ID = id;
            DispatchName = dispatchName;
            VoltageLevel = voltageLevel;
            DispatchingCenterControl = dispatchingCenterControl;
            DispatchingCenterVision = dispatchingCenterVision;
            PowerFacilityStart = powerFacilityStart;
            PowerFacilityEnd = powerFacilityEnd;
            UserItem = userItem;
        }

        #endregion
    }
}