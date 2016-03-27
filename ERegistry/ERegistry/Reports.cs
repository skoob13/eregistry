using System;
using Microsoft.Office.Interop.Excel;
using System.IO;

namespace ERegistry
{
    static class Reports
    {
        public static string CreateCheck(Reg registry)
        {
            try
            {
                Microsoft.Office.Interop.Excel.Application oXL;
                Microsoft.Office.Interop.Excel._Workbook oWB;
                Microsoft.Office.Interop.Excel._Worksheet oSheet;
                Microsoft.Office.Interop.Excel.Range oRng;
                oXL = new Microsoft.Office.Interop.Excel.Application();
                //oXL.Visible = false;

                //Get a new workbook.
                oWB = (Microsoft.Office.Interop.Excel.Workbook)(oXL.Workbooks.Add(XlWBATemplate.xlWBATWorksheet));
                oSheet = (Microsoft.Office.Interop.Excel._Worksheet)oWB.ActiveSheet;

                //Merging cells
                oSheet.Range[oSheet.Cells[1,1], oSheet.Cells[2,3]].Merge();
                oSheet.Range[oSheet.Cells[3, 2], oSheet.Cells[3, 3]].Merge();
                oSheet.Range[oSheet.Cells[4, 2], oSheet.Cells[4, 3]].Merge();
                oSheet.Range[oSheet.Cells[5, 1], oSheet.Cells[5, 6]].Merge();
                oSheet.Range[oSheet.Cells[7, 2], oSheet.Cells[7, 6]].Merge();
                oSheet.Range[oSheet.Cells[8, 2], oSheet.Cells[8, 6]].Merge();
                oSheet.Range[oSheet.Cells[9, 2], oSheet.Cells[9, 6]].Merge();
                oSheet.Range[oSheet.Cells[10, 2], oSheet.Cells[10, 6]].Merge();
                oSheet.Range[oSheet.Cells[12, 4], oSheet.Cells[12, 5]].Merge();
                oSheet.Range[oSheet.Cells[14, 5], oSheet.Cells[14, 6]].Merge();
                oSheet.Range[oSheet.Cells[14, 3], oSheet.Cells[14, 4]].Merge();

                oSheet.Cells[1, 1] = "ООО \"Центр натуральной медицины\"";
                oSheet.Cells[3, 1] = "ИНН:";
                oSheet.Cells[4, 1] = "ОГРН:";
                oSheet.Cells[3, 2] = "5900000000";
                oSheet.Cells[4, 2] = "5900000000";
                oSheet.Cells[2, 5] = "Дата:";
                oSheet.Cells[3, 5] = "Время:";
                oSheet.Cells[2, 6] = Utils.GCTime(registry.Time.Day) + "." + Utils.GCTime(registry.Time.Month) + "." + Utils.GCTime(registry.Time.Year);
                oSheet.Cells[3, 6] = Utils.GCTime(registry.Time.Hour) + ":" + Utils.GCTime(registry.Time.Minute);
                oSheet.Cells[5, 1] = "Чек №" + registry.ID.ToString();
                oSheet.Cells[7, 1] = "Клиент:";
                oSheet.Cells[8, 1] = "Адрес:";
                oSheet.Cells[9, 1] = "Врач:";
                oSheet.Cells[10, 1] = "Услуга:";
                oSheet.Cells[7, 2] = registry.Client.ToString();
                oSheet.Cells[8, 2] = registry.Client.Adress;
                oSheet.Cells[9, 2] = registry.Doctor.ToString();
                oSheet.Cells[10, 2] = registry.Service.Title;
                oSheet.Cells[12, 3] = "Получено:";
                oSheet.Cells[12, 4] = registry.Service.Price.ToString();
                oSheet.Cells[12, 6] = "рублей";
                oSheet.Cells[14, 3] = "Администратор:";
                oSheet.Cells[14, 5] = "_____________________";

                Microsoft.Office.Interop.Excel.Range formatRange;
                formatRange = oSheet.get_Range("a1", "c2");
                formatRange.EntireRow.Font.Bold = true;
                formatRange.WrapText = true;
                formatRange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                formatRange = oSheet.get_Range("a5", "f5");
                formatRange.EntireRow.Font.Bold = true;
                formatRange.WrapText = true;
                formatRange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                formatRange = oSheet.get_Range("a7");
                formatRange.EntireRow.Font.Bold = true;

                formatRange = oSheet.get_Range("a8");
                formatRange.EntireRow.Font.Bold = true;

                formatRange = oSheet.get_Range("a9");
                formatRange.EntireRow.Font.Bold = true;

                formatRange = oSheet.get_Range("a10");
                formatRange.EntireRow.Font.Bold = true;

                formatRange = oSheet.get_Range("c12");
                formatRange.EntireRow.Font.Bold = true;

                formatRange = oSheet.get_Range("a7", "f10");
                formatRange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                Microsoft.Office.Interop.Excel.Borders border = formatRange.Borders;
                border.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                border.Weight = 2d;

                string filepath = System.IO.Path.Combine(GetDirectory(), "Чек " + registry.ID + ".xls");
                oWB.SaveAs(filepath);
                oWB.Close();
                return filepath;
            }
            catch
            {
                return "";
            }
        }

        public static string CreateList(System.Data.DataTable dt, DateTime date, string doctor)
        {
            try
            {
                Microsoft.Office.Interop.Excel.Application oXL;
                Microsoft.Office.Interop.Excel._Workbook oWB;
                Microsoft.Office.Interop.Excel._Worksheet oSheet;
                oXL = new Microsoft.Office.Interop.Excel.Application();
                //oXL.Visible = false;

                //Get a new workbook.
                oWB = (Microsoft.Office.Interop.Excel.Workbook)(oXL.Workbooks.Add(XlWBATemplate.xlWBATWorksheet));
                oSheet = (Microsoft.Office.Interop.Excel._Worksheet)oWB.ActiveSheet;

                //Merging cells
                oSheet.Columns[1].ColumnWidth = 8;
                oSheet.Columns[2].ColumnWidth = 21;
                oSheet.Columns[3].ColumnWidth = 21;
                oSheet.Columns[4].ColumnWidth = 21;
                oSheet.Columns[5].ColumnWidth = 21;
                oSheet.Columns[6].ColumnWidth = 21;

                oSheet.Cells[1, 1] = "№";
                oSheet.Cells[1, 2] = "Дата";
                oSheet.Cells[1, 3] = "Фамилия";
                oSheet.Cells[1, 4] = "Имя";
                oSheet.Cells[1, 5] = "Отчество";
                oSheet.Cells[1, 6] = "Название услуги";

                int row = 2;

                for (int i=0; i<dt.Rows.Count; i++)
                {
                    object[] obj = dt.Rows[i].ItemArray;
                    oSheet.Cells[row, 1] = i+1;
                    oSheet.Cells[row, 2] = obj[0].ToString();
                    oSheet.Cells[row, 3] = obj[1].ToString();
                    oSheet.Cells[row, 4] = obj[2].ToString();
                    oSheet.Cells[row, 5] = obj[3].ToString();
                    oSheet.Cells[row, 6] = obj[4].ToString();
                    row++;
                }

                Microsoft.Office.Interop.Excel.Range formatRange;
                formatRange = oSheet.get_Range("a1", "f"+(row-1).ToString());
                formatRange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                Microsoft.Office.Interop.Excel.Borders border = formatRange.Borders;
                border.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                border.Weight = 2d;
                formatRange.WrapText = true;

                formatRange = oSheet.get_Range("a1", "f1");
                formatRange.EntireRow.Font.Bold = true;                

                string filepath = System.IO.Path.Combine(GetDirectory(), String.Format("Отчет от {0}-{1}-{2} для {3}.xls", Utils.GCTime(date.Day), Utils.GCTime(date.Month), Utils.GCTime(date.Year), doctor));
                oWB.SaveAs(filepath);
                oWB.Close();
                return filepath;
            }
            catch
            {
                return "";
            }
        }

        public static string CreateZList(System.Data.DataTable dt, DateTime date)
        {
            try
            {
                Microsoft.Office.Interop.Excel.Application oXL;
                Microsoft.Office.Interop.Excel._Workbook oWB;
                Microsoft.Office.Interop.Excel._Worksheet oSheet;
                oXL = new Microsoft.Office.Interop.Excel.Application();
                //oXL.Visible = false;

                //Get a new workbook.
                oWB = (Microsoft.Office.Interop.Excel.Workbook)(oXL.Workbooks.Add(XlWBATemplate.xlWBATWorksheet));
                oSheet = (Microsoft.Office.Interop.Excel._Worksheet)oWB.ActiveSheet;

                //Merging cells
                oSheet.Columns[1].ColumnWidth = 8;
                oSheet.Columns[2].ColumnWidth = 21;
                oSheet.Columns[3].ColumnWidth = 21;
                oSheet.Columns[4].ColumnWidth = 21;
                oSheet.Columns[5].ColumnWidth = 21;
                oSheet.Columns[6].ColumnWidth = 21;
                oSheet.Columns[7].ColumnWidth = 21;

                oSheet.Cells[1, 1] = "№";
                oSheet.Cells[1, 2] = "Дата";
                oSheet.Cells[1, 3] = "Услуга";
                oSheet.Cells[1, 4] = "Стоимость";
                oSheet.Cells[1, 5] = "Фамилия доктора";
                oSheet.Cells[1, 6] = "Имя доктора";
                oSheet.Cells[1, 7] = "Отчество доктора";

                int row = 2;
                double sum = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    object[] obj = dt.Rows[i].ItemArray;
                    oSheet.Cells[row, 1] = i + 1;
                    oSheet.Cells[row, 2] = obj[0].ToString();
                    oSheet.Cells[row, 3] = obj[1].ToString();
                    oSheet.Cells[row, 4] = obj[2].ToString();
                    oSheet.Cells[row, 5] = obj[3].ToString();
                    oSheet.Cells[row, 6] = obj[4].ToString();
                    oSheet.Cells[row, 7] = obj[4].ToString();
                    row++;
                    sum += Convert.ToDouble(obj[2].ToString());
                }

                Microsoft.Office.Interop.Excel.Range formatRange;
                formatRange = oSheet.get_Range("a1", "g" + row.ToString());
                formatRange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                Microsoft.Office.Interop.Excel.Borders border = formatRange.Borders;
                border.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                border.Weight = 2d;
                formatRange.WrapText = true;

                formatRange = oSheet.get_Range("a1", "g1");
                formatRange.EntireRow.Font.Bold = true;

                formatRange = oSheet.get_Range("a"+row.ToString(), "f"+(row).ToString());
                formatRange.Merge();

                oSheet.Cells[row, 1] = "Итого:";
                oSheet.Cells[row, 7] = sum.ToString();
                string filepath = System.IO.Path.Combine(GetDirectory(), String.Format("Z-Отчет от {0}-{1}-{2}.xls", Utils.GCTime(date.Day), Utils.GCTime(date.Month), Utils.GCTime(date.Year)));
                oWB.SaveAs(filepath);
                oWB.Close();
                return filepath;
            }
            catch
            {
                return "";
            }
        }

        private static string GetDirectory()
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var directory = System.IO.Path.Combine(currentDirectory, "Отчеты");

            if (!Directory.Exists(directory))
            {
                System.IO.Directory.CreateDirectory(directory);
            }

            return directory;
        }

    }
}
