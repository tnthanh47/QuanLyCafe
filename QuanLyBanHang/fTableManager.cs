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
        void ShowBill(int id)   // hàm show bill khi click vào bàn
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


        #endregion


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
    }
}
