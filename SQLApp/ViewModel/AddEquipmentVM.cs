using BespokeFusion;
using Data;
using SQLApp.Windows;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Data;

namespace SQLApp.ViewModel
{
    /// <summary>
    /// Класс модели представления для окна добавления оборудования
    /// </summary>
    class AddEquipmentVM : ViewModelBase
    {
        #region Коллекции как свойства

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

        public ListCollectionView Test { get; set; } =
            (ListCollectionView)CollectionViewSource.GetDefaultView(TotalData.CollectionEquipmentType);


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
                OnPropertyChanged(nameof(Dp));
            }
        }

        /// <summary>
        /// Добавленное оборудование
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

        #endregion

        #region коллекци отфильтрованные

        private ObservableCollection<EquipmentType> _equipmentTypeFilter;
        /// <summary>
        /// Коллекция отфильтрофанных типов оборудования по выбранному классу оборудования
        /// </summary>
        public ObservableCollection<EquipmentType> EquipmentTypeFilter
        {
            get { return _equipmentTypeFilter; }
            set
            {
                _equipmentTypeFilter = value;
                OnPropertyChanged(nameof(EquipmentTypeFilter));
            }
        }

        /// <summary>
        /// Загрузка данных
        /// </summary>
        public void LoadData()
        {
            NewEquipment = new Equipment();
            InputID = CollectionEquipment.Last().ID + 1;
        }

        #endregion

        #region выбранные данные как свойства

        private EquipmentView _selectedItem;
        /// <summary>
        /// Выбранный элемент
        /// </summary>
        public EquipmentView SelectedItem
        {
            get
            {
                return _selectedItem;
            }
            set
            {
                _selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
                if (_selectedItem != null)
                {
                    var selectedEquipment = CollectionEquipment.
                        Where(it => it.ID == _selectedItem.ID).First();
                    InputID = selectedEquipment.ID;
                    PowerFacilitySelected = CollectionPowerFacility.
                        Where(it => it.ID == selectedEquipment.IDPowerFacility).First();
                    EquipmentClassSelected = CollectionEquipmentClass.
                        Where(it => it.ID == selectedEquipment.IDClass).First();
                    EquipmentTypeSelected = CollectionEquipmentType.
                        Where(it => it.ID == selectedEquipment.IDType).First();
                    InputDispatchName = selectedEquipment.DispatchName;
                    if (selectedEquipment.Length != null)
                    {
                        InputLength = (float)selectedEquipment.Length;
                    }
                    else InputLength = 0;
                    if (selectedEquipment.NumberOfWires != null)
                    {
                        InputNumberOfWires = (int)selectedEquipment.NumberOfWires;
                    }
                    else InputNumberOfWires = 0;
                }
            }
        }

        private int _inputID;
        /// <summary>
        /// Введённый ID
        /// </summary>
        public int InputID
        {
            get { return _inputID; }
            set
            {
                _inputID = value;
                OnPropertyChanged(nameof(InputID));
            }
        }

        private PowerFacility _powerFacilitySelected;
        /// <summary>
        /// Выбранный энергообъект
        /// </summary>
        public PowerFacility PowerFacilitySelected
        {
            get { return _powerFacilitySelected; }
            set
            {
                _powerFacilitySelected = value;
                OnPropertyChanged(nameof(PowerFacilitySelected));
            }
        }

        private EquipmentClass _equipmentClassSelected;
        /// <summary>
        /// Выбранный класс оборудования
        /// </summary>
        public EquipmentClass EquipmentClassSelected
        {
            get { return _equipmentClassSelected; }
            set
            {
                _equipmentClassSelected = value;
                OnPropertyChanged(nameof(EquipmentClassSelected));
                if (EquipmentTypeFilter != null)
                {
                    EquipmentTypeFilter.Clear();
                }
                else
                {
                    EquipmentTypeFilter = new ObservableCollection<EquipmentType>();
                    foreach (var item in CollectionEquipmentType)
                    {
                        EquipmentTypeFilter.Add(item);
                    }
                }
                if (_equipmentClassSelected != null)
                {
                    if (_equipmentClassSelected.ID == 0)
                    {
                        foreach (var item in CollectionEquipmentType)
                        {
                            EquipmentTypeFilter.Add(item);
                        }
                    }
                    else
                    {
                        foreach (var item in CollectionEquipmentType.
                            Where(it => it.IDClass == _equipmentClassSelected.ID))
                        {
                            EquipmentTypeFilter.Add(item);
                        }
                    }
                }
            }
        }

        private EquipmentType _equipmentTypeSelected;
        /// <summary>
        /// Выбранный тип оборудования
        /// </summary>
        public EquipmentType EquipmentTypeSelected
        {
            get { return _equipmentTypeSelected; }
            set
            {
                _equipmentTypeSelected = value;
                OnPropertyChanged(nameof(EquipmentTypeSelected));
            }
        }

        private string _inputDispatchName;
        /// <summary>
        /// Введённое диспетчерское наименование
        /// </summary>
        public string InputDispatchName
        {
            get { return _inputDispatchName; }
            set
            {
                _inputDispatchName = value;
                OnPropertyChanged(nameof(InputDispatchName));
            }
        }

        private float _inputLength;
        /// <summary>
        /// Введённая длинна
        /// </summary>
        public float InputLength
        {
            get { return _inputLength; }
            set
            {
                _inputLength = value;
                OnPropertyChanged(nameof(InputLength));
            }
        }

        private int _inputNumberOfWires;
        /// <summary>
        /// Введённое число параллельных
        /// </summary>
        public int InputNumberOfWires
        {
            get { return _inputNumberOfWires; }
            set
            {
                _inputNumberOfWires = value;
                OnPropertyChanged(nameof(InputNumberOfWires));
            }
        }

        #endregion


        #region Комманды

        /// <summary>
        /// Добавление
        /// </summary>
        public RelayCommand<Window> AddEquipmentCommand
        {
            get
            {
                return new RelayCommand<Window>(parameter =>
                {
                    try
                    {
                        if (PowerFacilitySelected == null | PowerFacilitySelected.ID == 0)
                        {
                            MaterialMessageBox.Show("Не выбран энергообъект");
                        }
                        else if (EquipmentClassSelected.ID == 0 | EquipmentClassSelected == null)
                        {
                            MaterialMessageBox.Show("Не выбран класс оборудования");
                        }
                        else if (EquipmentTypeSelected.ID == 0 | EquipmentTypeSelected == null)
                        {
                            MaterialMessageBox.Show("Не выбран тип оборудования");
                        }
                        else
                        {
                            var powerFacilityName = CollectionPowerFacility.
                                Where(it => it.ID == PowerFacilitySelected.ID).
                                First().DispatchName;
                            var className = CollectionEquipmentClass.
                            Where(it => it.ID == EquipmentClassSelected.ID).
                            First().ClassName;
                            var typeName = CollectionEquipmentType.
                            Where(it => it.ID == EquipmentTypeSelected.ID).
                            First().TypeName;
                            var voltageLevel = CollectionVoltageLevel.
                            Where(it => it.ID == EquipmentTypeSelected.IDVoltageLevel).
                            First().VoltageLevel1;
                            if (MaterialMessageBox.ShowWithCancel(
                                $"Оборудование будет внесено со следующими данными:\n" +
                                $"ID" +
                                $": {InputID}\n" +
                                $"Диспетчерское наименование" +
                                $": {_inputDispatchName}\n" +
                                $"Энергообъект установки" +
                                $": {powerFacilityName}\n" +
                                $"Класс оборудования" +
                                $": {className}\n" +
                                $"Имя типа оборудования" +
                                $": {typeName}\n" +
                                $"Класс напряжения оборудования" +
                                $": {voltageLevel} кВ\n" +
                                $"Длина" +
                                $": {InputLength}\n" +
                                $"Число цепей" +
                                $": {InputNumberOfWires}\n" +
                                $"Нажмите cancel для корректировки данных\n"
                                , "Проверка ввода")
                                == MessageBoxResult.OK)
                            {
                                if (Dp.GetTable<Equipment>().Any((it => it.ID == InputID)))
                                {
                                    if (MaterialMessageBox.ShowWithCancel(
                                        $"Оборудование с таким ID уже существует, данные для него будут скорректированны.\n" +
                                        $"Нажмите cancel для Отмены."
                                        , "Подтверждение действия")
                                        == MessageBoxResult.OK)
                                    {
                                        NewEquipment = Dp.GetTable<Equipment>().
                                        Where(it => it.ID == InputID).First();
                                        FillNewEquipment();
                                    }
                                }
                                else
                                {
                                    FillNewEquipment();
                                    Dp.GetTable<Equipment>().InsertOnSubmit(NewEquipment);
                                }
                                Dp.SubmitChanges();
                                TotalData.UpdateDataFromDataContext();
                                parameter.Close();
                                if (MaterialMessageBox.ShowWithCancel(
                                        $"Добавить токовые ограничения для оборудования?")
                                        == MessageBoxResult.OK)
                                {
                                    AddTCurrentDepend addTCurrentDependForNewEq = new AddTCurrentDepend();
                                    addTCurrentDependForNewEq.ShowDialog();
                                }
                            }
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
        /// Задание свойств нового оборудвоания
        /// </summary>
        private void FillNewEquipment()
        {
            NewEquipment.ID = InputID;
            NewEquipment.IDPowerFacility = PowerFacilitySelected.ID;
            NewEquipment.IDClass = EquipmentClassSelected.ID;
            NewEquipment.IDType = EquipmentTypeSelected.ID;
            NewEquipment.DispatchName = InputDispatchName;
            NewEquipment.Length = InputLength;
            NewEquipment.NumberOfWires = InputNumberOfWires;
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

        /// <summary>
        /// Добавление нового энергообъекта
        /// </summary>
        public RelayCommand<Window> AddPowerFacilityCommand
        {
            get
            {
                return new RelayCommand<Window>(parameter =>
                {
                    AddPowerFacility addPowerFacility = new AddPowerFacility();
                    addPowerFacility.Owner = parameter;
                    addPowerFacility.ShowDialog();
                });
            }
        }

        /// <summary>
        /// Добавление нового типа оборудования
        /// </summary>
        public RelayCommand<Window> AddEquipmentTypeCommand
        {
            get
            {
                return new RelayCommand<Window>(parameter =>
                {
                    AddEquipmentType addEquipmentType = new AddEquipmentType();
                    addEquipmentType.Owner = parameter;
                    addEquipmentType.ShowDialog();
                });
            }
        }

        #endregion
    }
}
