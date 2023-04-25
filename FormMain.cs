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
    public partial class FormMain : Form
    {
        int index = -1;
        public bool isExit = true;
        public event EventHandler Logout;
        public FormMain()
        {
            InitializeComponent();
        }

        #region Event
        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isExit) {
                if (MessageBox.Show("Ban co muon thoat", "Cảnh báo", MessageBoxButtons.YesNo) != DialogResult.Yes)
                {
                    e.Cancel = true;
                }
            }
                
        }

        private void FormMain_FormClosed(object sender, FormClosingEventArgs e)
        {
            if(isExit)
            Application.Exit();
        }
        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Logout(this, new EventArgs());
        }

        NhanvienDAO dao;

        

        private void FormMain_Load_1(object sender, EventArgs e)
        {
            dao = new NhanvienDAO();
            try
            {
                data.DataSource = dao.GetAllNhanVien();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi : " + ex.Message);
            }
        }

        private void importFromExcelFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormImport f = new FormImport();
            f.Show();
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            FormAddNewUser f = new FormAddNewUser();
            f.Show();
            f.Exit += F_Exit;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormSearch f = new FormSearch();
            f.Show();
            f.Exit += F_Exit;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormUpdate f = new FormUpdate();
            f.Show();
            f.Exit += F_Exit;
        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormChangePass f = new FormChangePass();
            f.Show();
            f.Exit += F_Exit;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            data.DataSource = dao.GetAllNhanVien();
        }

        private void F_Exit(object? sender, EventArgs e)
        {
            if ((sender as FormAddNewUser) != null)
            {
                (sender as FormAddNewUser).Close();
            }
            else if((sender as FormSearch) != null)
            {
                (sender as FormSearch).Close();
            }
            else if((sender as FormUpdate) != null)
            {
                (sender as FormUpdate).Close();
            }
            else
            {
                (sender as FormChangePass).Close();
            }
            data.DataSource = dao.GetAllNhanVien();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(index != -1)
            {
                int id = int.Parse(data.Rows[index].Cells[0].Value.ToString());
                dao.deleteNhanvien(id);
                data.DataSource = dao.GetAllNhanVien();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
        }
    }
}
