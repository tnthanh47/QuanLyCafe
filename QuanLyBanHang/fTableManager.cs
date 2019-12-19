using LinqToTwitter;
using QuanLyBanHang.DAO;
using QuanLyBanHang.DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using Category = QuanLyBanHang.DTO.Category;
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
            LoadCategory();
        }
        #region Method
        void LoadTable()  // hàm để hiển thị các bàn
        {
            flpTable.Controls.Clear();
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
        public void ShowBill(int id)   // hàm show bill khi click vào bàn
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
            CultureInfo culture = new CultureInfo("vi-VN");
            txb_money.Text = totalPrice.ToString("c",culture);
            /*
             * void ShowBill(int id)
        {
            lsvBill.Items.Clear();
            List<QuanLyQuanCafe.DTO.Menu> listBillInfo = MenuDAO.Instance.GetListMenuByTable(id);
            float totalPrice = 0;
            foreach (QuanLyQuanCafe.DTO.Menu item in listBillInfo)
            {
                ListViewItem lsvItem = new ListViewItem(item.FoodName.ToString());
                lsvItem.SubItems.Add(item.Count.ToString());
                lsvItem.SubItems.Add(item.Price.ToString());
                lsvItem.SubItems.Add(item.TotalPrice.ToString());
                totalPrice += item.TotalPrice;
                lsvBill.Items.Add(lsvItem);
            }
            CultureInfo culture = new CultureInfo("vi-VN");

             */
        }
        void LoadCategory()
        {
            List<Category> listCategory = CategoryDAO.Instance.GetListCategory();
            cbCategory.DataSource = listCategory;
            cbCategory.DisplayMember = "NAME";
        }
        void LoadFoodByCategory(int id)
        {
            List<Food> listFood = FoodDAO.Instance.GetFoodByCategoryID(id);
            cbFood.DataSource = listFood;
            cbFood.DisplayMember = "NAME";
        }
        #endregion
        #region Events

        private void Btn_Click(object sender, EventArgs e)
        {
            int tableID = ((sender as Button).Tag as Table).ID;
            lsvBill.Tag = (sender as Button).Tag;
            ShowBill(tableID);

        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnFloor1_Click(object sender, EventArgs e)  // tầng 1
        {
            flpTable.Show();
        }

        private void bunifuTileButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void cbCategory_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            int id = 0;
            ComboBox cb = sender as ComboBox;
            if (cb.SelectedItem == null)
                return;
            Category selected = cb.SelectedItem as Category;
            id = selected.Id;
            LoadFoodByCategory(id);
        }
        private void btnAddFood_Click(object sender, EventArgs e)
        {
            Table table = lsvBill.Tag as Table;
            int idBill = BillDAO.Instance.GetUncheckedBillByTableID(table.ID);
            int idFood = (cbFood.SelectedItem as Food).Id;
            int count = (int)nudFood.Value;
            if (idBill == -1)
            {
                BillDAO.Instance.InsertBill(table.ID);
                BillInfoDAO.Instance.InsertBillInfo(BillDAO.Instance.GetMaxIdBill(), idFood, count);
            }
            else
            {
                BillInfoDAO.Instance.InsertBillInfo(idBill, idFood, count);
            }
          
            ShowBill(table.ID);
        }

        private void btn_pay_Click(object sender, EventArgs e)
        {
            Table table = lsvBill.Tag as Table;
            int idBill = BillDAO.Instance.GetUncheckedBillByTableID(table.ID);
            if (idBill != -1)
            {
                if (MessageBox.Show("Bạn muốn THANH TOÁN cho bàn " + table.Name, "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    BillDAO.Instance.CheckOut(idBill);
                    BillInfoDAO.Instance.DeleteBillInfoByBillId(idBill);
                    BillDAO.Instance.DeleteBillByTableID(table.ID);
                    ShowBill(table.ID);
                }
            }
            else
            {
                MessageBox.Show("Bàn không có hóa đơn", "Thông báo", MessageBoxButtons.OK);
            }
        }

        #endregion

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
