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
    public partial class fTableManager : Form
    {
        Button btn = new Button(); 
        public fTableManager()
        {
            InitializeComponent();
            LoadTable();
        }
        #region Method
        void LoadTable()
        {
            List<Table> tableList = TableDAO.Instance.LoadTableList();

            foreach (Table item in tableList)
            {
                Button btn = new Button() { Width = TableDAO.TableWidth, Height = TableDAO.TableHeight };
                btn.Text = item.Name + Environment.NewLine + item.Status;
                btn.Click += Btn_Click;
                btn.Tag = item;
                if(item.Status == "Trống")
                {
                    btn.BackColor = Color.AliceBlue;
                }
                else
                {
                    btn.BackColor = Color.LightPink;
                }
                flpTable.Controls.Add(btn);
               
            }
        }
        void ShowBill(int id)
        {
            lsvBill.Items.Clear();
            List<BillInfo> listBillinfo = BillInfoDAO.Instance.GetListBillInfo(BillDAO.Instance.GetUncheckedBillByTableID(id));
            foreach (BillInfo item in listBillinfo)
            {
                ListViewItem lsvItems = new ListViewItem(item.IdFood.ToString());
                lsvItems.SubItems.Add(item.Count.ToString());
                lsvBill.Items.Add(lsvItems);
            }
        }

        #endregion
        #region Events

        private void Btn_Click(object sender, EventArgs e)
        {
            int tableID = ((sender as Button).Tag as Table).ID;
            ShowBill(tableID);
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnFloor1_Click(object sender, EventArgs e)
        {
            flpTable.Show();
        }
        #endregion




    }
}
