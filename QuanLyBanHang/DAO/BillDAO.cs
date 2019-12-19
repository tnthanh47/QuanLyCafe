using QuanLyBanHang.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.DAO
{
    public class BillDAO
    {
        private static BillDAO instance;

        public static BillDAO Instance 
        {
            get { if (instance == null) instance = new BillDAO(); return BillDAO.instance; } 
            private set { BillDAO.instance = value; }  
        }
        private BillDAO() { }
        public int GetUncheckedBillByTableID(int id)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM BILL WHERE IDTABLE =" + id + "AND STATUS = 0");
            if (data.Rows.Count > 0)
            {
                Bill bill = new Bill(data.Rows[0]);
                return bill.Id;    // trả về id của bill nếu thành công
            }
            return -1;   // trả về -1 nếu không thành công
        }
        public void InsertBill(int id)
        {
            DataProvider.Instance.ExecuteNonQuery("EXEC USP_INSERTBILL @IDTABLE", new object[] { id });
        }
        public int GetMaxIdBill()
        {
            try
            {
                return (int)DataProvider.Instance.ExecuteScalar("SELECT MAX(ID) FROM BILL");
            }
            catch
            {
                return 1;
            }
        }

        public void CheckOut(int id)
        {
            string query = "UPDATE BILL SET STATUS = 1 WHERE ID =" + id;
            DataProvider.Instance.ExecuteNonQuery(query);
        }
        public void DeleteBillByTableID(int id)
        {
            string query = "DELETE FROM BILL WHERE IDTABLE = " + id;
            DataProvider.Instance.ExecuteNonQuery(query);
        }
    }
}
