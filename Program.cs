using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hrdNet
{
    class Program
    {
        static string connectionString = "server = localhost; uid = sa; pwd = 1111; database = PrivateData;";
        static void Main(string[] args)
        {
            string date = "";
            if (args.Length == 0)
            {
                date = DateTime.Now.ToString("yyyyMMdd");
            }
            else
            {
                date = args[0];
            }

            //구직자훈련과정
            HRDPOA01 hRDPOA01 = new HRDPOA01();
            hRDPOA01.getHRDPOA01_01(date);
            //hRDPOA01.getHRDPOA01_02();

            //근로자훈련과정
            //HRDPOA02 hRDPOA02 = new HRDPOA02();
            //hRDPOA02.getHRDPOA02_01();
            //hRDPOA02.getHRDPOA02_02();

            //기업훈련과정
            HRDPOA03 hRDPOA03 = new HRDPOA03();
            hRDPOA03.getHRDPOA03_01(date);
            //hRDPOA03.getHRDPOA03_02();
        }

        public static void insert(string query)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
        }

        public static DataSet selectDS(string query)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                DataSet ds = new DataSet();
                SqlDataAdapter _SqlDataAdapter = new SqlDataAdapter();
                _SqlDataAdapter.SelectCommand = new SqlCommand(query, conn);
                _SqlDataAdapter.Fill(ds);

                return ds;
            }
        }
    }
}
