using ProjectLibrary;
using ProjectLibrary.utils;
using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.Text.RegularExpressions;

namespace ProjectPhoneManagement_Buu
{
    public partial class Phone : Form
    {
        
        PhoneDAO dao = new PhoneDAO();
        SqlConnection cnn = new SqlConnection();

        public Phone()
        {
            InitializeComponent();
            CenterToScreen();
            cbManu.SelectedIndex = 0;
            cbStatus.SelectedIndex = 0;
            cbType.SelectedIndex = 0;
            cbCategory.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Validates vld = new Validates();
            
            string Name = txtName.Text;
            bool checkName = vld.CheckTextEmpty(Name);
            
            if (!vld.CheckFormat(txtID.Text, new Regex(@"^\d{1,4}$")))
            {
                MessageBox.Show("Input ID");
                txtID.Text = string.Empty;
            }
            else if (CheckDuplicateID(Convert.ToInt32(txtID.Text)))
            {
                MessageBox.Show("Duplicate ID");
                txtID.Text = string.Empty;
            }
            else if (checkName == false)
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
            else if (!vld.CheckFormat(txtAcquiredDate.Text, new Regex(@"^(?:(?:31(\/|-|\.)(?:0?[13578]|1[02]))\1|(?:(?:29|30)(\/|-|\.)(?:0?[13-9]|1[0-2])\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})$|^(?:29(\/|-|\.)0?2\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\d|2[0-8])(\/|-|\.)(?:(?:0?[1-9])|(?:1[0-2]))\4(?:(?:1[6-9]|[2-9]\d)?\d{4})$")))
            {
                MessageBox.Show("Invalid Date");
                txtAcquiredDate.Text = string.Empty;
            }
            */
            /*
            else if (txtAcquiredDate.MaskFull)
            {
                try
                {
                    DateTime.ParseExact(txtAcquiredDate.Text, "dd/MM/yyyy", null);
                }
                catch
                {
                    MessageBox.Show("Invalid date");
                    txtAcquiredDate.Text = "";
                }
            }
            */
            else
            {
                int id = Int32.Parse(txtID.Text);
                string name = txtName.Text;
                float price = float.Parse(txtPrice.Text);
                int manu = Int32.Parse(cbManu.Text);
                string date = txtAcquiredDate.Text;
                int quantity = Int32.Parse(txtQuantity.Text);
                int type = Int32.Parse(cbType.Text);
                int category = Int32.Parse(cbCategory.Text);
                int status = Int32.Parse(cbStatus.Text);
                bool add = dao.AddPhone(id, name, price, manu, date, quantity, type, category, status);
                if (add == true)
                {
                    MessageBox.Show("Add new Phone Successfull");
                }
                ResetValue();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            ManagePhone mnphone = new ManagePhone();
            mnphone.ShowDialog();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ResetValue();
        }

        private bool CheckDuplicateID(int id)
        {
            bool result = false;
            string sql = "Select ID From Phone Where ID = @ID";
            cnn = DBAcess.GetConnection();
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cnn.Open();
            cmd.Parameters.AddWithValue("@ID", id);
            try
            {
                var da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0) result = true;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                cnn.Close();
            }
            return result;
        }

        private void ResetValue()
        {
            txtID.Text = string.Empty;
            txtName.Text = string.Empty;
            txtPrice.Text = string.Empty;
            txtQuantity.Text = string.Empty;
            txtAcquiredDate.Text = string.Empty;
            cbManu.SelectedIndex = 0;
            cbStatus.SelectedIndex = 0;
            cbType.SelectedIndex = 0;
            cbCategory.SelectedIndex = 0;
        }
    }
}
