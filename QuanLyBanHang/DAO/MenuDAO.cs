using QuanLyBanHang.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.DAO
{
    public class MenuDAO
    {
        private static MenuDAO instance;

        public static MenuDAO Instance
        {
            get { if (instance == null) instance = new MenuDAO(); return MenuDAO.instance; }
            private set { MenuDAO.instance = value; }
        }
        private MenuDAO() { }
        public List<Menu> GetListMenu(int id)
        {
            List<Menu> listMenu = new List<Menu>();
            string query = "SELECT FOOD.NAME,FOOD.PRICE,BILLINFO.COUNT, FOOD.PRICE*BILLINFO.COUNT AS TOTALPRICE FROM FOOD, BILL, BILLINFO WHERE FOOD.ID = BILLINFO.IDFOOD AND BILL.ID = BILLINFO.IDBILL AND IDTABLE =" + id;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Menu menu = new Menu(item);
                listMenu.Add(menu);
            }
            return listMenu;
        }
    }
}
