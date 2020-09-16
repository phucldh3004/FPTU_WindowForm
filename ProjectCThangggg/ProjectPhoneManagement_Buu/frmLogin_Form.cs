using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Project_Phone_Management;
using ProjectLibrary;
using ProjectLibrary.daos;

namespace ProjectPhoneManagement_Buu
{


    public partial class Login_Form : Form

    {
        public string idUser = null;

        bool valid = false;
        private void txtId_Validating(object sender, CancelEventArgs e)
        {
            if (txtUsername.Text.Length < 1)
            {
                this.errorProvider1.SetError(txtUsername, "Please Enter User ID.");
                valid = false;
            }
            else
            {
                this.errorProvider1.SetError(txtUsername, "");
                valid = true;
            }
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (txtPassword.Text.Length < 1)
            {
                this.errorProvider1.SetError(txtPassword, "Please Password.");
                valid = false;
            }
            else
            {
                this.errorProvider1.SetError(txtPassword, "");
                valid = true;
            }
        }

        public Login_Form()
        {
            
            InitializeComponent();
            CenterToScreen();
            
            txtPassword.PasswordChar = '*';
        }
       private void Login_Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) btnExit_Login.PerformClick();
        }

        private void Login_Form_Load(object sender, EventArgs e)
        {
            panel_Login.BackColor = Color.FromArgb(100, 0, 0, 0);
        }

        private void btnExit_Login_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            txtId_Validating(sender, new CancelEventArgs());
            txtPassword_Validating(sender, new CancelEventArgs());
            if (valid)
            {
                string username = txtUsername.Text;
                string password = txtPassword.Text;

                
                LoginDAO dao = new LoginDAO();
                int check = dao.checkLogin(username, password);
                idUser = username;
                if (check == 1)
                {
                    
                    this.Hide();
                    new Admin().Show();
                    
                }
                else if (check == 2)
                {
                    this.Hide();
                    new Home_Form().Show();
                }
                else
                {
                    MessageBox.Show("Invalid username and password!");
                }
            }
            else
            {
                MessageBox.Show("Invalid entered Information!");
            }
        }

      

 
      


 
    }
}
