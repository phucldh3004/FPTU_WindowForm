using System;
using System.Data;
using System.Windows.Forms;
using Project_Phone_Management;
using System.Data.SqlClient;
using ProjectLibrary.daos;
using ProjectLibrary.utils;

namespace ProjectPhoneManagement_Buu
{
    public partial class CustomerControllPanel : UserControl
    {
        SqlConnection cnn = new SqlConnection();
        CustomerDAO dao = new CustomerDAO();
        Validates vld = new Validates();

        public CustomerControllPanel()
        {
            InitializeComponent();
            LoadData();
            tblData.ReadOnly = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home_Form home = new Home_Form();
            home.ShowDialog();
        }


        private void LoadData()
        {
            cnn = DBAcess.GetConnection();
            cnn.Open();
            string sql = "Select FullName, DayofBirth, Address, Email, PhoneNumber, PhoneID, PhoneName, Price, InvoiceDetails.Quantity" +
                " FROM Customer, Phone, InvoiceDetails, Invoice WHERE InvoiceDetails.InvoiceID = Invoice.ID" +
                " and Invoice.CustomerPhone = Customer.PhoneNumber and InvoiceDetails.PhoneID = Phone.ID";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            SqlDataReader rd = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(rd);
            tblData.DataSource = dt;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
        }
        private void tblData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
           
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
        }

        private void tblData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
       
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                tblData.DataSource = dao.SearchCustomerByPhone(txtSearch.Text);
            }
            catch
            {
                MessageBox.Show("Not Found");
            }
        }
    }
}