using ClosedXML.Excel;

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
            var path = @"C:\users\Strahinja\Desktop";
            var file = @"C:\users\Strahinja\source\repos\Birthdays\Birthdays\info.csv";
            var read = File.ReadAllText(file);
            var row = read.Split("\r\n");
            using var workbook = new XLWorkbook();
            var worksheet = workbook.AddWorksheet("Sheet1");
            worksheet.ColumnWidth = 20;
            worksheet.Cell("A1").Value = "38169778729";
            worksheet.Cell("A2").Value = "381655840111";
            worksheet.Cell("A3").Value = "38163584011";
            var selectedDate = dateTimePicker1.Value;
            int count = 4;
            for (int i = 0; i < row.Length; i++)
            {
                string item = row[i];
                var parts = item.Split(",");
                string phone = parts[0];
                string date = parts[1];
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
    }
}