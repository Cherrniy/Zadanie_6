using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Zadanie5.Controller
{
    class ConnectionsString
    {
        public static string ConnStr
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["Zadanie5.Properties.Settings.ConnStr"].ConnectionString;
            }
        }
    }
}
