using ProjectLibrary.dtos;
using ProjectLibrary.utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLibrary.daos
{
    public class LoginDAO
    {
        SqlConnection cnn = null;



        public int checkLogin(string username, string password)
        {
            int role = 0;
            try
            {

                cnn = DBAcess.GetConnection();
                cnn.Open();
                string sql = "SELECT IDRole FROM Account WHERE UserID = @UserID AND PasswordID = @Password";
                SqlCommand cmd = new SqlCommand(sql, cnn);
                cmd.Parameters.AddWithValue("@UserID", username);
                cmd.Parameters.AddWithValue("@Password", password);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                //cmd.Parameters.AddWithValue("@ID_Role", result);

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
                        role = int.Parse(dr["IDRole"].ToString());
                    }
                }
                else
                {
                    role = 0;
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

            return role;
        }

        public AccountDTO checkAcount(string id)
        {
            AccountDTO dto = new AccountDTO();
            try
            {

                cnn = DBAcess.GetConnection();
                cnn.Open();
                string sql = "SELECT UserID, PhoneNumber, FullName, AddressS FROM Account WHERE UserID ='" + id + "' ";
                SqlCommand cmd = new SqlCommand(sql, cnn);
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
                        dto.UserID = dr["UserID"].ToString();
                        dto.Fullname = dr["FullName"].ToString();
                        dto.PhoneNumer = dr["PhoneNumber"].ToString(); ;
                        dto.Address = dr["AddressS"].ToString();

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
