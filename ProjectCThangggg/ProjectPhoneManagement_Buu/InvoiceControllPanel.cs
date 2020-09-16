using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjectLibrary.daos;
using System.Xml;
using System.Globalization;
using ProjectLibrary.dtos;
using System.Net.Http.Headers;
using ProjectLibrary.utils;
using ProjectLibrary;

namespace ProjectPhoneManagement_Buu
{
    public partial class InvoiceControllPanel : UserControl
    {
        int numrow = 0;
        CartDAO cart = null;
        DataTable dt = null;
        string id = null;
        double total = 0;
        string message = null;


        InvoiceDetailsDAO dao = new InvoiceDetailsDAO();

        public InvoiceControllPanel()
        {
            InitializeComponent();
            LoadData();

        }
        public void LoadData()
        {
            total = 0;
            cart = new CartDAO();
            dt = new DataTable();
            dt = cart.getListInCart();
            dataInvoice.DataSource = dt;

            dataInvoice.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                total += (Int32.Parse(dt.Rows[i].ItemArray[3].ToString()) * Int32.Parse(dt.Rows[i].ItemArray[4].ToString()));
            }
            labelTotal.Text = total.ToString() + " VND";
            labelTotal.AutoSize = false;
        }
        public string OutOfReportString()
        {


            message = "PhoneName                Price          Quantity    \n";
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                message += dt.Rows[i].ItemArray[2] + "          ";
                message += dt.Rows[i].ItemArray[3] + "          ";
                message += dt.Rows[i].ItemArray[4] + "  \n";

            }
            message += "Total Price:    " + labelTotal.Text.Trim() + "  ";
            return message;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Are you sure change?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int id = 0;
                int quantity = 0;
                try
                {
                     id = Int32.Parse(this.id);
                     quantity = Int32.Parse(txtQuantity.Text);
                }
                catch (Exception ex)
                {
                    id = 0;
                    quantity = 0;
                    Console.WriteLine(ex.Message);
                }


                CartDAO cartDAO = new CartDAO();

                bool checkIDCart = cartDAO.checkDuplicate(id);
                if (checkIDCart == false)
                {
                    MessageBox.Show("Invalid ID!");
                }
                else
                {
                    bool result = cartDAO.UpdateCart(id, quantity);

                    if (result == true)
                    {
                        LoadData();
                    }
                }
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure Delete?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int id = 0;
                try
                {
                    id = Int32.Parse(this.id);
                }catch(Exception ex)
                {
                    id = 0;
                    Console.WriteLine(ex.Message);
                }


                CartDAO cartDAO = new CartDAO();

                bool checkIDCart = cartDAO.checkDuplicate(id);
                if (checkIDCart == false)
                {
                    MessageBox.Show("Invalid ID!");
                }
                else
                {
                    bool result = cartDAO.DeleteCart(id);

                    if (result == true)
                    {
                        LoadData();
                        MessageBox.Show("Successfully!");
                    }
                }
            }

        }



        private void btnReport_Click(object sender, EventArgs e)
        {


            if (MessageBox.Show("Are you sure want buy?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int quantityC = 0;

                AddCustomer frmCust = new AddCustomer();
                frmCust.ShowDialog();


                DateTime datePurchar = DateTime.Now;
                CustomerDAO cusDao = new CustomerDAO();
                CustomerDTO cusDTO = new CustomerDTO();

                string nameCust;
                nameCust = frmCust.nameCusomter;
                if (nameCust == null)   // chan khong cho exception null customer!
                {
                    MessageBox.Show("Input info customer!");  

                }
                else
                {

                    cusDTO = cusDao.checkCust(nameCust.ToString());
                    string custPhone = cusDTO.Phone1;
                    InvoiceDAO invoiceDAO = new InvoiceDAO();
                    bool addInvoice = invoiceDAO.addInvoice(datePurchar, custPhone, total);


                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        InvoiceDetailsDAO invoiceDetailDao = new InvoiceDetailsDAO();

                        int phoneID = Int32.Parse(dt.Rows[i].ItemArray[1].ToString());
                        int invoiceID = invoiceDAO.getID();
                        float price = float.Parse(dt.Rows[i].ItemArray[3].ToString());
                        int quantity = Int32.Parse(dt.Rows[i].ItemArray[4].ToString());
                        bool addToInvoideDeltails = invoiceDetailDao.addInvoiceDetails(phoneID, invoiceID, price, quantity);

                        PhoneDAO dao = new PhoneDAO();

                        int quantityDB = dao.getQuantityInDatabase(phoneID);

                        quantityC = quantityDB - quantity; // quantity con lai la bao nhieu????


                        bool updateQuantity = dao.UpdateQuantityPhone(phoneID, quantityC);

                    }


                    CartDAO cartDAO = new CartDAO();
                    cartDAO.DeleteAllCart();


                    message = "                 P&b Mobile\n";
                    message += "              Invoice\n";
                    message += "\n";
                    message += "Name Customer: " + nameCust + "\n";
                    message += "Phone Customer: " + custPhone + "\n";

                    message += "\n";
                    message += "        Thank you and see you again!";
                    File file = new File();
                    file.WriteToFile(message);

                    LoadData();
                    MessageBox.Show("Successfully!");

                }
            }
        }

        private void dataInvoice_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            numrow = e.RowIndex;
            id = dataInvoice.Rows[numrow].Cells[0].Value.ToString();
            dataInvoice.ReadOnly = true;
            txtIDCart.Text = id;

        }


    }
}

