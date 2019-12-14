using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.DTO
{
    class Bill
    {
        private int id;
        private int status;
        private DateTime? dateCheckIn;
        private DateTime? dateCheckOut;
        public Bill(int id, DateTime? dateCheckIn, DateTime? dateCheckOut, int status)
        {
            this.Id = id;
            this.DateCheckIn = dateCheckIn;
            this.DateCheckOut = dateCheckOut;
            this.Status = status;
        }
        public Bill(DataRow row)
        {
            this.Id = (int)row["ID"];
            this.DateCheckIn = (DateTime?)row["DATECHECKIN"];
            var DateCheckOutTemp = row["DATECHECKOUT"];
            if(DateCheckOutTemp.ToString() != "")
                this.DateCheckOut = (DateTime?)DateCheckOutTemp;
            this.Status = (int)row["STATUS"];
        }
        public int Id { get => id; set => id = value; }
        public int Status { get => status; set => status = value; }
        public DateTime? DateCheckIn { get => dateCheckIn; set => dateCheckIn = value; }
        public DateTime? DateCheckOut { get => dateCheckOut; set => dateCheckOut = value; }
    }
}
