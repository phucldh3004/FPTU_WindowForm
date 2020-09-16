using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using ProjectLibrary;
using ProjectLibrary.utils;
using System.Data.SqlClient;
using ProjectLibrary.dtos;
using System.Text.RegularExpressions;

namespace ProjectPhoneManagement_Buu
{
    public partial class ManagePhone : Form
    {
        SqlConnection cnn = new SqlConnection();
        PhoneDAO dao = new PhoneDAO();
        PhoneDTO dto = new PhoneDTO();

        public ManagePhone()
        {
            InitializeComponent();
            CenterToScreen();
            LoadData();
            
            tblData.ReadOnly = true;
            txtID.Enabled = false;
            txtAccquired.Enabled = false;
            txtName.Enabled = false;
            txtPrice.Enabled = false;
            txtQuantity.Enabled = false;
            cbCategory.Enabled = false;
            cbManu.Enabled = false;
            cbStatus.Enabled = false;
            cbType.Enabled = false;
        }

        private void LoadData()
        {
            cnn = DBAcess.GetConnection();
            cnn.Open();
            string sql = "Select * From Phone";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            SqlDataReader rd = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(rd);
            tblData.DataSource = dt;
            tblData.Sort(tblData.Columns[0], ListSortDirection.Ascending);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.Hide();
            Phone phone = new Phone();
            phone.ShowDialog();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin admin = new Admin();
            admin.ShowDialog();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Validates vld = new Validates();
            string Name = txtName.Text;
            bool checkName = vld.CheckTextEmpty(Name);

            if (checkName == false)
            {
                MessageBox.Show("Input Name");
                txtName.Text = string.Empty;
            }
            else if (!vld.CheckFormat(txtPrice.Text, new Regex(@"^\d{7,8}$")))
            {
                MessageBox.Show("Input Price number");
                txtPrice.Text = string.Empty;
            }
            else if (!vld.CheckFormat(txtQuantity.Text, new Regex(@"^\d{1,3}$")))
            {
                MessageBox.Show("Input Quantity number");
                txtQuantity.Text = string.Empty;
            }
            /*
            else if (!vld.CheckFormat(txtAccquired.Text, new Regex(@"^(?:(?:31(\/|-|\.)(?:0?[13578]|1[02]))\1|(?:(?:29|30)(\/|-|\.)(?:0?[13-9]|1[0-2])\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})$|^(?:29(\/|-|\.)0?2\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\d|2[0-8])(\/|-|\.)(?:(?:0?[1-9])|(?:1[0-2]))\4(?:(?:1[6-9]|[2-9]\d)?\d{4})$")))
            {
                MessageBox.Show("Invalid Date");
                txtAccquired.Text = string.Empty;
            }
            */
            else
            {

                int id = Int32.Parse(txtID.Text);
                string name = txtName.Text;
                float price = float.Parse(txtPrice.Text);
                int manu = Int32.Parse(cbManu.Text);
               // DateTime dateT = DateTime.Parse(txtAccquired.Text.ToString());
               // string date = dateT.ToString("MM/dd/yyyy");
                string date = txtAccquired.Text;
                
                int quantity = Int32.Parse(txtQuantity.Text);
                int type = Int32.Parse(cbType.Text);
                int category = Int32.Parse(cbCategory.Text);
                int status = Int32.Parse(cbStatus.Text);

                bool update = dao.UpdatePhone(id, name, price, manu, date, quantity, type, category, status);
                if (update == true)
                {
                    MessageBox.Show("Update information Phone Successfull");
                    ResetValue();
                }
            }
            LoadData();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            
        }


        private void btnRemove_Click(object sender, EventArgs e)
        {
            int id = Int32.Parse(txtID.Text);
            bool remove = dao.RemovePhone(id);
            if(remove == true)
            {
                txtID.Text = string.Empty;
                ResetValue();
                tblData.DataSource = null;
                MessageBox.Show("Remove successfull");
            }
            LoadData();
            ResetValue();
        }

        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            try
            {
                tblData.DataSource = dao.SearchPhoneByName(txtSearch.Text);
            }
            catch
            {
                MessageBox.Show("Not Found");
            }
        }

        private void tblData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            txtID.Text = tblData.Rows[i].Cells[0].Value.ToString();
            txtName.Text = tblData.Rows[i].Cells[1].Value.ToString();
            txtPrice.Text = tblData.Rows[i].Cells[2].Value.ToString();
            cbManu.Text = tblData.Rows[i].Cells[3].Value.ToString();
            txtAccquired.Text = tblData.Rows[i].Cells[4].Value.ToString();
            txtQuantity.Text = tblData.Rows[i].Cells[5].Value.ToString();
            cbType.Text = tblData.Rows[i].Cells[6].Value.ToString();
            cbCategory.Text = tblData.Rows[i].Cells[7].Value.ToString();
            cbStatus.Text = tblData.Rows[i].Cells[8].Value.ToString();

            txtAccquired.Enabled = true;
            txtName.Enabled = true;
            txtPrice.Enabled = true;
            txtQuantity.Enabled = true;
            cbCategory.Enabled = true;
            cbManu.Enabled = true;
            cbStatus.Enabled = true;
            cbType.Enabled = true;
        }

        private void ResetValue()
        {
            txtSearch.Text = string.Empty;
            txtName.Text = string.Empty;
            txtAccquired.Text = string.Empty;
            txtPrice.Text = string.Empty;
            txtQuantity.Text = string.Empty;
            cbType.SelectedIndex = 0;
            cbCategory.SelectedIndex = 0;
            cbManu.SelectedIndex = 0;
            cbStatus.SelectedIndex = 0;
        }

        private void maskedTextBox1_KeyUp(object sender, KeyEventArgs e)
        {
        }
    }
}
