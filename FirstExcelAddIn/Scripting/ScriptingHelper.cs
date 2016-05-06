using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using CefSharp;
using CefSharp.WinForms;

namespace FirstExcelAddIn.Scripting
{
    class ScriptingHelper
    {
        public ChromiumWebBrowser wb { get; set; }

        public ScriptingHelper(ChromiumWebBrowser browser)
        {
            // TODO: Complete member initialization
            wb = browser;
        }

        
        public void Startup()
        {
            //wb.ExecuteScriptAsync("msgMe();", new object[] { "me" });
            string name = "'me'";
            wb.ExecuteScriptAsync(String.Format("msgMe({0})", name));
        }
        
        public void DisplayMsg(string land, object j)
        {
            MessageBox.Show("Executing from "+land+" via C#");

            //use this to fetch values from unknown object
            Type myType = j.GetType();
            //IList<PropertyInfo> props = new List<PropertyInfo>(myType.GetProperties());
            PropertyInfo[] props = myType.GetProperties();

            foreach (PropertyInfo prop in props)
            {
                //object propValue = prop.GetValue(myObject, null);
                var v = prop;

                // Do something with propValue
            }
        }

        public string GetBack()
        {
            return "returned from C# land";
        }

    }
}
