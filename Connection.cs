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
        //Server name of Hau's DB: MYPC
        //Server name of Thien's DB: MAYTROI\THIENTV
        private static String stringConnection = @"Data Source=MAYTROI\THIENTV;Initial Catalog=pbl3;Integrated Security=True";
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(stringConnection);
        }
    }
}
