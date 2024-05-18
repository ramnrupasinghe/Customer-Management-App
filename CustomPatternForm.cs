using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace CustomerManagementApp
{
    public partial class CustomPatternForm : Form
    {
        public CustomPatternForm()
        {
            InitializeComponent();
        }

        private void CustomPatternForm_Load(object sender, EventArgs e)
        {
            txtPattern.Text = "Custom Pattern";
            txtPattern.Focus();
        }

        private bool ValidatePattern(string pattern)
        {
            if (string.IsNullOrEmpty(pattern))
                return false;

            string regexPattern = @"^[a-zA-Z0-9]+$";

            return System.Text.RegularExpressions.Regex.IsMatch(pattern, regexPattern);
        }
       

        private void ExportToExcel(string customPattern, string savePath)
        {
            try
            {
                Excel.Application excelApp = new Excel.Application();
                excelApp.Visible = true;

                Excel.Workbook workbook = excelApp.Workbooks.Add();

                Excel.Worksheet worksheet = workbook.Worksheets[1];
                worksheet.Name = "Custom Pattern";

                worksheet.Cells[1, 1].Value = "Custom Pattern:";
                worksheet.Cells[1, 2].Value = customPattern;

                
                string[] columnHeaders = txtHeaders.Text.Split(',');
                for (int i = 0; i < columnHeaders.Length; i++)
                {
                    worksheet.Cells[2, i + 1].Value = columnHeaders[i];
                }

                workbook.SaveAs(savePath);

                workbook.Close();
                excelApp.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred while exporting to Excel: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }         

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string customPattern = txtPattern.Text;

            if (!ValidatePattern(customPattern))
            {
                MessageBox.Show("Please enter a valid custom pattern.", "Invalid Pattern", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel Files|*.xlsx;*.xls";
            saveFileDialog.Title = "Save Excel File";
            saveFileDialog.FileName = "CustomPattern.xlsx";
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string savePath = saveFileDialog.FileName;
                ExportToExcel(customPattern, savePath);
            }
        }
    }
}
