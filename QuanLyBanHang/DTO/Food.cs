using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.DTO
{
    class Food
    {
        private int id;
        private int idCategory;
        private string name;
        private float price;
        public Food(int id,string name,int idCategory, float price)
        {
            this.Id = id;
            this.Name = name;
            this.IdCategory = idCategory;
            this.Price = price;
        }
        public Food(DataRow row)
        {
            this.Id = (int)row["ID"];
            this.Name = row["NAME"].ToString();
            this.IdCategory = (int)row["IDCATEGORY"];
            this.Price = (float)Convert.ToDouble((row["PRICE"]).ToString());
        }
        public int Id { get => id; set => id = value; }
        public int IdCategory { get => idCategory; set => idCategory = value; }
        public string Name { get => name; set => name = value; }
        public float Price { get => price; set => price = value; }
    }
}
