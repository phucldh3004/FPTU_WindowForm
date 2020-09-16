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
    public partial class frmAddCategory : Form
    {
        public int quantity = 0;
  
        public frmAddCategory()
        {
            InitializeComponent();
            CenterToScreen();
           
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
           
            if (!(txtQuantity.Text.Trim().Equals(""))){
                try
                {
                    quantity = Int32.Parse(txtQuantity.Text.Trim());
                } catch (Exception ex)
                {
                    MessageBox.Show("Input valid quantity!"+ex.Message);
                }
            }
            else
            {
                MessageBox.Show("input quantity!");
            }

            this.Hide();
            

            
            

        }
       
    }
}
