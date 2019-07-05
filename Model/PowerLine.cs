using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class PowerLine
    {
        #region Поля

        public int Id;

        public string DispatchName;

        public int IdDispatchingCenterControl;

        //public int IdDispatchingCenterVision;

        public int IdPowerFacilityStart;

        public int IdPowerFacilityEnd;

        public string UserItem;

        #endregion

        #region Конструкторы
        public PowerLine(int id, string dispatchName, int idDispatchingCenterControl,
            /*int idDispatchingCenterVision,*/ int idPowerFacilityStart, 
            int idPowerFacilityEnd, string userItem)
        {
            Id = id;
            DispatchName = dispatchName;
            IdDispatchingCenterControl = idDispatchingCenterControl;
            //IdDispatchingCenterVision = idDispatchingCenterVision;
            IdPowerFacilityStart = idPowerFacilityStart;
            IdPowerFacilityEnd = idPowerFacilityEnd;
            UserItem = userItem;
        }

        public PowerLine()
        {
        }
        #endregion
    }
}
