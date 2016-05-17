using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Data;
using System.IO;
using AutomationFrameWork.Exceptions;

namespace AutomationFrameWork.Utils
{
    public class ExcelUtilities
    {
        private static readonly ExcelUtilities _instance = new ExcelUtilities();
        static ExcelUtilities()
        {
        }
        public static ExcelUtilities Instance
        {
            get
            {
                return _instance;
            }
        }
        /// <summary>
        /// This method is use for
        /// return data in exel file
        /// </summary>        /// 
        /// <returns></returns>
        public DataTable GetExcelData(string path, string sheet, bool hasHeader = true)
        {
            DataTable _returnDataTable;
            int _totalCols = 0;
            int _totalRows = 0;
            int _startRow = hasHeader ? 2 : 1;
            ExcelRange _workSheetRow = null;
            DataRow _dataRow = null;
            try
            {
                using (ExcelPackage package = new ExcelPackage())
                {
                    // Open the Excel file and load it to the ExcelPackage
                    using (var stream = File.OpenRead(path))
                    {
                        package.Load(stream);
                    }
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.First();
                    _returnDataTable = new DataTable(worksheet.Name);
                    _totalCols = worksheet.Dimension.End.Column;
                    _totalRows = worksheet.Dimension.End.Row;
                    foreach (var firstRowCell in worksheet.Cells[1, 1, 1, _totalCols])
                    {
                        _returnDataTable.Columns.Add(hasHeader ? firstRowCell.Text : string.Format("Column {0}", firstRowCell.Start.Column));
                    }
                    for (int rowNum = _startRow; rowNum <= _totalRows; rowNum++)
                    {
                        _workSheetRow = worksheet.Cells[rowNum, 1, rowNum, _totalCols];
                        _dataRow = _returnDataTable.NewRow();
                        foreach (var cell in _workSheetRow)
                        {
                            _dataRow[cell.Start.Column - 1] = cell.Text;
                        }
                        _returnDataTable.Rows.Add(_dataRow);
                    }
                }
                return _returnDataTable;
            }
            catch (FileNotFoundException)
            {
                throw new StepErrorException("Cannot found excel file in '" + path + "'");
            }
            catch (IOException)
            {
                throw new StepErrorException("Cannot access excel file in '" + path + "'");
            }
            //Still define Data Type 

        }
    }
}
