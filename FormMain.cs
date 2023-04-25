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
        static int id_now = -1;

        static bool control = true;

        public event EventHandler Logout;
        public FormMain(int id)
        {
            id_now = id;
            InitializeComponent();
        }

        #region Event
        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isExit) {
                if (MessageBox.Show("Bạn có muốn thoát?", "Cảnh báo", MessageBoxButtons.YesNo) != DialogResult.Yes)
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

        NhanvienDAO nvdao;
        PhongbanDAO pbdao;
        

        private void FormMain_Load_1(object sender, EventArgs e)
        {
            nvdao = new NhanvienDAO();
            pbdao = new PhongbanDAO();
            try
            {
                data.DataSource = nvdao.GetAllNhanVien();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi : " + ex.Message);
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
            if (control)
            {
                FormAddNewUser f = new FormAddNewUser();
                f.Show();
                f.Exit += F_Exit;
            }
            else
            {
                FormAddPhongBan f = new FormAddPhongBan();
                f.Show();
                f.Exit += F_Exit;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (control)
            {
                FormSearch f = new FormSearch();
                f.Show();
                f.Exit += F_Exit;
            } else
            {
                FormSearch_PhongBan f = new FormSearch_PhongBan();
                f.Show();
                f.Exit += F_Exit;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (control)
            {
                FormUpdate f = new FormUpdate();
                f.Show();
                f.Exit += F_Exit;
            } 
            else
            {
                FormUpdate_PhongBan f = new FormUpdate_PhongBan();
                f.Show();
                f.Exit += F_Exit;
            }
            
        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormChangePass f = new FormChangePass(id_now);
            f.Show();
            f.Exit += F_Exit;
            this.Hide();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            data.DataSource = nvdao.GetAllNhanVien();
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
            else if ((sender as FormSearch_PhongBan) != null)
            {
                (sender as FormSearch_PhongBan).Close();
            }
            else if ((sender as FormUpdate_PhongBan) != null)
            {
                (sender as FormUpdate_PhongBan).Close();
            }
            else if ((sender as FormAddPhongBan) != null)
            {
                (sender as FormAddPhongBan).Close();
            }
            else
            {
                (sender as FormChangePass).Close();
                this.Show();
            }
            if (control)
            {
                data.DataSource = nvdao.GetAllNhanVien();
            } else
            {
                data.DataSource = pbdao.GetAllPhongBan();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(index != -1)
            {
                int id = int.Parse(data.Rows[index].Cells[0].Value.ToString());
                nvdao.deleteNhanvien(id);
                data.DataSource = nvdao.GetAllNhanVien();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
        }


        private void phòngBanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            control = false;
            pbdao = new PhongbanDAO();
            this.labelTitle.Text = "Quản lí phòng ban";
            data.DataSource = pbdao.GetAllPhongBan();
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            control = true;
            nvdao = new NhanvienDAO();
            this.labelTitle.Text = "Quản lí nhân viên";
            data.DataSource = nvdao.GetAllNhanVien();
        }
    }
}
