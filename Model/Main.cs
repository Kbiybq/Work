using System.ComponentModel;
using System.Data.SqlClient;




namespace Model
{
    public class Main
    {
        public static string SqlConnection() 
        {
            string connectionString = "Data Source=PAHOMOVIK;Initial Catalog=Current_info;Integrated Security=True";
            /*
            SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder();
            scsb.IntegratedSecurity = true;
            scsb.InitialCatalog = "master";
            DataConnectionDialog dlg = new DataConnectionDialog(scsb);
            if (DialogResult.OK == dlg.ShowDialog())
            {
                using (SqlConnection conn = new SqlConnection(dlg.ConnectionStringBuilder))
                {
                    conn.Open();
                    //...
                }
            }
            */
            return connectionString;
        }


    }
}
