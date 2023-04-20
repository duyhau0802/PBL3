using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace PBL3
{
    class Modify
    {

        SqlDataAdapter dataAdapter; // dung de chua bang
        SqlCommand cmd; // dung de truy van va cap nhat csdl
        public Modify()
        {
        }
        // dataset
        // datatable
        public DataTable GetAllNhanVien()
        {
            DataTable dataTable = new DataTable();
            string query = "select * from chitietnhanvien";
            using (SqlConnection sqlConnection = Connection.GetConnection())
            {
                sqlConnection.Open();
                dataAdapter = new SqlDataAdapter(query, sqlConnection);
                dataAdapter.Fill(dataTable);  

                sqlConnection.Close();
            }
            return dataTable;
        }

        public bool insert(NhanVien nv)
        {
            SqlConnection sqlcon = Connection.GetConnection();
            string query = "insert into chitietnhanvien (hoten, gioitinh, ngaysinh, sdt, diachi, cccd, email) values (@hoten,@gioitinh,@ngaysinh,@sdt,@diachi,@cccd,@email)";
            try
            {
                sqlcon.Open();
                cmd = new SqlCommand(query, sqlcon);
               
                cmd.Parameters.Add("@hoten", SqlDbType.VarChar).Value = nv.Name;
                cmd.Parameters.Add("@gioitinh", SqlDbType.VarChar).Value = nv.Gender;
                cmd.Parameters.Add("@ngaysinh", SqlDbType.DateTime).Value = nv.DateOfBirth;
                cmd.Parameters.Add("@sdt", SqlDbType.VarChar).Value = nv.PhoneNumber;
                cmd.Parameters.Add("@diachi", SqlDbType.VarChar).Value = nv.Address;
                cmd.Parameters.Add("@cccd", SqlDbType.VarChar).Value = nv.CCCD;
                cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = nv.Email;

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
