using QuanLyBanHang.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.DAO
{
    class FoodDAO
    {
        private static FoodDAO instance;

        internal static FoodDAO Instance 
        { 
            get { if (instance == null) instance = new FoodDAO(); return FoodDAO.instance; } 
            private set { FoodDAO.instance = value; } 
        }
        private FoodDAO() { }
        public List<Food> GetFoodByCategoryID(int id)
        {
            List<Food> listFood = new List<Food>();
            string query = "SELECT * FROM FOOD WHERE IDCATEGORY = " + id;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Food food = new Food(item);
                listFood.Add(food);
            }
            return listFood;
        }
        public List<Food> GetListFood()
        {
            List<Food> list = new List<Food>();

            string query = "select * from Food";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Food food = new Food(item);
                list.Add(food);
            }

            return list;
        }
        public List<Food> SearchFood(string name)
        {
            List<Food> list = new List<Food>();

            string query = "select * from Food where name like " + "'%" + name + "%'";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Food food = new Food(item);
                list.Add(food);
            }

            return list;
        }
        public bool InsertFood( string name, int idcategory, float price)
        {
            string query = "INSERT into Food(Name,idCategory,price) values (" + "'"+name+"'" + ", " + "'" + idcategory + "'" +","+ "'" + price + "'" + " )";
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateFood(string name, int idcategory, float price,int id)
        {
            string query = "Update Food  set name  = " + "'" + name + "'" + ", idcategory = " + "'" + idcategory + "'" + ", price = " + "'" + price + "'" + " where id = " + id;
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteFood(int id)
        {
            BillInfoDAO.Instance.DeleteBillInfoByFoodId(id);
            string query = "delete food where id =" + id;
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
    }
}
