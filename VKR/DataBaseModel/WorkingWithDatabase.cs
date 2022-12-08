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

        public List<string> GetColumnName(string connectionString, string query)
        {
            List<string> listNameCol = new List<string>();
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlCommand comand = new SqlCommand(query, sqlConnection);
                SqlDataReader dataReader = comand.ExecuteReader();

                for (int i = 0; i < dataReader.FieldCount; i++)
                {
                    listNameCol.Add(dataReader.GetName(i));
                }
                return listNameCol;
            }
        }

        public List<string> GetData(string connectionString, string query)
        {
            List<string> listData = new List<string>();
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlCommand comand = new SqlCommand(query, sqlConnection);
                SqlDataReader dataReader = comand.ExecuteReader();
                
                while (dataReader.Read())
                {
                    for (int i = 0; i < dataReader.FieldCount; i++)
                    {
                        string item = dataReader.GetFieldValue<object>(i).ToString();
                        listData.Add(item);
                    }
                }
                return listData;
            }
        }

        public void SaveToCSV(string connectionString, string query, string path)
        {
            List<string> listData = GetColumnName(connectionString, query);
            listData.AddRange(GetData(connectionString, query));
            int columnCount = GetColumnName(connectionString, query).Count;

            using (var writer = new StreamWriter(path, false, Encoding.Default))
            {
                for (int i = 0, j = 1; i < listData.Count; i++, j++)
                {
                    if (j == columnCount) 
                    { 
                        writer.Write(listData[i].ToString() + "\n"); 
                        j = 0; 
                    }
                    else 
                    { 
                        writer.Write(listData[i].ToString() + ";"); 
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

        public DataTable PullData(string connectionString, string query)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(query, connection);
                SqlDataAdapter sqlAdapret = new SqlDataAdapter(sqlCommand);
                sqlAdapret.Fill(dataTable);
                sqlAdapret.Dispose();
            }
            return dataTable;
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
