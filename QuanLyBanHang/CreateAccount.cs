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
    public partial class fCreateAccount : Form
    {
        public fCreateAccount()
        {
            InitializeComponent();
        }
        public bool CompareAccount(string username)
        {
            List<Account> accountList = AccountDAO.Instance.GetListAccountToCompare();
            foreach (Account item in accountList)
            {
                if (item.UserName == username)
                {
                    return false;
                }
            }
            return true;
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txbAccount.Text;
            string displayname = txbDisplayName.Text;
            int type = Convert.ToInt32(txbType.Text);
            string password = txbPassword.Text;
            string repassword = txbRePassword.Text;
            if (CompareAccount(username) == true)
            {
                if (password == repassword)
                {
                    if (type == 1)
                    {
                        AccountDAO.Instance.CreateAccount(username, displayname, password, type);
                        MessageBox.Show("Thêm tài khoản Admin thành công", "Thông báo", MessageBoxButtons.OK);
                    }
                    else if (type == 0)
                    {
                        AccountDAO.Instance.CreateAccount(username, displayname, password, type);
                        MessageBox.Show("Thêm tài khoản Nhân viên thành công", "Thông báo", MessageBoxButtons.OK);
                    }
                    else MessageBox.Show("Loại tài khoản không hợp lệ, vui lòng nhập lại", "Thông báo", MessageBoxButtons.OK);
                }
                else MessageBox.Show("Mật khẩu không giống nhau, vui lòng nhập lại", "Thông báo", MessageBoxButtons.OK);
            }
            else MessageBox.Show("Tài khoản đã tồn tại , vui lòng nhập lại", "Thông báo", MessageBoxButtons.OK);
        }
       
    }
}
