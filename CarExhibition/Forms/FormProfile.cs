using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarExhibition.Forms
{
    public partial class FormProfile : Form
    {
        [System.Runtime.InteropServices.DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn
        (
          int nLeftRect,
          int nTopRect,
          int nRightRect,
          int nBottomRect,
          int nWidthEllipse,
          int nHeightEllipse
        );

        public FormProfile()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 32, 32));
        }

        private void FormProfile_Load(object sender, EventArgs e)//برای نمایش اطلاعات کاربری
        {
            labelNameAndFamily.Text = Properties.Settings.Default.RememberNameSetting;
            labelPhoneNumber.Text = Properties.Settings.Default.RememberPNSetting;
            labelEmail.Text = Properties.Settings.Default.RememberEMSetting;
            labelUserName.Text = Properties.Settings.Default.RememberUNSetting;
            labelPassword.Text = Properties.Settings.Default.RememberPDSetting;
        }

        private void pictureBoxExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
