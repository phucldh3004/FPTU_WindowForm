using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjectLibrary;
using ProjectLibrary.Staff;
using ProjectLibrary.utils;

namespace ProjectPhoneManagement_Buu
{
    public partial class ManageStaff : Form
    {

        StaffDAO staffDAO = null;
        StaffDTO staffDTO = null;
        SqlConnection cnn = null;
        int numrow;
        public ManageStaff()
        {
            InitializeComponent();
            CenterToScreen();
            tblData.ReadOnly = true;
            loadData();


        }
        public void loadData()
        {
            cnn = DBAcess.GetConnection();
            cnn.Open();
            String sql = "Select * From Account";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);


            DataTable dt = new DataTable();
            da.Fill(dt);
            if (cnn.State == ConnectionState.Closed)
            {
                cnn.Open();
            }
            if (dt != null)
            {
                tblData.DataSource = dt;
            }
            tblData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        public void clearTextBox()
        {
            txtAddress.Text = "";
            txtFullname.Text = "";
            txtPass.Text = "";
            txtPhone.Text = "";


        }
        public void Search()
        {
            string searchId = txtSearch.Text;
            clearTextBox();
            staffDAO = new StaffDAO();
            staffDTO = new StaffDTO();
            staffDTO = staffDAO.SearchByStaffID(searchId);
            if (staffDTO.StaffID == null)
            {
                MessageBox.Show("StaffID not exist!");
            }
            else
            {



                txtAddress.Text = staffDTO.Address;
                txtFullname.Text = staffDTO.StaffName;
                txtPass.Text = staffDTO.Password;
                txtPhone.Text = staffDTO.PhoneNumber;


                DataTable data = new DataTable();

                data.Columns.Add("StaffID", typeof(string));
                data.Columns.Add("Password", typeof(string));
                data.Columns.Add("Fullname", typeof(string));
                data.Columns.Add("PhoneNumber", typeof(string));
                data.Columns.Add("Address", typeof(string));


                DataRow dataR = data.NewRow();
                dataR["StaffID"] = staffDTO.StaffID;
                dataR["Password"] = staffDTO.Password;
                dataR["Fullname"] = staffDTO.StaffName;
                dataR["PhoneNumber"] = staffDTO.PhoneNumber;
                dataR["Address"] = staffDTO.Address;
                data.Rows.Add(dataR);

                tblData.DataSource = data;

            }
        }



        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddStaff stff = new AddStaff();
            stff.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin ad = new Admin();
            ad.ShowDialog();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchId = txtSearch.Text;
            if (searchId.Equals("*"))
            {
                clearTextBox();
                loadData();
            }
            else
            {
                clearTextBox();
                staffDAO = new StaffDAO();
                staffDTO = new StaffDTO();
                staffDTO = staffDAO.SearchByStaffID(searchId);
                if (staffDTO.StaffID == null)
                {
                    MessageBox.Show("StaffID not exist!");
                }
                else
                {
                    Search();

                }


            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string id = txtSearch.Text;
            string password = txtPass.Text;
            string fullname = txtFullname.Text;
            string phone = txtPhone.Text;
            string address = txtAddress.Text;

            ProjectLibrary.utils.Validates validate = new Validates();
            staffDAO = new StaffDAO();

            bool checkID = validate.CheckTextEmpty(id);
            bool checkPass = validate.CheckTextEmpty(password);
            bool checkName = validate.CheckTextEmpty(fullname);
            bool checkPhone = validate.CheckTextEmpty(phone);
            bool checkPhoneNumner = validate.IsNumber(phone);
            bool checkAddress = validate.CheckTextEmpty(address);
            bool checkDuplicate = staffDAO.CheckDuplicateID(id);

            if (checkID == false)
            {
                MessageBox.Show("Input id!");
            }
            else if (checkPass == false)
            {
                MessageBox.Show("Input password!");
            }
            else if (checkName == false)
            {
                MessageBox.Show("Input name!");
            }
            else if (checkAddress == false)
            {
                MessageBox.Show("Input address!");
            }
            else if (checkPhone == false)
            {
                MessageBox.Show("Input number phone!");
            }
            else if (checkPhoneNumner == false)
            {
                MessageBox.Show("Number phone is string number!");
            }
            else if (checkDuplicate == false)
            {
                MessageBox.Show("Invalid ID to update!");
            }

            else
            {
                bool update = false;
                try
                {
                     update = staffDAO.UpdateStaff(id, password, fullname, phone, address);

                }
                catch(NullReferenceException ex)
                {
                    Console.WriteLine(ex.Message);
                }


                if (update == true)
                {
                    Search();
                    loadData();
                    MessageBox.Show("Update Successfully!");

                }
                else
                {
                    MessageBox.Show("Invalid id!");
                }
            }






        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Delete row?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {


                string id = txtSearch.Text;
                StaffDAO dao = new StaffDAO();
                bool checkDuplicate = dao.CheckDuplicateID(id);
                if (checkDuplicate == true)
                {

                    bool remove;

                    remove = staffDAO.DeleteStaff(id);
                    if (remove == true)
                    {
                        txtSearch.Text = "";
                        clearTextBox();
                        tblData.DataSource = null;
                        loadData();

                        MessageBox.Show("Delete successfully!");
                    }
                    else
                    {
                        MessageBox.Show("Invalid id!");
                    }
                }
                else
                {
                    MessageBox.Show("Wrong id!");
                }
            }
        }

        private void tblData_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            numrow = e.RowIndex;
            txtSearch.Text = tblData.Rows[numrow].Cells[0].Value.ToString();
            Search();


        }

    }
}
