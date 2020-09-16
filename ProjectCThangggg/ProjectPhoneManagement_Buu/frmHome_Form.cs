using ProjectPhoneManagement_Buu;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_Phone_Management
{
    public partial class Home_Form : Form
    {
        public Home_Form()
        {
            InitializeComponent();
            HomeControlPanel homeControl = new HomeControlPanel();
            this.pnl2.Controls.Add(homeControl);
            CenterToScreen();

        }

        private void btn_Home_Click(object sender, EventArgs e)
        {
            this.pnl2.Controls.Clear();
            HomeControlPanel homeControl = new HomeControlPanel();
            
            this.pnl2.Controls.Add(homeControl);
        }

        

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_Invoice_Click(object sender, EventArgs e)
        {
            this.pnl2.Controls.Clear();
            InvoiceControllPanel invoiceControll = new InvoiceControllPanel();
            this.pnl2.Controls.Add(invoiceControll);

        }

        private void btn_Customer_Click(object sender, EventArgs e)
        {
            this.pnl2.Controls.Clear();
            CustomerControllPanel customerControllPanel = new CustomerControllPanel();
            this.pnl2.Controls.Add(customerControllPanel);
        }
    }
    }

