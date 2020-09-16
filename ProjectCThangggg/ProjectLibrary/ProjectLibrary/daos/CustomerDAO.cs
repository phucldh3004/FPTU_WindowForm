using ProjectLibrary.dtos;
using ProjectLibrary.utils;
using System;
using System.Data;
using System.Data.SqlClient;

namespace ProjectLibrary.daos
{
    public class CustomerDAO
    {
        CustomerDTO dto = new CustomerDTO();
        SqlConnection cnn = new SqlConnection();

        
        public bool AddCustomer(string fullname, string birthday, string address, string email, string phonenumber)
        {
            bool result;
            try
            {
                cnn = DBAcess.GetConnection();
                cnn.Open();
                SqlCommand cmd = cnn.CreateCommand();

                cmd.Parameters.AddWithValue("@FullName", fullname);
                cmd.Parameters.AddWithValue("@DayofBirth", birthday);
                cmd.Parameters.AddWithValue("@Address", address);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@PhoneNumber", phonenumber);

                cmd.CommandText = "Insert Into Customer(FullName,DayofBirth,Address,Email,PhoneNumber)" +
                    " Values(@FullName, @DayofBirth, @Address, @Email, @PhoneNumber)";
                cmd.ExecuteNonQuery();
                result = true;
            }
            catch (SqlException ex)
            {
                result = false;
                throw new Exception(ex.Message);
            }
            finally
            {
                cnn.Close();
            }
            return result;
        }

    
        public bool RemoveCustomer(string phonenumber)
        {
            bool result;
            try
            {
                cnn = DBAcess.GetConnection();
                cnn.Open();
                SqlCommand cmd = cnn.CreateCommand();
                cmd.Parameters.AddWithValue("@PhoneNumber", phonenumber);

                cmd.CommandText = "Delete From Customer Where PhoneNumber = @PhoneNumber";
                cmd.ExecuteNonQuery();
                result = true;
            }
            catch (SqlException ex)
            {
                result = false;
                throw new Exception(ex.Message);
            }
            finally
            {
                cnn.Close();
            }
            return result;
        }

        

        public DataTable SearchCustomerByPhone(string keySearch)
        {
            DataTable dt = new DataTable();
            SqlConnection cnn = new SqlConnection();
            try
            {
                cnn = DBAcess.GetConnection();
                SqlCommand cmd = new SqlCommand("FindCust10", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Filter10", keySearch);
                cnn.Open();
                SqlDataReader r = cmd.ExecuteReader();
                dt.Load(r);
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

        public bool UpdateCustomer(string FullName, string DayofBirth, string Address, string Email, string PhoneNumber)
        {
            bool result;
            try
            {
                SqlConnection cnn = DBAcess.GetConnection();
                cnn.Open();
                SqlCommand cmd = cnn.CreateCommand();
                cmd.CommandText = "Update Customer set FullName = '"+FullName+"', DayofBirth = '"+DayofBirth+"', " +
                    "Address = '"+Address+"', Email = '"+Email+"' Where PhoneNumber = '"+PhoneNumber+"'";
                cmd.ExecuteNonQuery();
                result = true;
            }
            catch(SqlException ex)
            {
                result = false;
                throw new Exception(ex.Message);
            }

            return result;
        }

        public CustomerDTO checkCust(string id)
        {
            CustomerDTO dto = new CustomerDTO();
            try
            {

                cnn = DBAcess.GetConnection();
                cnn.Open();
                string sql = "SELECT * FROM Customer WHERE FullName =@FullName";
                SqlCommand cmd = new SqlCommand(sql, cnn);
                cmd.Parameters.AddWithValue("@FullName", id);
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
                        dto.FullName1 = dr["FullName"].ToString();
                        dto.BirthDay1 = DateTime.Parse(dr["DayofBirth"].ToString());
                        dto.Email1 = dr["Email"].ToString(); ;
                        dto.Address1 = dr["Address"].ToString();
                        dto.Phone1 = dr["PhoneNumber"].ToString();
                    }
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
            return dto;
        }
    }
}
