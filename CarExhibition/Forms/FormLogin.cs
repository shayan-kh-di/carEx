using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE;
using BLL;
using FoxLearn.License;

namespace CarExhibition.Forms
{
    public partial class FormLogin : Form
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
        public FormLogin()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;//To round the form
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 32, 32));//To round the form
        }
        BLL.BLLS.BLL_Login bll = new BLL.BLLS.BLL_Login();
        T_Login t = new T_Login();
        private void guna2TextBoxUserNameLogin_KeyDown(object sender, KeyEventArgs e)//for Login form
        {
            if (e.KeyCode == Keys.Enter)
            {
                guna2TextBoxPasswordLogin.Focus();
            }
        }
        private void guna2TextBoxPasswordLogin_KeyDown(object sender, KeyEventArgs e)//to login with enter
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (bll.Login(guna2TextBoxUserNameLogin.Text, guna2TextBoxPasswordLogin.Text) == 1)
                {
                    FormMenu cem = new FormMenu();
                    cem.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("The information entered is not correct!", "Security Message!", MessageBoxButtons.OK
                        , MessageBoxIcon.Error);
                }
                if (guna2CheckBoxRemember.Checked)//To remember Somebody
                {
                    Properties.Settings.Default.UserNameSetting = guna2TextBoxUserNameLogin.Text;
                    Properties.Settings.Default.PasswordSetting = guna2TextBoxPasswordLogin.Text;

                }
            }
        }
        private void linkLabelForgotPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)//show panel recovery password
        {
            guna2ShadowPanelPasswordrecovery.Visible = true;
        }
        private void guna2ButtonLogin_Click(object sender, EventArgs e)//to login with button
        {
            if (bll.Login(guna2TextBoxUserNameLogin.Text, guna2TextBoxPasswordLogin.Text) == 1)
            {
                FormMenu cem = new FormMenu();
                cem.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("The information entered is not correct!", "Security Message!", MessageBoxButtons.OK
                    , MessageBoxIcon.Error);
            }
            if (guna2CheckBoxRemember.Checked)//To remember Somebody
            {
                Properties.Settings.Default.UserNameSetting = guna2TextBoxUserNameLogin.Text;
                Properties.Settings.Default.PasswordSetting = guna2TextBoxPasswordLogin.Text;
                Properties.Settings.Default.Save();
            }
        }
        private void linkLabelRequest_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)// to get devicecode
        {
            guna2TextBoxDevicecode.Text = ComputerInfo.GetComputerId();
        }
        private void guna2ButtonClose_Click(object sender, EventArgs e)//to close panel avtivation
        {
            guna2ShadowPanelAvtivation.Visible = false;
        }
        private void guna2ButtonAvtiveation_Click(object sender, EventArgs e)//to avtivation program
        {
            if (guna2CheckBoxConfirmCode.Checked == true)
            {
                KeyManager km = new KeyManager(guna2TextBoxDevicecode.Text);
                string productkey = guna2TextBoxActivationcode.Text;
                if (km.ValidKey(ref productkey))
                {
                    KeyValuesClass kv = new KeyValuesClass();
                    if (km.DisassembleKey(productkey, ref kv))
                    {
                        LicenseInfo lic = new LicenseInfo();
                        lic.ProductKey = productkey;
                        lic.FullName = "personal accounting";
                        if (kv.Type == LicenseType.TRIAL)
                        {
                            lic.Day = kv.Expiration.Day;
                            lic.Month = kv.Expiration.Month;
                            lic.Year = kv.Expiration.Year;
                        }
                        km.SaveSuretyFile(string.Format(@"{0}\key.lic", Application.StartupPath), lic);
                        MessageBox.Show("Software activation was done successfully", "Message", MessageBoxButtons
                            .OK, MessageBoxIcon.Information);
                        guna2ShadowPanelAvtivation.Visible = false;
                        guna2ShadowPanelRegister.Visible = true;
                    }
                }
                else
                    MessageBox.Show("The activation code is invalid", "Security Message!", MessageBoxButtons
                            .OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Confirm the information and try again", "Security Message!", MessageBoxButtons.OK
                       , MessageBoxIcon.Error);
        }
        private void guna2TextBoxNameAndFamilyRegister_KeyDown(object sender, KeyEventArgs e)//for register panel
        {
            if (e.KeyCode == Keys.Enter)
            {
                guna2TextBoxPhoneNumberRegister.Focus();
            }
        }
        private void guna2TextBoxPhoneNumberRegister_KeyDown(object sender, KeyEventArgs e)//for register panel
        {
            if (e.KeyCode == Keys.Enter)
            {
                guna2TextBoxEmailRegister.Focus();
            }
        }
        private void guna2TextBoxEmailRegister_KeyDown(object sender, KeyEventArgs e)//for register panel
        {
            if (e.KeyCode == Keys.Enter)
            {
                guna2TextBoxUserNameRegister.Focus();
            }
        }
        private void guna2TextBoxUserNameRegister_KeyDown(object sender, KeyEventArgs e)//for register panel
        {
            if (e.KeyCode == Keys.Enter)
            {
                guna2TextBoxPasswordRegister.Focus();
            }
        }
        private void guna2TextBoxPasswordRegister_KeyDown(object sender, KeyEventArgs e)//for register panel
        {
            if (e.KeyCode == Keys.Enter)
            {
                guna2TextBoxRepeatpasswordRegister.Focus();
            }
        }
        private void guna2TextBoxRepeatpasswordRegister_KeyDown(object sender, KeyEventArgs e)//for register somebody with enter
        {
            if (guna2TextBoxPasswordRegister.Text == guna2TextBoxRepeatpasswordRegister.Text)
            {
                t.NameAndFamily = guna2TextBoxNameAndFamilyRegister.Text;
                t.Mobile = guna2TextBoxPhoneNumberRegister.Text;
                t.Email = guna2TextBoxEmailRegister.Text;
                t.UserName = guna2TextBoxUserNameRegister.Text;
                t.Password = guna2TextBoxPasswordRegister.Text;
                bll.Register(t);
                Properties.Settings.Default.RememberUNSetting = guna2TextBoxUserNameRegister.Text;
                Properties.Settings.Default.RememberPDSetting = guna2TextBoxPasswordRegister.Text;
                Properties.Settings.Default.RememberPNSetting = guna2TextBoxPhoneNumberRegister.Text;
                Properties.Settings.Default.RememberNameSetting = guna2TextBoxNameAndFamilyRegister.Text;
                Properties.Settings.Default.RememberEMSetting = guna2TextBoxEmailRegister.Text;
                Properties.Settings.Default.Save();
                MessageBox.Show("Account created successfully", "Message", MessageBoxButtons
                        .OK, MessageBoxIcon.Information);
                linkLabelActivation.Visible = false;
                guna2ShadowPanelRegister.Visible = false;
            }
            else
                MessageBox.Show("The password is not valid", "Security Message!", MessageBoxButtons
                        .OK, MessageBoxIcon.Error);
        }
        private void guna2ButtonRegister_Click(object sender, EventArgs e)//for register somebody with button
        {
            if (guna2TextBoxPasswordRegister.Text == guna2TextBoxRepeatpasswordRegister.Text)
            {
                t.NameAndFamily = guna2TextBoxNameAndFamilyRegister.Text;
                t.Mobile = guna2TextBoxPhoneNumberRegister.Text;
                t.Email = guna2TextBoxEmailRegister.Text;
                t.UserName = guna2TextBoxUserNameRegister.Text;
                t.Password = guna2TextBoxPasswordRegister.Text;
                bll.Register(t);
                Properties.Settings.Default.RememberUNSetting = guna2TextBoxUserNameRegister.Text;
                Properties.Settings.Default.RememberPDSetting = guna2TextBoxPasswordRegister.Text;
                Properties.Settings.Default.RememberPNSetting = guna2TextBoxPhoneNumberRegister.Text;
                Properties.Settings.Default.RememberNameSetting = guna2TextBoxNameAndFamilyRegister.Text;
                Properties.Settings.Default.RememberEMSetting = guna2TextBoxEmailRegister.Text;
                Properties.Settings.Default.Save();
                MessageBox.Show("Account created successfully", "Message", MessageBoxButtons
                        .OK, MessageBoxIcon.Information);
                linkLabelActivation.Visible = false;
                guna2ShadowPanelRegister.Visible = false;
            }
            else
                MessageBox.Show("The password is not valid", "Security Message!", MessageBoxButtons
                        .OK, MessageBoxIcon.Error);
        }
        private void guna2ButtonClose3_Click(object sender, EventArgs e)//for close register panel
        {
            guna2ShadowPanelAvtivation.Visible = false;
                guna2ShadowPanelRegister.Visible = false;
                     guna2ShadowPanelPasswordrecovery.Visible = false;
        }
        private void guna2TextBoxPhoneNumberRecovery_KeyDown(object sender, KeyEventArgs e)//for recovery panel
        {
            if (e.KeyCode == Keys.Enter)
            {
                guna2TextBoxEmailRicovery.Focus();
            }
        }
        private void guna2TextBoxEmailRicovery_KeyDown(object sender, KeyEventArgs e)//to recovery password with enter
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (guna2CheckBoxConfirmRecovery.Checked == true)
                {
                    if (bll.Exist(guna2TextBoxPhoneNumberRecovery.Text, guna2TextBoxEmailRicovery.Text) == true)
                    {
                        if (Properties.Settings.Default.RememberPNSetting != string.Empty)
                        {
                            if (MessageBox.Show("Your Password is (" + Properties.Settings.Default.RememberPDSetting + ")", "Security Message!",
                                MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                            {
                                guna2TextBoxPhoneNumberRecovery.Clear();
                                guna2TextBoxEmailRicovery.Clear();
                                guna2ShadowPanelPasswordrecovery.Visible = false;
                            }
                        }
                    }
                    else
                        MessageBox.Show("The information entered is not correct", "Security Message!", MessageBoxButtons.OK
                            , MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("Confirm the information and try again", "Security Message!", MessageBoxButtons.OK
                           , MessageBoxIcon.Error);
            }
        }
        private void guna2ButtonRecovery_Click(object sender, EventArgs e)// to recover password with button
        {
            if (guna2CheckBoxConfirmRecovery.Checked == true)
            {
                if (bll.Exist(guna2TextBoxPhoneNumberRecovery.Text, guna2TextBoxEmailRicovery.Text) == true)
                {
                    if (Properties.Settings.Default.RememberPNSetting != string.Empty)
                    {
                        if (MessageBox.Show("Your Password is (" + Properties.Settings.Default.RememberPDSetting + ")", "Security Message!",
                            MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                        {
                            guna2TextBoxPhoneNumberRecovery.Clear();
                            guna2TextBoxEmailRicovery.Clear();
                            guna2ShadowPanelPasswordrecovery.Visible = false;
                            guna2CheckBoxConfirmRecovery.Checked = false;
                        }
                    }
                }
                else
                    MessageBox.Show("The information entered is not correct", "Security Message!", MessageBoxButtons.OK
                        , MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Confirm the information and try again", "Security Message!", MessageBoxButtons.OK
                       , MessageBoxIcon.Error);
        }
        private void guna2Button1_Click(object sender, EventArgs e)//for close panel recovery
        {
            guna2ShadowPanelPasswordrecovery.Visible = false;
        }

        private void linkLabelActivation_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            guna2ShadowPanelAvtivation.Visible = true;
        }
        private void labelXShowAndHide_MouseMove(object sender, MouseEventArgs e)//show password
        {
            guna2TextBoxPasswordLogin.PasswordChar = '\0';
            labelXShowAndHide.Symbol = "59637";
        }
        private void labelXShowAndHide_MouseLeave(object sender, EventArgs e)//hide password
        {
            guna2TextBoxPasswordLogin.PasswordChar = '•';
            labelXShowAndHide.Symbol = "59636";
        }
        private void FormLogin_Load_1(object sender, EventArgs e)//cheked the infromiton
        {
            if (bll.Login("", "") == 0)
            {
                linkLabelActivation.Visible = true;
            }
            else
            {
                linkLabelActivation.Visible = false;
            }
            if (Properties.Settings.Default.UserNameSetting != string.Empty)
            {
                guna2TextBoxUserNameLogin.Text = Properties.Settings.Default.UserNameSetting;
                guna2TextBoxPasswordLogin.Text = Properties.Settings.Default.PasswordSetting;
            }
        }
        private void guna2ButtonExit_Click(object sender, EventArgs e)//to exit of program
        {
            if (MessageBox.Show("Do you want to exit the software?", "Message", MessageBoxButtons.YesNo
          , MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
