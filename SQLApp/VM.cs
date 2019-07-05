using Data;
using System;
using System.Collections.ObjectModel;
using BespokeFusion;
using static SQLApp.SQLConnectionClass;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;

namespace SQLApp
{
    public class VM : Service
    {
        #region Коллекции как свойства

        /// <summary>
        /// Коллекция классов названий диспетчерских центров
        /// </summary>
        public ObservableCollection<DispatchingCenter> CollectionDispatchingCenter { get; set; } =
            new ObservableCollection<DispatchingCenter>();

        /// <summary>
        /// Коллекция класса уровней напряжения
        /// </summary>
        public ObservableCollection<VoltageLevelClass> CollectionVoltageLevel{ get; set; } =
            new ObservableCollection<VoltageLevelClass>();

        /// <summary>
        /// Коллекция класса описания ЛЭП
        /// </summary>
        public ObservableCollection<PowerLineDiscription> CollectionPowerLineDiscription{ get; set; } =
            new ObservableCollection<PowerLineDiscription>();

        /// <summary>
        /// Коллекция класса описание диспетчерского ведения
        /// </summary>
        public ObservableCollection<PowerLineDispatchingVision> CollectionPowerLineDVision { get; set; } =
            new ObservableCollection<PowerLineDispatchingVision>();

        /// <summary>
        /// Коллекция класса ЛЭП
        /// </summary>
        public ObservableCollection<PowerLine> CollectionPowerLine { get; set; } =
            new ObservableCollection<PowerLine>();

        /// <summary>
        /// Коллекция класса ЛЭП
        /// </summary>
        public ObservableCollection<PowerFacility> CollectionPowerFacility { get; set; } =
            new ObservableCollection<PowerFacility>();

        /// <summary>
        /// Коллекция класса описание типов токового ограничения
        /// </summary>
        public ObservableCollection<CurrentDepend> CollectionCurrentDepend { get; set; } =
            new ObservableCollection<CurrentDepend>();

        /// <summary>
        /// Коллекция класса описание допустимой токовой нагрузки оборудования (сегмента линии)
        /// </summary>
        public ObservableCollection<TCurrentDepend> CollectionTCurrentDepend { get; set; } =
            new ObservableCollection<TCurrentDepend>();
        #endregion


        #region Параметры сортировки как свойства
        private int DCControlSelectedId { get; set; }

        private int DCVisionSelectedId { get; set; }

        private int VoltageLevelSelectedId { get; set; }

        private int PowerFacilityStartSelectedId { get; set; }

        private int PowerFacilityEndSelectedId { get; set; }
        #endregion

        /// <summary>
        /// Подключение к базе данных и считывание информации
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public RelayCommand LoadingDataFromDB
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    try
                    {
                        SQLConnectionClass sQLConnection = new SQLConnectionClass();
                        sQLConnection.FormationSqlConnectionString();
                        sQLConnection.CreateSQLConnection();
                        var reader = sQLConnection.Reader(
                            "SELECT * FROM DispatchingCenter" + ";" +
                            "SELECT * FROM VoltageLevel" + ";" +
                            "SELECT * FROM PowerFacility" + ";" +
                            "SELECT * FROM PowerLineDiscription" + ";" +
                            "SELECT * FROM PowerLineDispatchingVision" + ";" +
                            "SELECT * FROM CurrentDepend" + ";" +
                            "SELECT * FROM TCurrentDepend");
                        while (reader.HasRows)
                        {
                            WhileReader(reader, 
                                (SqlDataReader) => FillDispatchingCenterCollection(SqlDataReader));
                            reader.NextResult();
                            WhileReader(reader, 
                                (SqlDataReader) => FillVoltageLevelCollection(SqlDataReader));
                            reader.NextResult();
                            WhileReader(reader, 
                                (SqlDataReader) => FillPowerFacilityCollection(SqlDataReader));
                            reader.NextResult();
                            WhileReader(reader,
                                (SqlDataReader) => FillPowerLineDiscriptionCollection(SqlDataReader));
                            reader.NextResult();
                            WhileReader(reader,
                                (SqlDataReader) => FillDispatchingCenterVisionCollection(SqlDataReader));
                        }
                        reader.Close();
                        FormationPowerLineCollection();
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
        /// Чтение всех строк в ридере
        /// </summary>
        /// <param name="reader"></param>
        private void WhileReader(SqlDataReader reader, Action<SqlDataReader> action)
        {
            while (reader.Read())
            {
                action.Invoke(reader);
            }
        }

        /// <summary>
        /// Заполнение коллекции диспетчерских центров
        /// </summary>
        /// <param name="reader"></param>
        private void FillDispatchingCenterCollection(SqlDataReader reader)
        {
            var id = Convert.ToInt32(reader["id"]);
            var nameDispatchingCenter = reader["NameDispatchingCenter"].ToString();
            CollectionDispatchingCenter.Add(new DispatchingCenter(id, nameDispatchingCenter));
        }

        /// <summary>
        /// Заполнение коллекции уровней напржения
        /// </summary>
        /// <param name="reader"></param>
        private void FillVoltageLevelCollection(SqlDataReader reader)
        {
            var id = Convert.ToInt32(
                reader[nameof(VoltageLevelClass.Id)]);
            var voltageLevel = Convert.ToInt32(
                reader[nameof(VoltageLevelClass.VoltageLevel)]);
            CollectionVoltageLevel.Add(new VoltageLevelClass(id, voltageLevel));
        }

        /// <summary>
        /// Заполнение колекции энергообъектов
        /// </summary>
        /// <param name="reader"></param>
        private void FillPowerFacilityCollection(SqlDataReader reader)
        {
            var id = Convert.ToInt32(
                reader[nameof(PowerFacility.Id)]);
            var dispatchName = 
                reader[nameof(PowerFacility.DispatchName)].ToString();
            CollectionPowerFacility.Add(new PowerFacility(id, dispatchName));
        }

        /// <summary>
        /// Заполнение колекции описания ЛЭП
        /// </summary>
        /// <param name="reader"></param>
        private void FillPowerLineDiscriptionCollection(SqlDataReader reader)
        {
            var id = Convert.ToInt32(
                reader[nameof(PowerLineDiscription.Id)]);
            var dispatchName = 
                reader[nameof(PowerLineDiscription.DispatchName)].ToString();
            var idVoltageLevel = Convert.ToInt32(
                reader[nameof(PowerLineDiscription.IdVoltageLevel)]);
            var idDispatchingCenterControl = Convert.ToInt32(
                reader[nameof(PowerLineDiscription.IdDispatchingCenterControl)]);
            var idPowerFacilityStart = Convert.ToInt32(
                reader[nameof(PowerLineDiscription.IdPowerFacilityStart)]);
            var idPowerFacilityEnd = Convert.ToInt32(
                reader[nameof(PowerLineDiscription.IdPowerFacilityEnd)]);
            var userItem = 
                reader[nameof(PowerLineDiscription.UserItem)].ToString();
            CollectionPowerLineDiscription.Add(new PowerLineDiscription(id,
                dispatchName, idVoltageLevel, idDispatchingCenterControl,
                idPowerFacilityStart, idPowerFacilityEnd, userItem));
        }

        /// <summary>
        /// Зополнение колекции ДЦ ведения
        /// </summary>
        /// <param name="reader"></param>
        private void FillDispatchingCenterVisionCollection(SqlDataReader reader)
        {
            var idPowerLine = Convert.ToInt32(reader["IDPowerLine"]);
            var idDispatchingCenterVision = Convert.ToInt32(
                reader[nameof(PowerLineDispatchingVision.IdDispatchingCenterVision)]);
            CollectionPowerLineDVision.Add(new PowerLineDispatchingVision(idPowerLine,
                idDispatchingCenterVision));
        }

        /// <summary>
        /// Формирование колекции ЛЭП
        /// </summary>
        private void FormationPowerLineCollection()
        {
            foreach (PowerLineDiscription powerLineDiscription in CollectionPowerLineDiscription )
            {
                var id = powerLineDiscription.Id;
                var dispatchName = powerLineDiscription.DispatchName;
                var voltageLevel = CollectionVoltageLevel.Where
                    (it => it.Id == powerLineDiscription.IdVoltageLevel)
                    .FirstOrDefault().VoltageLevel;
                var dispatchingCenterControl = CollectionDispatchingCenter.Where
                    (it => it.Id == powerLineDiscription.IdDispatchingCenterControl)
                    .FirstOrDefault().NameDispatchingCenter;
                var collectionDCenterVision = CollectionPowerLineDVision.Where
                    (it => it.Id == powerLineDiscription.Id);
                var dispatchingCenterVision = new List<string>();
                foreach (PowerLineDispatchingVision item in collectionDCenterVision)
                {
                    dispatchingCenterVision.Add(CollectionDispatchingCenter.Where
                        (it => it.Id == item.IdDispatchingCenterVision).
                        FirstOrDefault().NameDispatchingCenter);
                }
                var powerFacilityStart = CollectionPowerFacility.Where
                    (it => it.Id == powerLineDiscription.IdPowerFacilityStart)
                    .FirstOrDefault().DispatchName;
                var powerFacilityEnd = CollectionPowerFacility.Where
                    (it => it.Id == powerLineDiscription.IdPowerFacilityEnd)
                    .FirstOrDefault().DispatchName;
                var userItem = powerLineDiscription.UserItem;
                CollectionPowerLine.Add(new PowerLine(id, dispatchName, voltageLevel,
                    dispatchingCenterControl, dispatchingCenterVision, powerFacilityStart,
                    powerFacilityEnd, userItem));
            }

        }

    }
}
