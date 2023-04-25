﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PBL3.Entity;
using System.Diagnostics.Eventing.Reader;

namespace PBL3.Model
{
    internal class NhanvienDAO
    {
        SqlDataAdapter dataAdapter; // dung de chua bang
        SqlCommand cmd; // dung de truy van va cap nhat csdl
        public NhanvienDAO()
        {
        }
        // dataset
        // datatable

        public DataTable searchNhanvien(string tieuchi, string value)
        {
            SqlConnection sqlcon = Connection.GetConnection();
            DataTable dataTable = new DataTable();
            string query = "select * from chitietnhanvien where ";
            if (tieuchi.Equals("ID"))
            {
                query += "id = " + value;
            } else if(tieuchi.Equals("Họ tên"))
            {
                query += "hoten = N\'" + value + "\'";
            } else if(tieuchi.Equals("Giới tính"))
            {
                query += "gioitinh = N\'" + value + "\'";
            } else if (tieuchi.Equals("SĐT"))
            {
                query += "sdt = \'" + value + "\'";
            } else if (tieuchi.Equals("Địa chỉ"))
            {
                query += "diachi = N\'" + value + "\'";
            } else if (tieuchi.Equals("CCCD"))
            {
                query += "cccd = \'" + value + "\'";
            } else if (tieuchi.Equals("Email"))
            {
                query += "email = N\'" + value + "\'";
            } 
            //else if(tieuchi.Equals("Chức vụ"))
            //{
            //    query = "select * " +
            //        "from chitietnhanvien as ct " +
            //        "join chucvu as cv on ct.chucvu = cv.id " +
            //        "where cv.tenchucvu = N\'" + value + "\'";
            //}
            try
            {
                sqlcon.Open();
                dataAdapter = new SqlDataAdapter(query, sqlcon);
                dataAdapter.Fill(dataTable);
                return dataTable;
                
            } catch (Exception ex)
            {
                return null;
            }
            finally { sqlcon.Close(); }
        }

        public bool updateNhanVien(NhanVien nv)
        {
            SqlConnection sqlcon = Connection.GetConnection();
            string query = "update chitietnhanvien " +
                "set hoten=N\'" + nv.Name + "\'," +
                "gioitinh=N\'" + nv.Gender + "\'," +
                "ngaysinh=@ngaysinh," +
                "sdt=@sdt," +
                "diachi=N\'" + nv.Address + "\'," +
                "cccd=@cccd," +
                "email=@email " +
                "where chitietnhanvien.id=@id";
            try
            {
                sqlcon.Open();
                cmd = new SqlCommand(query, sqlcon);

                cmd.Parameters.Add("@ngaysinh", SqlDbType.DateTime).Value = nv.DateOfBirth;
                cmd.Parameters.Add("@sdt", SqlDbType.VarChar).Value = nv.PhoneNumber;
                cmd.Parameters.Add("@cccd", SqlDbType.VarChar).Value = nv.CCCD;
                cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = nv.Email;
                cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = nv.Id;

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
            string query = "insert into chitietnhanvien(hoten,gioitinh,ngaysinh,sdt,diachi,cccd,email,useraccount) values " +
                "(N\'" + nv.Name + "\'," +
                "N\'" + nv.Gender + "\'," +
                "@ngaysinh," +
                "@sdt," +
                "N\'" + nv.Address + "\'," +
                "@cccd," +
                "@email," +
                "@useraccount)";
            try
            {
                sqlcon.Open();
                cmd = new SqlCommand(query, sqlcon);
                cmd.Parameters.Add("@ngaysinh", SqlDbType.DateTime).Value = nv.DateOfBirth;
                cmd.Parameters.Add("@sdt", SqlDbType.VarChar).Value = nv.PhoneNumber;
                cmd.Parameters.Add("@cccd", SqlDbType.VarChar).Value = nv.CCCD;
                cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = nv.Email;
                cmd.Parameters.Add("@useraccount", SqlDbType.Int).Value = nv.Useraccount;

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

        public bool deleteNhanvien(int id)
        {
            SqlConnection sqlcon = Connection.GetConnection();
            string query = "delete from chitietnhanvien where chitietnhanvien.id=@id";
            try
            {
                sqlcon.Open();
                cmd = new SqlCommand(query, sqlcon);
                cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = id;

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

        public List<String> getAllNameNhanVien()
        {
            List<String> list = new List<String>();
            SqlConnection sqlcon = Connection.GetConnection();
            DataTable dataTable = new DataTable();
            string query = "select nv.hoten from chitietnhanvien as nv";
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
            string query = "select nv.id from chitietnhanvien as nv where nv.hoten = N\'" + name + "\'";
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
    }
}
