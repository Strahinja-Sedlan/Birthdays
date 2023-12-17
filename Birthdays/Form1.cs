using ClosedXML.Excel;
using System.Data.OleDb;

namespace Birthdays
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:/Users/PC/Desktop/DDK/DDK - Indjija.mdb");
            OleDbCommand select = new OleDbCommand();
            select.Connection = con;
            select.CommandText = "Select * From RODJENDANI";
            con.Open();
            OleDbDataReader reader = select.ExecuteReader();
            var path = @"C:\users\pc\Desktop";
            using var workbook = new XLWorkbook();
            var worksheet = workbook.AddWorksheet("Sheet1");
            worksheet.ColumnWidth = 20;
            worksheet.Cell("A1").Value = "38169778729";
            worksheet.Cell("A2").Value = "381655840111";
            worksheet.Cell("A3").Value = "38163584011";
            var selectedDate = dateTimePicker1.Value;
            int count = 4;
            while (reader.Read())
            {
                string phone = reader.GetString(3);
                string date = reader.GetDateTime(4).ToString();
                DateTime birthday;
                DateTime.TryParse(date, out birthday);
                if (birthday.Month == selectedDate.Month && birthday.Day == selectedDate.Day)
                {
                    worksheet.Cell("A" + count).Value = phone;
                    count++;
                }
            }
            var fileName = "/" + selectedDate.Day.ToString() + "." + selectedDate.Month.ToString() + ".xlsx";
            workbook.SaveAs(path + fileName);

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}