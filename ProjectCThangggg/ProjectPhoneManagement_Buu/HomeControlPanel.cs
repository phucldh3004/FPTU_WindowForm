using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjectLibrary;
using ProjectLibrary.dtos;
using ProjectLibrary.utils;
using ProjectLibrary.daos;

namespace ProjectPhoneManagement_Buu
{
    public partial class HomeControlPanel : UserControl
    {
        int numrow;
        string choose;
        public int quantityD;
        int quantity;
        
        public HomeControlPanel()
        {
            InitializeComponent();
            dataGridPhone.ReadOnly = true;
            CartDAO cartDAO = new CartDAO();
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            quantityD = Int32.Parse(dataGridPhone.Rows[numrow].Cells[5].Value.ToString());
            do
            {
                frmAddCategory frmAdd = new frmAddCategory();
                frmAdd.ShowDialog();

                quantity = frmAdd.quantity;
                //frmAdd.Hide();
                if (quantity > quantityD)
                {
                    MessageBox.Show("Input valid quantity!");
                }
            } while (quantityD < quantity);

            if ((quantityD > quantity) && (quantity != 0))
            {
                if (MessageBox.Show("Are you sure?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {

                }

                InvoiceControllPanel frmInvoice = new InvoiceControllPanel();

                choose = dataGridPhone.Rows[numrow].Cells[0].Value.ToString();

                string phoneName = dataGridPhone.Rows[numrow].Cells[1].Value.ToString();
                float price = float.Parse(dataGridPhone.Rows[numrow].Cells[2].Value.ToString());

                CartDAO cart = new CartDAO();
                cart.addToCart(Int32.Parse(choose), phoneName, price, quantity);

            }







        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            string categories = cbCate.Text.Trim();
            string type = cbType.Text.Trim();
            string status = cbStatus.Text.Trim();
            string sPriceFrom = txtPriceFrom.Text.Trim();
            string sPriceTo = txtPriceTo.Text.Trim();

            double PriceFrom = -1;
            double PriceTo = -1;

            if (!string.IsNullOrEmpty(sPriceFrom))
            {
                try
                {
                    PriceFrom = double.Parse(sPriceFrom);
                }
                catch (Exception)
                {
                    MessageBox.Show("Please input valid Price From!");
                    return;
                }

                if (PriceFrom < 0)
                {
                    MessageBox.Show("Price must be greater or equal 0!");
                    return;
                }
            }

            if (!string.IsNullOrEmpty(sPriceTo))
            {
                try
                {
                    PriceTo = double.Parse(sPriceTo);
                }
                catch (Exception)
                {
                    MessageBox.Show("Please input valid Price To!");
                    return;
                }

                if (PriceTo < 0)
                {
                    MessageBox.Show("Price must be greater or equal 0!");
                    return;
                }
            }

            PhoneDAO phoneDAO = new PhoneDAO();

            DataTable data = new DataTable();
            data = phoneDAO.SearchPhone(categories, type, status, PriceFrom, PriceTo);


            DataTable dataTable = new DataTable();
            dataTable = LoadDataForTable(data);
            dataGridPhone.DataSource = dataTable;



        }



        private void HomeControlPanel_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        public void LoadData()
        {

            LoadForCbType();
            LoadForCbCategories();
            LoadForCBStatus();
            LoadForTableGrid();

        }
        public void LoadForCBStatus()
        {
            PhoneStatusDAO phoneStatusDAO = new PhoneStatusDAO();
            List<PhoneStatusDTO> listStatus = phoneStatusDAO.GetListStatus();
            cbStatus.Items.Clear();
            cbStatus.Items.Add("All");
            foreach (PhoneStatusDTO phoneStatusDTO in listStatus)
            {
                cbStatus.Items.Add(phoneStatusDTO.Description);
            }
            cbStatus.SelectedIndex = 0;
        }

        public void LoadForCbType()
        {
            PhoneTypeDAO phoneTypeDAO = new PhoneTypeDAO();
            List<PhoneTypeDTO> listType = phoneTypeDAO.GetListType();

            cbType.Items.Clear();
            cbType.Items.Add("All");
            foreach (PhoneTypeDTO phoneTypeDTO in listType)
            {
                cbType.Items.Add(phoneTypeDTO.Description);
            }
            cbType.SelectedIndex = 0;

        }
        public void LoadForCbCategories()
        {
            PhoneCategoriesDAO phoneCategoriesDAO = new PhoneCategoriesDAO();
            List<PhoneCategoriesDTO> listCate = phoneCategoriesDAO.GetListCategories();

            cbCate.Items.Clear();
            cbCate.Items.Add("All");
            foreach (PhoneCategoriesDTO phoneCategoriesDTO in listCate)
            {
                cbCate.Items.Add(phoneCategoriesDTO.Description);
            }
            cbCate.SelectedIndex = 0;
        }
        public void LoadForTableGrid()
        {
            PhoneDAO phone = new PhoneDAO();
            DataTable dt = phone.getListPhones();

            DataTable dataTable = LoadDataForTable(dt);


            dataGridPhone.ClearSelection();
            dataGridPhone.DataSource = dataTable;
            dataGridPhone.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;



        }




        public DataTable LoadDataForTable(DataTable dt)
        {
            PhoneTypeDAO phoneTypeDAO = new PhoneTypeDAO();
            PhoneCategoriesDAO phoneCategoriesDAO = new PhoneCategoriesDAO();
            PhoneStatusDAO phoneStatusDAO = new PhoneStatusDAO();


            DataTable dataTable = new DataTable();
            dataTable.Columns.Add(new DataColumn("ID", Type.GetType("System.Int32")));
            dataTable.Columns.Add(new DataColumn("PhoneName", Type.GetType("System.String")));
            dataTable.Columns.Add(new DataColumn("Price", Type.GetType("System.Int32")));
            dataTable.Columns.Add(new DataColumn("ManufactureYear", Type.GetType("System.Int32")));
            dataTable.Columns.Add(new DataColumn("AcquiredDate", Type.GetType("System.DateTime")));
            dataTable.Columns.Add(new DataColumn("Quantity", Type.GetType("System.Int32")));
            dataTable.Columns.Add(new DataColumn("TypeID", Type.GetType("System.String")));
            dataTable.Columns.Add(new DataColumn("CategoryID", Type.GetType("System.String")));
            dataTable.Columns.Add(new DataColumn("StatusID", Type.GetType("System.String")));


            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow row = dataTable.NewRow();
                row[0] = dt.Rows[i].ItemArray[0].ToString();

                row[1] = dt.Rows[i].ItemArray[1].ToString();

                row[2] = dt.Rows[i].ItemArray[2].ToString();

                row[3] = dt.Rows[i].ItemArray[3].ToString();

                row[4] = dt.Rows[i].ItemArray[4].ToString();

                row[5] = dt.Rows[i].ItemArray[5].ToString();

                //row[6] = changeType(dt.Rows[i].ItemArray[6].ToString());

                int rowType = (int)dt.Rows[i].ItemArray[6];
                row[6] = phoneTypeDAO.GetTypeDescriptionByID(rowType);
                int rowCate = (int)dt.Rows[i].ItemArray[7];
                row[7] = phoneCategoriesDAO.GetCateDescriptionByID(rowCate);
                int rowStatus = (int)dt.Rows[i].ItemArray[8];
                row[8] = phoneStatusDAO.GetStatusDescriptionByID(rowStatus);

                dataTable.Rows.Add(row);
            }


            return dataTable;
        }

        private void dataGridPhone_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            numrow = e.RowIndex;
            choose = dataGridPhone.Rows[numrow].Cells[0].Value.ToString();
        }
    }
}
