using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHang
{
    
    public partial class Admin : Form
    {
        UsC_Revuene rev = new UsC_Revuene();
        UsC_Drink drink = new UsC_Drink();
        UsC_Food food = new UsC_Food();
        UsC_Staff staff = new UsC_Staff();
        public Admin()
        {
            InitializeComponent();

            this.Load += Admin_Load;
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            pnl_usercontrol.Controls.Add(rev);
            pnl_usercontrol.Controls.Add(drink);
            pnl_usercontrol.Controls.Add(food);
            pnl_usercontrol.Controls.Add(staff);
        }

        private void btn_food_Click(object sender, EventArgs e)
        {
            food.BringToFront();
        }

        private void btn_rev_Click(object sender, EventArgs e)
        {
            rev.BringToFront();
        }

        private void btn_drink_Click(object sender, EventArgs e)
        {
            drink.BringToFront();
        }

        private void btn_staff_Click(object sender, EventArgs e)
        {
            staff.BringToFront();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
