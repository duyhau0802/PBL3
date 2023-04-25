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
            if (index != -1)
            {
                txtHoTen.Text = data.Rows[index].Cells[1].Value.ToString();
                txtGioiTinh.Text = data.Rows[index].Cells[2].Value.ToString();
                NgaySinh.Text = data.Rows[index].Cells[3].Value.ToString();
                txtSDT.Text = data.Rows[index].Cells[4].Value.ToString();
                txtDiaChi.Text = data.Rows[index].Cells[5].Value.ToString();
                txtCMND.Text = data.Rows[index].Cells[6].Value.ToString();
                txtEmail.Text = data.Rows[index].Cells[7].Value.ToString();
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(index != -1)
            {
                int id = int.Parse(data.Rows[index].Cells[0].Value.ToString());
                string name = this.txtHoTen.Text;
                string gender = this.txtGioiTinh.Text;
                DateTime ngaysinh = this.NgaySinh.Value;
                //DateTime ngaysinh = DateTime.Now;
                string diaChi = this.txtDiaChi.Text;
                string phoneNumber = this.txtSDT.Text;
                string email = this.txtEmail.Text;
                string cccd = this.txtCMND.Text;
                int user = int.Parse(data.Rows[index].Cells[8].Value.ToString());
                NhanVien nv = new NhanVien(id, name, gender, ngaysinh, phoneNumber, diaChi, cccd, email, user);
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
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Exit(this, new EventArgs());
        }
    }
}
