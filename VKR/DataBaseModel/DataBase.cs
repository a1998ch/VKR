using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace DataBaseModel
{
    public class DataBase
    {
        public void DownloadData(string dataBasePath)
        {
            SqlConnection sqlConnection = new SqlConnection(dataBasePath);
        }
    }
}
