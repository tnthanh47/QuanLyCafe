using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHang
{
    public partial class fManager : Form
    {
        public fManager()
        {
            InitializeComponent();
        }

        private void btnManager_Click(object sender, EventArgs e)
        {
            fTableManager table = new fTableManager();
            this.Hide();
            table.ShowDialog();
            this.Show();
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            Admin admin = new Admin();
            this.Hide();
            admin.ShowDialog();
            this.Show();
        }

        private void btnAccountInfo_Click(object sender, EventArgs e)
        {
            fAcountProfile acountProfile = new fAcountProfile();
            this.Hide();
            acountProfile.ShowDialog();
            this.Show();
        }

        private void btnCreateAccount_Click(object sender, EventArgs e)
        {
            fAcountProfile acountProfile = new fAcountProfile();
            this.Hide();
            acountProfile.ShowDialog();
            this.Show();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
