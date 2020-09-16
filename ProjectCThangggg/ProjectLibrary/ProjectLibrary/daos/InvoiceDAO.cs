using ProjectLibrary.dtos;
using ProjectLibrary.utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLibrary.daos
{
    public class InvoiceDAO
    {
        SqlConnection cnn = null;
        InvoiceDTO invoiceDTO = null;
        public bool addInvoice(DateTime dateOfPurCharse, string customerPhone, double totalPrice)
        {
            bool add;
            try
            {
                cnn = DBAcess.GetConnection();
                cnn.Open();
                string sql = "INSERT INTO Invoice(DateOfPurcharse, CustomerPhone, TotalPrice) VALUES" +
                    "(@DateOfPurcharse, @CustomerPhone, @TotalPrice)";
                SqlCommand cmd = new SqlCommand(sql, cnn);

                cmd.Parameters.AddWithValue("@DateOfPurcharse", dateOfPurCharse);
                cmd.Parameters.AddWithValue("@CustomerPhone", customerPhone);
                cmd.Parameters.AddWithValue("@TotalPrice", totalPrice);

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


        public int getID()
        {
            int add = 0;
            try
            {
                cnn = DBAcess.GetConnection();
                cnn.Open();
                string sql = "SELECT Max(ID) as LastID FROM Invoice";
                SqlCommand cmd = new SqlCommand(sql, cnn);
                cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();
            da.Fill(dt);
            if (cnn.State == ConnectionState.Closed)
            {
                cnn.Open();
            }
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                       
                            add = int.Parse(dr["LastID"].ToString());
                        
                  
                }
            }
            else
            {
                add = 0;
            }
                }
            catch (SqlException se)
            {
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