using BespokeFusion;
using Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SQLApp
{
    class AddPowerFacilityVM : ViewModelBase
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
        public static PowerFacility NewPowerFacility
        {
            get
            {
                return TotalData.NewPowerFacility;
            }
            set
            {
                TotalData.NewPowerFacility = value;
            }
        }

        #endregion

        #region выбранные данные как свойства

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

        private PowerFacility _selectedItem;
        /// <summary>
        /// Выбранный элемент
        /// </summary>
        public PowerFacility SelectedItem
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
                    InputID = SelectedItem.ID;
                    InputDispatchName = SelectedItem.DispatchName;
                }
            }
        }

        /// <summary>
        /// Загрузка данных
        /// </summary>
        public void LoadData()
        {
            NewPowerFacility = new PowerFacility();
        }

        #endregion

        #region Комманды

        /// <summary>
        /// Добавление нового энергообъекта
        /// </summary>
        public RelayCommand<Window> AddPowerFacilityCommand
        {
            get
            {
                return new RelayCommand<Window>(parameter =>
                {
                    try
                    {
                        if (MaterialMessageBox.ShowWithCancel(
                                $"Энергообъект будет внесён со следующими данными:\n" +
                                $"ID энергообъекта" +
                                $": {InputID}\n" +
                                $"Диспетчерское наименование энергообъекта" +
                                $": {InputDispatchName}\n" +
                                $"Нажмите cancel для корректировки данных\n"
                                , "Проверка ввода")
                                == MessageBoxResult.OK)
                        {
                            if (Dp.GetTable<PowerFacility>().Any((it => it.ID == InputID)))
                            {
                                if (MaterialMessageBox.ShowWithCancel(
                                    $"Энергообъект с таким ID уже существует, данные для него будут скорректированны.\n" +
                                    $"Нажмите cancel для Отмены."
                                    , "Подтверждение действия") 
                                    == MessageBoxResult.OK)
                                {
                                    NewPowerFacility = Dp.GetTable<PowerFacility>().
                                    Where(it => it.ID == InputID).First();
                                    FillNewPowerFacility();
                                }
                            }
                            else
                            {
                                FillNewPowerFacility();
                                Dp.GetTable<PowerFacility>().InsertOnSubmit(NewPowerFacility);
                            }
                            Dp.SubmitChanges();
                            TotalData.UpdateDataFromDataContext();
                            parameter.Close();
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
        /// Заполнение свойств нового энергообъекта
        /// </summary>
        private void FillNewPowerFacility()
        {
            NewPowerFacility.ID = InputID;
            NewPowerFacility.DispatchName = InputDispatchName;
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
    }
    #endregion
}
