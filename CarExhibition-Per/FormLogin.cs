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
    public partial class FormLogin : Form
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

        public FormLogin()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 32, 32));
        }

        private void pictureBoxExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("قصد خروج از نرم افزار را دارید؟", "!پیغام", MessageBoxButtons.YesNo
                , MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        Login_BLL bll = new Login_BLL();


        private void gunaButtonLogin_Click(object sender, EventArgs e)
        {
            if (bll.Login(gunaTextBoxUserName.Text, gunaTextBoxPassword.Text) == 1)
            {
                FormMenu cem = new FormMenu();
                cem.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("اطلاعات وارد شده صحیح نمی باشد", "!پیغام امنیتی", MessageBoxButtons.OK
                    , MessageBoxIcon.Error);
            }
            if (checkBoxRemimber.Checked)
            {
                Properties.Settings.Default.UserNameSetting = gunaTextBoxUserName.Text;
                Properties.Settings.Default.PasswordSetting = gunaTextBoxPassword.Text;
                Properties.Settings.Default.Save();
            }
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            if (bll.Login("", "") == 0)
            {
                linkLabelActivion.Visible = true;
            }
            else
            {
                linkLabelActivion.Visible = false;
            }
            if (Properties.Settings.Default.UserNameSetting != string.Empty)
            {
                gunaTextBoxUserName.Text = Properties.Settings.Default.UserNameSetting;
                gunaTextBoxPassword.Text = Properties.Settings.Default.PasswordSetting;
            }
        }

        private void linkLabelRiovery_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormRicovery fr = new FormRicovery();
            fr.Show();
        }

        private void linkLabelActivion_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormRegster fre = new FormRegster();
            fre.Show();
        }

        private void gunaTextBoxUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                gunaTextBoxPassword.Focus();
            }
        }

        private void gunaTextBoxPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (bll.Login(gunaTextBoxUserName.Text, gunaTextBoxPassword.Text) == 1)
                {
                    FormMenu cem = new FormMenu();
                    cem.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("اطلاعات وارد شده صحیح نمی باشد", "!پیغام امنیتی", MessageBoxButtons.OK
                        , MessageBoxIcon.Error);
                }
                if (checkBoxRemimber.Checked)
                {
                    Properties.Settings.Default.UserNameSetting = gunaTextBoxUserName.Text;
                    Properties.Settings.Default.PasswordSetting = gunaTextBoxPassword.Text;
                    Properties.Settings.Default.Save();
                }
            }
        }

        private void FormLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (MessageBox.Show("قصد خروج از نرم افزار را دارید؟", "!پیغام", MessageBoxButtons.YesNo
            , MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Application.Exit();
                }
            }
        }

        private void labelX1_MouseMove(object sender, MouseEventArgs e)
        {
            gunaTextBoxPassword.PasswordChar = '\0';
            labelXShowPassword.Symbol = "";
        }

        private void labelXShowPassword_MouseLeave(object sender, EventArgs e)
        {
            gunaTextBoxPassword.PasswordChar = '•';
            labelXShowPassword.Symbol = "";
        }
    }
}
