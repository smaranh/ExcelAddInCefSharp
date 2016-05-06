using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;
using System.Windows.Forms;

namespace FirstExcelAddIn
{
    public partial class MyRibbon
    {
        Form form = null;
        private void MyRibbon_Load(object sender, RibbonUIEventArgs e)
        {
            this.button1.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button1_Click);
            //Cef.Initialize(new CefSettings());
        }

        private void button1_Click(object sender, RibbonControlEventArgs e)
        {
            //MessageBox.Show("It works!!");
            if (form == null)
            {
                form = new Form1();
                form.Show();
            }
        }
    }
}
