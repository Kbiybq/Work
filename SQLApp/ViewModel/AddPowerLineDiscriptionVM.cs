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
    /// Класс модели представления для окна добавления энергообъекта
    /// </summary>
    class AddPowerLineDiscriptionVM : ViewModelBase
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
        /// коллекция выбранных ДЦ
        /// </summary>
        public ObservableCollection<DispatchingCenterWithChoiceVM> CollectionChecked
        {
            get
            {
                return TotalData.CollectionChecked;
            }
            set
            {
                TotalData.CollectionChecked = value;
            }
        }

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
        /// Загрузка данных
        /// </summary>
        public void LoadData()
        {
            NewPowerLineDiscription = new PowerLineDiscription();
            InputID = CollectionPowerLineDiscription.Last().ID + 1;
        }

        #endregion

        #region выбранные данные

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

        private string _inputDispatchName;
        /// <summary>
        /// Введённое диспетчерское наименование
        /// </summary>
        public string InputDispatchName
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

        private VoltageLevel _voltageLevelSelected;
        /// <summary>
        /// Выбранный класс напряжения
        /// </summary>
        public VoltageLevel VoltageLevelSelected
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

        private DispatchingCenter _dCControlSelected;
        /// <summary>
        /// Выбранный ДЦ контроля
        /// </summary>
        public DispatchingCenter DCControlSelected
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
        /// Выбранный ДЦ ведения
        /// </summary>
        public DispatchingCenter DCVisionSelected
        {
            get { return _dCVisionSelected; }
            set
            {
                _dCVisionSelected = value;
                OnPropertyChanged(nameof(DCVisionSelected));
            }
        }

        private PowerFacility _powerFacilityStartSelected;
        /// <summary>
        /// Выбранный энергообъект начала ЛЭП
        /// </summary>
        public PowerFacility PowerFacilityStartSelected
        {
            get { return _powerFacilityStartSelected; }
            set
            {
                _powerFacilityStartSelected = value;
                OnPropertyChanged(nameof(PowerFacilityStartSelected));
            }
        }

        private PowerFacility _powerFacilityEndSelected;
        /// <summary>
        /// Выбранный энергообъект конца ЛЭП
        /// </summary>
        public PowerFacility PowerFacilityEndSelected
        {
            get { return _powerFacilityEndSelected; }
            set
            {
                _powerFacilityEndSelected = value;
                OnPropertyChanged(nameof(PowerFacilityEndSelected));
            }
        }

        private PowerLineView _selectedItem;
        /// <summary>
        /// Выбранный элемент
        /// </summary>
        public PowerLineView SelectedItem
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
                    var selectedPowerLine = CollectionPowerLineDiscription.
                        Where(it => it.ID == _selectedItem.ID).First();
                    InputID = selectedPowerLine.ID;
                    InputDispatchName = selectedPowerLine.DispatchName;
                    VoltageLevelSelected = CollectionVoltageLevel.
                        Where(it => it.ID == selectedPowerLine.IDVoltageLevel).First();
                    DCControlSelected = CollectionDispatchingCenter.
                        Where(it => it.ID == selectedPowerLine.IDDispatchingCenterControl).First();
                    PowerFacilityStartSelected = CollectionPowerFacility.
                        Where(it => it.ID == selectedPowerLine.IDPowerFacilityStart).First();
                    PowerFacilityEndSelected = CollectionPowerFacility.
                        Where(it => it.ID == selectedPowerLine.IDPowerFacilityEnd).First();
                    foreach (DispatchingCenterWithChoiceVM item in CollectionChecked)
                    {
                        item.IsSelected = false;
                    }
                    foreach (PowerLineDispatchingVision item in
                        Dp.GetTable<PowerLineDispatchingVision>().
                                        Where(it => it.IDPowerLine == selectedPowerLine.ID))
                    {
                        CollectionChecked.Where(it => it.Id == item.IDDispatchingCenterVision).First().IsSelected = true;
                    }
                }
            }
        }

        #endregion

        #region Комманды

        /// <summary>
        /// Добавление
        /// </summary>
        public RelayCommand<Window> AddPowerLineCommand
        {
            get
            {
                return new RelayCommand<Window>(parameter =>
                {
                    try
                    {
                        if (InputID == 0)
                        {
                            MaterialMessageBox.Show("Не введён номер(ID) ЛЭП");
                        }
                        else if (InputDispatchName == "")
                        {
                            MaterialMessageBox.Show("Введите диспетчерское наименование оборудования");
                        }
                        else if (VoltageLevelSelected.ID == 0)
                        {
                            MaterialMessageBox.Show("Не выбран класс напряжения");
                        }
                        else if (DCControlSelected.ID == 0)
                        {
                            MaterialMessageBox.Show("Не выбран диспетчерский центр контроля");
                        }
                        else if (CollectionChecked.All(it => it.IsSelected == false))
                        {
                            MaterialMessageBox.Show("Не выбран диспетчерский центр ведения");
                        }
                        else if (PowerFacilityStartSelected.ID == 0)
                        {
                            MaterialMessageBox.Show("Не выбран энергообъект начала");
                        }
                        else if (PowerFacilityEndSelected.ID == 0)
                        {
                            MaterialMessageBox.Show("Не выбран энергообъект конца");
                        }
                        else
                        {
                            string dcVision = "";
                            foreach (DispatchingCenterWithChoiceVM item in CollectionChecked)
                            {
                                if(item.IsSelected)
                                {
                                    dcVision += item.Value + ";";
                                }
                            }
                            
                            if (MaterialMessageBox.ShowWithCancel(
                            $"ЛЭП будет внесена со следующими данными:\n" +
                            $"ID" +
                            $": {InputID}\n" +
                            $"Диспетчерское наименование" +
                            $": {InputDispatchName}\n" +
                            $"Класс напряжения" +
                            $": {VoltageLevelSelected.VoltageLevel1} кВ\n" +
                            $"ДЦ контроля" +
                            $": {DCControlSelected.NameDispatchingCenter}\n" +
                            $"ДЦ ведения" +
                            $": {dcVision}\n" +
                            $"Энергообъект начала" +
                            $": {PowerFacilityStartSelected.DispatchName}\n" +
                            $"Энергообъект конца" +
                            $": {PowerFacilityEndSelected.DispatchName}\n" +
                            $"Нажмите cancel для корректировки данных\n"
                            , "Проверка ввода")
                            == MessageBoxResult.OK)
                            {
                                if (Dp.GetTable<PowerLineDiscription>().Any((it => it.ID == InputID)))
                                {
                                    if (MaterialMessageBox.ShowWithCancel(
                                    $"ЛЭП с таким ID уже существует, данные для неё будут скорректированны.\n" +
                                    $"Нажмите cancel для Отмены."
                                    , "Подтверждение действия")
                                    == MessageBoxResult.OK)
                                    {
                                        NewPowerLineDiscription = Dp.GetTable<PowerLineDiscription>().
                                        Where(it => it.ID == InputID).First();
                                        FillNewPowerLineDiscription();
                                        InsertPowerLineDispatchingVision();
                                    }
                                }
                                else
                                {
                                    FillNewPowerLineDiscription();
                                    InsertPowerLineDispatchingVision();
                                    Dp.GetTable<PowerLineDiscription>().InsertOnSubmit(NewPowerLineDiscription);
                                }
                                Dp.SubmitChanges();
                                TotalData.UpdateDataFromDataContext();
                                parameter.Close();

                                if (MaterialMessageBox.ShowWithCancel(
                                        $"Добавить оборудование для ЛЭП?")
                                        == MessageBoxResult.OK)
                                {
                                    AddPowerLineComposition addPowerLine = new AddPowerLineComposition();
                                    addPowerLine.ShowDialog();
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
        /// Добваление
        /// </summary>
        private void FillNewPowerLineDiscription()
        {
            NewPowerLineDiscription.ID = InputID;
            NewPowerLineDiscription.DispatchName = InputDispatchName;
            NewPowerLineDiscription.IDVoltageLevel = VoltageLevelSelected.ID;
            NewPowerLineDiscription.IDDispatchingCenterControl = DCControlSelected.ID;
            NewPowerLineDiscription.IDPowerFacilityStart = _powerFacilityStartSelected.ID;
            NewPowerLineDiscription.IDPowerFacilityEnd = _powerFacilityEndSelected.ID;
            NewPowerLineDiscription.UserItem = Environment.UserName;
        }

        private void InsertPowerLineDispatchingVision()
        {
            if (Dp.GetTable<PowerLineDispatchingVision>().
                                        Where(it => it.IDPowerLine == InputID).Any())
            {
                foreach (PowerLineDispatchingVision item in
                Dp.GetTable<PowerLineDispatchingVision>().
                                        Where(it => it.IDPowerLine == InputID))
                {
                    Dp.GetTable<PowerLineDispatchingVision>().DeleteOnSubmit(item);
                }
            }
            foreach (int item in 
                CollectionChecked.Where(v => v.IsSelected).Select(v => v.Id))
            {
                var NewDCVision = new PowerLineDispatchingVision();
                NewDCVision.IDPowerLine = NewPowerLineDiscription.ID;
                NewDCVision.IDDispatchingCenterVision = item;
                Dp.GetTable<PowerLineDispatchingVision>().InsertOnSubmit(NewDCVision);
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

        #endregion
    }
}
