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
        [System.Runtime.InteropServices.DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]//To round the form
        private static extern IntPtr CreateRoundRectRgn//To round the form
        (
          int nLeftRect,//To round the form
          int nTopRect,//To round the form
          int nRightRect,//To round the form
          int nBottomRect,//To round the form
          int nWidthEllipse,//To round the form
          int nHeightEllipse//To round the form
        );
        public FormProfile()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;//To round the form
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 32, 32));//To round the form
        }
        private void FormProfile_Load(object sender, EventArgs e)
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
