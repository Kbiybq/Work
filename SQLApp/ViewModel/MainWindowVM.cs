using BespokeFusion;
using Data;
using SQLApp.Windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Linq;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace SQLApp
{
    /// <summary>
    /// Модель представления главного окна
    /// </summary>
    public class MainWindowVM : ViewModelBase
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
        /// Коллекция класса описания ЛЭП
        /// </summary>
        public ObservableCollection<PowerLineDiscription> CollectionPowerLineDiscription
        {
            get
            {
                return TotalData.CollectionPowerLineDiscription;
            }
            set
            {
                TotalData.CollectionPowerLineDiscription = value;
            }
        }
        /// <summary>
        /// Коллекция класса описание диспетчерского ведения
        /// </summary>
        public ObservableCollection<PowerLineDispatchingVision> CollectionPowerLineDVision
        {
            get
            {
                return TotalData.CollectionPowerLineDVision;
            }
            set
            {
                TotalData.CollectionPowerLineDVision = value;
            }
        }

        /// <summary>
        /// Коллекция класса ЛЭП
        /// </summary>
        public ObservableCollection<PowerLineView> CollectionPowerLineView
        {
            get
            {
                return TotalData.CollectionPowerLineView;
            }
            set
            {
                TotalData.CollectionPowerLineView = value;
            }
        }

        /// <summary>
        /// Коллекция класса Энергообъектов
        /// </summary>
        public ObservableCollection<PowerFacility> CollectionPowerFacility
        {
            get
            {
                return TotalData.CollectionPowerFacility;
            }
            set
            {
                TotalData.CollectionPowerFacility = value;
            }
        }

        /// <summary>
        /// Коллекция класса описание типов токового ограничения
        /// </summary>
        public ObservableCollection<CurrentDepend> CollectionCurrentDepend
        {
            get
            {
                return TotalData.CollectionCurrentDepend;
            }
            set
            {
                TotalData.CollectionCurrentDepend = value;
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
        /// Коллекция класса описание типов токового ограничения
        /// </summary>
        public ObservableCollection<TCurrentDepend> CollectionEquipmentTCurrentDepend
        {
            get
            {
                return TotalData.CollectionEquipmentTCurrentDepend;
            }
            set
            {
                TotalData.CollectionEquipmentTCurrentDepend = value;
            }
        }

        /// <summary>
        /// Коллекция класса токовых ограничений
        /// </summary>
        public ObservableCollection<CurrentLimitsView> CollectionCurrentLimitsView
        {
            get
            {
                return TotalData.CollectionCurrentLimitsView;
            }
            set
            {
                TotalData.CollectionCurrentLimitsView = value;
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
        /// Коллекция класса типов оборудования
        /// </summary>
        public ObservableCollection<EquipmentType> CollectionEquipmentType
        {
            get
            {
                return TotalData.CollectionEquipmentType;
            }
            set
            {
                TotalData.CollectionEquipmentType = value;
            }
        }

        /// <summary>
        /// Коллекция класса типов оборудования для представления
        /// </summary>
        public ObservableCollection<EquipmentTypeView> CollectionEquipmentTypeView
        {
            get
            {
                return TotalData.CollectionEquipmentTypeView;
            }
            set
            {
                TotalData.CollectionEquipmentTypeView = value;
            }
        }

        /// <summary>
        /// Коллекция класса оборудования
        /// </summary>
        public ObservableCollection<Equipment> CollectionEquipment
        {
            get
            {
                return TotalData.CollectionEquipment;
            }
            set
            {
                TotalData.CollectionEquipment = value;
            }
        }

        /// <summary>
        /// Коллекция класса оборудования для представления
        /// </summary>
        public ObservableCollection<EquipmentView> CollectionEquipmentView
        {
            get
            {
                return TotalData.CollectionEquipmentView;
            }
            set
            {
                TotalData.CollectionEquipmentView = value;
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

        #region Выбранные вкладки и строки как свойства

        /// <summary>
        /// Верхняя выбранная вкладка
        /// </summary>
        public TabItem UpperSelectedTab { get; set; }

        /// <summary>
        /// Нижняя выбранная вкладка
        /// </summary>
        public TabItem LowerSelectedTab { get; set; }

        /// <summary>
        /// Выбранный элемент
        /// </summary>
        public object SelectedItem { get; set; }

        #endregion

        #region Параметры поиска как свойства

        private string _inputDispatchName;
        /// <summary>
        /// Введённое диспетчерское наименование
        /// </summary>
        private string InputDispatchName
        {
            get
            {
                return _inputDispatchName;
            }
            set
            {
                _inputDispatchName = value;
                OnPropertyChanged(nameof(InputDispatchName));
            }
        }

        private DispatchingCenter _dCControlSelected;
        /// <summary>
        /// Выбранный ДЦ контроля
        /// </summary>
        private DispatchingCenter DCControlSelected
        {
            get
            {
                return _dCControlSelected;
            }
            set
            {
                _dCControlSelected = value;
                OnPropertyChanged(nameof(DCControlSelected));
            }
        }

        private DispatchingCenter _dCVisionSelected;
        /// <summary>
        /// Выбранный ДЦ контроля
        /// </summary>
        private DispatchingCenter DCVisionSelected
        {
            get
            {
                return _dCVisionSelected;
            }
            set
            {
                _dCVisionSelected = value;
                OnPropertyChanged(nameof(DCVisionSelected));
            }
        }

        private VoltageLevel _voltageLevelSelected;
        /// <summary>
        /// Выбранный класс напряжения
        /// </summary>
        private VoltageLevel VoltageLevelSelected
        {
            get
            {
                return _voltageLevelSelected;
            }
            set
            {
                _voltageLevelSelected = value;
                OnPropertyChanged(nameof(VoltageLevelSelected));
            }
        }

        private PowerFacility _powerFacilityStartSelected;
        /// <summary>
        /// Выбранный энергообъект начала
        /// </summary>
        private PowerFacility PowerFacilityStartSelected
        {
            get
            {
                return _powerFacilityStartSelected;
            }
            set
            {
                _powerFacilityStartSelected = value;
                OnPropertyChanged(nameof(PowerFacilityStartSelected));
            }
        }

        private PowerFacility _powerFacilityEndSelected;
        /// <summary>
        /// Выбранный энергообъект конца
        /// </summary>
        private PowerFacility PowerFacilityEndSelected
        {
            get
            {
                return _powerFacilityEndSelected;
            }
            set
            {
                _powerFacilityEndSelected = value;
                OnPropertyChanged(nameof(PowerFacilityEndSelected));
            }
        }

        #endregion

        #region Команды

        /// <summary>
        /// Загрузка данных из БД
        /// </summary>
        public RelayCommand<object> LoadingDataFromDB
        {
            get
            {
                return new RelayCommand<object>(obj =>
                {
                    try
                    {
                        SQLConnectionClass sQLConnection = new SQLConnectionClass();
                        sQLConnection.FormationSqlConnectionString();
                        Dp = sQLConnection.CreateDataContext();
                        TotalData.UpdateDataFromDataContext();

                        MaterialMessageBox.Show("Данные успешно загружены");
                    }
                    catch (Exception exp)
                    {
                        MaterialMessageBox.ShowError(exp.Message);
                    }
                });
            }
        }

        /// <summary>
        /// Обновление данных из БД
        /// </summary>
        public RelayCommand<object> UpdateDataInWindow
        {
            get
            {
                return new RelayCommand<object>(obj =>
                {
                    try
                    {
                        TotalData.UpdateDataFromDataContext();
                    }
                    catch (Exception exp)
                    {
                        MaterialMessageBox.ShowError(exp.Message);
                    }
                });
            }
        }

        /// <summary>
        /// Сохранение всех изменений в БД
        /// </summary>
        public RelayCommand<object> SaveChangesToDB
        {
            get
            {
                return new RelayCommand<object>(obj =>
                {
                    try
                    {
                        var result = MaterialMessageBox.ShowWithCancel(
                                               "Сохранение изменений привет к изменению данных в БД!",
                                               true);
                        if (result == MessageBoxResult.OK)
                        {
                            Dp.SubmitChanges();
                            TotalData.UpdateDataFromDataContext();
                            MaterialMessageBox.Show("Данные успешно сохранены");
                        }
                    }
                    catch (Exception exp)
                    {
                        MaterialMessageBox.ShowError(exp.Message);
                    }
                });
            }
        }

        /// <summary>
        /// Удаление элемента из выбранной таблицы (с удалением из всех связанных таблиц)
        /// </summary>
        public RelayCommand<object> RemoveCommand
        {
            get
            {
                return new RelayCommand<object>(obj =>
                    {
                        try
                        {
                            if (SelectedItem != null & LowerSelectedTab != null)
                            {
                                var result = MaterialMessageBox.ShowWithCancel($"Вы действительно хотите удалить выбранный объект " +
                                    $"и все связанные с ним данные? "
                                    ,"Подтверждение действия");
                                if (result == MessageBoxResult.OK)
                                {
                                    switch (LowerSelectedTab.Name)
                                    {
                                        case nameof(CollectionPowerLineView):
                                            var result1 = MaterialMessageBox.ShowWithCancel(
                                               "Удаление линии приведёт к удалению " +
                                               "ВСЕХ связанных с ней данных, включая оборудование и токовые ограничения!",
                                               true);
                                            if (result1 == MessageBoxResult.OK)
                                            {
                                                var powerLineView = (PowerLineView)SelectedItem;
                                                var deletionItem = CollectionPowerLineDiscription.Where
                                                (it => it.ID == powerLineView.ID).FirstOrDefault();
                                                Dp.GetTable<PowerLineDiscription>().DeleteOnSubmit(deletionItem);
                                            }
                                            break;
                                        case nameof(CollectionEquipmentTypeView):
                                            var result2 = MaterialMessageBox.ShowWithCancel(
                                                "Удаление типа оборудования приведёт к удалению ВСЕГО оборудования имеющего данный тип " +
                                                "и связанных с ним данных!",
                                                true);
                                            if (result2 == MessageBoxResult.OK)
                                            {
                                                var equipmentTypeView = (EquipmentTypeView)SelectedItem;
                                                var deletionItem = CollectionEquipmentType.Where
                                                (it => it.ID == equipmentTypeView.ID).FirstOrDefault();
                                                Dp.GetTable<EquipmentType>().DeleteOnSubmit(deletionItem);
                                            }
                                            break;
                                        case nameof(CollectionPowerFacility):
                                            var result3 = MaterialMessageBox.ShowWithCancel(
                                                "Удаление энергообъекта приведёт к удалению ВСЕГО оборудования " +
                                                "и ВСЕХ ЛЭП, связанных с ним!",
                                                true);
                                            if (result3 == MessageBoxResult.OK)
                                            {
                                                Dp.GetTable<PowerFacility>().DeleteOnSubmit((PowerFacility)SelectedItem);
                                            }
                                            break;
                                        case nameof(CollectionEquipmentView):
                                            var result4 = MaterialMessageBox.ShowWithCancel(
                                                "Удаление оборудования приведёт к удалению ВСЕХ связанных с ним данных",
                                                true);
                                            if (result4 == MessageBoxResult.OK)
                                            {
                                                var equipmentView = (EquipmentView)SelectedItem;
                                                var deletionItem = CollectionEquipment.Where
                                                (it => it.ID == equipmentView.ID).FirstOrDefault();
                                                Dp.GetTable<Equipment>().DeleteOnSubmit(deletionItem);
                                            }
                                            break;
                                        case nameof(CollectionCurrentDepend):
                                            var result5 = MaterialMessageBox.ShowWithCancel(
                                            "Удаление типа токового ограничения приведёт к удалению ВСЕХ токовых ограничений " +
                                            ", имеющих данный тип!",
                                            true);
                                            if (result5 == MessageBoxResult.OK)
                                            {
                                                Dp.GetTable<CurrentDepend>().DeleteOnSubmit((CurrentDepend)SelectedItem);
                                            }
                                            break;
                                        case nameof(CollectionCurrentLimitsView):
                                            var result6 = MaterialMessageBox.ShowWithCancel(
                                                "Подтвержите удаление токового ограничения",
                                                true);
                                            if (result6 == MessageBoxResult.OK)
                                            {
                                                var сurrentLimitsView = (CurrentLimitsView)SelectedItem;
                                                var deletionItem = CollectionTCurrentDepend.Where
                                                (it => it.IDEquipment == сurrentLimitsView.IDEquipment);
                                                var deletionItem1 = deletionItem.Where
                                                (it => it.IDCurrentDepend == сurrentLimitsView.IDCurrentDepend);
                                                var deletionItem2 = deletionItem1.Where
                                                (it => it.Temp == сurrentLimitsView.Temp).FirstOrDefault();
                                                Dp.GetTable<TCurrentDepend>().DeleteOnSubmit(deletionItem2);
                                            }
                                            break;

                                    }
                                    Dp.SubmitChanges();
                                    TotalData.UpdateDataFromDataContext();
                                }
                            }
                            else
                            {
                                throw new Exception("Не выбран элемент для удаления");
                            }
                        }
                        catch (Exception exp)
                        {
                            MaterialMessageBox.ShowError(exp.Message);
                        }
                    });
            }
        }

        /// <summary>
        /// Добавление элемента в выбранную таблицу
        /// </summary>
        public RelayCommand<Window> AddCommand
        {
            get
            {
                return new RelayCommand<Window>(parameter =>
                {
                    try
                    {
                        if (LowerSelectedTab != null)
                        {
                            var result = MaterialMessageBox.ShowWithCancel($"Добавленить/изменить элемент в текущей таблице?"
                                , "Подтверждение действия");
                            if (result == MessageBoxResult.OK)
                            {
                                switch (LowerSelectedTab.Name)
                                {
                                    case nameof(CollectionPowerLineView):
                                        AddPowerLineDiscription addPowerLineDiscription = new AddPowerLineDiscription();
                                        addPowerLineDiscription.Owner = parameter;
                                        addPowerLineDiscription.ShowDialog();
                                        break;
                                    case nameof(CollectionEquipmentTypeView):
                                        AddEquipmentType addEquipmentType = new AddEquipmentType();
                                        addEquipmentType.Owner = parameter;
                                        addEquipmentType.ShowDialog();
                                        break;
                                    case nameof(CollectionPowerFacility):
                                        AddPowerFacility addPowerFacility = new AddPowerFacility();
                                        addPowerFacility.Owner = parameter;
                                        addPowerFacility.ShowDialog();
                                        break;
                                    case nameof(CollectionEquipmentView):
                                        AddEquipment addEquipment = new AddEquipment();
                                        addEquipment.Owner = parameter;
                                        addEquipment.ShowDialog();
                                        break;
                                    case nameof(CollectionCurrentDepend):
                                        AddCurrentDepend addCurrentDepend = new AddCurrentDepend();
                                        addCurrentDepend.Owner = parameter;
                                        addCurrentDepend.ShowDialog();
                                        break;
                                    case nameof(CollectionCurrentLimitsView):
                                        AddTCurrentDepend addTCurrentDepend = new AddTCurrentDepend();
                                        addTCurrentDepend.Owner = parameter;
                                        addTCurrentDepend.ShowDialog();
                                        break;
                                }
                            }
                        }
                        else
                        {
                            throw new Exception("Не выбрана панель для добавления");
                        }
                    }
                    catch (Exception exp)
                    {
                        MaterialMessageBox.ShowError(exp.Message);
                    }
                });
            }
        }

        /// <summary>
        /// Формирование токовых ограничений по выбранной ЛЭП
        /// </summary>
        public RelayCommand<Window> FeedCurrentLimit
        {
            get
            {
                return new RelayCommand<Window>(parameter =>
                {
                    try
                    {
                        if (SelectedItem != null & LowerSelectedTab.Name == nameof(CollectionPowerLineView))
                        {
                            var powerLineView = (PowerLineView)SelectedItem;
                            var result = MaterialMessageBox.ShowWithCancel(
                                $"Сформировать токовые ограничения для выбранной ЛЭП? \n" +
                                $"{powerLineView.DispatchName}"
                                , "Подтверждение действия");
                            if (result == MessageBoxResult.OK)
                            {
                                
                            }
                        }
                        else
                        {
                            throw new Exception("Для формирования токового ограничения выберете ЛЭП");
                        }
                    }
                    catch (Exception exp)
                    {
                        MaterialMessageBox.ShowError(exp.Message);
                    }
                });
            }
        }

        /// <summary>
        /// Вывод информации
        /// </summary>
        public RelayCommand<object> Info
        {
            get
            {
                return new RelayCommand<object>(obj =>
                {
                    MaterialMessageBox.Show(
                        $"Версия программы: 0.2b\n" +
                        $"Дата сборки: 31.07.2019\n" +
                        $"Разработчик: VolokhovNA@osib.so-ups.ru");
                });
            }
        }

        #endregion
    }
}
