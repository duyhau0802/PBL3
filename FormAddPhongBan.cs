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
    public partial class FormAddPhongBan : Form
    {
        public event EventHandler Exit;

        public FormAddPhongBan()
        {
            InitializeComponent();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        PhongbanDAO pbdao;
        private void btnAdd_Click(object sender, EventArgs e)
        {
            pbdao = new PhongbanDAO();
            string name = txbName.Text;
            NhanvienDAO nhanvien = new NhanvienDAO();
            int truongphong = nhanvien.getIdByName(cbbTruong.Text);
            Phongban pb = new Phongban(name, truongphong);
            if (pbdao.insertPb(pb))
            {
                MessageBox.Show("Thành công");
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

        private void FormAddPhongBan_Load(object sender, EventArgs e)
        {
            NhanvienDAO nhanvien = new NhanvienDAO();
            this.cbbTruong.Items.AddRange(nhanvien.getAllNameNhanVien().ToArray());
        }
    }
}
