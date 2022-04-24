﻿using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.SS.Util;

namespace EbSite.Core
{

    public static class ExcelHelper
    {

        public static void ExportTest(List<DataTable> dtSource, string strHeaderText, string strFileName, List<string> sheetName)
        {
            using (MemoryStream ms = Export(dtSource, strHeaderText, sheetName))
            {
                using (FileStream fs = new FileStream(strFileName, FileMode.Create, FileAccess.Write))
                {
                    byte[] data = ms.ToArray();
                    fs.Write(data, 0, data.Length);
                    fs.Flush();
                }
            }
        }
        #region DataTable导出到Excel文件
        /// <summary>   
        /// DataTable导出到Excel文件   
        /// </summary>   
        /// <param name="dtSource">源DataTable</param>   
        /// <param name="strHeaderText">表头文本</param>   
        /// <param name="strFileName">保存位置</param>   
        public static void Export(DataTable dtSource, string strHeaderText, string strFileName)
        {
            using (MemoryStream ms = Export(dtSource, strHeaderText))
            {
                using (FileStream fs = new FileStream(strFileName, FileMode.Create, FileAccess.Write))
                {
                    byte[] data = ms.ToArray();
                    fs.Write(data, 0, data.Length);
                    fs.Flush();
                }
            }
        }

        public static MemoryStream Export(List<DataTable> dtSource, string strHeaderText, List<string> sheetName)
        {
            HSSFWorkbook workbook = new HSSFWorkbook();


            for (int sheetIndex = 0; sheetIndex < sheetName.Count; sheetIndex++)
            {
                ISheet sheet = workbook.CreateSheet(sheetName[sheetIndex]);
                ICellStyle dateStyle = workbook.CreateCellStyle();
                IDataFormat format = workbook.CreateDataFormat();
                dateStyle.DataFormat = format.GetFormat("yyyy-mm-dd");

                //取得列宽   
                int[] arrColWidth = new int[dtSource[sheetIndex].Columns.Count];
                foreach (DataColumn item in dtSource[sheetIndex].Columns)
                {
                    arrColWidth[item.Ordinal] = Encoding.GetEncoding(936).GetBytes(item.ColumnName.ToString()).Length;
                }
                for (int i = 0; i < dtSource[sheetIndex].Rows.Count; i++)
                {
                    for (int j = 0; j < dtSource[sheetIndex].Columns.Count; j++)
                    {
                        int intTemp = Encoding.GetEncoding(936).GetBytes(dtSource[sheetIndex].Rows[i][j].ToString()).Length;
                        if (intTemp > arrColWidth[j])
                        {
                            arrColWidth[j] = intTemp;
                        }
                    }
                }

                int rowIndex = 0;

                if (dtSource[sheetIndex].Rows.Count == 0)
                {
                    try
                    {
                        #region 新建表，填充表头，填充列头，样式
                        if (rowIndex == 65535 || rowIndex == 0)
                        {
                            if (rowIndex != 0)
                            {
                                sheet = workbook.CreateSheet();
                            }

                            #region 表头及样式
                            {
                                IRow headerRow = sheet.CreateRow(0);
                                headerRow.HeightInPoints = 25;
                                headerRow.CreateCell(0).SetCellValue(sheetName[sheetIndex] + strHeaderText);

                                ICellStyle headStyle = workbook.CreateCellStyle();
                                headStyle.Alignment = HorizontalAlignment.CENTER;
                                IFont font = workbook.CreateFont();
                                font.FontHeightInPoints = 12;
                                font.Boldweight = 700;
                                headStyle.SetFont(font);

                                headerRow.GetCell(0).CellStyle = headStyle;

                                sheet.AddMergedRegion(new CellRangeAddress(0, 0, 0, dtSource[sheetIndex].Columns.Count - 1));
                                //headerRow.Dispose();
                                //headerRow.d
                            }
                            #endregion

                            #region 列头及样式
                            {
                                IRow headerRow = sheet.CreateRow(1);

                                ICellStyle headStyle = workbook.CreateCellStyle();
                                headStyle.Alignment = HorizontalAlignment.CENTER;
                                IFont font = workbook.CreateFont();
                                font.FontHeightInPoints = 10;
                                font.Boldweight = 700;
                                headStyle.SetFont(font);

                                foreach (DataColumn column in dtSource[sheetIndex].Columns)
                                {
                                    headerRow.CreateCell(column.Ordinal).SetCellValue(column.ColumnName);
                                    headerRow.GetCell(column.Ordinal).CellStyle = headStyle;

                                    //设置列宽   
                                    sheet.SetColumnWidth(column.Ordinal, (arrColWidth[column.Ordinal] + 1) * 256);

                                }
                                //headerRow.Dispose();
                            }
                            #endregion

                            rowIndex = 2;
                        }
                        #endregion
                    }
                    catch
                    { }
                }
                else
                {

                    foreach (DataRow row in dtSource[sheetIndex].Rows)
                    {
                        #region 新建表，填充表头，填充列头，样式
                        if (rowIndex == 65535 || rowIndex == 0)
                        {
                            if (rowIndex != 0)
                            {
                                sheet = workbook.CreateSheet();
                            }

                            #region 表头及样式
                            {
                                IRow headerRow = sheet.CreateRow(0);
                                headerRow.HeightInPoints = 25;
                                headerRow.CreateCell(0).SetCellValue(sheetName[sheetIndex] + strHeaderText);

                                ICellStyle headStyle = workbook.CreateCellStyle();
                                headStyle.Alignment = HorizontalAlignment.CENTER;
                                IFont font = workbook.CreateFont();
                                font.FontHeightInPoints = 12;
                                font.Boldweight = 700;
                                headStyle.SetFont(font);

                                headerRow.GetCell(0).CellStyle = headStyle;

                                sheet.AddMergedRegion(new CellRangeAddress(0, 0, 0, dtSource[sheetIndex].Columns.Count - 1));
                                //headerRow.Dispose();
                                //headerRow.d
                            }
                            #endregion

                            #region 列头及样式
                            {
                                IRow headerRow = sheet.CreateRow(1);

                                ICellStyle headStyle = workbook.CreateCellStyle();
                                headStyle.Alignment = HorizontalAlignment.CENTER;
                                IFont font = workbook.CreateFont();
                                font.FontHeightInPoints = 10;
                                font.Boldweight = 700;
                                headStyle.SetFont(font);

                                foreach (DataColumn column in dtSource[sheetIndex].Columns)
                                {
                                    headerRow.CreateCell(column.Ordinal).SetCellValue(column.ColumnName);
                                    headerRow.GetCell(column.Ordinal).CellStyle = headStyle;

                                    //设置列宽   
                                    sheet.SetColumnWidth(column.Ordinal, (arrColWidth[column.Ordinal] + 1) * 256);

                                }
                                //headerRow.Dispose();
                            }
                            #endregion

                            rowIndex = 2;
                        }
                        #endregion


                        #region 填充内容
                        IRow dataRow = sheet.CreateRow(rowIndex);
                        foreach (DataColumn column in dtSource[sheetIndex].Columns)
                        {
                            ICell newCell = dataRow.CreateCell(column.Ordinal);

                            string drValue = row[column].ToString();

                            switch (column.DataType.ToString())
                            {
                                case "System.String"://字符串类型   
                                    newCell.SetCellValue(drValue);
                                    break;
                                case "System.DateTime"://日期类型   
                                    DateTime dateV;
                                    DateTime.TryParse(drValue, out dateV);
                                    newCell.SetCellValue(dateV);

                                    newCell.CellStyle = dateStyle;//格式化显示   
                                    break;
                                case "System.Boolean"://布尔型   
                                    bool boolV = false;
                                    bool.TryParse(drValue, out boolV);
                                    newCell.SetCellValue(boolV);
                                    break;
                                case "System.Int16"://整型   
                                case "System.Int32":
                                case "System.Int64":
                                case "System.Byte":
                                    int intV = 0;
                                    int.TryParse(drValue, out intV);
                                    newCell.SetCellValue(intV);
                                    break;
                                case "System.Decimal"://浮点型   
                                case "System.Double":
                                    double doubV = 0;
                                    double.TryParse(drValue, out doubV);
                                    newCell.SetCellValue(doubV);
                                    break;
                                case "System.DBNull"://空值处理   
                                    newCell.SetCellValue("");
                                    break;
                                default:
                                    newCell.SetCellValue("");
                                    break;
                            }

                        }
                        #endregion

                        rowIndex++;
                    }
                }
            }

            using (MemoryStream ms = new MemoryStream())
            {
                workbook.Write(ms);
                ms.Flush();
                ms.Position = 0;
                workbook = null;
                return ms;
            }

        }

        /// <summary>   
        /// DataTable导出到Excel的MemoryStream   
        /// </summary>   
        /// <param name="dtSource">源DataTable</param>   
        /// <param name="strHeaderText">表头文本</param>    
        public static MemoryStream Export(DataTable dtSource, string strHeaderText)
        {
            HSSFWorkbook workbook = new HSSFWorkbook();
            ISheet sheet = workbook.CreateSheet();

            #region 右击文件 属性信息
            {
                //DocumentSummaryInformation dsi = PropertySetFactory.CreateDocumentSummaryInformation();
                //dsi.Company = "";
                //workbook.DocumentSummaryInformation = dsi;

                //SummaryInformation si = PropertySetFactory.CreateSummaryInformation();
                //si.Author = ""; //填加xls文件作者信息   
                //si.ApplicationName = "NPOI测试程序"; //填加xls文件创建程序信息   
                //si.LastAuthor = ""; //填加xls文件最后保存者信息   
                //si.Comments = "说明信息"; //填加xls文件作者信息   
                //si.Title = "NPOI测试"; //填加xls文件标题信息   
                //si.Subject = "NPOI测试Demo";//填加文件主题信息   
                //si.CreateDateTime = DateTime.Now;
                //workbook.SummaryInformation = si;
            }
            #endregion

            ICellStyle dateStyle = workbook.CreateCellStyle();
            IDataFormat format = workbook.CreateDataFormat();
            dateStyle.DataFormat = format.GetFormat("yyyy-mm-dd");

            //取得列宽   
            int[] arrColWidth = new int[dtSource.Columns.Count];
            foreach (DataColumn item in dtSource.Columns)
            {
                arrColWidth[item.Ordinal] = Encoding.GetEncoding(936).GetBytes(item.ColumnName.ToString()).Length;
            }
            for (int i = 0; i < dtSource.Rows.Count; i++)
            {
                for (int j = 0; j < dtSource.Columns.Count; j++)
                {
                    int intTemp = Encoding.GetEncoding(936).GetBytes(dtSource.Rows[i][j].ToString()).Length;
                    if (intTemp > arrColWidth[j])
                    {
                        arrColWidth[j] = intTemp;
                    }
                }
            }

            int rowIndex = 0;

            foreach (DataRow row in dtSource.Rows)
            {
                #region 新建表，填充表头，填充列头，样式
                if (rowIndex == 65535 || rowIndex == 0)
                {
                    if (rowIndex != 0)
                    {
                        sheet = workbook.CreateSheet();
                    }

                    #region 表头及样式
                    {
                        IRow headerRow = sheet.CreateRow(0);
                        headerRow.HeightInPoints = 25;
                        headerRow.CreateCell(0).SetCellValue(strHeaderText);

                        ICellStyle headStyle = workbook.CreateCellStyle();
                        headStyle.Alignment = HorizontalAlignment.CENTER;
                        IFont font = workbook.CreateFont();
                        font.FontHeightInPoints = 20;
                        font.Boldweight = 700;
                        headStyle.SetFont(font);

                        headerRow.GetCell(0).CellStyle = headStyle;

                        sheet.AddMergedRegion(new CellRangeAddress(0, 0, 0, dtSource.Columns.Count - 1));
                        //headerRow.Dispose();
                    }
                    #endregion


                    #region 列头及样式
                    {
                        IRow headerRow = sheet.CreateRow(1);


                        ICellStyle headStyle = workbook.CreateCellStyle();
                        headStyle.Alignment = HorizontalAlignment.CENTER;
                        IFont font = workbook.CreateFont();
                        font.FontHeightInPoints = 10;
                        font.Boldweight = 700;
                        headStyle.SetFont(font);


                        foreach (DataColumn column in dtSource.Columns)
                        {
                            headerRow.CreateCell(column.Ordinal).SetCellValue(column.ColumnName);
                            headerRow.GetCell(column.Ordinal).CellStyle = headStyle;

                            //设置列宽   
                            sheet.SetColumnWidth(column.Ordinal, (arrColWidth[column.Ordinal] + 1) * 256);

                        }
                        //headerRow.Dispose();
                    }
                    #endregion

                    rowIndex = 2;
                }
                #endregion


                #region 填充内容
                IRow dataRow = sheet.CreateRow(rowIndex);
                foreach (DataColumn column in dtSource.Columns)
                {
                    ICell newCell = dataRow.CreateCell(column.Ordinal);

                    string drValue = row[column].ToString();

                    switch (column.DataType.ToString())
                    {
                        case "System.String"://字符串类型   
                            newCell.SetCellValue(drValue);
                            break;
                        case "System.DateTime"://日期类型   
                            DateTime dateV;
                            DateTime.TryParse(drValue, out dateV);
                            newCell.SetCellValue(dateV);

                            newCell.CellStyle = dateStyle;//格式化显示   
                            break;
                        case "System.Boolean"://布尔型   
                            bool boolV = false;
                            bool.TryParse(drValue, out boolV);
                            newCell.SetCellValue(boolV);
                            break;
                        case "System.Int16"://整型   
                        case "System.Int32":
                        case "System.Int64":
                        case "System.Byte":
                            int intV = 0;
                            int.TryParse(drValue, out intV);
                            newCell.SetCellValue(intV);
                            break;
                        case "System.Decimal"://浮点型   
                        case "System.Double":
                            double doubV = 0;
                            double.TryParse(drValue, out doubV);
                            newCell.SetCellValue(doubV);
                            break;
                        case "System.DBNull"://空值处理   
                            newCell.SetCellValue("");
                            break;
                        default:
                            newCell.SetCellValue("");
                            break;
                    }

                }
                #endregion

                rowIndex++;
            }


            using (MemoryStream ms = new MemoryStream())
            {
                workbook.Write(ms);
                ms.Flush();
                ms.Position = 0;

                //sheet.Dispose();
                //workbook.Dispose();//一般只用写这一个就OK了，他会遍历并释放所有资源，但当前版本有问题所以只释放sheet   
                return ms;
            }

        }

        #endregion
        ///// <summary>   
        ///// 用于Web导出   
        ///// </summary>   
        ///// <param name="dtSource">源DataTable</param>   
        ///// <param name="strHeaderText">表头文本</param>   
        ///// <param name="strFileName">文件名</param>   
        //public static void ExportByWeb(DataTable dtSource, string strHeaderText, string strFileName)
        //{

        //    HttpContext curContext = HttpContext.Current;

        //    // 设置编码和附件格式   
        //    curContext.Response.ContentType = "application/vnd.ms-excel";
        //    curContext.Response.ContentEncoding = Encoding.GetEncoding("gb2312");
        //    curContext.Response.Charset = "";
        //    curContext.Response.AppendHeader("Content-Disposition",
        //        "attachment;filename=" + HttpUtility.UrlEncode(strFileName, Encoding.GetEncoding("gb2312")));

        //    curContext.Response.BinaryWrite(Export(dtSource, strHeaderText).GetBuffer());
        //    curContext.Response.End();

        //}

        #region 读取excel
        /// <summary>读取excel   
        /// 默认第一行为标头   
        /// </summary>   
        /// <param name="strFileName">excel文档路径</param>   
        /// <param name="startIndex">读取标头开始行,下标0开始</param> 
        /// <returns></returns>   
        public static DataTable Import(string strFileName, int startIndex)
        {
            DataTable dt = new DataTable();

            HSSFWorkbook hssfworkbook;
            using (FileStream file = new FileStream(strFileName, FileMode.Open, FileAccess.Read))
            {
                hssfworkbook = new HSSFWorkbook(file);
            }
            ISheet sheet = hssfworkbook.GetSheetAt(0);
            System.Collections.IEnumerator rows = sheet.GetRowEnumerator();

            IRow headerRow = sheet.GetRow(startIndex);
            int cellCount = headerRow.LastCellNum;

            for (int j = 0; j < cellCount; j++)
            {
                ICell cell = headerRow.GetCell(j);
                try
                {
                    dt.Columns.Add(cell.ToString());
                }
                catch
                {
                    cellCount = j;
                    break;
                }
            }

            for (int i = (sheet.FirstRowNum + 1 + startIndex); i <= sheet.LastRowNum; i++)
            {
                IRow row = sheet.GetRow(i);
                DataRow dataRow = dt.NewRow();
                try
                {
                    for (int j = row.FirstCellNum; j < cellCount; j++)
                    {
                        if (row.GetCell(j) != null)
                        {
                            if (row.GetCell(j).ToString().Trim().Replace(" ", "").Length == 0)
                            {
                                dataRow[j] = "";
                                //break;
                                //return dt;
                            }
                            else
                            {
                                try
                                {
                                    string currTempValue = row.GetCell(j).ToString();
                                    if (currTempValue.Contains("/") || currTempValue.Contains("-"))
                                    {
                                        //Convert.ToDateTime(row.GetCell(j).ToString());
                                        if (row.GetCell(j).DateCellValue.Year > 1900)
                                        {
                                            DateTime currTempDateValue = Convert.ToDateTime(row.GetCell(j).DateCellValue.Year + "-"
                                            + row.GetCell(j).DateCellValue.Month + "-"
                                            + row.GetCell(j).DateCellValue.Day + " "
                                            + row.GetCell(j).DateCellValue.Hour + ":"
                                            + row.GetCell(j).DateCellValue.Minute + ":"
                                            + row.GetCell(j).DateCellValue.Second + "");
                                            dataRow[j] = currTempDateValue;
                                            continue;
                                        }
                                    }
                                }
                                catch
                                {

                                }
                                dataRow[j] = row.GetCell(j).ToString().Trim().Replace(" ", "");
                            }
                        }
                        //else
                        //{
                        //    return dt;
                        //}
                    }
                }
                catch
                {
                    break;
                }

                dt.Rows.Add(dataRow);
            }
            return dt;
        }

        /// <summary>读取excel   
        /// 默认第一行为标头   
        /// </summary>   
        /// <param name="strFileName">excel文档路径</param>   
        /// <param name="startIndex">读取标头开始行,下标0开始</param> 
        /// <returns></returns>   
        public static DataTable ImportNCValueList(string strFileName, int startIndex)
        {
            DataTable dt = new DataTable();

            HSSFWorkbook hssfworkbook;
            using (FileStream file = new FileStream(strFileName, FileMode.Open, FileAccess.Read))
            {
                hssfworkbook = new HSSFWorkbook(file);
            }
            ISheet sheet = hssfworkbook.GetSheetAt(0);
            if (sheet.SheetName.ToLower() == "macro1")
            {
                sheet = hssfworkbook.GetSheetAt(1);
            }
            System.Collections.IEnumerator rows = sheet.GetRowEnumerator();

            IRow headerRow = sheet.GetRow(startIndex);
            int cellCount = headerRow.LastCellNum;

            for (int j = 0; j < cellCount; j++)
            {
                ICell cell = headerRow.GetCell(j);
                try
                {
                    dt.Columns.Add(cell.ToString());
                }
                catch
                {
                    cellCount = j;
                    break;
                }
            }

            for (int i = (sheet.FirstRowNum +1+ startIndex); i <= sheet.LastRowNum; i++)
            {
                IRow row = sheet.GetRow(i);
                DataRow dataRow = dt.NewRow();
                try
                {
                    for (int j = row.FirstCellNum; j < cellCount; j++)
                    {
                        if (j == 0)
                        {
                            if (row.GetCell(j).ToString().Trim().Replace(" ", "").Length == 0)
                            {
                                return dt;
                            }
                        }
                        if (row.GetCell(j) != null)
                        {
                            if (row.GetCell(j).ToString().Trim().Replace(" ", "").Length == 0)
                            {
                                dataRow[j] = "";
                            }
                            else
                            {
                                try
                                {
                                    string currTempValue = row.GetCell(j).ToString();
                                    if (currTempValue.Contains("/") || currTempValue.Contains("-"))
                                    {
                                        if (row.GetCell(j).DateCellValue.Year > 1900)
                                        {
                                            DateTime currTempDateValue = Convert.ToDateTime(row.GetCell(j).DateCellValue.Year + "-"
                                            + row.GetCell(j).DateCellValue.Month + "-"
                                            + row.GetCell(j).DateCellValue.Day + " "
                                            + row.GetCell(j).DateCellValue.Hour + ":"
                                            + row.GetCell(j).DateCellValue.Minute + ":"
                                            + row.GetCell(j).DateCellValue.Second + "");
                                            dataRow[j] = currTempDateValue;
                                            continue;
                                        }
                                    }
                                }
                                catch
                                {

                                }
                                dataRow[j] = row.GetCell(j).ToString().Trim().Replace(" ", "");
                            }
                        }
                    }
                }
                catch
                {
                    break;
                }

                dt.Rows.Add(dataRow);
            }
            return dt;
        }


        /// <summary>读取excel   
        /// 默认第一行为标头   
        /// </summary>   
        /// <param name="strFileName">excel文档路径</param>   
        /// <param name="startIndex">读取标头开始行,下标0开始</param> 
        /// <param name="sheetList">sheet集合,如sheet1,sheet2,sheet3</param> 
        /// <param name="errorMessage">返回的异常数据</param> 
        /// <returns></returns>   
        public static List<DataTable> GetListByImport(string strFileName, int startIndex, List<string> sheetName, ref string errorMessage)
        {
            List<DataTable> tableList = new List<DataTable>();

            HSSFWorkbook hssfworkbook;
            using (FileStream file = new FileStream(strFileName, FileMode.Open, FileAccess.Read))
            {
                hssfworkbook = new HSSFWorkbook(file);
            }
            for (int i = 0; i < sheetName.Count; i++)
            {
                try
                {
                    if (hssfworkbook.GetSheetIndex(sheetName[i]) != -1)
                    {

                    }
                    else
                    {
                        errorMessage = "上传的EXCEL不规范！";
                        return null;
                    }
                }
                catch
                {
                    errorMessage = sheetName[i] + "不存在，请不要随意修改EXCEL！";
                    return null;
                }
            }

            for (int sheetIndex = 0; sheetIndex < hssfworkbook.NumberOfSheets; sheetIndex++)
            {
                ISheet sheet = hssfworkbook.GetSheetAt(sheetIndex);
                DataTable dt = new DataTable(hssfworkbook.GetSheetName(sheetIndex));
                System.Collections.IEnumerator rows = sheet.GetRowEnumerator();

                IRow headerRow = sheet.GetRow(startIndex);
                int cellCount = 0;
                try
                {
                    cellCount = headerRow.LastCellNum;
                }
                catch
                {
                    tableList.Add(dt);
                    continue;
                }

                for (int j = 0; j < cellCount; j++)
                {
                    ICell cell = headerRow.GetCell(j);
                    try
                    {
                        dt.Columns.Add(cell.ToString());
                    }
                    catch
                    {
                        cellCount = j;
                        break;
                    }
                }

                for (int i = (sheet.FirstRowNum + 1 + startIndex); i <= sheet.LastRowNum; i++)
                {
                    IRow row = sheet.GetRow(i);
                    DataRow dataRow = dt.NewRow();
                    try
                    {
                        for (int j = row.FirstCellNum; j < cellCount; j++)
                        {
                            if (row.GetCell(j) != null)
                            {
                                if (row.GetCell(j).ToString().Trim().Replace(" ", "").Length == 0)
                                {
                                    dataRow[j] = "";
                                    //break;
                                    //return dt;
                                }
                                else
                                {
                                    dataRow[j] = row.GetCell(j).ToString().Trim().Replace(" ", "");
                                }
                            }
                            //else
                            //{
                            //    return dt;
                            //}
                        }
                    }
                    catch
                    {
                        break;
                    }

                    dt.Rows.Add(dataRow);
                }
                tableList.Add(dt);
            }
            return tableList;
        }

        #endregion


    }
}
