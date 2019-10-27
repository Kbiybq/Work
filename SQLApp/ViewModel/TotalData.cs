using Data;
using SQLApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLApp
{
    /// <summary>
    /// Класс общих данных
    /// </summary>
    public static class TotalData
    {
        /// <summary>
        /// Коллекция класса диспетчерских центров
        /// </summary>
        public static ObservableCollection<DispatchingCenter> CollectionDispatchingCenter { get; set; } =
            new ObservableCollection<DispatchingCenter>();

        /// <summary>
        /// Коллекция класса уровней напряжения
        /// </summary>
        public static ObservableCollection<VoltageLevel> CollectionVoltageLevel { get; set; } =
            new ObservableCollection<VoltageLevel>();

        /// <summary>
        /// Коллекция класса описания ЛЭП
        /// </summary>
        public static ObservableCollection<PowerLineDiscription> CollectionPowerLineDiscription { get; set; } =
            new ObservableCollection<PowerLineDiscription>();

        /// <summary>
        /// Последнее добавленное описание ЛЭП
        /// </summary>
        public static PowerLineDiscription NewPowerLineDiscription { get; set; } =
            new PowerLineDiscription();

        /// <summary>
        /// Коллекция класса описание диспетчерского ведения
        /// </summary>
        public static ObservableCollection<PowerLineDispatchingVision> CollectionPowerLineDVision { get; set; } =
            new ObservableCollection<PowerLineDispatchingVision>();

        /// <summary>
        /// Коллекция класса ЛЭП
        /// </summary>
        public static ObservableCollection<PowerLineView> CollectionPowerLineView { get; set; } =
            new ObservableCollection<PowerLineView>();

        /// <summary>
        /// Коллекция класса Энергообъектов
        /// </summary>
        public static ObservableCollection<PowerFacility> CollectionPowerFacility { get; set; } =
            new ObservableCollection<PowerFacility>();

        /// <summary>
        /// Последний добавленный энергоообъект
        /// </summary>
        public static PowerFacility NewPowerFacility { get; set; } =
            new PowerFacility();

        /// <summary>
        /// Коллекция класса описание типов токового ограничения
        /// </summary>
        public static ObservableCollection<CurrentDepend> CollectionCurrentDepend { get; set; } =
            new ObservableCollection<CurrentDepend>();

        /// <summary>
        /// Коллекция класса описание допустимой токовой нагрузки оборудования (сегмента линии)
        /// </summary>
        public static ObservableCollection<TCurrentDepend> CollectionTCurrentDepend { get; set; } =
            new ObservableCollection<TCurrentDepend>();

        /// <summary>
        /// Последнее добавленное токовое ограничение
        /// </summary>
        public static TCurrentDepend NewTCurrentDepend { get; set; } =
            new TCurrentDepend();


        /// <summary>
        /// Коллекция токовых огрничений одного оборудования
        /// </summary>
        public static ObservableCollection<TCurrentDepend> CollectionEquipmentTCurrentDepend { get; set; } =
            new ObservableCollection<TCurrentDepend>();

        /// <summary>
        /// Коллекция класса токовых ограничений
        /// </summary>
        public static ObservableCollection<CurrentLimitsView> CollectionCurrentLimitsView { get; set; } =
            new ObservableCollection<CurrentLimitsView>();

        /// <summary>
        /// Коллекция класса классов оборудования
        /// </summary>
        public static ObservableCollection<EquipmentClass> CollectionEquipmentClass { get; set; } =
            new ObservableCollection<EquipmentClass>();

        /// <summary>
        /// Коллекция класса типов оборудования
        /// </summary>
        public static ObservableCollection<EquipmentType> CollectionEquipmentType { get; set; } =
            new ObservableCollection<EquipmentType>();

        /// <summary>
        /// Последний добавленный тип оборудования
        /// </summary>
        public static EquipmentType NewEquipmentType { get; set; } =
            new EquipmentType();

        /// <summary>
        /// Коллекция класса типов оборудования для представления
        /// </summary>
        public static ObservableCollection<EquipmentTypeView> CollectionEquipmentTypeView { get; set; } =
            new ObservableCollection<EquipmentTypeView>();

        /// <summary>
        /// Коллекция класса оборудования
        /// </summary>
        public static ObservableCollection<Equipment> CollectionEquipment { get; set; } =
            new ObservableCollection<Equipment>();

        /// <summary>
        /// Последнее добавленное оборудование
        /// </summary>
        public static Equipment NewEquipment { get; set; } =
            new Equipment();

        /// <summary>
        /// Коллекция класса оборудования для представления
        /// </summary>
        public static ObservableCollection<EquipmentView> CollectionEquipmentView { get; set; } =
            new ObservableCollection<EquipmentView>();

        /// <summary>
        /// коллекция класса описания состава элементов, из которых состоит ЛЭП
        /// </summary>
        public static ObservableCollection<PowerLineComposition> CollectionPowerLineComposition { get; set; } =
            new ObservableCollection<PowerLineComposition>();

        /// <summary>
        /// Последнее добавленное оборудование в элемент
        /// </summary>
        public static PowerLineComposition NewPowerLineComposition { get; set; } =
            new PowerLineComposition();

        /// <summary>
        /// коллекция выбранных ДЦ
        /// </summary>
        public static ObservableCollection<DispatchingCenterWithChoiceVM> CollectionChecked { get; set; } =
            new ObservableCollection<DispatchingCenterWithChoiceVM>();

        /// <summary>
        /// Загруженная БД
        /// </summary>
        public static Current_infoDataContext Dp { get; set; } =
            new Current_infoDataContext();

        #region Методы
        /// <summary>
        /// Обновление данных из DataContext
        /// </summary>
        public static void UpdateDataFromDataContext()
        {
            FillDispatchingCenterCollection();
            FillVoltageLevelCollection();
            FillPowerFacilityCollection();
            FillEquipmentClassCollection();
            FillEquipmentTypeCollection();
            FillEquipmentCollection();
            FillPowerLineDiscriptionCollection();
            FillDispatchingCenterVisionCollection();
            FillCurrentDependCollection();
            FillTCurrentDependCollection();
            FillEquipmentTCurrentDependCollection();
            FillPowerLineCompositionCollection();

            PositionInPowerLineCollectionVM.FillPositionElementCollection();

            FormationCollectionEquipmentTypeView();
            FormationEquipmentViewCollection();
            FormationPowerLineCollection();
            FormationCurrentLimitsViewCollection();
        }
        #endregion

        #region Методы заполнения коолекций данными из БД

        /// <summary>
        /// Заполнение коллекции диспетчерских центров
        /// </summary>
        /// <param name="reader"></param>
        public static void FillDispatchingCenterCollection()
        {
            CollectionDispatchingCenter.Clear();
            CollectionChecked.Clear();
            foreach (DispatchingCenter dispatchingCenter in Dp.DispatchingCenter)
            {
                CollectionDispatchingCenter.Add(dispatchingCenter);
                CollectionChecked.Add(
                    new DispatchingCenterWithChoiceVM() 
                    { Value = dispatchingCenter.NameDispatchingCenter, 
                        Id = dispatchingCenter.ID,  
                        IsSelected = false });
            }
        }

        

        /// <summary>
        /// Заполнение коллекции уровней напржения
        /// </summary>
        /// <param name="reader"></param>
        public static void FillVoltageLevelCollection()
        {
            CollectionVoltageLevel.Clear();
            foreach (VoltageLevel voltageLevel in Dp.VoltageLevel)
            {
                CollectionVoltageLevel.Add(voltageLevel);
            }
        }

        /// <summary>
        /// Заполнение колекции энергообъектов
        /// </summary>
        /// <param name="reader"></param>
        public static void FillPowerFacilityCollection()
        {
            CollectionPowerFacility.Clear();
            foreach (PowerFacility powerFacility in Dp.PowerFacility)
            {
                CollectionPowerFacility.Add(powerFacility);
            }
        }

        /// <summary>
        /// Заполнение колекции классов оборудования
        /// </summary>
        /// <param name="reader"></param>
        public static void FillEquipmentClassCollection()
        {
            CollectionEquipmentClass.Clear();
            foreach (EquipmentClass equipmentClass in Dp.EquipmentClass)
            {
                CollectionEquipmentClass.Add(equipmentClass);
            }
        }

        /// <summary>
        /// Заполнение колекции типов оборудования
        /// </summary>
        /// <param name="reader"></param>
        public static void FillEquipmentTypeCollection()
        {
            CollectionEquipmentType.Clear();
            foreach (EquipmentType equipmentType in Dp.EquipmentType)
            {
                CollectionEquipmentType.Add(equipmentType);
            }
        }

        /// <summary>
        /// Заполнение колекции оборудования
        /// </summary>
        /// <param name="reader"></param>
        public static void FillEquipmentCollection()
        {
            CollectionEquipment.Clear();
            foreach (Equipment equipment in Dp.Equipment)
            {
                CollectionEquipment.Add(equipment);
            }
        }

        /// <summary>
        /// Заполнение колекции описания ЛЭП
        /// </summary>
        /// <param name="reader"></param>
        public static void FillPowerLineDiscriptionCollection()
        {
            CollectionPowerLineDiscription.Clear();
            foreach (PowerLineDiscription powerLineDiscription in Dp.PowerLineDiscription)
            {
                CollectionPowerLineDiscription.Add(powerLineDiscription);
            }
        }

        /// <summary>
        /// Зополнение колекции ДЦ ведения
        /// </summary>
        /// <param name="reader"></param>
        public static void FillDispatchingCenterVisionCollection()
        {
            CollectionPowerLineDVision.Clear();
            foreach (PowerLineDispatchingVision powerLineDispatchingVision in Dp.PowerLineDispatchingVision)
            {
                CollectionPowerLineDVision.Add(powerLineDispatchingVision);
            }
        }

        /// <summary>
        /// Зополнение колекции типов токовых ограничений
        /// </summary>
        /// <param name="reader"></param>
        public static void FillCurrentDependCollection()
        {
            CollectionCurrentDepend.Clear();
            foreach (CurrentDepend currentDepend in Dp.CurrentDepend)
            {
                CollectionCurrentDepend.Add(currentDepend);
            }
        }

        /// <summary>
        /// Зополнение колекции описания допустимой токовой нагрузки оборудования (сегмента линии)
        /// </summary>
        /// <param name="reader"></param>
        public static void FillTCurrentDependCollection()
        {
            CollectionTCurrentDepend.Clear();
            foreach (TCurrentDepend tCurrentDepend in Dp.TCurrentDepend)
            {
                CollectionTCurrentDepend.Add(tCurrentDepend);
            }
        }

        /// <summary>
        /// Зополнение колекции 
        /// </summary>
        /// <param name="reader"></param>
        public static void FillEquipmentTCurrentDependCollection()
        {
            CollectionEquipmentTCurrentDepend.Clear();
            for (int i = -35; i <= 40; i = i + 5)
            {
                var item = new TCurrentDepend();
                item.Temp = i;
                CollectionEquipmentTCurrentDepend.Add(item);
            }
        }

        /// <summary>
        /// Зополнение колекции описания оборудования в элементе
        /// </summary>
        /// <param name="reader"></param>
        public static void FillPowerLineCompositionCollection()
        {
            CollectionPowerLineComposition.Clear();
            foreach (PowerLineComposition powerLineComposition in Dp.PowerLineComposition)
            {
                CollectionPowerLineComposition.Add(powerLineComposition);
            }
        }

        #endregion

        #region Методы формирования коллекций для представления из полученных из БД данных

        /// <summary>
        /// Формирование колекции для представления типов оборудования
        /// </summary>
        public static void FormationCollectionEquipmentTypeView()
        {
            CollectionEquipmentTypeView.Clear();
            foreach (EquipmentType equipmentType in CollectionEquipmentType)
            {
                var id = equipmentType.ID;
                var сlassName = CollectionEquipmentClass.Where
                    (it => it.ID == equipmentType.IDClass)
                    .FirstOrDefault().ClassName;
                var TypeName = equipmentType.TypeName;
                var voltageLevel = CollectionVoltageLevel.Where
                    (it => it.ID == equipmentType.IDVoltageLevel)
                    .FirstOrDefault().VoltageLevel1;
                var inom = equipmentType.Inom;
                CollectionEquipmentTypeView.Add(new EquipmentTypeView(id, сlassName, TypeName,
                    voltageLevel, inom));
            }
        }

        /// <summary>
        /// Формирование колекции представления оборудования
        /// </summary>
        public static void FormationEquipmentViewCollection()
        {
            CollectionEquipmentView.Clear();
            foreach (Equipment equipment in CollectionEquipment)
            {
                var id = equipment.ID;
                var powerFacility = CollectionPowerFacility.Where
                    (it => it.ID == equipment.IDPowerFacility)
                    .FirstOrDefault().DispatchName;
                var className = CollectionEquipmentClass.Where
                    (it => it.ID == equipment.IDClass)
                    .FirstOrDefault().ClassName;
                var typeName = CollectionEquipmentType.Where
                    (it => it.ID == equipment.IDType)
                    .FirstOrDefault().TypeName;
                var dispatchName = equipment.DispatchName;
                var powerLineID = 0;
                var powerLineDispatchName = "";
                if (CollectionPowerLineComposition.
                    Where(it => it.IDEquipment == equipment.ID).Count() !=0)
                {
                    powerLineID = CollectionPowerLineComposition.
                        Where(it => it.IDEquipment == equipment.ID).First().IDPowerLine;
                    powerLineDispatchName = CollectionPowerLineDiscription.
                        Where(it => it.ID == powerLineID).First().DispatchName;
                }
                CollectionEquipmentView.Add(new EquipmentView(id, powerFacility, className,
                    typeName, dispatchName, powerLineID, powerLineDispatchName));
            }
        }

        /// <summary>
        /// Формирование колекции ЛЭП
        /// </summary>
        public static void FormationPowerLineCollection()
        {
            CollectionPowerLineView.Clear();
            foreach (PowerLineDiscription powerLineDiscription in CollectionPowerLineDiscription)
            {
                var id = powerLineDiscription.ID;
                var dispatchName = powerLineDiscription.DispatchName;
                var voltageLevel = CollectionVoltageLevel.Where
                    (it => it.ID == powerLineDiscription.IDVoltageLevel)
                    .FirstOrDefault().VoltageLevel1;
                var dispatchingCenterControl = CollectionDispatchingCenter.Where
                    (it => it.ID == powerLineDiscription.IDDispatchingCenterControl)
                    .FirstOrDefault().NameDispatchingCenter;
                var collectionDCenterVision = CollectionPowerLineDVision.Where
                    (it => it.IDPowerLine == powerLineDiscription.ID);
                var dispatchingCenterVision = new List<string>();
                foreach (PowerLineDispatchingVision item in collectionDCenterVision)
                {
                    dispatchingCenterVision.Add(CollectionDispatchingCenter.Where
                        (it => it.ID == item.IDDispatchingCenterVision).
                        FirstOrDefault().NameDispatchingCenter);
                }
                var powerFacilityStart = CollectionPowerFacility.Where
                    (it => it.ID == powerLineDiscription.IDPowerFacilityStart)
                    .FirstOrDefault().DispatchName;
                var powerFacilityEnd = CollectionPowerFacility.Where
                    (it => it.ID == powerLineDiscription.IDPowerFacilityEnd)
                    .FirstOrDefault().DispatchName;
                var userItem = powerLineDiscription.UserItem;
                CollectionPowerLineView.Add(new PowerLineView(id, dispatchName, voltageLevel,
                    dispatchingCenterControl, dispatchingCenterVision, powerFacilityStart,
                    powerFacilityEnd, userItem));
            }
        }

        /// <summary>
        /// Формирование колекции токовых ограничений
        /// </summary>
        public static void FormationCurrentLimitsViewCollection()
        {
            CollectionCurrentLimitsView.Clear();
            foreach (TCurrentDepend tCurrentDepend in CollectionTCurrentDepend)
            {
                var id = tCurrentDepend.IDEquipment;
                var equipmentDispatchName = CollectionEquipment.Where
                    (it => it.ID == tCurrentDepend.IDEquipment)
                    .FirstOrDefault().DispatchName;
                var iDCurrentDepend = tCurrentDepend.IDCurrentDepend;
                var typeOfCurrentLoad = CollectionCurrentDepend.Where
                    (it => it.ID == tCurrentDepend.IDCurrentDepend)
                    .FirstOrDefault().TypeOfCurrentLoad;
                var allowTime = CollectionCurrentDepend.Where
                    (it => it.ID == tCurrentDepend.IDCurrentDepend)
                    .FirstOrDefault().AllowTime;
                var temp = tCurrentDepend.Temp;
                var current = tCurrentDepend.Current;
                var kcorr = tCurrentDepend.Kcorr;
                CollectionCurrentLimitsView.Add(new CurrentLimitsView(id, equipmentDispatchName, iDCurrentDepend, typeOfCurrentLoad,
                    allowTime, temp, current, kcorr));
            }
        }

        #endregion
    }
}
