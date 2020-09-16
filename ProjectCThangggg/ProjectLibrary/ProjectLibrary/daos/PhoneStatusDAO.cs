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
    public class PhoneStatusDAO
    {
        public List<PhoneStatusDTO> GetListStatus()
        {
            List<PhoneStatusDTO> list = null;
            string sql = "Select ID, Description from PhoneStatus";
            SqlConnection cnn = DBAcess.GetConnection();
            SqlCommand cmd = new SqlCommand(sql, cnn);
            try
            {
                if (cnn.State == ConnectionState.Closed)
                {
                    cnn.Open();
                    SqlDataReader rd = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    if (rd.HasRows)
                    {
                        while (rd.Read())
                        {
                            if (list == null)

                                list = new List<PhoneStatusDTO>();
                            PhoneStatusDTO dto = new PhoneStatusDTO();


                            dto.Id = rd.GetInt32(0);
                            dto.Description = rd.GetString(1);


                            list.Add(dto);

                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        }
        
        public string GetStatusDescriptionByID(int ID)
        {
            string result = "";
            string SQL = "SELECT Description FROM PhoneStatus WHERE ID = @ID";
            SqlConnection cnn = DBAcess.GetConnection();
            SqlCommand cmd = new SqlCommand(SQL, cnn);
            cmd.Parameters.AddWithValue("@ID", ID);
            try
            {
                if (cnn.State == ConnectionState.Closed)
                {
                    cnn.Open();
                    SqlDataReader rd = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    if (rd.Read())
                    {
                        result = rd.GetString(0);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }
        public int GetStatusIDByName(string Name)
        {
            int result = 0;
            string SQL = "SELECT ID FROM PhoneStatus WHERE Description = @Name";
            SqlConnection cnn = DBAcess.GetConnection();
            SqlCommand cmd = new SqlCommand(SQL, cnn);
            cmd.Parameters.AddWithValue("@Name", Name);
            try
            {
                if (cnn.State == ConnectionState.Closed)
                {
                    cnn.Open();
                    SqlDataReader rd = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    if (rd.Read())
                    {
                        result = rd.GetInt32(0);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }
    }

}
