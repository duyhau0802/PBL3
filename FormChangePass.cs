namespace PBL3
{
    public partial class FormChangePass : Form
    {

        public event EventHandler Exit;
        public FormChangePass()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormMain f = new FormMain();
            f.Show();
            this.Hide();
        }

        private void lbPassword_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Exit(this, new EventArgs());
        }
    }
}