using QuanLyBanHang.DAO;
using QuanLyBanHang.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Menu = QuanLyBanHang.DTO.Menu;
using Microsoft.Win32;
using Microsoft.Office.Interop.Excel;
using SaveFileDialog = System.Windows.Forms.SaveFileDialog;

namespace QuanLyBanHang
{
    public partial class CheckBill : Form
    {
       // fTableManager fTableManager = new fTableManager();
        public static string tableName = string.Empty ;
        public static double money = 0;
        public static ListView lsv = new ListView();
        public static int discount = 0;
        public static int idTable;
        float totalPrice = 0;
        
        public CheckBill()
        {
            InitializeComponent();
            btnView.Enabled = true;
            btnPrint.Enabled = false;
            button2.Enabled = false;
            Load();
           
        }
        public void Load()
        {
            bill();
            //lb_money.Text = money;
            lbDiscount.Text = discount.ToString();
            lbTableName.Text = tableName;
            CultureInfo culture = new CultureInfo("vi-VN");
            lb_money.Text = money.ToString() + ",000 VND"  ;
        }
        void bill()
        {
            List<Menu> listBillinfo = MenuDAO.Instance.GetListMenu(idTable);
            foreach (Menu item in listBillinfo)
            {
                ListViewItem lsvItems = new ListViewItem(item.FoodName.ToString());
                lsvItems.SubItems.Add(item.Price.ToString());
                lsvItems.SubItems.Add(item.Count.ToString());
                lsvItems.SubItems.Add(item.TotalPrice.ToString());
                totalPrice += item.TotalPrice;
                lsv_Bill.Items.Add(lsvItems);
            }
        }
     

        // click
        private void button2_Click(object sender, EventArgs e)
        {
            lsv_Bill.Items.Clear();
            int idBill = BillDAO.Instance.GetUncheckedBillByTableID(idTable);  // lấy ra những bill chưa thanh toán theo id của bàn
            double priceDiscount = totalPrice - totalPrice * discount / 100;
            if (idBill != -1)
            {
                BillDAO.Instance.CheckOut(idBill, discount, (float)money);
                if (MessageBox.Show("Thanh toán thành công", "Thông báo", MessageBoxButtons.OK) == DialogResult.OK)
                {
                    lbTableName.Text = "";
                    lb_money.Text = "";
                    lbDiscount.Text = "";
                    btnView.Enabled = true;
                    this.Close();
                }

            }
        }
        private void btnView_Click(object sender, EventArgs e)
        {
            Load();
            btnView.Enabled = false;
            btnPrint.Enabled = true;
            button2.Enabled = true;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            try
            {
                using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Text Documents|*.txt", ValidateNames = true })
                {
                    if(sfd.ShowDialog() == DialogResult.OK)
                    {
                        using (TextWriter tw = new StreamWriter(new FileStream(sfd.FileName, FileMode.Create), Encoding.UTF8))
                        {
                            tw.WriteLine("\n");
                            tw.WriteLine("\n");
                            tw.WriteLine("                       ***   THE COFFEE KING  ***");
                            tw.WriteLine("\n");
                            tw.WriteLine("Bàn: " + lbTableName.Text);
                            tw.WriteLine("Thời gian: " + dt);
                            tw.WriteLine("\n");
                            tw.WriteLine("     Tên món" + "\t" + "       Giá" + "\t" + "   Số lượng" + "\t" + "        Thành tiền"); 
                            foreach (ListViewItem item in lsv_Bill.Items)
                            {
                                tw.WriteLineAsync(item.SubItems[0].Text + "\t     " + item.SubItems[1].Text + "\t       " + item.SubItems[2].Text + "\t          " + item.SubItems[3].Text);
                            }
                            tw.WriteLine("\n");
                            tw.WriteLine("--------------------------------------------------------------");
                            tw.WriteLine("Giảm giá: " + lbDiscount.Text);
                            tw.WriteLine("Tổng tiền: " + lb_money.Text);
                            tw.WriteLine("---------------------------------------------------------------");

                           MessageBox.Show("Xuất đơn thành công","Thông báo",MessageBoxButtons.OK);
                        }
                    }
                }
               
            }
            catch
            {
                MessageBox.Show("Xảy ra lỗi ", "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            btnView.Enabled = true;
        }
    }
}
