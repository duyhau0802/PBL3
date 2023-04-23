using PBL3.Entity;
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
    public partial class FormUpdate : Form
    {
        int index = -1;
        public event EventHandler Exit;
        public FormUpdate()
        {
            InitializeComponent();
        }

        NhanvienDAO dao;
        private void FormUpdate_Load(object sender, EventArgs e)
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

        private void data_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
            txtID.Text = data.Rows[index].Cells[0].Value.ToString();
            txtHoTen.Text = data.Rows[index].Cells[1].Value.ToString();
            txtGioiTinh.Text = data.Rows[index].Cells[2].Value.ToString();
            NgaySinh.Text = data.Rows[index].Cells[3].Value.ToString();
            txtSDT.Text = data.Rows[index].Cells[4].Value.ToString();
            txtDiaChi.Text = data.Rows[index].Cells[5].Value.ToString();
            txtCMND.Text = data.Rows[index].Cells[6].Value.ToString();
            txtEmail.Text = data.Rows[index].Cells[7].Value.ToString();
            txtUser.Text = data.Rows[index].Cells[8].Value.ToString();
            txtPosition.Text = data.Rows[index].Cells[9].Value.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int id = int.Parse(this.txtID.Text);
            string name = this.txtHoTen.Text;
            string gender = this.txtGioiTinh.Text;
            DateTime ngaysinh = this.NgaySinh.Value;
            //DateTime ngaysinh = DateTime.Now;
            string diaChi = this.txtDiaChi.Text;
            string phoneNumber = this.txtSDT.Text;
            string email = this.txtEmail.Text;
            string cccd = this.txtCMND.Text;
            int user = int.Parse(this.txtUser.Text);
            int position = int.Parse(this.txtPosition.Text);
            NhanVien nv = new NhanVien(id, name, gender, ngaysinh, phoneNumber, diaChi, cccd, email, user, position);
            if (dao.updateNhanVien(nv))
            {
                MessageBox.Show("OK");
                try
                {
                    data.DataSource = dao.GetAllNhanVien();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Loi : " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("error");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Exit(this, new EventArgs());
        }
    }
}
