using PBL3.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace PBL3.Model
{
    internal class ChucvuDAO
    {
        SqlDataAdapter dataAdapter; // dung de chua bang
        SqlCommand cmd; // dung de truy van va cap nhat csdl
        public ChucvuDAO() { }

        public List<String> getAllNameChucvu()
        {
            List<String> list = new List<String>();
            SqlConnection sqlcon = Connection.GetConnection();
            string query = "select cv.tenchucvu from chucvu as cv";
            try
            {
                sqlcon.Open();
                cmd = new SqlCommand(query, sqlcon);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(reader.GetString(0));
                }
                return list;
            }
            catch
            {
                return null;
            }
        }

        public int getIdByName(String name)
        {
            int kq = 0;
            SqlConnection sqlcon = Connection.GetConnection();
            string query = "select cv.id from chucvu as cv where cv.tenchucvu = N\'" + name + "\'";
            try
            {
                sqlcon.Open();
                cmd = new SqlCommand(query, sqlcon);
                SqlDataReader reader = cmd.ExecuteReader();
                if(reader.Read())
                {
                    kq = reader.GetInt32(0);
                }
            }
            catch
            {
                return -1;
            }
            finally { sqlcon.Close(); }
            return kq;
        }
    }
}
