using ProjectLibrary.daos;
using ProjectLibrary.dtos;
using ProjectLibrary.utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLibrary
{
    public class PhoneDAO
    {
        string strConnection = @"server=.;database=PhoneManagerment;uid=sa;pwd=123";
        SqlConnection cnn = new SqlConnection();
        // PhoneDTO phone = new PhoneDTO();

        public DataTable getListPhone()
        {
            DataTable dt = new DataTable();
            try
            {
                cnn = new SqlConnection(strConnection);
                SqlCommand cmd = new SqlCommand("GetListPhone", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cnn.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                dt.Load(rd);
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


        PhoneDTO phoneDTO = null;
        public DataTable getListPhones()//Phuc Dev
        {
            DataTable dt = new DataTable();
            try
            {
                cnn = DBAcess.GetConnection();
                cnn.Open();

                string sql = "SELECT ID, PhoneName, Price, ManufactureYear, AcquiredDate, Quantity, TypeID, CategoryID, StatusID FROM Phone";

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

        public DataTable SearchPhone(string categories, string type, string status, double priceFrom, double priceTo)
        {
            DataTable dt = new DataTable();

            string sql = "SELECT ID, PhoneName, Price, ManufactureYear, AcquiredDate, Quantity, TypeID, CategoryID, StatusID FROM Phone";

            PhoneTypeDAO phoneTypeDAO = new PhoneTypeDAO();
            PhoneStatusDAO phoneStatusDAO = new PhoneStatusDAO();
            PhoneCategoriesDAO phoneCategoriesDAO = new PhoneCategoriesDAO();

            if (!categories.Equals("All"))
            {
                int cateID = phoneCategoriesDAO.GetCateIDByName(categories);
                String cateDes = cateID.ToString();
                if (!sql.Contains("WHERE"))
                {
                    sql = sql + " WHERE CategoryID ='" + cateDes + "'";
                }


            }
            if (!type.Equals("All"))
            {
                int typeID = phoneTypeDAO.GetTypeIDByName(type);
                String typeDes = typeID.ToString();
                if (!sql.Contains("WHERE"))
                {
                    sql = sql + " WHERE TypeID ='" + typeDes + "'";
                }
                else
                {
                    sql = sql + " AND TypeID ='" + typeDes + "'";
                }
            }
            if (!status.Equals("All"))
            {
                int statusID = phoneStatusDAO.GetStatusIDByName(status);
                String statusDes = statusID.ToString();
                if (!sql.Contains("WHERE "))
                {
                    sql = sql + " WHERE StatusID ='" + statusDes + "'";
                }
                else
                {
                    sql = sql + " AND StatusID ='" + statusDes + "'";
                }
            }
            if (!(priceFrom == -1 && priceTo == -1))
            {
                if (priceFrom > -1 && priceTo > -1)
                {
                    if (!sql.Contains("WHERE "))
                    {
                        sql = sql + " WHERE Price BETWEEN " + priceFrom + " AND " + priceTo;
                    }
                    else
                    {
                        sql = sql + " AND Price BETWEEN " + priceFrom + " AND " + priceTo;
                    }
                }
                else if (priceFrom > -1 && priceTo == -1)
                {
                    if (!sql.Contains("WHERE "))
                    {
                        sql = sql + " WHERE Price >= " + priceFrom;
                    }
                    else
                    {
                        sql = sql + " AND Price >= " + priceFrom;
                    }
                }
                else if (priceFrom == -1 && priceTo > -1)
                {
                    if (!sql.Contains("WHERE "))
                    {
                        sql = sql + " WHERE Price <= " + priceTo;
                    }
                    else
                    {
                        sql = sql + " AND Price <= " + priceTo;
                    }
                }
                Console.WriteLine(sql);
            }

            SqlConnection cnn = DBAcess.GetConnection();
            SqlCommand cmd = new SqlCommand(sql, cnn);

            try
            {

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


            return dt;
        }

        

        public bool checkDuplicate(int code)
        {
            bool result = false;
            string sql = "Select ID FROM Phone WHERE ID=@code";
            cnn = new SqlConnection(strConnection);
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

       



       
        public bool AddPhone(int id, string name, double price, int manu, string date, int quanity, int type, int category, int status)
        {
            bool result;
            try
            {
                cnn = DBAcess.GetConnection();
                cnn.Open();
                SqlCommand cmd = cnn.CreateCommand();
                cmd.CommandText = "Insert Into Phone(ID,PhoneName,Price,ManufactureYear,AcquiredDate,Quantity,TypeID,CategoryID,StatusID)" +
                    " Values(" + id + ", '" + name + "', " + price + " , " + manu + " , '" + date + "', " + quanity + ", " + type + ", " + category + ", " + status + ")";
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

        public bool RemovePhone(int id)
        {
            bool result;
            try
            {
                cnn = DBAcess.GetConnection();
                cnn.Open();
                SqlCommand cmd = cnn.CreateCommand();
                cmd.CommandText = "Delete From Phone Where ID ='" + id + "'";
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

        public bool UpdatePhone(int id, string name, float price, int manu, string date, int quantity, int type, int category, int status)
        {
            bool result;
            try
            {
                SqlConnection cnn = DBAcess.GetConnection();
                cnn.Open();
                SqlCommand cmd = cnn.CreateCommand();
                cmd.CommandText = "Update Phone set PhoneName = '" + name + "', Price =  '" + price + "' ," +
                 " ManufactureYear =  '" + manu + "' , AcquiredDate = '" + date + "', Quantity = '" + quantity + "'," +
                 " TypeID = '" + type + "', CategoryID = '" + category + "', StatusID = '" + status + "' Where ID = '" + id + "'";
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

        public DataTable SearchPhoneByName(string keySearch)
        {
            DataTable dt = new DataTable();
            SqlConnection cnn = new SqlConnection();
            try
            {
                cnn = DBAcess.GetConnection();
                SqlCommand cmd = new SqlCommand("FindPhone9", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Filter9", keySearch);
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
        public bool UpdateQuantityPhone(int id , int quantity)
        {
            bool result =false;
            try
            {
                SqlConnection cnn = DBAcess.GetConnection();
                cnn.Open();
                SqlCommand cmd = cnn.CreateCommand();
                cmd.CommandText = "Update Phone set Quantity = @Quantity WHERE ID = @ID";
                cmd.Parameters.AddWithValue("@Quantity", quantity);
                cmd.Parameters.AddWithValue("@ID", id);
                int ex =  cmd.ExecuteNonQuery();

                if(ex == 1)
                {
                    result = true;
                }
                
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

        public int getQuantityInDatabase(int id)
        {
            int quantity = 0;
            try
            {

                cnn = DBAcess.GetConnection();
                cnn.Open();
                string sql = "SELECT Quantity FROM Phone WHERE ID = '"+id+"'";
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
                        quantity = int.Parse(dr["Quantity"].ToString());
                    }
                }
                else
                {
                    quantity = 0;
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

            return quantity;
        }




    }
}
