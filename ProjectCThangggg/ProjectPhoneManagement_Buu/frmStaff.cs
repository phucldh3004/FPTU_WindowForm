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
    public partial class Staff : Form
    {
        public Staff()
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

        }
    }



    
    
}
