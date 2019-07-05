using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    /// <summary>
    /// описание ЛЭП
    /// </summary>
    public class PowerLineDiscription : DataBase
    {
        #region Свойства

        /// <summary>
        /// Диспетчерское наименование оборудования
        /// </summary>
        public string DispatchName { get; set; }

        /// <summary>
        /// Уникальный идентификационный номер уровня напряжения
        /// </summary>
        public int IdVoltageLevel { get; set; }

        /// <summary>
        /// Уникальный идентификационный номер филиала в чьём управлении находится
        /// </summary>
        public int IdDispatchingCenterControl { get; set; }

        /// <summary>
        /// Уникальный идентификационный номер энергообъекта начала
        /// </summary>
        public int IdPowerFacilityStart { get; set; }

        /// <summary>
        /// Уникальный идентификационный номер энергообъекта конца
        /// </summary>
        public int IdPowerFacilityEnd { get; set; }

        /// <summary>
        /// Данные пользователя, который внёс информацию
        /// </summary>
        public string UserItem { get; set; }

        #endregion

        #region Конструкторы
        public PowerLineDiscription(int id, string dispatchName,
            int idVoltageLevel, int idDispatchingCenterControl,
            int idPowerFacilityStart, int idPowerFacilityEnd, string userItem)
            : base(id)
        {
            DispatchName = dispatchName;
            IdVoltageLevel = idVoltageLevel;
            IdDispatchingCenterControl = idDispatchingCenterControl;
            IdPowerFacilityStart = idPowerFacilityStart;
            IdPowerFacilityEnd = idPowerFacilityEnd;
            UserItem = userItem;
        }

        #endregion
    }
}
