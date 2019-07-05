using Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Collections.ObjectModel;

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
        /// Формирование строки подключения
        /// </summary>
        /// <returns></returns>
        public void FormationSqlConnectionString()
        {
            ConnectionString = "Data Source=PAHOMOVIK;Initial Catalog=Current_info;Integrated Security=True";
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
