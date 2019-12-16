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
    }
}
