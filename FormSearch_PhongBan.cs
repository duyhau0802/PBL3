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
    public partial class FormSearch_PhongBan : Form
    {
        public event EventHandler Exit;

        public FormSearch_PhongBan()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Exit(this, new EventArgs());
        }

        PhongbanDAO dao;
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string tieuchi = cbbTieuChi.Text;
            string value = txtDuLieu.Text;
            dao = new PhongbanDAO();
            try
            {
                KetQua.DataSource = dao.searchPhongban(tieuchi, value);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi : " + ex.Message);
            }
        }
    }
}
