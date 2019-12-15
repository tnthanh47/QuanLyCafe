using LinqToTwitter;
using QuanLyBanHang.DAO;
using QuanLyBanHang.DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Menu = QuanLyBanHang.DTO.Menu;

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
            float totalPrice = 0;
            List<Menu> listBillinfo = MenuDAO.Instance.GetListMenu(id);
            foreach (Menu item in listBillinfo)
            {
                ListViewItem lsvItems = new ListViewItem(item.FoodName.ToString());
                lsvItems.SubItems.Add(item.Price.ToString());
                lsvItems.SubItems.Add(item.Count.ToString());
                lsvItems.SubItems.Add(item.TotalPrice.ToString());
                totalPrice += item.TotalPrice;
                lsvBill.Items.Add(lsvItems);
            }
            Culture culture = new Culture();
            txb_money.Text = totalPrice.ToString();
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

        private void bunifuTileButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
