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
    public partial class FormAddNewUser : Form
    {
        public event EventHandler Exit;
        public FormAddNewUser()
        {
            InitializeComponent();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void FormAddNewUser_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        NhanVien nv;
        NhanvienDAO dao;
        private void button1_Click(object sender, EventArgs e)
        {
            dao = new NhanvienDAO();
            string name = this.txtName.Text;
            string gender = this.txtGender.Text;
            DateTime ngaysinh = this.dateOfbirth.Value;
            //DateTime ngaysinh = DateTime.Now;
            string diaChi = this.txtDiachi.Text;
            string phoneNumber = this.txtSdt.Text;
            string email = this.txtEmail.Text;
            string cccd = this.txtCCCD.Text;
            int user = int.Parse(this.textUserId.Text);
            int position = int.Parse(this.cbbPosition.Text);

            nv = new NhanVien(name,gender,ngaysinh,phoneNumber,diaChi,cccd,email, user, position);
            if (dao.insert(nv))
            {
                MessageBox.Show("OK");
            }
            else
            {
                MessageBox.Show("error");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Exit(this, new EventArgs());
        }
    }
}
