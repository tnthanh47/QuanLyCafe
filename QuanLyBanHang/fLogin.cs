using QuanLyBanHang.DAO;
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
    public partial class fLogin : Form
    {
        public fLogin()
        {
            InitializeComponent();
            FormClosing += Form1_FormClosing;
           
        }

        bool login(string userName, string passWord) // hàm kiểm tra tài khoản và mật khẩu
        {
            return AccountDAO.Instance.Login(userName, passWord);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string userName = txbLoginAccount.Text;
            string passWord = txbLoginPassword.Text;
            if (login(userName, passWord))
            {
                fManager manager = new fManager();
                this.Hide();
                manager.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Nhập sai tên hoặc mặt khẩu", "Thông báo", MessageBoxButtons.OK);
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát chương trình ?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

    }
}
