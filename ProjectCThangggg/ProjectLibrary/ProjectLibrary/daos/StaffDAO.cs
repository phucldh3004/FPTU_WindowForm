using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using ProjectLibrary.Staff;
using ProjectLibrary.utils;

namespace ProjectLibrary
{
    public class StaffDAO
    {
        SqlConnection cnn = null;


        StaffDTO staff = null;

        public StaffDTO SearchByStaffID(string staffID)
        {
            try
            {


                cnn = DBAcess.GetConnection();
                cnn.Open();
                staff = new StaffDTO();
                string sql = "SELECT UserID, PasswordID, PhoneNumber, FullName, AddressS FROM Account WHERE UserID = @StaffID";
                SqlCommand cmd = new SqlCommand(sql, cnn);
                cmd.Parameters.AddWithValue("@StaffID", staffID);
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
                        staff.StaffID = dr["UserID"].ToString();
                        staff.StaffName = dr["FullName"].ToString();
                        staff.Password = dr["PasswordID"].ToString(); ;
                        staff.Address = dr["AddressS"].ToString();
                        staff.PhoneNumber = dr["PhoneNumber"].ToString();

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

            return staff;
        }
        public bool AddStaff(string id, string pass, string name, string phone, string address)
        {
            bool add;
            int role = 2;
            try
            {
                cnn = DBAcess.GetConnection();
                cnn.Open();
                string sql = "INSERT INTO Account(UserID,PasswordID,IDRole,PhoneNumber,FullName,AddressS) " +
                    "VALUES( @StaffID, @Password,@Role, @Phone, @Name, @Address)";
                SqlCommand cmd = new SqlCommand(sql, cnn);

                cmd.Parameters.AddWithValue("@StaffID", id);
                cmd.Parameters.AddWithValue("@Password", pass);
                cmd.Parameters.AddWithValue("@Role", role);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Phone", phone);
                cmd.Parameters.AddWithValue("@Address", address);

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
        public bool UpdateStaff(string id, string pass, string name, string phone, string address)
        {
            bool check = false;

            try
            {
                cnn = DBAcess.GetConnection();
                cnn.Open();
                string sql = "UPDATE Account Set PasswordID = @Pass,PhoneNumber= @Phone,FullName= @Fullname,AddressS= @Address " +
                    "Where UserID= @UserID ";
                     
                SqlCommand cmd = new SqlCommand(sql, cnn);

                cmd.Parameters.AddWithValue("@Pass", pass);
                cmd.Parameters.AddWithValue("@Phone", phone);
                cmd.Parameters.AddWithValue("@Fullname", name);
                cmd.Parameters.AddWithValue("@Address", address);
                cmd.Parameters.AddWithValue("@UserID", id);

                int ex = cmd.ExecuteNonQuery();
                if (ex == 1)
                {
                    check = true;
                }
                else
                {
                    Console.WriteLine(ex);
                }
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
        public bool CheckDuplicateID(string id)
        {
            bool result = false;
            string sql = "Select UserID From Account Where UserID = @ID";
            cnn = DBAcess.GetConnection();
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cnn.Open();
            cmd.Parameters.AddWithValue("@ID", id);
            try
            {
                var da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0) { result = true; }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                cnn.Close();
            }
            return result;
        }
        public bool DeleteStaff(String id)
        {
            bool check = false;
            try
            {
                cnn = DBAcess.GetConnection();
                cnn.Open();
                string sql = "Delete FROM Account WHERE UserID = @ID";

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
    }
}
