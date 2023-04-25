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
    public partial class FormUpdate_PhongBan : Form
    {
        int index = -1;
        public event EventHandler Exit;

        public FormUpdate_PhongBan()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Exit(this, new EventArgs());
        }

        private void data_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
            if(index != -1)
            {
                this.txtName.Text = data.Rows[index].Cells[1].Value.ToString();
                this.cbbTruong.Text = data.Rows[index].Cells[2].Value.ToString();
            }
        }

        NhanvienDAO nvdao;
        PhongbanDAO pbdao;
        private void FormUpdate_PhongBan_Load(object sender, EventArgs e)
        {
            nvdao = new NhanvienDAO();
            pbdao= new PhongbanDAO();
            try
            {
                data.DataSource = pbdao.GetAllPhongBan();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi : " + ex.Message);
            }
            this.cbbTruong.Items.AddRange(nvdao.getAllNameNhanVien().ToArray());
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (index != -1)
            {
                int id = int.Parse(data.Rows[index].Cells[0].Value.ToString());
                string name = this.txtName.Text;
                int truongphong = nvdao.getIdByName(this.cbbTruong.Text);
                
                Phongban pb = new Phongban(id, name, truongphong);

                if (pbdao.updatePhongban(pb))
                {
                    MessageBox.Show("OK");
                    try
                    {
                        data.DataSource = pbdao.GetAllPhongBan();
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
    }
}
