using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyBanHang.DAO;
using QuanLyBanHang.DTO;

namespace QuanLyBanHang
{
    public partial class UsC_Drink : UserControl
    {
        BindingSource foodList = new BindingSource();
        public UsC_Drink()
        {
            
            InitializeComponent();
            dtgvListFood.DataSource = foodList;
            LoadListFood();
            LoadCategoryCb(cb_FoodCategory);
            FoodBinding();
        }
        #region Method
        void LoadListFood()
        {
            foodList.DataSource = FoodDAO.Instance.GetListFood();
        }
        void FoodBinding()
        {
            txb_FoodName.DataBindings.Add(new Binding("Text", dtgvListFood.DataSource, "Name",true,DataSourceUpdateMode.Never));
            txb_FoodID.DataBindings.Add(new Binding("Text", dtgvListFood.DataSource, "ID",true,DataSourceUpdateMode.Never));
            txb_FoodPrice.DataBindings.Add(new Binding("Text", dtgvListFood.DataSource, "Price",true,DataSourceUpdateMode.Never));
        }
        void LoadCategoryCb(ComboBox cb)
        {
            cb.DataSource = CategoryDAO.Instance.GetListCategory();
            cb.DisplayMember = "name";
        }
        List<Food> SearchFoodByName(string name)
        {
            List<Food> listfood = FoodDAO.Instance.SearchFood(name);
            return listfood;
        }
        #endregion

        #region Event
        private void btn_ViewFood_Click(object sender, EventArgs e)
        {
            LoadListFood();
        }

        private void btn_AddFood_Click(object sender, EventArgs e)
        {
            string name = txb_FoodName.Text;
            int idcategory = (cb_FoodCategory.SelectedItem as Category).Id;
            float price = float.Parse(txb_FoodPrice.Text);
            if (FoodDAO.Instance.InsertFood(name, idcategory, price))
            {
                MessageBox.Show("Thêm món ăn thành công");
                LoadListFood();
                if (insertFood != null)
                    insertFood(this, new EventArgs());
            }
            else MessageBox.Show("Xảy ra lỗi khi thêm món ăn");
        }
        private void btn_UpdateFood_Click(object sender, EventArgs e)
        {
            string name = txb_FoodName.Text;
            int idcategory = (cb_FoodCategory.SelectedItem as Category).Id;
            float price = float.Parse(txb_FoodPrice.Text);
            int id = Convert.ToInt32(txb_FoodID.Text);
            if (FoodDAO.Instance.UpdateFood(name, idcategory, price, id))
            {
                MessageBox.Show("Sửa món ăn thành công");
                LoadListFood();
                if (updateFood != null)
                    updateFood(this, new EventArgs());
            }
            else MessageBox.Show("Xảy ra lỗi khi sửa món ăn");
        }
        private void btn_DeleteFood_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txb_FoodID.Text);
            if (FoodDAO.Instance.DeleteFood(id))
            {
                MessageBox.Show("Xóa món ăn thành công");
                LoadListFood();
                if (deleteFood != null)
                    deleteFood(this, new EventArgs());
            }
            else MessageBox.Show("Xảy ra lỗi khi xóa món ăn");
        }
        private void btn_Search_Click(object sender, EventArgs e)  // event tìm kiếm món ăn
        {
            foodList.DataSource = SearchFoodByName(txb_SearchFood.text);
        }
        private void txb_FoodID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (dtgvListFood.SelectedCells.Count > 0)
                {
                    int id = (int)dtgvListFood.SelectedCells[0].OwningRow.Cells["idCategory"].Value;

                    Category category = CategoryDAO.Instance.GetCategoryByID(id);

                    cb_FoodCategory.SelectedItem = category;

                    int index = -1;
                    int i = 0;
                    foreach (Category item in cb_FoodCategory.Items)
                    {
                        if (item.Id == category.Id)
                        {
                            index = i;
                            break;
                        }
                        i++;
                    }
                    cb_FoodCategory.SelectedIndex = index;
                }
            }
            catch { }
        }

        private event EventHandler insertFood;
        public event EventHandler InsertFood
        {
            add { insertFood += value; }
            remove { insertFood -= value; }
        }

        private event EventHandler deleteFood;
        public event EventHandler DeleteFood
        {
            add { deleteFood += value; }
            remove { deleteFood -= value; }
        }

        private event EventHandler updateFood;
        public event EventHandler UpdateFood
        {
            add { updateFood += value; }
            remove { updateFood -= value; }
        }

        #endregion

       
    }
}
