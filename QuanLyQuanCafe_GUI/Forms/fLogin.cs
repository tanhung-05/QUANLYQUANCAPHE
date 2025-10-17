using QuanLyQuanCafe_BUS;
using QuanLyQuanCafe_DTO; // Thêm using này
using System;
using System.Windows.Forms;

namespace QuanLyQuanCafe_GUI.Forms
{
    public partial class fLogin : Form
    {
        public fLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text;
            string passWord = txtPassword.Text;

            if (AccountBUS.Instance.Login(userName, passWord))
            {
                // Lấy thông tin tài khoản để truyền qua form chính
                AccountDTO loginAccount = AccountBUS.Instance.GetAccountByUserName(userName);

                fTableManager f = new fTableManager(loginAccount); // Truyền thông tin tài khoản
                this.Hide();
                f.ShowDialog();
                this.Show(); // Show lại form login sau khi form chính đóng
                txtPassword.Text = ""; // Xóa mật khẩu sau khi đăng xuất
            }
            else
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void fLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có thật sự muốn thoát chương trình?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void fLogin_Load(object sender, EventArgs e)
        {

        }
    }
}