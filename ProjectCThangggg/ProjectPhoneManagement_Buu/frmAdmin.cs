using ProjectLibrary.daos;
using ProjectLibrary.dtos;
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
    public partial class Admin : Form
    {
        Login_Form login = new Login_Form();

        string idUsername;
       
        public Admin()
        {
            InitializeComponent();
            CenterToScreen();
            idUsername = login.idUser;

            //Login_Form login = new Login_Form();
            // idUsername = login.idUser;
            LoginDAO dao = new LoginDAO();
           
           
          

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void btnMnStaff_Click(object sender, EventArgs e)
        {
            this.Hide();
            ManageStaff mstf = new ManageStaff();
            mstf.ShowDialog();
        }

        private void btnMnPhone_Click(object sender, EventArgs e)
        {
            this.Hide();
            ManagePhone mphone = new ManagePhone();
            mphone.ShowDialog();
        }
        private void btnExit_Login_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }
        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login_Form login = new Login_Form();
            login.ShowDialog();

        }

        private void btnViewReport_Click(object sender, EventArgs e)
        {

        }
    }
}
