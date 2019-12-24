using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyBanHang.DAO;

namespace QuanLyBanHang
{
    public partial class UsC_Staff : UserControl
    {
        BindingSource accountList = new BindingSource();
        public UsC_Staff()
        {
            InitializeComponent();
            dtgvAccount.DataSource = accountList;
            LoadListAccount();
            AccountBinding();

        }

        #region Method
        void LoadListAccount()
        {
            accountList.DataSource = AccountDAO.Instance.GetListAccount();
        }
        void AccountBinding()
        {
            txb_Username.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "username", true, DataSourceUpdateMode.Never));
            txb_Displayname.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "displayname", true, DataSourceUpdateMode.Never));
            txb_Type.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "type", true, DataSourceUpdateMode.Never));
        }
        #endregion

        #region Event
        private void btn_ViewAccount_Click(object sender, EventArgs e)
        {
            LoadListAccount();
        }
        private void btn_DeleteAccount_Click(object sender, EventArgs e)
        {
            if (txb_Type.Text != "1")
            {
                if (MessageBox.Show("Bạn có muốn xóa tài khoản", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    string name = txb_Username.Text;
                    AccountDAO.Instance.DeleteAccount(name);
                    LoadListAccount();
                }
            }
            else MessageBox.Show("Không thể xóa Admin", "Thông báo", MessageBoxButtons.OK);
        }
        #endregion


    }
}
