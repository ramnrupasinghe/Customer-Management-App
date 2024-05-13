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
    }
}
