using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL3.Model
{
    internal class UserDAO
    {
        SqlDataAdapter dataAdapter; // dung de chua bang
        SqlCommand cmd; // dung de truy van va cap nhat csdl
        public UserDAO() { }

        public bool checkLogin(string username, string password)
        {
            SqlConnection conn = Connection.GetConnection();
            string query = "select u.password, u.role_id from users as u where u.username=@username";
            try
            {
                conn.Open();
                cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add("@username", SqlDbType.VarChar).Value = username;
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    if (reader.GetString(0).Equals(password))
                    {
                        if (reader.GetInt32(1) == 1)
                        {
                            Constant.AccountType = true;
                        }
                        else
                        {
                            Constant.AccountType = false;
                        }
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
            finally { conn.Close(); }
        }
    }
}
