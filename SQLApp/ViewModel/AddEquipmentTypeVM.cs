using BespokeFusion;
using Data;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace SQLApp
{
    /// <summary>
    /// Класс модели представления для окна добавления типа оборудования
    /// </summary>
    class AddEquipmentTypeVM : ViewModelBase
    {
        #region Коллекции как свойства
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

        /// <summary>
        /// Добавленный энергообъект
        /// </summary>
        public static EquipmentType NewEquipmentType
        {
            get
            {
                return TotalData.NewEquipmentType;
            }
            set
            {
                TotalData.NewEquipmentType = value;
            }
        }

        #endregion

        #region выбранные данные как свойства

        private EquipmentTypeView _selectedItem;
        /// <summary>
        /// Выбранный элемент
        /// </summary>
        public EquipmentTypeView SelectedItem
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
                    var selectedEquipmentType = CollectionEquipmentType.
                        Where(it => it.ID == _selectedItem.ID).First();
                    InputID = selectedEquipmentType.ID;
                    EquipmentClassSelected = CollectionEquipmentClass.
                        Where(it => it.ID == selectedEquipmentType.IDClass).First();
                    VoltageLevelSelected = CollectionVoltageLevel.
                        Where(it => it.ID == selectedEquipmentType.IDVoltageLevel).First();
                    InputTypeName = selectedEquipmentType.TypeName;
                    InputInom = selectedEquipmentType.Inom;
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
            }
        }

        private string inputTypeName;
        /// <summary>
        /// Введённое имя типа
        /// </summary>
        public string InputTypeName
        {
            get { return inputTypeName; }
            set
            {
                inputTypeName = value;
                OnPropertyChanged(nameof(InputTypeName));
            }
        }

        private VoltageLevel _voltageLevelSelected;
        /// <summary>
        /// Выбранный класс напряжения
        /// </summary>
        public VoltageLevel VoltageLevelSelected
        {
            get { return _voltageLevelSelected; }
            set
            {
                _voltageLevelSelected = value;
                OnPropertyChanged(nameof(VoltageLevelSelected));
            }
        }

        private int _inputInom;
        /// <summary>
        /// Введённый номинальный ток
        /// </summary>
        public int InputInom
        {
            get { return _inputInom; }
            set
            {
                _inputInom = value;
                OnPropertyChanged(nameof(InputInom));
            }
        }

        /// <summary>
        /// Загрузка данных
        /// </summary>
        public void LoadData()
        {
            NewEquipmentType = new EquipmentType();
            InputID = CollectionEquipmentType.Last().ID + 1;
        }


        #endregion

        #region Комманды

        /// <summary>
        /// Добавление типа оборудования
        /// </summary>
        public RelayCommand<Window> AddEquipmentTypeCommand
        {
            get
            {
                return new RelayCommand<Window>(parameter =>
                {
                    try
                    {
                        if (EquipmentClassSelected.ID == 0)
                        {
                            MaterialMessageBox.Show("Не выбран класс оборудования");
                        }
                        else if (VoltageLevelSelected.ID == 0)
                        {
                            MaterialMessageBox.Show("Не выбран класс напряжения");
                        }
                        else
                        {
                            var className = CollectionEquipmentClass.Where
                                (it => it.ID == EquipmentClassSelected.ID).First().ClassName;
                            var voltageLevel = CollectionVoltageLevel.Where
                                (it => it.ID == VoltageLevelSelected.ID).First().VoltageLevel1;
                            if (MaterialMessageBox.ShowWithCancel(
                                $"Тип оборудования будет внесён со следующими данными:\n" +
                                $"ID типа" +
                                $": {InputID}\n" +
                                $"Класс оборудования" +
                                $": {className}\n" +
                                $"Имя типа оборудования" +
                                $": {InputTypeName}\n" +
                                $"Класс напряжения оборудования" +
                                $": {voltageLevel}\n" +
                                $"Номинальный ток" +
                                $": {InputInom}\n" +
                                $"Нажмите cancel для корректировки данных\n"
                                , "Проверка ввода")
                                == MessageBoxResult.OK)
                            {
                                if (Dp.GetTable<EquipmentType>().Any((it => it.ID == InputID)))
                                {
                                    if (MaterialMessageBox.ShowWithCancel(
                                        $"Тип оборудования с таким ID уже существует, данные для него будут скорректированны.\n" +
                                        $"Нажмите cancel для Отмены."
                                        , "Подтверждение действия") 
                                        == MessageBoxResult.OK)
                                    {
                                        NewEquipmentType = Dp.GetTable<EquipmentType>().
                                        Where(it => it.ID == InputID).First();
                                        FillNewEquipmentType();
                                    }
                                }
                                else
                                {
                                    FillNewEquipmentType();
                                    Dp.GetTable<EquipmentType>().InsertOnSubmit(NewEquipmentType);
                                }
                                Dp.SubmitChanges();
                                TotalData.UpdateDataFromDataContext();
                                parameter.Close();
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
        /// Заполнение свойств нового типа оборудования
        /// </summary>
        private void FillNewEquipmentType()
        {
            NewEquipmentType.IDClass = EquipmentClassSelected.ID;
            NewEquipmentType.IDVoltageLevel = VoltageLevelSelected.ID;
            NewEquipmentType.TypeName = InputTypeName;
            NewEquipmentType.Inom = InputInom;
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
