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
    public partial class FormMainRoleNhanVien : Form
    {
        public bool isExit = true;
        static int id_now = -1;

        public event EventHandler Logout;
        public FormMainRoleNhanVien(int id)
        {
            id_now = id;
            InitializeComponent();
        }

        #region Event
        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isExit) {
                if (MessageBox.Show("Bạn có muốn thoát", "Cảnh báo", MessageBoxButtons.YesNo) != DialogResult.Yes)
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
            NhanVien nv = dao.getById(id_now);
            if (nv != null)
            {
                string[] dateofBirth = nv.DateOfBirth.ToShortDateString().Split('/');
                this.lbID.Text += nv.Id;
                this.lbName.Text += nv.Name;
                this.lbGender.Text += nv.Gender;
                this.lbBirth.Text += dateofBirth[1] + "/" + dateofBirth[0] + "/" + dateofBirth[2];
                this.lbPhone.Text += nv.PhoneNumber;
                this.lbAddress.Text += nv.Address;
                this.lbIDC.Text += nv.CCCD;
                this.lbEmail.Text += nv.Email;
            }
            else
            {
                MessageBox.Show("Error");
            }
        }

        private void importFromExcelFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormImport f = new FormImport();
            f.Show();
            this.Hide();
        }
        #endregion
    }
}
