using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLCuaHangViTinh
{
    public partial class frmDangNhap : Form
    {
        QL_NguoiDung CauHinh = new QL_NguoiDung();
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUser.Text.Trim()))
            {
                MessageBox.Show("Không được để trống " + lblUser.Text.ToLower());
                this.txtUser.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtPassword.Text.Trim()))
            {
                MessageBox.Show("Không được để trống " + lblPassword.Text.ToLower());
                this.txtPassword.Focus();
                return;
            }
            int kq = CauHinh.Check_Config(); // Hàm check_Config thuộc class QL_NguoiDung
            if (kq == 0)
            {
                ProcessLogin();
            }
            if (kq == 1)
            {
                MessageBox.Show("Cấu hình không tồn tại"); // Xử lý cấu hình
                ProcessConfig();
            }
            if (kq == 2)
            {
                MessageBox.Show("Chuỗi cấu hình không phù hợp"); // Xử lý cấu hình
                ProcessConfig();
            }
        }

        public void ProcessLogin()
        {
            int result;
            result = CauHinh.Check_User(txtUser.Text, txtPassword.Text);
            if (result == 0)
            {
                MessageBox.Show("Sai " + lblUser.Text.ToLower() + " hoặc " + lblPassword.Text.ToLower());
                return;
            }
            else if (result == 1)
            {
                MessageBox.Show("Tài khoản bị khóa");
                return;
            }
            if (Program.mainForm == null || Program.mainForm.IsDisposed)
            {
                Program.mainForm = new frmMenu();

            }
            this.Visible = false;
            Program.mainForm.Show();
        }

        public void ProcessConfig()
        {
            if (Program.lgin == null || Program.lgin.IsDisposed)
            {
                Program.lgin = new SetCauHinh();

            }
            this.Visible = false;
            Program.lgin.Show();
        }

    }
}
