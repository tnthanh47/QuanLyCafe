using QuanLyBanHang.DTO;
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
        private Account loginAccount;

        public Account LoginAccount { get { return loginAccount; } set { loginAccount = value; } }

        public fManager(Account acc)
        {
            InitializeComponent();
            this.LoginAccount = acc;
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
            fAcountProfile acountProfile = new fAcountProfile(LoginAccount);
            this.Hide();
            acountProfile.ShowDialog();
            this.Show();
        }

        private void btnCreateAccount_Click(object sender, EventArgs e)
        {
            fCreateAccount createAccount = new fCreateAccount();
            this.Hide();
            createAccount.ShowDialog();
            this.Show();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }
    }
}
