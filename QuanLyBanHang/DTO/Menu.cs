using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.DTO
{
    public class Menu
    {
        private string foodName;
        private float price;
        private int count;
        private float totalPrice;
        public Menu(string foodName,int count,float price,float totalPrice)
        {
            this.FoodName = foodName;
            this.Count = count;
            this.Price = price;
            this.TotalPrice = totalPrice; 
        }
        public Menu(DataRow row)
        {
            this.FoodName = row["NAME"].ToString();
            this.Count = (int)row["COUNT"];
            this.Price = (float)Convert.ToInt32((row["PRICE"]));
            this.TotalPrice = (float)Convert.ToInt32((row["TOTALPRICE"]));
        }
        public string FoodName { get => foodName; set => foodName = value; }
        public float Price { get => price; set => price = value; }
        public int Count { get => count; set => count = value; }
        public float TotalPrice { get => totalPrice; set => totalPrice = value; }
    }
}
