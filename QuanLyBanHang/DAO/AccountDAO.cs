using QuanLyBanHang.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace QuanLyBanHang.DAO
{
    public class AccountDAO
    {
        private static AccountDAO instance;

        public static AccountDAO Instance   // SingleTon
        {
            get { if (instance == null) instance = new AccountDAO(); return instance; }
            private set { instance = value; }
        }

        private AccountDAO() { }

        public bool Login(string userName, string passWord)  // hàm kiểm tra tên đăng nhập và mật khẩu có hợp lệ
        {
            string query = "USP_Login @USERNAME , @PASSWORD";

            DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[] { userName, passWord });

            return result.Rows.Count > 0;
        }
        public bool issTaff(string userName, string passWord)   // hàm kiểm tra xem có phải là nhân viên hay k
        {
            int a = 0;
            string query = "select * from Account where UserName = '" + userName + "' and TYPE = '" + a + "'";

            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            if (result.Rows.Count > 0)
                return true;
            else return false;
        }
        public bool UpdateAccount(string userName, string displayName, string pass, string newPass)  // hàm cập nhật mật khẩu
        {
            int result = DataProvider.Instance.ExecuteNonQuery("exec USP_UpdateAccount @userName , @displayName , @password , @newPassword", new object[] { userName, displayName, pass, newPass });

            return result > 0;
        }
        public void DeleteAccount(string name)// hàm xóa tài khoản
        {
            string query = "delete from account where username = " + "'"+name+"'";
            DataProvider.Instance.ExecuteNonQuery(query);
        }
        public Account GetAccountByUserName(string userName)    // tìm tài khoản theo tên
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("Select * from account where USERNAME = '" + userName + "'");

            foreach (DataRow item in data.Rows)
            {
                return new Account(item);
            }

            return null;
        }
        public DataTable GetListAccount()  // lấy ra danh sách tài khoản
        {
            string query = "select username  , displayname , type  from account";
            return DataProvider.Instance.ExecuteQuery(query);
        }
        public void CreateAccount(string username, string displayname,string password,int type)   // hàm tạo tài khoản
        {
            string query = "INSERT INTO ACCOUNT(USERNAME,DISPLAYNAME,PASSWORD,TYPE) VALUES( " + "'" + username + "'" + "," + "'" + displayname + "'" + ", " + "'" + password + "'" + ", " + type + ")";
            DataProvider.Instance.ExecuteNonQuery(query);
        }
        public List<Account> GetListAccountToCompare()    // hàm lấy ra danh sách tài khoản để so sánh có tồn tại hay không khi tạo tài khoản
        {
            List<Account> accountList = new List<Account>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * from account");

            foreach (DataRow item in data.Rows)
            {
                Account account = new Account(item);
                accountList.Add(account);
            }
            return accountList;
        }

      
    }
}
