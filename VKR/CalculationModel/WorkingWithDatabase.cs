﻿using System;
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

namespace CalculationModel
{
    public class WorkingWithDatabase
    {
        private List<T> DataList<T>(string connectionString, string query)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlCommand comand = new SqlCommand(query, sqlConnection);
                SqlDataReader dataReader = comand.ExecuteReader();

                List<T> listData = new List<T>();
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
                switch (nameOrValue)
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
            List<object> data = DataList<object>(connectionString, DataBaseQuerys.QueryAllData);
            using (var writer = new StreamWriter(path, false, Encoding.Default))
            {
                foreach (var value in data)
                {
                    writer.Write(value);
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

        public string LoadingCSVInDB(string connectionString, string path)
        {
            DataTable csvFileData = ConvertToDataTable(path);
            string a = String.Empty;

            foreach (DataRow row in csvFileData.Rows)
            {
                foreach (DataColumn column in csvFileData.Columns)
                {
                    a += row[column.ColumnName].ToString() + " ";
                }
            }
            return a;
        }
    }
}