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
using System.Data;
using System.Data.OleDb;
using System.Globalization;
using System.Data.Common;
using System.Collections;

namespace DataBaseModel
{
    public class WorkingWithDatabase
    {
        private T GetValue<T>(String value)
        {
            return (T)Convert.ChangeType(value, typeof(T));
        }

        public List<T> ColumnName<T>(string connectionString, string query)
        {
            List<T> listNameCol = new List<T>();
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlCommand comand = new SqlCommand(query, sqlConnection);
                SqlDataReader dataReader = comand.ExecuteReader();

                for (int i = 0; i < dataReader.FieldCount; i++)
                {
                    listNameCol.Add(GetValue<T>(dataReader.GetName(i)));
                }
                return listNameCol;
            }
        }

        public List<T> Data<T>(string connectionString, string query)
        {
            List<T> listData = new List<T>();
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlCommand comand = new SqlCommand(query, sqlConnection);
                SqlDataReader dataReader = comand.ExecuteReader();
                
                while (dataReader.Read())
                {
                    for (int i = 0; i < dataReader.FieldCount; i++)
                    {
                        listData.Add(dataReader.GetFieldValue<T>(i));
                    }
                }
                return listData;
            }
        }

        public Dictionary<string, List<T>> DataDict<T>(string connectionString, string query)
        {
            Dictionary<string, List<T>> dictData = new Dictionary<string, List<T>>();
            List<T> listData = new List<T>();
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlCommand comand = new SqlCommand(query, sqlConnection);
                SqlDataReader dataReader = comand.ExecuteReader();

                for (int i = 0; i < dataReader.FieldCount; i++)
                {
                    while (dataReader.Read())
                    {
                        listData.Add(dataReader.GetFieldValue<T>(i));
                    }
                    dictData.Add(dataReader.GetName(i), listData);
                }
            }
            return dictData;
        }

        public List<T> AllData<T>(string connectionString, string query)
        {
            List<T> listData = ColumnName<T>(connectionString, query);
            listData.AddRange(Data<T>(connectionString, query));
            return listData;
        }

        public void SaveToCSV(string connectionString, string query, string path)
        {
            List<object> data = AllData<object>(connectionString, query);
            int ColumnCount = ColumnName<string>(connectionString, query).Count;

            using (var writer = new StreamWriter(path, false, Encoding.Default))
            {
                for (int i = 0, j = 1; i < data.Count; i++, j++)
                {
                    if (j == ColumnCount) 
                    { 
                        writer.Write(data[i].ToString() + "\n"); 
                        j = 0; 
                    }
                    else 
                    { 
                        writer.Write(data[i].ToString() + ";"); 
                    }
                }
            }
        }

        public DataTable ConvertToDataTable(string filePath)
        {
            DataTable dataTable = new DataTable();
            using (var stream = new StreamReader(filePath, Encoding.Default))
            {
                string[] headers = stream.ReadLine().Split(';');
                foreach (string header in headers)
                {
                    dataTable.Columns.Add(header);
                }
                while (!stream.EndOfStream)
                {
                    string[] rows = stream.ReadLine().Split(';');
                    DataRow dataRow = dataTable.NewRow();
                    for (int i = 0; i < headers.Length; i++)
                    {
                        dataRow[i] = rows[i];
                    }
                    dataTable.Rows.Add(dataRow);
                }
            }
            return dataTable;
        }

        public void PullData(string connectionString, DataTable dataTable, string query)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(query, connection);
                SqlDataAdapter sqlAdapret = new SqlDataAdapter(sqlCommand);
                sqlAdapret.Fill(dataTable);
                sqlAdapret.Dispose();
            }
        }

        public int SearchLastId(DataTable dataTable, string columnName)
        {
            DataRow lastRow = dataTable.Rows[dataTable.Rows.Count - 1];
            int id = (int)lastRow[columnName];
            return id;
        }

        public int SearchLastId(string connectionString, string tableName, string columnName)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand(DataBaseQuerys.LastId(tableName, columnName), connection);
                var result = sqlCommand.ExecuteScalar();
                return (int)result;
            }
        }
    }
}
