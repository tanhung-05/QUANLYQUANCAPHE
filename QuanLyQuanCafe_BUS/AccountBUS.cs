using QuanLyQuanCafe_DAO;
using QuanLyQuanCafe_DTO; // Thêm using này
using System.Data;

namespace QuanLyQuanCafe_BUS
{
    public class AccountBUS
    {
        private static AccountBUS instance;
        public static AccountBUS Instance
        {
            get { if (instance == null) instance = new AccountBUS(); return instance; }
            private set { instance = value; }
        }
        private AccountBUS() { }

        public bool Login(string userName, string passWord)
        {
            return AccountDAO.Instance.Login(userName, passWord);
        }

        public AccountDTO GetAccountByUserName(string userName)
        {
            return AccountDAO.Instance.GetAccountByUserName(userName);
        }
    }
}