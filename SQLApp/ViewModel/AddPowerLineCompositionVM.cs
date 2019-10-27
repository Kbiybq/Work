using BespokeFusion;
using Data;
using SQLApp.Windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SQLApp.ViewModel
{
    /// <summary>
    /// Класс модели представления для окна добавления описания ЛЭП
    /// </summary>
    class AddPowerLineCompositionVM : ViewModelBase
    {

        #region Коллекции как свойства

        /// <summary>
        /// Коллекция классов названий диспетчерских центров
        /// </summary>
        public ObservableCollection<DispatchingCenter> CollectionDispatchingCenter
        {
            get
            {
                return TotalData.CollectionDispatchingCenter;
            }
            set
            {
                TotalData.CollectionDispatchingCenter = value;
            }
        }

        /// <summary>
        /// Коллекция класса уровней напряжения
        /// </summary>
        public ObservableCollection<VoltageLevel> CollectionVoltageLevel
        {
            get
            {
                return TotalData.CollectionVoltageLevel;
            }
            set
            {
                TotalData.CollectionVoltageLevel = value;
            }
        }

        /// <summary>
        /// Коллекция класса классов оборудования
        /// </summary>
        public ObservableCollection<EquipmentClass> CollectionEquipmentClass
        {
            get
            {
                return TotalData.CollectionEquipmentClass;
            }
            set
            {
                TotalData.CollectionEquipmentClass = value;
            }
        }

        /// <summary>
        /// Коллекция класса описание допустимой токовой нагрузки оборудования (сегмента линии)
        /// </summary>
        public ObservableCollection<TCurrentDepend> CollectionTCurrentDepend
        {
            get
            {
                return TotalData.CollectionTCurrentDepend;
            }
            set
            {
                TotalData.CollectionTCurrentDepend = value;
            }
        }

        /// <summary>
        /// коллекция класса описания состава элементов, из которых состоит ЛЭП
        /// </summary>
        public ObservableCollection<PowerLineComposition> CollectionPowerLineComposition
        {
            get
            {
                return TotalData.CollectionPowerLineComposition;
            }
            set
            {
                TotalData.CollectionPowerLineComposition = value;
            }
        }

        /// <summary>
        /// Загруженная БД
        /// </summary>
        private Current_infoDataContext Dp
        {
            get
            {
                return TotalData.Dp;
            }
            set
            {
                TotalData.Dp = value;
                OnPropertyChanged("Dp");
            }
        }

        #endregion

        #region последнее добавленное оборудование

        /// <summary>
        /// Последнее добавленное описание ЛЭП
        /// </summary>
        public static PowerLineDiscription NewPowerLineDiscription
        {
            get
            {
                return TotalData.NewPowerLineDiscription;
            }
            set
            {
                TotalData.NewPowerLineDiscription = value;
            }
        }

        /// <summary>
        /// Последнее добавленное оборудование
        /// </summary>
        public static Equipment NewEquipment
        {
            get
            {
                return TotalData.NewEquipment;
            }
            set
            {
                TotalData.NewEquipment = value;
            }
        }

        /// <summary>
        /// Последнее добавленное оборудование
        /// </summary>
        public static PowerLineComposition NewPowerLineComposition
        {
            get
            {
                return TotalData.NewPowerLineComposition;
            }
            set
            {
                TotalData.NewPowerLineComposition = value;
            }
        }

        #endregion

        #region Комманды

        /// <summary>
        /// Добавление нового типа оборудования
        /// </summary>
        public RelayCommand<PositionInPowerLineVM> AddEquipment
        {
            get
            {
                return new RelayCommand<PositionInPowerLineVM>(parameter =>
                {
                    AddEquipment addEquipment = new AddEquipment();
                    addEquipment.ShowDialog();
                    var flagCorrectType = false;
                    var str = parameter.ToString();
                    switch (str)
                    {
                        case "AddOsh1":
                            if(NewEquipment.IDClass == 1)
                            {
                                FillNewPowerLineCmposition(1, 1);
                                flagCorrectType = true;
                            }
                            break;
                        case "AddTT1":
                            if (NewEquipment.IDClass == 4)
                            {
                                FillNewPowerLineCmposition(1, 2);
                                flagCorrectType = true;
                            }
                            break;
                    }
                    if (flagCorrectType)
                    {
                        if (CollectionPowerLineComposition.
                        Any(it => it.IDEquipment == NewEquipment.ID))
                        {
                            if (MaterialMessageBox.ShowWithCancel(
                                    $"Данное оборудование уже привязано к ЛЭП, перепривязать его?.\n" +
                                    $"Нажмите cancel для Отмены."
                                    , "Подтверждение действия")
                                    == MessageBoxResult.OK)
                            {
                                Dp.GetTable<PowerLineComposition>().
                                DeleteOnSubmit(
                                    CollectionPowerLineComposition.
                                    Where(it => it.IDEquipment == NewEquipment.ID).First());
                                Dp.GetTable<PowerLineComposition>().InsertOnSubmit(NewPowerLineComposition);
                                Dp.SubmitChanges();
                                TotalData.UpdateDataFromDataContext();
                            }
                        }
                        else
                        {
                            Dp.GetTable<PowerLineComposition>().InsertOnSubmit(NewPowerLineComposition);
                            Dp.SubmitChanges();
                            TotalData.UpdateDataFromDataContext();
                        }
                    }
                    else
                    {
                        MaterialMessageBox.ShowError(
                            "Тип добавленного оборудования не соответствует выбраному элементу! \n" +
                            "Оборудование не будет добавлено!");
                    }
                });
            }
        }

        /// <summary>
        /// Заполнение свойств нового оборудования в описании ЛЭП
        /// </summary>
        /// <param name="iDElementPosition">номер элемента</param>
        /// <param name="iDEquipmentPosition">номер позиции в элементе</param>
        private static void FillNewPowerLineCmposition(int iDElementPosition, int iDEquipmentPosition)
        {
            NewPowerLineComposition.IDPowerLine = NewPowerLineDiscription.ID;
            NewPowerLineComposition.IDElementPosition = iDElementPosition;
            NewPowerLineComposition.IDEquipmentPosition = iDEquipmentPosition;
            NewPowerLineComposition.IDEquipment = NewEquipment.ID;
        }


        /// <summary>
        /// Добавление
        /// </summary>
        public RelayCommand<Window> AddPowerLineCompositionCommand
        {
            get
            {
                return new RelayCommand<Window>(parameter =>
                {
                    try
                    {
                        FillElementCurrentLimit();

                        Dp.SubmitChanges();
                        TotalData.UpdateDataFromDataContext();
                        parameter.Close();

                    }
                    catch (Exception exp)
                    {
                        MaterialMessageBox.ShowError(exp.Message);
                    }
                });
            }
        }

        /// <summary>
        /// Формирование токовых ограничений элементов
        /// </summary>
        private void FillElementCurrentLimit()
        {
            for (int i = 1; i <= 9 ; i++)
            {
                var collEquipmentForSerching = CollectionPowerLineComposition.
                Where(it => it.IDPowerLine == NewPowerLineDiscription.ID).
                Where(it => it.IDElementPosition == i);
                if(collEquipmentForSerching.Count() != 0)
                {
                    var collTCurrentDepend = CollectionTCurrentDepend.
                        Where(it => it.IDCurrentDepend == 1);
                    var collTCurrentDependEquipment = new ObservableCollection<TCurrentDepend>();
                    foreach (TCurrentDepend item in collTCurrentDepend)
                    {
                        foreach (PowerLineComposition item2 in collEquipmentForSerching)
                        {
                            if (item2.IDEquipment == item.IDEquipment)
                            {
                                collTCurrentDependEquipment.Add(item);
                            }
                        }
                    }
                    if(collTCurrentDependEquipment.Count() != 0)
                    {
                        for (int j = -5; j <= 40; j = j + 5)
                        {
                            if (collTCurrentDependEquipment.Where
                                    (it => it.Temp == j) != null)
                            {
                                var minCurrent = collTCurrentDependEquipment.Where
                                    (it => it.Temp == j).Min(it => it.Current);
                                var newElementCurrentLimit = new ElementCurrentLimit
                                {
                                    IDPowerLine = NewPowerLineDiscription.ID,
                                    IDElementPosition = i,
                                    IDCurrentDepend = 1,
                                    Temp = j,
                                    MinCurrent = minCurrent
                                };
                                Dp.GetTable<ElementCurrentLimit>().InsertOnSubmit(newElementCurrentLimit);
                            }
                        }
                            
                    }

                }

            }
        }

        /// <summary>
        /// Отмена
        /// </summary>
        public RelayCommand<Window> CancelCommand
        {
            get
            {
                return new RelayCommand<Window>(parameter =>
                {
                    parameter.Close();
                });
            }
        }

        #endregion
    }
}
