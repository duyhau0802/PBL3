﻿using System;
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
        public event EventHandler Logout;
        public FormMainRoleNhanVien()
        {
            InitializeComponent();
        }

        #region Event
        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isExit) {
                if (MessageBox.Show("Ban co muon thoat", "Cảnh báo", MessageBoxButtons.YesNo) != DialogResult.Yes)
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

        Modify modify;

        

        private void FormMain_Load_1(object sender, EventArgs e)
        {
            modify = new Modify();
            try
            {
                dataGridView1.DataSource = modify.GetAllNhanVien();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi : " + ex.Message);
            }
        }

        private void importFromExcelFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormImport f = new FormImport();
            f.Show();
            this.Hide();
        }
        #endregion

        private void button3_Click(object sender, EventArgs e)
        {
            FormSearch f = new FormSearch();
            f.Show();
        }
    }
}
