using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;    

namespace PBL3
{
    class Connection
    {
        private static String stringConnection = @"Data Source=MYPC;Initial Catalog=pbl3;Integrated Security=True";
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(stringConnection);
        }
    }
}
