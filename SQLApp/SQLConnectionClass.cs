using Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data.Linq;

namespace SQLApp
{
    public class SQLConnectionClass
    {
        /// <summary>
        /// Строка подключения
        /// </summary>
        private string ConnectionString { get; set; }

        /// <summary>
        /// Подключение
        /// </summary>
        private SqlConnection Connection { get; set; }

        /// <summary>
        /// Дата контекст
        /// </summary>
        public Current_infoDataContext db { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Current_infoDataContext CreateDataContext()
        {
            return db = new Current_infoDataContext(ConnectionString);
        }

        /// <summary>
        /// Формирование строки подключения
        /// </summary>
        /// <returns></returns>
        public void FormationSqlConnectionString()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        /// <summary>
        /// Cоздание подключения
        /// </summary>
        public void CreateSQLConnection()
        {
            Connection = new SqlConnection(ConnectionString);
            Connection.Open();
        }

        /// <summary>
        /// Закрытие подключения
        /// </summary>
        public void CloseSQLConnection()
        {
            Connection.Close();
        }

        /// <summary>
        /// Создание ридера с определённым запросом
        /// </summary>
        /// <param name="sqlExpression"></param>
        /// <returns></returns>
        public SqlDataReader Reader(string sqlExpression)
        {
            var reader = new SqlCommand(sqlExpression, Connection).ExecuteReader();
            return reader;
        }

        
    }
}
