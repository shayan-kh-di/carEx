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
    public partial class FormMenu : Form
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
        public FormMenu()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;//To round the form
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 32, 32));//To round the form
        }
        private void labelXShowPeofile_Click(object sender, EventArgs e)
        {
            FormProfile ff = new FormProfile();
            ff.Show();
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to exit the software?", "Message", MessageBoxButtons.YesNo
            , MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        private void guna2ButtonNewCarArrival_Click(object sender, EventArgs e)
        {
            FormCarArrival fc = new FormCarArrival();
            fc.Show();
        }
    }
}
