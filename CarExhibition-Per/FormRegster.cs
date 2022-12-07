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
    public partial class FormRegster : Form
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

        public FormRegster()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 32, 32));
        }

        Login_BLL bll = new Login_BLL();
        T_Login h = new T_Login();

        private void gunaButtonRegister_Click(object sender, EventArgs e)
        {
            if (gunaTextBoxPasswordAgain.Text == gunaTextBoxPassword.Text)
            {
                h.NameAndFamily = gunaTextBoxNameAndFamily.Text;
                h.Mobile = gunaTextBoxMobile.Text;
                h.Email = gunaTextBoxEmail.Text;
                h.UserName = gunaTextBoxUserName.Text;
                h.Password = gunaTextBoxPassword.Text;
                bll.Register(h);
                MessageBox.Show("حساب کاربری شما با موفقیت ایجاد شد", "!پیغام", MessageBoxButtons
                        .OK, MessageBoxIcon.Information);
                FormActivion cea = new FormActivion();
                cea.Close();
                this.Close();
                FormLogin ce = new FormLogin();
                ce.linkLabelActivion.Visible = false;
            }
            else
                MessageBox.Show("پسورد ها با هم مطابقت ندارند", "!پیغام", MessageBoxButtons
                        .OK, MessageBoxIcon.Error);
        }

        private void pictureBoxExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gunaTextBoxNameAndFamily_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                gunaTextBoxMobile.Focus();
            }
        }

        private void gunaTextBoxMobile_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                gunaTextBoxEmail.Focus();
            }
        }

        private void gunaTextBoxEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                gunaTextBoxUserName.Focus();
            }
        }

        private void gunaTextBoxUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                labelPassword.Focus();
            }
        }

        private void gunaTextBoxPasswordAgain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (gunaTextBoxPasswordAgain.Text == gunaTextBoxPassword.Text)
                {
                    h.NameAndFamily = gunaTextBoxNameAndFamily.Text;
                    h.Mobile = gunaTextBoxMobile.Text;
                    h.Email = gunaTextBoxEmail.Text;
                    h.UserName = gunaTextBoxUserName.Text;
                    h.Password = gunaTextBoxPassword.Text;
                    bll.Register(h);
                    MessageBox.Show("حساب کاربری شما با موفقیت ایجاد شد", "!پیغام", MessageBoxButtons
                            .OK, MessageBoxIcon.Information);
                    FormActivion cea = new FormActivion();
                    cea.Close();
                    this.Close();
                    FormLogin ce = new FormLogin();
                    ce.linkLabelActivion.Visible = false;
                }
                else
                    MessageBox.Show("پسورد ها با هم مطابقت ندارند", "!پیغام", MessageBoxButtons
                            .OK, MessageBoxIcon.Error);
            }
        }

        private void FormRegster_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
