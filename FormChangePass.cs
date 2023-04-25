using PBL3.Model;

namespace PBL3
{
    public partial class FormChangePass : Form
    {
        static int id_now = -1;

        public event EventHandler Exit;
        public FormChangePass(int id)
        {
            id_now = id;
            InitializeComponent();
        }

        private void lbPassword_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Exit(this, new EventArgs());
        }

        UserDAO user;
        private void btnChange_Click(object sender, EventArgs e)
        {
            user = new UserDAO();
            MessageBox.Show(user.changePass(id_now, txbOldPass.Text, txbNewPass.Text, txbConfirm.Text));
            txbConfirm.Text = txbNewPass.Text = txbOldPass.Text = "";
        }
    }
}