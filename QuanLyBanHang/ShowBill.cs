using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyBanHang.DAO;
using QuanLyBanHang.DTO;
using Category = QuanLyBanHang.DTO.Category;
using Menu = QuanLyBanHang.DTO.Menu;

namespace QuanLyBanHang
{
    public partial class ShowBill : Form
    {
        public ShowBill()
        {
            InitializeComponent();
        }

        public void ShowtoBill(int id)   // hàm show bill khi click vào bàn
        {
            ls_bill.Items.Clear();
            float totalPrice = 0;
            //float discount = Convert.ToInt32(nudDiscount.Value);
            List<Menu> listBillinfo = MenuDAO.Instance.GetListMenu(id);
            foreach (Menu item in listBillinfo)
            {
                ListViewItem lsvItems = new ListViewItem(item.FoodName.ToString());
                lsvItems.SubItems.Add(item.Price.ToString());
                lsvItems.SubItems.Add(item.Count.ToString());
                lsvItems.SubItems.Add(item.TotalPrice.ToString());
                totalPrice += item.TotalPrice;
                ls_bill.Items.Add(lsvItems);
            }
            CultureInfo culture = new CultureInfo("vi-VN");
            lb_money.Text = totalPrice.ToString("c", culture);
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
