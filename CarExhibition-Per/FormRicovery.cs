using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CarExhibition_BE;
using CarExhibition_BLL;

namespace CarExhibition_Per
{
    public partial class FormRicovery : Form
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

        public FormRicovery()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 32, 32));
        }

        private void pictureBoxExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        Login_BLL bll = new Login_BLL();
        T_Login t = new T_Login();

        private void gunaButtonRicovery_Click(object sender, EventArgs e)
        {
            t.Email = gunaTextBoxEmail.Text;
            t.Mobile = gunaTextBoxMobile.Text;
            if (bll.Exist(t) == true)
            {
                
            }
            else
                MessageBox.Show("اطلاعات وارد شده صحیح نمی باشد","!پیغام امنیتی",MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
        }

        private void gunaTextBoxMobile_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                gunaTextBoxEmail.Focus();
            }
        }

        private void FormRicovery_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
