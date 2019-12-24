using QuanLyBanHang.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.DAO
{
    public class TableDAO
    {
        private static TableDAO instance;

        public static TableDAO Instance
        {
            get { if (instance == null) instance = new TableDAO(); return TableDAO.instance; }
            private set { TableDAO.instance = value; }
        }

        public static int TableWidth = 90;
        public static int TableHeight = 90;

        private TableDAO() { }

        public List<Table> LoadTableList()
        {
            List<Table> tableList = new List<Table>();

            DataTable data = DataProvider.Instance.ExecuteQuery("USP_GetTableList");

                foreach (DataRow item in data.Rows)
                {
                    Table table = new Table(item);
                    tableList.Add(table);
                }
            return tableList;
        }
        public List<Table> LoadTableListforFloor1() // thêm bàn theo từng tầng
        {
            List<Table> tableList = new List<Table>();

            DataTable data = DataProvider.Instance.ExecuteQuery("USP_GetTableList");

            foreach (DataRow item in data.Rows)
            {
                Table table = new Table(item);
                if (table.ID <= 10)
                {
                    tableList.Add(table);
                }
            }
            return tableList;
        }
        public List<Table> LoadTableListforFloor2() // thêm bàn theo từng tầng
        {
            List<Table> tableList = new List<Table>();

            DataTable data = DataProvider.Instance.ExecuteQuery("USP_GetTableList");

            foreach (DataRow item in data.Rows)
            {
                Table table = new Table(item);
                if (table.ID > 10)
                {
                    tableList.Add(table);
                }
            }
            return tableList;
        }

        public void ChangeTableStatus(int id)
        {
            string query = "UPDATE TABLEFOOD SET STATUS = N'Có người' WHERE ID = " + id;
            DataProvider.Instance.ExecuteNonQuery(query);
        }
        public void SwitchTable(int id1, int id2)
        {
            DataProvider.Instance.ExecuteQuery("USP_SwitchTable @IDTABLE1 , @IDTABLE2 ", new object[] { id1, id2 });
        }
    }
}
