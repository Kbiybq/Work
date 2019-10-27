using BespokeFusion;
using Data;
using SQLApp.Windows;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace SQLApp.ViewModel
{
    /// <summary>
    /// Класс модели представления для окна добавления токового ограничения
    /// </summary>
    class AddTCurrentDependVM : ViewModelBase
    {
        #region Коллекции как свойства
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

        #region выбранные данные как свойства

        /// <summary>
        /// Последнее добавленное оборудование
        /// </summary>
        public static TCurrentDepend NewTCurrentDepend
        {
            get
            {
                return TotalData.NewTCurrentDepend;
            }
            set
            {
                TotalData.NewTCurrentDepend = value;
            }
        }


        private EquipmentView _equipmentSelected;
        /// <summary>
        /// Оборудование, выбранное для добавления
        /// </summary>
        public EquipmentView EquipmentSelected
        {
            get { return _equipmentSelected; }
            set
            {
                _equipmentSelected = value;
                OnPropertyChanged(nameof(EquipmentSelected));
            }
        }

        private CurrentDepend _currentDependSelected;
        /// <summary>
        /// Выбранный тип токового ограничения
        /// </summary>
        public CurrentDepend CurrentDependSelected
        {
            get { return _currentDependSelected; }
            set
            {
                _currentDependSelected = value;
                OnPropertyChanged(nameof(CurrentDependSelected));
                FillCollectionEquipmentTCurrentDepend();
            }
        }

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
                    FillCollectionEquipmentTCurrentDepend();
                }
            }
        }

        /// <summary>
        /// Метод для формирования коллекции тококвых ограничений по выбранным парамтрам
        /// </summary>
        private void FillCollectionEquipmentTCurrentDepend()
        {
            EquipmentSelected = SelectedItem;
            if (CurrentDependSelected != null)
            {
                CollectionEquipmentTCurrentDepend.Clear();
                var collectionSelectEquipmentTCurrent =
                    CollectionTCurrentDepend.
                    Where(it => it.IDEquipment == SelectedItem.ID).
                    Where(it => it.IDCurrentDepend == CurrentDependSelected.ID);
                for (int i = -35; i <= 40; i = i + 5)
                {
                    if (collectionSelectEquipmentTCurrent.
                            Where(it => it.Temp == i).Count() == 1)
                    {
                        CollectionEquipmentTCurrentDepend.
                            Add(collectionSelectEquipmentTCurrent.
                            Where(it => it.Temp == i).First());
                    }
                    else
                    {
                        var item = new TCurrentDepend();
                        item.Temp = i;
                        CollectionEquipmentTCurrentDepend.Add(item);
                    }
                }
            }
        }

        #endregion

        /// <summary>
        /// Загрузка данных
        /// </summary>
        public void LoadData()
        {
            if(NewEquipment.ID != 0)
            {
                EquipmentSelected = CollectionEquipmentView.
                    Where(it => it.ID == NewEquipment.ID).First();
            }
        }

        #region Комманды

        /// <summary>
        /// Добавление нового токового ограничения
        /// </summary>
        public RelayCommand<Window> AddTCurrentDependCommand
        {
            get
            {
                return new RelayCommand<Window>(parameter =>
                {
                    try
                    {
                        if (CurrentDependSelected.ID == 0 | CurrentDependSelected == null)
                        {
                            MaterialMessageBox.Show("Не выбран тип токового ограничения");
                        }
                        else if (EquipmentSelected.ID == 0 | EquipmentSelected == null)
                        {
                            MaterialMessageBox.Show("Не выбрано оборудование");
                        }
                        else
                        {
                            if (MaterialMessageBox.ShowWithCancel(
                                $"Будет добавленно токовое ограничение для:\n" +
                                $"Оборудование" +
                                $": {EquipmentSelected.DispatchName}\n" +
                                $"Установленное на" +
                                $": {EquipmentSelected.PowerFacility}\n" +
                                $"Нажмите cancel для корректировки данных\n"
                                , "Проверка ввода") 
                                == MessageBoxResult.OK)
                            {
                                if (Dp.GetTable<TCurrentDepend>()
                                .Where(it => it.IDEquipment == EquipmentSelected.ID)
                                .Any(it => it.IDCurrentDepend == CurrentDependSelected.ID))
                                {
                                    if (MaterialMessageBox.ShowWithCancel(
                                        $"Для данного оборудования уже заданно данное токовое ограничение," +
                                        $" данные будут скорректированны.\n" +
                                        $"Нажмите cancel для Отмены."
                                        , "Подтверждение действия")
                                        == MessageBoxResult.OK)
                                    {
                                        foreach (TCurrentDepend item in CollectionEquipmentTCurrentDepend)
                                        {
                                            if(Dp.GetTable<TCurrentDepend>()
                                            .Where(it => it.IDEquipment == EquipmentSelected.ID)
                                            .Where(it => it.IDCurrentDepend == CurrentDependSelected.ID)
                                            .Where(it => it.Temp == item.Temp).Count() == 0)
                                            {
                                                FillNewTCurrentDepend(item);
                                                Dp.GetTable<TCurrentDepend>().InsertOnSubmit(NewTCurrentDepend);
                                            }
                                            else
                                            {
                                                NewTCurrentDepend = Dp.GetTable<TCurrentDepend>()
                                                .Where(it => it.IDEquipment == EquipmentSelected.ID)
                                                .Where(it => it.IDCurrentDepend == CurrentDependSelected.ID)
                                                .Where(it => it.Temp == item.Temp).First();
                                                FillNewTCurrentDepend(item);
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    foreach (TCurrentDepend item in CollectionEquipmentTCurrentDepend)
                                    {
                                        FillNewTCurrentDepend(item);
                                        Dp.GetTable<TCurrentDepend>().InsertOnSubmit(NewTCurrentDepend);
                                        Dp.SubmitChanges();
                                    }
                                }
                                TotalData.UpdateDataFromDataContext();
                                parameter.Close();
                                if (MaterialMessageBox.ShowWithCancel(
                                            $"Добавить eще токовые ограничения для оборудования?")
                                            == MessageBoxResult.OK)
                                {
                                    AddTCurrentDepend addTCurrentDepend = new AddTCurrentDepend();
                                    addTCurrentDepend.ShowDialog();
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
        /// Заполнение свойств нового токового ограничения
        /// </summary>
        /// <param name="item"></param>
       private void FillNewTCurrentDepend(TCurrentDepend item)
        {
            NewTCurrentDepend = new TCurrentDepend();
            NewTCurrentDepend.IDEquipment = EquipmentSelected.ID;
            NewTCurrentDepend.IDCurrentDepend = CurrentDependSelected.ID;
            NewTCurrentDepend.Temp = item.Temp;
            NewTCurrentDepend.Current = item.Current;
            NewTCurrentDepend.Kcorr = item.Kcorr;
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
