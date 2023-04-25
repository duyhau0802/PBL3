using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL3.Model
{
    internal class TaskDAO
    {
        SqlDataAdapter dataAdapter; // dung de chua bang
        SqlCommand cmd; // dung de truy van va cap nhat csdl

        public TaskDAO()
        {

        }

        public DataTable GetAllTaskByID(int id)
        {
            DataTable dataTable = new DataTable();
            string query = "select t.id, t.detail, t.deadline, s.name from task as t join status as s on t.id_status = s.id where id_nv = " + id;
            using (SqlConnection sqlConnection = Connection.GetConnection())
            {
                sqlConnection.Open();
                dataAdapter = new SqlDataAdapter(query, sqlConnection);
                dataAdapter.Fill(dataTable);

                sqlConnection.Close();
            }
            return dataTable;
        }

        public DataTable GetAllTaskByIdUserAndIdStatus(int id_nv, int id_status)
        {
            DataTable dataTable = new DataTable();
            string query = "select t.id, t.detail, t.deadline, s.name " +
                "from task as t " +
                "join status as s on t.id_status = s.id " +
                "where t.id_nv = " + id_nv + " and t.id_status = " + id_status;
            using (SqlConnection sqlConnection = Connection.GetConnection())
            {
                sqlConnection.Open();
                dataAdapter = new SqlDataAdapter(query, sqlConnection);
                dataAdapter.Fill(dataTable);

                sqlConnection.Close();
            }
            return dataTable;
        }

        public bool changeStatus(int id)
        {
            SqlConnection sqlcon = Connection.GetConnection();
            string query = "update task " +
                "set id_status = id_status + 1 " +
                "where task.id=@id";
            try
            {
                sqlcon.Open();
                cmd = new SqlCommand(query, sqlcon);

                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

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
