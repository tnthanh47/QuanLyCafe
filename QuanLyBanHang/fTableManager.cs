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
        UsC_Drink drink = new UsC_Drink();
        CheckBill checkbill = new CheckBill();
        public fTableManager()
        {
            InitializeComponent();
            //LoadTable();
            LoadCategory();
            LoadComboBoxTable1(cb_Table1);
            cbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cbFood.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_Table1.DropDownStyle = ComboBoxStyle.DropDownList;
           // cb_Table2.DropDownStyle = ComboBoxStyle.DropDownList;
            drink.InsertFood += Drink_InsertFood;
            drink.UpdateFood += Drink_UpdateFood;
            drink.DeleteFood += Drink_DeleteFood;
        }

        private void Drink_DeleteFood(object sender, EventArgs e)
        {
           LoadFoodByCategory((cbCategory.SelectedItem as Category).Id);
            if (lsvBill.Tag != null)
                ShowBill((lsvBill.Tag as Table).ID);
            LoadTable();
        }

        private void Drink_UpdateFood(object sender, EventArgs e)
        {
            LoadFoodByCategory((cbCategory.SelectedItem as Category).Id);
            if (lsvBill.Tag != null)
                ShowBill((lsvBill.Tag as Table).ID);
        }

        private void Drink_InsertFood(object sender, EventArgs e)
        {
            LoadFoodByCategory((cbCategory.SelectedItem as Category).Id);
            if (lsvBill.Tag != null)
                ShowBill((lsvBill.Tag as Table).ID);
        }
        #region Method
        public void LoadTable()  // hàm để hiển thị các bàn
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
        public void LoadTableFloor1()
        {
            flpTable.Controls.Clear();
            List<Table> tableList = TableDAO.Instance.LoadTableListforFloor1();
            foreach (Table item in tableList)
            {
                Button btn = new Button() { Width = TableDAO.TableWidth, Height = TableDAO.TableHeight };
                btn.Text = item.Name + Environment.NewLine + item.Status;
                btn.Click += Btn_Click;
                btn.Tag = item;
                if (item.Status == "Trống")
                {
                    btn.BackColor = Color.AliceBlue;
                }
                else
                {
                    btn.BackColor = Color.LightPink;
                }
                flpTable.Controls.Add(btn);
            }
        }  // hàm để hiển thị bàn tầng 1
        public void LoadTableFloor2()
        {
            flpTable.Controls.Clear();
            List<Table> tableList = TableDAO.Instance.LoadTableListforFloor2();
            foreach (Table item in tableList)
            {
                Button btn = new Button() { Width = TableDAO.TableWidth, Height = TableDAO.TableHeight };
                btn.Text = item.Name + Environment.NewLine + item.Status;
                btn.Click += Btn_Click;
                btn.Tag = item;
                if (item.Status == "Trống")
                {
                    btn.BackColor = Color.AliceBlue;
                }
                else
                {
                    btn.BackColor = Color.LightPink;
                }
                flpTable.Controls.Add(btn);
            }
        }  // hàm để hiển thị bàn tầng 2
        public void ShowBill(int id)   // hàm show bill khi click vào bàn
        {
            lsvBill.Items.Clear();
            float totalPrice = 0;
            float discount = Convert.ToInt32(nudDiscount.Value);
            List<Menu> listBillinfo = MenuDAO.Instance.GetListMenu(id);
            foreach (Menu item in listBillinfo)
            {
                ListViewItem lsvItems = new ListViewItem(item.FoodName.ToString());
                lsvItems.SubItems.Add(item.Price.ToString());
                lsvItems.SubItems.Add(item.Count.ToString());
                lsvItems.SubItems.Add(item.TotalPrice.ToString());
                totalPrice += item.TotalPrice;
                lsvBill.Items.Add(lsvItems);
                //CheckBill.lsv.Items.Add(lsvItems);
            }
            
            CultureInfo culture = new CultureInfo("vi-VN");
            txb_Money.Text = totalPrice.ToString("c",culture);
        }

        void LoadCategory()  //hàm để đổ dữ liệu Category vào ComboBox
        {
            List<Category> listCategory = CategoryDAO.Instance.GetListCategory();
            cbCategory.DataSource = listCategory;
            cbCategory.DisplayMember = "NAME";
        }
        public void LoadFoodByCategory(int id)  //hàm để đổ dữ liệu Food vào ComboBox
        {
            List<Food> listFood = FoodDAO.Instance.GetFoodByCategoryID(id);
            cbFood.DataSource = listFood;
            cbFood.DisplayMember = "NAME";
        }
        void LoadComboBoxTable1(ComboBox cb)  // hàm để đổ dữ liệu Table vào Combobox
        {
            cb.DataSource = TableDAO.Instance.LoadTableList();
            cb.DisplayMember = "Name";
        }
        #endregion
        #region Events

        private void Btn_Click(object sender, EventArgs e)    // event xảy ra khi NHẤN vô từng bàn
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
            LoadTableFloor1();
        }
        private void btn_Floor2_Click(object sender, EventArgs e)
        {
            LoadTableFloor2();
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
        private void btnAddFood_Click(object sender, EventArgs e)  // hàm thêm món ăn vào bill
        {
            Table table = lsvBill.Tag as Table;
            if (table != null)
            {
                int idBill = BillDAO.Instance.GetUncheckedBillByTableID(table.ID);
                int idFood = (cbFood.SelectedItem as Food).Id;
                int count = (int)nudFood.Value;
                if (count > 0)
                {
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
                    TableDAO.Instance.ChangeTableStatus(table.ID);  // sau khi thêm món ăn sẽ Update lại trạng thái của bàn thành Có người
                }
                LoadTable();  // Load lại trạng thái của bàn
            }
        }

        private void btn_pay_Click(object sender, EventArgs e)  // hàm thanh toán 
        {
            Table table = lsvBill.Tag as Table;
            if (table != null)
            {
                int idBill = BillDAO.Instance.GetUncheckedBillByTableID(table.ID);  // lấy ra những bill chưa thanh toán theo id của bàn
                int discount = (int)nudDiscount.Value;
                double totalPrice = Convert.ToDouble(txb_Money.Text.Split(',')[0]);
                double priceDiscount = totalPrice - totalPrice * discount / 100;
                if (idBill != -1)
                {
                    try
                    {
                        lsvBill.Items.Clear();
                        CheckBill.idTable = table.ID;
                        CheckBill.discount = discount;
                        CheckBill.tableName = table.Name.ToString();
                        CheckBill.money = priceDiscount;
                        this.Hide();
                        checkbill.ShowDialog();
                        this.Show();
                        LoadTable();
                        //LoadTableFloor1();
                        //LoadTableFloor2();
                    }
                    catch 
                    {
                    }

                }
                else  MessageBox.Show("Không có hóa đơn", "Thông báo", MessageBoxButtons.OK);
            }
            else MessageBox.Show("Không có hóa đơn", "Thông báo", MessageBoxButtons.OK);
        }

        private void Btn_Switch_Click(object sender, EventArgs e) // hàm chuyển bàn
        {
            try
            {
                int id1 = (lsvBill.Tag as Table).ID;
                int id2 = (cb_Table1.SelectedItem as Table).ID;

                if (MessageBox.Show("Bạn có muốn chuyển từ Bàn " + (lsvBill.Tag as Table).Name + " sang bàn " + (cb_Table1.SelectedItem as Table).Name, "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    TableDAO.Instance.SwitchTable(id1, id2);
                    LoadTable();
                }
            }
            catch { MessageBox.Show("Lỗi khi chuyển bàn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }


        #endregion

        
    }
}
