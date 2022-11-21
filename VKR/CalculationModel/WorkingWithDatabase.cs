using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.ComponentModel;
using System.IO;
using System.Xml.Serialization;
using System.Security.Permissions;

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

        private List<T> DataList<T>(string connectionString)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlCommand comand = new SqlCommand(QueryAllData, sqlConnection);
                SqlDataReader dataReader = comand.ExecuteReader();

                List <T> listData = new List<T>();
                if (dataReader.HasRows)
                {
                    AddValue<T>(dataReader, listData, false);

                    while (dataReader.Read())
                    {
                        AddValue<T>(dataReader, listData);
                    }
                }
                return listData;
            }
        }

        private void AddValue<T>(SqlDataReader dataReader, List<T> list, bool nameOrValue = true)
        {
            var tabStop = GetValue<T>("\n");
            var semicolon = GetValue<T>(";");

            for (int i = 0; i < dataReader.FieldCount; i++)
            {
                switch(nameOrValue)
                {
                    case false:
                        list.Add(GetValue<T>(dataReader.GetName(i)));
                        break;
                    case true:
                        list.Add(dataReader.GetFieldValue<T>(i));
                        break;
                }
                if (i < dataReader.FieldCount - 1)
                    list.Add(semicolon);
            }
            list.Add(tabStop);
        }

        private T GetValue<T>(String value)
        {
            return (T)Convert.ChangeType(value, typeof(T));
        }

        public void SaveToCSV(string connectionString, string path)
        {
            List<object> data = DataList<object>(connectionString);
            using (var writer = new StreamWriter(path, false, System.Text.Encoding.Default))
            {
                foreach (var value in data)
                {
                    writer.Write(value);
                }
            }
        }
    }
}
