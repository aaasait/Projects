using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFNwdProject
{
    public class Connection
    {
        public static string GetConnectionString
        {
            get
            {
                return "Server=EVT03307NB\\MSSQLSERVER2022;Initial Catalog=NORTHWND; Uid=sa; Password=AbdullahSaitKoc68";
            }
        }
    }
}
