using ProjectLibrary.dtos;
using ProjectLibrary.utils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLibrary.daos
{
    public class InvoiceDetailsDAO
    {
        SqlConnection cnn = null;
        InvoideDetailsDTO invoideDetailsDTO = null;
        public bool addInvoiceDetails(int phoneID, int invoiceID, float unitPrice, int quantity)
        {
            bool add;
            try
            {
                cnn = DBAcess.GetConnection();
                cnn.Open();
           
                string sql = "INSERT INTO InvoiceDetails(PhoneID, InvoiceID, UnitPrice, Quantity) VALUES" +
                    "(@PhoneID, @InvoiceID, @UnitPrice, @Quantity)";
                SqlCommand cmd = new SqlCommand(sql, cnn);

                cmd.Parameters.AddWithValue("@PhoneID", phoneID);
                cmd.Parameters.AddWithValue("@InvoiceID", invoiceID);
                cmd.Parameters.AddWithValue("@UnitPrice", unitPrice);
                cmd.Parameters.AddWithValue("@Quantity", quantity);

                cmd.ExecuteNonQuery();
                add = true;

            }
            catch (SqlException se)
            {
                add = false;
                throw new Exception(se.Message);

            }
            finally
            {
                cnn.Close();
            }
            return add;

        }

    }
}
