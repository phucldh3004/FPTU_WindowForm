using ProjectLibrary.daos;
using ProjectLibrary.utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectPhoneManagement_Buu
{
    public partial class AddCustomer : Form
    {
        public string nameCusomter = null;
        CustomerDAO dao = new CustomerDAO();
        Validates validate = null;
        public AddCustomer()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            validate = new Validates();

            string FullName = txtFullName.Text;
            nameCusomter = FullName;
            string Birth = txtBirth.Text;
            string address = txtAddress.Text;
            string Phone = txtPhone.Text;
            string Email = txtEmail.Text;

            bool checkEmptyFullName = validate.CheckTextEmpty(FullName);
            bool checkEmptyPhone = validate.CheckTextEmpty(Phone);
            bool checkPhone = validate.checkPhone(Phone);
            bool checkDate = false;
            try
            {
                DateTime.ParseExact(Birth, "MM/dd/yyyy", null);
                checkDate = true;
            }
            catch
            {
               
                txtBirth.Text = "";
                checkDate = false;
            }

            

            if (checkEmptyFullName == false)
            {
                MessageBox.Show("Input Fullname");
            }
            else if (checkEmptyPhone == false)
            {
                MessageBox.Show("Input Phone");
            }
            else if (checkPhone == false)
            {
                MessageBox.Show("Input Phone is string number 10 character!");
            }
            else if (checkDate == false)
            {
                MessageBox.Show("Invalid Date!");
            }
            else
            {
                bool add = dao.AddCustomer(FullName, Birth, address, Phone, Email);
                if (add == true)
                {
                    MessageBox.Show("Add new Customer Successfull");
                    this.Hide();
                }
            }
        }
    }
}
