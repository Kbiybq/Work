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

namespace SQLApp.ViewModel
{
    /// <summary>
    /// Класс модели представления для окна добавления типа токового ограничения
    /// </summary>
    class AddCurrentDependVM : ViewModelBase
    {
        #region Коллекции как свойства
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
        public ObservableCollection<string> CollectionTypeCurrentDepend { get; set; } = 
            new ObservableCollection<string>();

        /// <summary>
        /// Коллекция класса описание типов токового ограничения
        /// </summary>
        public ObservableCollection<string> CollectionTypeTime { get; set; } =
            new ObservableCollection<string>();

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

        private string _typeCurrentDependSelected;
        /// <summary>
        /// Выбранный тип ограничения
        /// </summary>
        public string TypeCurrentDependSelected
        {
            get { return _typeCurrentDependSelected; }
            set
            {
                _typeCurrentDependSelected = value;
                OnPropertyChanged(nameof(TypeCurrentDependSelected));
            }
        }

        private int _inputTime;
        /// <summary>
        /// Введённое значение времени превышения
        /// </summary>
        public int InputTime
        {
            get { return _inputTime; }
            set
            {
                _inputTime = value;
                OnPropertyChanged(nameof(InputTime));
            }
        }

        private string _typeTimeSelected;
        /// <summary>
        /// выбранное время
        /// </summary>
        public string TypeTimeSelected
        {
            get { return _typeTimeSelected; }
            set
            {
                _typeTimeSelected = value;
                OnPropertyChanged(nameof(TypeTimeSelected));
            }
        }

        #endregion

        /// <summary>
        /// Загрузка данных
        /// </summary>
        public void LoadData()
        {
            CollectionTypeCurrentDepend.Clear();
            CollectionTypeCurrentDepend.Add("ДДТН");
            CollectionTypeCurrentDepend.Add("АДТН");
            CollectionTypeTime.Clear();
            CollectionTypeTime.Add("с.");
            CollectionTypeTime.Add("мин.");
            InputID = CollectionCurrentDepend.Last().ID + 1;
        }

        #region Комманды

        /// <summary>
        /// Добавление нового токового ограничения
        /// </summary>
        public RelayCommand<Window> AddCurrentDependCommand
        {
            get
            {
                return new RelayCommand<Window>(parameter =>
                {
                    try
                    {
                        if (TypeCurrentDependSelected == "АДТН" | TypeCurrentDependSelected == "ДДТН")
                        {
                            if (TypeCurrentDependSelected == "АДТН" & TypeTimeSelected == null)
                            {
                                MaterialMessageBox.Show("Не указано допустимое время токовой нагрузки");
                            }
                            else
                            {
                                var result = MaterialMessageBox.ShowWithCancel(
                                $"Будет добавленно тип токового ограничения:\n" +
                                $"Тип ограничения" +
                                $": {TypeCurrentDependSelected}\n" +
                                $"Допустимое время токовой нагрузки" +
                                $": {InputTime}" + $" {TypeTimeSelected}\n" +
                                $"Нажмите cancel для корректировки данных\n"
                                , "Проверка ввода");
                                if (result == MessageBoxResult.OK)
                                {
                                    var newCurrentDepend = new CurrentDepend
                                    {
                                        ID = InputID,
                                        TypeOfCurrentLoad = TypeCurrentDependSelected,
                                        AllowTime = InputTime + " " + TypeTimeSelected
                                    };
                                    Dp.GetTable<CurrentDepend>().InsertOnSubmit(newCurrentDepend);
                                    Dp.SubmitChanges();
                                    parameter.Close();
                                }
                            }
                        }
                        else if (Dp.GetTable<CurrentDepend>().Any((it => it.ID == InputID)))
                        {
                            MaterialMessageBox.ShowError("Токовое ограничение с таким ID уже существует");
                        }
                        else
                        {
                            MaterialMessageBox.Show("Не выбран тип токового ограничения");
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
