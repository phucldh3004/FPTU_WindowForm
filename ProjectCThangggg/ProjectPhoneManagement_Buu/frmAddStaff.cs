using ProjectLibrary;
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
    public partial class AddStaff : Form
    {
       

        
        public AddStaff()
        {
            InitializeComponent();
            CenterToScreen();

            

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            ManageStaff ms = new ManageStaff();
            ms.Show();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtID.Text = "";
            txtPassword.Text = "";
            txtFullname.Text = "";
            txtPhone.Text = "";
            txtAddress.Text = "";

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Validates validate = new Validates(); 
            String id = txtID.Text;
            String pass = txtPassword.Text;
            String name = txtFullname.Text;
            String phone = txtPhone.Text;
            String address = txtAddress.Text;
            bool checkIDEmpty = validate.CheckTextEmpty(id);
            bool checkID = validate.checkText1(id);
            bool checkPassEmpty = validate.CheckTextEmpty(pass);
            bool checkPass = validate.checkText1(pass);
            bool checkPhoneCharacter = validate.checkPhone(phone);
            bool checkName = validate.CheckTextEmpty(name);
            bool checkPhone = validate.CheckTextEmpty(phone);
            bool checkPhoneNumner = validate.IsNumber(phone);
            bool checkAddress = validate.CheckTextEmpty(address);

            StaffDAO dao = new StaffDAO();
            bool checkDuplicateID = dao.CheckDuplicateID(id);

            if (checkIDEmpty == false)
            {
                MessageBox.Show("Input id!");
            }
            else if (checkID == false)
            {
                MessageBox.Show("Input id 3-10 character!");
            }
            else if (checkDuplicateID == true)
            {
                MessageBox.Show("Duplicate ID!");
            }

            else if (checkPassEmpty == false)
            {
                MessageBox.Show("Input password!");
            }
            else if (checkPass == false)
            {
                MessageBox.Show("Input password 3-10 character!");
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
            else if (checkPhoneCharacter == false)
            {
                MessageBox.Show("Input phone is 10 character number!");
            }

            else
            {
                StaffDAO staffDAO = new StaffDAO();

                bool addStaff = staffDAO.AddStaff(id, pass, name, phone, address);
                if (addStaff == true)
                {

                    MessageBox.Show("Insert Successfully!");
                }
                
            }

            
        }

        private void txtID_Leave(object sender, EventArgs e)
        {
            if(txtID.Text == "")
            {
                txtID.Text = "Enter ID 3-15 character!";
                txtID.ForeColor = Color.Gray;
            }
        }

        private void txtPhone_Leave(object sender, EventArgs e)
        {
            if (txtPhone.Text == "")
            {
                txtPhone.Text = "Enter Phone 10 character is number!";
                txtPhone.ForeColor = Color.Gray;
            }
        }

        private void txtAddress_Leave(object sender, EventArgs e)
        {
            if (txtAddress.Text == "")
            {
                txtAddress.Text = "Enter Phone address!";
                txtAddress.ForeColor = Color.Gray;
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (txtPassword.Text == "")
            {
                txtPassword.Text = "Enter password 3-10 character!";
                txtPassword.ForeColor = Color.Gray;
            }
          
        }

        private void txtFullname_Leave(object sender, EventArgs e)
        {
            if (txtFullname.Text == "")
            {
                txtFullname.Text = "Enter Fullname!";
                txtFullname.ForeColor = Color.Gray;
            }
        }

        private void txtID_Enter(object sender, EventArgs e)
        {
            if(txtID.Text == "Enter ID 3-15 character!")
            {
                txtID.Text = "";
                txtID.ForeColor = Color.Black;
            }
        }

        private void txtAddress_Enter(object sender, EventArgs e)
        {
            if(txtAddress.Text == "Enter Phone address!")
            {
                txtAddress.Text = "";
                txtAddress.ForeColor = Color.Black;
            }
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text == "Enter password 3-10 character!")
            {
                txtPassword.Text = "";
                txtPassword.ForeColor = Color.Black;
            }
        }

        private void txtPhone_Enter(object sender, EventArgs e)
        {
            if (txtPhone.Text == "Enter Phone 10 character is number!")
            {
                txtPhone.Text = "";
                txtPhone.ForeColor = Color.Black;
            }
        }

        private void txtFullname_Enter(object sender, EventArgs e)
        {
            if (txtFullname.Text == "Enter Fullname!")
            {
                txtFullname.Text = "";
                txtFullname.ForeColor = Color.Black;
            }
        }
    }



    
    
}
