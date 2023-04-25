using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using PBL3.Entity;

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

        public bool checkPass(int id, string password)
        {
            SqlConnection conn = Connection.GetConnection();
            string query = "select u.password from users as u where u.id=@id";
            try
            {
                conn.Open();
                cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    if (reader.GetString(0).Equals(password))
                    {
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

        public int getIdByName(String name)
        {
            int kq = 0;
            SqlConnection sqlcon = Connection.GetConnection();
            string query = "select u.id from users as u where u.username = N\'" + name + "\'";
            try
            {
                sqlcon.Open();
                cmd = new SqlCommand(query, sqlcon);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
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

        public string changePass(int id, string oldPass, string newPass, string confirm)
        {
            SqlConnection sqlcon = Connection.GetConnection();
            string query = "update users " +
                "set password=@password " +
                "where users.id=@id";
            if(checkPass(id, oldPass))
            {
                if (newPass.Equals(confirm))
                {
                    try
                    {
                        sqlcon.Open();
                        cmd = new SqlCommand(query, sqlcon);

                        cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = newPass;
                        cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = id;

                        cmd.ExecuteNonQuery();//thuc thi lenh truy van

                        return "Thành công";
                    }
                    catch
                    {
                        return "Error";
                    }
                    finally
                    {
                        sqlcon.Close();
                    }
                }
                else
                {
                    return "Mật khẩu xác nhận không đúng";
                }
            }
            else
            {
                return "Mật khẩu hiện tại không đúng";
            }
        }

        public bool insertUser(User user)
        {
            SqlConnection sqlcon = Connection.GetConnection();
            string query = "insert into users(username, password, role_id) values " +
                "@username," +
                "@password," +
                "@type)";
            try
            {
                sqlcon.Open();
                cmd = new SqlCommand(query, sqlcon);
                cmd.Parameters.Add("@username", SqlDbType.DateTime).Value = user.UserName;
                cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = user.PassWord;
                cmd.Parameters.Add("@type", SqlDbType.VarChar).Value = user.AccountType;

                cmd.ExecuteNonQuery();//thuc thi lenh truy van

            }
            catch
            {
                return false;
            }
            finally
            {
                sqlcon.Close();
            }
            return true;
        }
    }
}
