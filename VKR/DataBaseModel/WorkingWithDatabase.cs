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

        public void SaveToCSV(DataTable dataTable, string path)
        {
            using (var writer = new StreamWriter(path, false, Encoding.Default))
            {
                int i = 0;
                foreach (DataColumn col in dataTable.Columns)
                {
                    if (i == dataTable.Columns.Count - 1)
                    {
                        writer.Write(col.ColumnName.ToString());
                    }
                    else
                    {
                        writer.Write(col.ColumnName.ToString() + ";");
                    }
                    i++;
                }
                writer.Write("\n");

                foreach (DataRow row in dataTable.Rows)
                {
                    int j = 0;
                    foreach (DataColumn col in dataTable.Columns)
                    {
                        if (j == dataTable.Columns.Count - 1)
                        {
                            writer.Write(row[col.ColumnName].ToString());
                        }
                        else
                        {
                            writer.Write(row[col.ColumnName].ToString() + ";");
                        }
                        j++;
                    }
                    writer.Write("\n");
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

                if (dataTable.Columns.Count != 7)
                {
                    throw new ArgumentException("Структура файла не соответствует требуемому формату");
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

        public DataTable AddTableToDataTable(string connectionString, string query, DataTable dataTable, bool autoGenId = false)
        {
            DataTable dt = new DataTable();

            int idIncrease = 0;
            int lastId = SearchLastId(connectionString, "Schema_data", "Scheme_id");

            List<string> colNameList = GetColumnName(connectionString, query);
            foreach (var col in colNameList)
            {
                dt.Columns.Add(col);
            }

            foreach (DataRow row in dataTable.Rows)
            {
                var dtRow = dt.Rows.Add();
                idIncrease++;
                foreach (DataColumn col in dataTable.Columns)
                {
                    if (colNameList.Contains(col.ColumnName))
                    {
                        if (autoGenId)
                        {
                            dtRow["Scheme_id"] = lastId + idIncrease - dataTable.Rows.Count;
                        }
                        dtRow[col.ColumnName] = row[col.ColumnName];
                    }
                }
            }
            return dt;
        }

        public bool AddTableToDb(string connectionString, string query, DataTable dataTable, bool autoGenId = false)
        {
            int checkResult = 0;
            DataTable dt = AddTableToDataTable(connectionString, query, dataTable, autoGenId);
            DataTable dtCheck = PullData(connectionString, query);

            for (int item = 0; item < dt.Rows.Count; item++)
            {
                for (int i = 0; i < dtCheck.Rows.Count; i++)
                {
                    int check = 0;
                    for (int j = 0; j < dtCheck.Columns.Count; j++)
                    {
                        if (dtCheck.Rows[i][j].ToString() == dt.Rows[item][j].ToString())
                        {
                            check++;
                        }
                    }
                    if (check == dtCheck.Columns.Count - 1)
                    {
                        checkResult++;
                    }
                    if (checkResult > 1)
                    {
                        return false;
                    }
                }
            }

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var adapter = new SqlDataAdapter(query, connection);
                var commandBuilder = new SqlCommandBuilder(adapter);
                adapter.Update(dt);
            }
            return true;
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
