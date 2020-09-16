using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLibrary.utils
{
    public class DBAcess
    {
        public static SqlConnection GetConnection()
        {
            string strConnection = "server=.;database=PhoneMangement;uid=sa;pwd=123456";
            SqlConnection cnn = new SqlConnection(strConnection);
            return cnn;
        }
    }
}
