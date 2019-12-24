using QuanLyBanHang.DAO;
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
        bool isStafff(string userName,string passWord)
        {
            return AccountDAO.Instance.issTaff(userName, passWord);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txbLoginAccount.Text;
            string password = txbLoginPassword.Text;
            if (login(username, password)&& isStafff(username,password)==false)
            {
                Account loginAccount = AccountDAO.Instance.GetAccountByUserName(username);
                fManager manage = new fManager(loginAccount);
                this.Hide();
                manage.ShowDialog();
                this.Show();
            }
            else if (login(username, password) && isStafff(username, password) )
            {
                Account loginAccount = AccountDAO.Instance.GetAccountByUserName(username);
                fStaff staff = new fStaff(loginAccount);
                this.Hide();
                staff.ShowDialog();
                this.Show();
                
            }
            else if(login(username,password)==false)
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
