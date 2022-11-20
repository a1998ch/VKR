using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using _Excel = Microsoft.Office.Interop.Excel;
using System.Text.RegularExpressions;

namespace ExcelModel
{
    public class Excel
    {
        private _Excel._Application _excel = new _Excel.Application();

        private Workbook _workbook;

        private Worksheet _worksheet;

        private string _path;

        private int _sheet;

        protected string Path
        {
            set => _path = value;
            get => _path;
        }

        protected int Sheet
        {
            set => _sheet = value;
            get => _sheet;
        }

        // Найти последний заполненый столбец
        private int LastColumn
        {
            get => _worksheet.Cells.Find("*", System.Reflection.Missing.Value,
                                           System.Reflection.Missing.Value, System.Reflection.Missing.Value,
                                           _Excel.XlSearchOrder.xlByColumns, _Excel.XlSearchDirection.xlPrevious,
                                           false, System.Reflection.Missing.Value, System.Reflection.Missing.Value).Column;
        }

        // Найти последнюю заполненую строку
        private int LastRow
        {
            get => _worksheet.Cells.Find("*", System.Reflection.Missing.Value,
                                           System.Reflection.Missing.Value, System.Reflection.Missing.Value,
                                           _Excel.XlSearchOrder.xlByRows, _Excel.XlSearchDirection.xlPrevious,
                                           false, System.Reflection.Missing.Value, System.Reflection.Missing.Value).Row;
        }

        public Excel(string path, int sheet)
        {
            Path = path;
            Sheet = sheet;
            _workbook = _excel.Workbooks.Open(Path);
            _worksheet = _workbook.Worksheets[Sheet];
        }

        public void SaveExcel(string savePath)
        {
            _workbook.SaveAs(savePath);
        }
        public void ExcelClose()
        {
            _excel.Quit();
        }
        private string ReadCell(int i, int j)
        {
            return _worksheet.Cells[i, j].Value.ToString();
        }

        public string[,] WriteBook(string[,] array)
        {
            array = new string[LastRow, LastColumn];
            for (int i = 0; i < array.GetLength(0); i++)
            {
                array[i, 0] = ReadCell(i + 1, 1);
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = ReadCell(i + 1, j + 1);
                }
            }
            return array;
        }

        public List<T> WriteBookColumn<T>(string nameColumn, int firstRow = 1)
        {
            List<T> list = new List<T>();
            Range range = _worksheet.get_Range($"{nameColumn.ToUpper()}{firstRow}", $"{nameColumn}{LastRow}");
            foreach (var cell in range.Value)
            {
                list.Add(cell);
            }
            return list;
        }

        public void WriteCell(string[] array, int numberColumn, int firstRow = 1)
        {
            for (int i = 0; i < array.Length; i++)
            {
                _worksheet.Cells[i + firstRow, numberColumn] = array[i];
            }
        }
    }
}
