// Trong file fTableManager.cs
using QuanLyQuanCafe_DTO; // Thêm using này
using System.Windows.Forms;

namespace QuanLyQuanCafe_GUI.Forms
{
    public partial class fTableManager : Form
    {
        private AccountDTO loginAccount;

        public AccountDTO LoginAccount
        {
            get { return loginAccount; }
            set { loginAccount = value; }
        }
        public fTableManager(AccountDTO acc)
        {
            InitializeComponent();
            this.LoginAccount = acc;
        }

        private void fTableManager_Load(object sender, System.EventArgs e)
        {

        }
    }
}