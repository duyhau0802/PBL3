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
        Modify modify;
        private void button1_Click(object sender, EventArgs e)
        {
            modify = new Modify();
            string name = this.txtName.Text;
            string gender = this.txtGender.Text;
            DateTime ngaysinh = this.dateOfbirth.Value;
            //DateTime ngaysinh = DateTime.Now;
            string diaChi = this.txtDiachi.Text;
            string phoneNumber = this.txtSdt.Text;
            string email = this.txtEmail.Text;
            string cccd = this.txtCCCD.Text;
            nv = new NhanVien(name,gender,ngaysinh,phoneNumber,diaChi,cccd,email);
            if (modify.insert(nv))
            {
                MessageBox.Show("OK");
            }
            else
            {
                MessageBox.Show("error");
            }
        }
    }
}
