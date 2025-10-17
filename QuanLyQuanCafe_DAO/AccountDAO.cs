using QuanLyQuanCafe_DTO; // Thêm using này để sử dụng AccountDTO
using System.Data;

namespace QuanLyQuanCafe_DAO
{
    public class AccountDAO
    {
        private static AccountDAO instance;
        public static AccountDAO Instance
        {
            get { if (instance == null) instance = new AccountDAO(); return instance; }
            private set { instance = value; }
        }
        private AccountDAO() { }

        /// <summary>
        /// Kiểm tra thông tin đăng nhập.
        /// </summary>
        /// <param name="userName">Tên đăng nhập</param>
        /// <param name="passWord">Mật khẩu</param>
        /// <returns>True nếu đăng nhập thành công, False nếu thất bại.</returns>
        public bool Login(string userName, string passWord)
        {
            // Lưu ý: Trong thực tế, mật khẩu trong CSDL nên được mã hóa (hash).
            // Ở đây chúng ta làm đơn giản để phục vụ mục đích học tập.
            string query = "USP_Login @userName , @passWord";

            DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[] { userName, passWord });

            return result.Rows.Count > 0;
        }

        /// <summary>
        /// Lấy thông tin tài khoản bằng Tên đăng nhập.
        /// </summary>
        /// <param name="userName">Tên đăng nhập</param>
        /// <returns>Một đối tượng AccountDTO.</returns>
        public AccountDTO GetAccountByUserName(string userName)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM TAIKHOAN WHERE TenDangNhap = '" + userName + "'");

            foreach (DataRow item in data.Rows)
            {
                return new AccountDTO(item);
            }

            return null;
        }
    }
}