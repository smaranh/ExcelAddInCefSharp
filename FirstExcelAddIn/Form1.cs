using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;


namespace FirstExcelAddIn
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            try
            {
                InitBrowser();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message.ToString());
            }
        }

        public ChromiumWebBrowser browser;
        public void InitBrowser()
        {
            
            browser = new ChromiumWebBrowser("http://localhost/gitEMF/src/tests/app/test.html?testCaseId=fullscreen");
            browser.RegisterJsObject("scriptingHelper", new Scripting.ScriptingHelper(browser));
            
            browser.Dock = DockStyle.Fill;
            this.Controls.Add(browser);

            ChromeDevToolsSystemMenu.CreateSysMenu(this);
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            // Test if the About item was selected from the system menu
            if ((m.Msg == ChromeDevToolsSystemMenu.WM_SYSCOMMAND) && ((int)m.WParam == ChromeDevToolsSystemMenu.SYSMENU_CHROME_DEV_TOOLS))
            {
                browser.ShowDevTools();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Cef.Shutdown();
        }

        public void ExecuteScript()
        {
            browser.ExecuteScriptAsync("msgMe();");
        }


    }
}
