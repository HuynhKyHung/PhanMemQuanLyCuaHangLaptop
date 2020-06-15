using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FontAwesome.Sharp;

namespace QLCuaHangViTinh
{
    public partial class frmMenu : Form
    {
        //Fields
        private IconButton currentBtn;
        private Panel leftBorderBtn;
        private Form currentForm;
        
        //Constructor
        public frmMenu()
        {
            InitializeComponent();
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 40);
            panelMenu.Controls.Add(leftBorderBtn);

            //Form
            this.Text = String.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }

        //Structs
        private struct RBGColors
        {
            public static Color color1 = Color.FromArgb(172, 126, 241);
            public static Color color2 = Color.FromArgb(249, 118, 176);
            public static Color color3 = Color.FromArgb(253, 138, 114);
            public static Color color4 = Color.FromArgb(95, 77, 221);
            public static Color color5 = Color.FromArgb(249, 88, 155);
            public static Color color6 = Color.FromArgb(24, 161, 251);
            public static Color color7 = Color.FromArgb(172, 171, 241);
            public static Color color8 = Color.FromArgb(249, 181, 231);
            public static Color color9 = Color.FromArgb(253, 191, 221);
            public static Color color10 = Color.FromArgb(95, 201, 211);
        }

        private void ActivateButton(object senderBtn, Color color)
        {
            if(senderBtn!=null)
            {
                DisableButton();
                //Button
                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Color.FromArgb(37, 36, 81);
                currentBtn.ForeColor = color;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = color;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;

                //Left border button
                leftBorderBtn.BackColor = color;
                leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();

                //Icon Current Title
                iconCurrent.IconChar = currentBtn.IconChar;
                iconCurrent.IconColor = color;
            }    
        }

        //Methods
        private void DisableButton()
        {
            if(currentBtn!=null)
            {
                currentBtn.BackColor = Color.FromArgb(75, 30, 68);
                currentBtn.ForeColor = Color.White;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = Color.White;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }    
        }

        private void openForm(Form cform)
        {
            if (currentForm != null)
            {
                currentForm.Close();
            }
            currentForm = cform;
            cform.TopLevel = false;
            cform.FormBorderStyle = FormBorderStyle.None;
            cform.Dock = DockStyle.Fill;

            pnlDesktop.Controls.Add(cform);
            pnlDesktop.Tag = cform;
            cform.BringToFront();
            cform.Show();
            lblTieuDe.Text = cform.Text;
        }

        private void iconbtnTongQuan_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RBGColors.color1);
        }

        private void iconbtnDonHang_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RBGColors.color2);
            openForm(new frmDonHang());
        }

        private void iconbtnSanPham_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RBGColors.color3);
        }

        private void iconbtnDoiTac_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RBGColors.color4);
        }

        private void iconbtnBaoCao_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RBGColors.color5);
        }

        private void iconbtnThongBao_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RBGColors.color6);
        }

        private void iconbtnCauHinh_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RBGColors.color7);
            openForm(new frmCauHinhNguoiDung());
        }

        private void iconbtnHoTro_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RBGColors.color8);
        }

        private void iconbtnNangCapDichVu_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RBGColors.color9);
        }

        private void iconbtnDangXuat_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RBGColors.color10);
            Application.Exit();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            //currentForm.Close();
            Reset();
        }

        private void Reset()
        {
            DisableButton();
            leftBorderBtn.Visible = false;
            iconCurrent.IconChar = IconChar.Home;
            iconCurrent.IconColor = Color.MediumPurple;
            lblTieuDe.Text = "Tổng quan";
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void pnlTitle_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {
            MaximizeBox = true;
            
            MinimizeBox = true;
        }

        private void iconMin_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void iconMax_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                WindowState = FormWindowState.Maximized;
            else
                WindowState = FormWindowState.Normal;
        }

        private void iconClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
