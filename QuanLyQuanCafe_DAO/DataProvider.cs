using System;
using System.Configuration; // Thư viện để đọc App.config
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace QuanLyQuanCafe_DAO
{
    public class DataProvider
    {
        // Sử dụng mẫu Singleton để đảm bảo chỉ có 1 thể hiện của DataProvider trong suốt ứng dụng
        private static DataProvider instance;
        public static DataProvider Instance
        {
            get { if (instance == null) instance = new DataProvider(); return instance; }
            private set { instance = value; }
        }
        private DataProvider() { }

        // Lấy chuỗi kết nối từ file App.config của project GUI
        private string connectionStr = ConfigurationManager.ConnectionStrings["QuanLyQuanCafeDB"].ConnectionString;

        /// <summary>
        /// Thực thi câu lệnh SELECT và trả về kết quả là một DataTable.
        /// </summary>
        /// <param name="query">Câu lệnh SQL (VD: "SELECT * FROM Table")</param>
        /// <param name="parameter">Các tham số cho câu lệnh (VD: new object[] { "value1", 123 })</param>
        /// <returns>DataTable chứa kết quả.</returns>
        public DataTable ExecuteQuery(string query, object[] parameter = null)
        {
            DataTable data = new DataTable();
            // 'using' sẽ tự động giải phóng tài nguyên (đóng connection) khi khối lệnh kết thúc
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);

                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(data);
                connection.Close();
            }
            return data;
        }

        /// <summary>
        /// Thực thi câu lệnh INSERT, UPDATE, DELETE và trả về số dòng bị ảnh hưởng.
        /// </summary>
        /// <param name="query">Câu lệnh SQL</param>
        /// <param name="parameter">Các tham số</param>
        /// <returns>Số dòng bị ảnh hưởng.</returns>
        public int ExecuteNonQuery(string query, object[] parameter = null)
        {
            int data = 0;
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);

                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }

                data = command.ExecuteNonQuery();
                connection.Close();
            }
            return data;
        }

        /// <summary>
        /// Thực thi câu lệnh trả về một giá trị duy nhất từ dòng đầu tiên, cột đầu tiên của kết quả.
        /// </summary>
        /// <param name="query">Câu lệnh SQL (VD: "SELECT COUNT(*) FROM Table")</param>
        /// <param name="parameter">Các tham số</param>
        /// <returns>Giá trị duy nhất (dưới dạng object).</returns>
        public object ExecuteScalar(string query, object[] parameter = null)
        {
            object data = 0;
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);

                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }

                data = command.ExecuteScalar();
                connection.Close();
            }
            return data;
        }
    }
}