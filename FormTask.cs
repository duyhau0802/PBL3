using PBL3.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBL3
{
    public partial class FormTask : Form
    {
        int index = -1;
        static int id_now;
        public event EventHandler Exit;
        public event EventHandler Logout;
        public FormTask(int id)
        {
            id_now = id;
            InitializeComponent();
        }

        TaskDAO taskDAO;
        private void FormTask_Load(object sender, EventArgs e)
        {
            taskDAO = new TaskDAO(); 
            try
            {
                data.DataSource = taskDAO.GetAllTaskByID(id_now);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi : " + ex.Message);
            }
        }

        private void quảnLýTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Exit(this, new EventArgs());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                data.DataSource = taskDAO.GetAllTaskByID(id_now);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi : " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                data.DataSource = taskDAO.GetAllTaskByIdUserAndIdStatus(id_now, 1);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi : " + ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                data.DataSource = taskDAO.GetAllTaskByIdUserAndIdStatus(id_now, 2);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi : " + ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                data.DataSource = taskDAO.GetAllTaskByIdUserAndIdStatus(id_now, 3);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi : " + ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //Tính toán trễ hạn

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if(index != -1)
            {
                if (taskDAO.changeStatus(int.Parse(this.data.Rows[index].Cells[0].Value.ToString())))
                {
                    MessageBox.Show("Thành công");
                } else
                {
                    MessageBox.Show("Lỗi");
                }
                
                data.DataSource = taskDAO.GetAllTaskByID(id_now);

            } else
            {
                MessageBox.Show("Chưa chọn nhiệm vụ");
            }
        }

        private void data_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormLogin f = new FormLogin();
            f.Show();
            this.Hide();
        }
    }
}
