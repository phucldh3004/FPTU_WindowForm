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
     public class CartDAO
    {
        SqlConnection cnn = null;
        public bool addToCart(int idPhone,string phoneName, float price, int quantity)
        {
            bool add;

            try
            {
                cnn = DBAcess.GetConnection();
                cnn.Open();
                string sql = "INSERT INTO Cart(IDPhone,PhoneName,Price,Quantity) " +
                    "VALUES( @IDPhone, @PhoneName, @Price, @Quantity)";
                SqlCommand cmd = new SqlCommand(sql, cnn);

                cmd.Parameters.AddWithValue("@IDPhone", idPhone);
                cmd.Parameters.AddWithValue("@PhoneName", phoneName);
                cmd.Parameters.AddWithValue("@Price", price);
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

        public bool UpdateCart(int   id, int quantity)
        {
            bool check;

            try
            {
                cnn = DBAcess.GetConnection();
                cnn.Open();
                string sql = "UPDATE Cart Set Quantity= @Quantity " +
                    "Where ID= @ID ";

                SqlCommand cmd = new SqlCommand(sql, cnn);
                cmd.Parameters.AddWithValue("@Quantity", quantity);
                cmd.Parameters.AddWithValue("@ID", id);

                cmd.ExecuteNonQuery();
                check = true;

            }
            catch (SqlException se)
            {
                check = false;
                throw new Exception(se.Message);

            }
            finally
            {
                cnn.Close();
            }
            return check;
        }
        public bool DeleteCart(int id)
        {
            bool check;
            try
            {
                cnn = DBAcess.GetConnection();
                cnn.Open();
                String sql = "Delete FROM Cart WHERE ID = @ID";

                SqlCommand cmd = new SqlCommand(sql, cnn);
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.ExecuteNonQuery();

                check = true;
            }
            catch (SqlException se)
            {
                check = false;
                throw new Exception(se.Message);

            }
            finally
            {
                cnn.Close();
            }
            return check;
        }

        public void DeleteAllCart()
        {
            try
            {
                cnn = DBAcess.GetConnection();
                cnn.Open();
                String sql = "Delete FROM Cart";

                SqlCommand cmd = new SqlCommand(sql, cnn);

                cmd.ExecuteNonQuery();
            }
            catch (SqlException se)
            {
           
                throw new Exception(se.Message);

            }
            finally
            {
                cnn.Close();
            }
        }
        public DataTable getListInCart()
        {
            DataTable dt = new DataTable();
            try
            {
                cnn = DBAcess.GetConnection();
                cnn.Open();

                string sql = "SELECT ID, IDPhone, PhoneName, Price, Quantity FROM Cart";

                SqlCommand cmd = new SqlCommand(sql, cnn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(dt);
                if (cnn.State == ConnectionState.Closed)
                {
                    cnn.Open();
                }
                if (dt != null)
                {
                    dt = dt;
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                cnn.Close();
            }
            return dt;
        }

        public bool checkDuplicate(int code)
        {
            bool result = false;
            string sql = "Select ID FROM Cart WHERE ID=@code";
            cnn = DBAcess.GetConnection();
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.Parameters.AddWithValue("@code", code);
            try
            {
                if (cnn.State == ConnectionState.Closed) cnn.Open();
                var da = new SqlDataAdapter(cmd);
                DataTable table = new DataTable();
                da.Fill(table);
                if (table.Rows.Count > 0) result = true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (cnn.State == ConnectionState.Open) cnn.Close();
            }
            return result;
        }

    }
}
