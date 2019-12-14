using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.DTO
{
    public class BillInfo
    {
        private int id;
        private int idBill;
        private int idFood;
        private int count;
        public BillInfo(int id, int idBill,int idFood, int count)
        {
            this.Id = id;
            this.IdBill = idBill;
            this.IdFood = idFood;
            this.Count = count;
        }
        public BillInfo(DataRow row)
        {
            this.Id = (int)row["ID"];
            this.IdBill = (int)row["IDBILL"];
            this.IdFood = (int)row["IDFOOD"];
            this.Count = (int)row["COUNT"];
        }
        public int Id { get => id; set => id = value; }
        public int IdBill { get => idBill; set => idBill = value; }
        public int IdFood { get => idFood; set => idFood = value; }
        public int Count { get => count; set => count = value; }
    }
}
