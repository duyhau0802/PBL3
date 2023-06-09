﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PBL3.Entity;

namespace PBL3.Model
{
    internal class PhongbanDAO
    {
        SqlDataAdapter dataAdapter; // dung de chua bang
        SqlCommand cmd; // dung de truy van va cap nhat csdl
        public PhongbanDAO() { }

        public DataTable GetAllPhongBan()
        {
            DataTable dataTable = new DataTable();
            string query = "select d.id, d.name as N\'Tên phòng ban\', c.hoten as N\'Tên trường phòng\' from department as d join chitietnhanvien as c on d.truongphong = c.id";
            using (SqlConnection sqlConnection = Connection.GetConnection())
            {
                sqlConnection.Open();
                dataAdapter = new SqlDataAdapter(query, sqlConnection);
                dataAdapter.Fill(dataTable);

                sqlConnection.Close();
            }
            return dataTable;
        }

        public List<String> getAllNamePhongBan()
        {
            List<String> list = new List<String>();
            SqlConnection sqlcon = Connection.GetConnection();
            DataTable dataTable = new DataTable();
            string query = "select pb.name from department as pb";
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
            string query = "select pb.id from department as pb where pb.name = N\'" + name + "\'";
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

        public List<int> getIdByTruongphong(int id)
        {
            List<int> list = new List<int>();
            SqlConnection sqlcon = Connection.GetConnection();
            string query = "select pb.id from department as pb where pb.truongphong = " + id;
            try
            {
                sqlcon.Open();
                cmd = new SqlCommand(query, sqlcon);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(reader.GetInt32(0));
                }
            }
            catch
            {
                return null;
            }
            finally { sqlcon.Close(); }
            return list;
        }

        public bool insertPb(Phongban pb)
        {
            SqlConnection sqlcon = Connection.GetConnection();
            string query = "insert into department(name, truongphong) values " +
                "(@name," +
                "@truongphong)";
            try
            {
                sqlcon.Open();
                cmd = new SqlCommand(query, sqlcon);
                cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = pb.Name;
                cmd.Parameters.Add("@truongphong", SqlDbType.VarChar).Value = pb.Truongphong;

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

        public DataTable searchPhongban(string tieuchi, string value)
        {
            SqlConnection sqlcon = Connection.GetConnection();
            DataTable dataTable = new DataTable();
            string query = "select d.id, d.name as N'Tên phòng ban', c.hoten as N'Tên trường phòng' " +
                "from department as d " +
                "join chitietnhanvien as c on d.truongphong = c.id " +
                "where ";
            

            if (tieuchi.Equals("Tên phòng ban"))
            {
                query += "name = \'" + value + "\'";
            }
            else if (tieuchi.Equals("Trưởng phòng"))
            {
                query += "truongphong = " + value;
            }
            try
            {
                sqlcon.Open();
                dataAdapter = new SqlDataAdapter(query, sqlcon);
                dataAdapter.Fill(dataTable);
                return dataTable;

            }
            catch (Exception ex)
            {
                return null;
            }
            finally { sqlcon.Close(); }
        }

        public bool updatePhongban(Phongban pb)
        {
            SqlConnection sqlcon = Connection.GetConnection();
            string query = "update department " +
                "set name=N\'" + pb.Name + "\'," +
                "truongphong=" + pb.Truongphong +
                " where department.id=@id";
            try
            {
                sqlcon.Open();
                cmd = new SqlCommand(query, sqlcon);

                cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = pb.Id;

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

        public bool deletePhongban(int id)
        {
            SqlConnection sqlcon = Connection.GetConnection();
            string query = "delete from department where department.id=@id";
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
    }
}
