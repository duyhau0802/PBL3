using PBL3.Model;
using System.Diagnostics;

namespace PBL3
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }
        /*
        bool CheckLogin(string name, string pass) {
            for (int i = 0; i < ListUser.Instance.ListAccountUser.Count; i++) {
                if (name == ListUser.Instance.ListAccountUser[i].UserName && pass == ListUser.Instance.ListAccountUser[i].PassWord)
                {
                    Constant.AccountType = ListUser.Instance.ListAccountUser[i].AccountType;
                    return true;
                } 
            }
            return false;
        }*/

        UserDAO dao;
        private void button1_Click(object sender, EventArgs e)
        {
            dao = new UserDAO();
            if (dao.checkLogin(txbUsername.Text, txtPass.Text))
            {
                if (Constant.AccountType == true)
                {
                    FormMain f = new FormMain();
                    f.Show();
                    this.Hide();
                    f.Logout += F_Logout;
                }
                else
                {
                    FormMainRoleNhanVien f = new FormMainRoleNhanVien();
                    f.Show();
                    this.Hide();
                    f.Logout += F_Logout;
                }
            }
            else {
                MessageBox.Show("Sai ten hoac mat khau", "Loi",MessageBoxButtons.OK);
                txbUsername.Focus();
                return;
            }
            
        }

        private void F_Logout(object? sender, EventArgs e)
        {
            if((sender as FormMain) != null)
            {
                (sender as FormMain).Close();
            } else
            {
                (sender as FormMainRoleNhanVien).Close();
            }
            this.Show();
        }
        private void FormLogin_FormClosed(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        private void lbPassword_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }

        private void ckbShowPassEvent(object sender, EventArgs e)
        {
            if(ckbShowPass.Checked)
                txtPass.UseSystemPasswordChar = false;
            if (!ckbShowPass.Checked)
                txtPass.UseSystemPasswordChar = true;

        }
    }
}