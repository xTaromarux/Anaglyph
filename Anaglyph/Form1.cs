using Anaglyph.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Anaglyph
{
    public partial class AnaglyphForm : System.Windows.Forms.Form
    {
        public AnaglyphForm()
        {
            InitializeComponent();
            UC_CSharp uc = new UC_CSharp();
            addUserControl(uc);
        }



        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Logo_Click(object sender, EventArgs e)
        {

        }

        private void Menu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void addUserControl(UserControl userControl)
        {
            if (userControl != null)
            {
                userControl.Dock = DockStyle.Fill;
                PanelContainer.Controls.Clear();
                PanelContainer.Controls.Add(userControl);
                userControl.BringToFront();
            }
        }

        private void FirstTab_Click(object sender, EventArgs e)
        {
            UC_CSharp uc = new UC_CSharp();
            addUserControl(uc);
        }

        private void SecondTab_Click(object sender, EventArgs e)
        {
            UC_Assembly uc = new UC_Assembly();
            addUserControl(uc);
        }

        private void Label_Click(object sender, EventArgs e)
        {

        }

        private void Container_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonMinimalize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;
        [DllImport("User32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        private void ThirdTab_Click(object sender, EventArgs e)
        {
            UC_Result uc = new UC_Result();
            addUserControl(uc);
        }
    }
}

