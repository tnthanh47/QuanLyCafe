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
using QuanLyBanHang.DTO;
using System.Text;
using System.IO;


namespace QuanLyBanHang
{
    public partial class UsC_Revuene : UserControl
    {
        
        public UsC_Revuene()
        {
            InitializeComponent();
        }

        void LoadListBillByDate(DateTime checkIn, DateTime checkOut)
        {
            float rev = 0;
            dtgvBill.DataSource = BillDAO.Instance.GetListBillByDate(checkIn, checkOut);
            for (int i = 0; i < dtgvBill.Rows.Count - 1; i++)
            {
                rev += float.Parse(dtgvBill.Rows[i].Cells["Tổng tiền"].Value.ToString());
        }
            lb_money.Text = rev.ToString() + ",000 VND";
        }
      

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //DateTime date = DateTime.Now();
            try
            {
                using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Text Documents|*.txt", ValidateNames = true })
                {
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        using (TextWriter writer = new StreamWriter(new FileStream(sfd.FileName, FileMode.Create), Encoding.UTF8))
                        {

                            writer.WriteLine("\n");
                            writer.WriteLine("\n");
                            writer.WriteLine("                                                       ***   THE COFFEE KING  ***");
                            writer.WriteLine("\n");
                            writer.WriteLine("     Mã Bill" + "\t" + "     Mã bàn" + "\t" + "       Tên bàn" + "\t" + "                Từ ngày" + "\t" + "                     Tới ngày" + "\t" + "             Giảm giá" + "\t" + "     Tổng tiền");

                            for (int i = 0; i < dtgvBill.Rows.Count - 1; i++)
                            {
                                for (int j = 0; j < dtgvBill.Columns.Count; j++)
                                {
                                    writer.Write("\t" + dtgvBill.Rows[i].Cells[j].Value.ToString() + "\t" + "|");
                                }
                                writer.WriteLine("");

                                writer.WriteLine("-------------------------------------------------------------------------------------------------------------------------------------------------");
                            }
                            writer.Close();
                        }
                    }
                    MessageBox.Show("Xuất đơn thành công");
                }
            }
            catch
            {
                MessageBox.Show("Xảy ra lỗi ", "Thông báo", MessageBoxButtons.OK);
            }
            
        }

        private void btnDeleteBill_Click(object sender, EventArgs e)
        {
            try
            {
                int idTable = (int)dtgvBill.SelectedCells[0].OwningRow.Cells["Mã bàn"].Value;
                int idBill = (int)dtgvBill.SelectedCells[0].OwningRow.Cells["Mã bill"].Value;
                BillInfoDAO.Instance.DeleteBillInfoByBillId(idBill);
                BillDAO.Instance.DeleteBillByTableID(idTable);
                LoadListBillByDate(dtpkFromDate.Value, dtpkToDate.Value);
                MessageBox.Show("Xóa hóa đơn thành công", "Thông báo", MessageBoxButtons.OK);
            }
            catch { MessageBox.Show("Lỗi khi xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnWiewBill_Click(object sender, EventArgs e)
        {
            LoadListBillByDate(dtpkFromDate.Value, dtpkToDate.Value);
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
           textBox1.Text = "1";
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            int page = Convert.ToInt32(textBox1.Text);

            if (page > 1)
                page--;

            textBox1.Text = page.ToString();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            int page = Convert.ToInt32(textBox1.Text);
            int sumRecord = BillDAO.Instance.GetNumBillListByDate(dtpkFromDate.Value, dtpkToDate.Value);

            if (page < sumRecord)
                page++;

            textBox1.Text = page.ToString();
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            int sumRecord = BillDAO.Instance.GetNumBillListByDate(dtpkFromDate.Value, dtpkToDate.Value);

            int lastPage = sumRecord / 10;

            if (sumRecord % 10 != 0)
                lastPage++;

           textBox1.Text = lastPage.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dtgvBill.DataSource = BillDAO.Instance.GetBillListByDateAndPage(dtpkFromDate.Value, dtpkToDate.Value, Convert.ToInt32(textBox1.Text));
        }

    }
}
