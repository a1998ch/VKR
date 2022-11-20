using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CalculationModel
{
    public class WorkingWithDatabase
    {
        private string QueryAllData
        {
            get =>
                   $"SELECT p.K2U_Value, p.Power_Value, v.Voltage_value, r.Regulation_Name, s.Scheme_Name " +
                   $"FROM Value_param p, Voltage_level v, Regulation_Type r, Scheme s " +
                   $"WHERE s.Voltage_id = v.Voltage_id AND " +
                   $"s.Value_id = p.Value_id AND " +
                   $"r.Regulation_id = s.Regulation_id";
        }

        public List<T> Data<T>(string connectionString)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlCommand comand = new SqlCommand(QueryAllData, sqlConnection);
                SqlDataReader dataReader = comand.ExecuteReader();

                List<T> list = new List<T>();
                while (dataReader.Read())
                {
                    for (int i = 0; i < dataReader.FieldCount; i++)
                    {
                        list.Add(dataReader.GetFieldValue<T>(i));
                    }
                }
                return list;
            }
        }
    }
}
