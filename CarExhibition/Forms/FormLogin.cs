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

        BLL.BLLS.BLL_Login bll = new BLL.BLLS.BLL_Login();

        T_Login t = new T_Login();

        FormMenu FormMenu = new FormMenu();

        private void guna2TextBoxUserNameLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                guna2TextBoxPasswordLogin.Focus();
            }
        }

        private void guna2TextBoxPasswordLogin_KeyDown(object sender, KeyEventArgs e)//برای ورود با زدن کلید اینتر
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (bll.Login(guna2TextBoxUserNameLogin.Text, guna2TextBoxPasswordLogin.Text) == 1)
                {
                    FormMenu.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("اطلاعات وارد شده صحیح نمی باشد","پیغام امنیتی", MessageBoxButtons.OK
                        , MessageBoxIcon.Error);
                }
                if (guna2CheckBoxRemember.Checked)
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

        private void guna2ButtonLogin_Click(object sender, EventArgs e)//برای ورود به نرم افزار و چک کردن اطلاعات
        {
            if (bll.Login(guna2TextBoxUserNameLogin.Text, guna2TextBoxPasswordLogin.Text) == 1)
            {
                FormMenu.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("اطلاعات وارد شده صحیح نمی باشد", "پیغام امنیتی", MessageBoxButtons.OK
                    , MessageBoxIcon.Error);
            }
            if (guna2CheckBoxRemember.Checked)//برای انجام عملیات بخاطر سپردن
            {
                Properties.Settings.Default.UserNameSetting = guna2TextBoxUserNameLogin.Text;
                Properties.Settings.Default.PasswordSetting = guna2TextBoxPasswordLogin.Text;
                Properties.Settings.Default.Save();
            }
        }

        private void linkLabelRequest_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)// برای گرفتن کد دستگاه
        {
            guna2TextBoxDevicecode.Text = ComputerInfo.GetComputerId();
        }

        private void guna2ButtonClose_Click(object sender, EventArgs e)
        {
            guna2ShadowPanelAvtivation.Visible = false;
            guna2TextBoxDevicecode.Clear();
            guna2TextBoxActivationcode.Clear();
        }

        private void guna2ButtonAvtiveation_Click(object sender, EventArgs e)//برای فعال سازی نرم افزار
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
                        MessageBox.Show("فعال سازی نرم افزار با موفقیت انجام شد", "پیغام", MessageBoxButtons
                            .OK, MessageBoxIcon.Information);
                        guna2ShadowPanelAvtivation.Visible = false;
                        guna2ShadowPanelRegister.Visible = true;
                    }
                }
                else
                    MessageBox.Show("اخطار! کد فعال ساز نامعتبر می باشد", "پیغام امنیتی", MessageBoxButtons
                            .OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("اطلاعات را تایید و دوباره تلاش کنید", "پیغام امنیتی", MessageBoxButtons.OK
                       , MessageBoxIcon.Error);
        }

        private void guna2TextBoxNameAndFamilyRegister_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                guna2TextBoxPhoneNumberRegister.Focus();
            }
        }

        private void guna2TextBoxPhoneNumberRegister_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                guna2TextBoxEmailRegister.Focus();
            }
        }

        private void guna2TextBoxEmailRegister_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                guna2TextBoxUserNameRegister.Focus();
            }
        }

        private void guna2TextBoxUserNameRegister_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                guna2TextBoxPasswordRegister.Focus();
            }
        }

        private void guna2TextBoxPasswordRegister_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                guna2TextBoxRepeatpasswordRegister.Focus();
            }
        }

        private void guna2TextBoxRepeatpasswordRegister_KeyDown(object sender, KeyEventArgs e)//برای ایجاد حساب کاربری با کلید اینتر
        {
            if (e.KeyCode == Keys.Enter)
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
                    MessageBox.Show("حساب کاربری شما با موفقیت ایجاد شد", "پیغام", MessageBoxButtons
                            .OK, MessageBoxIcon.Information);
                    linkLabelActivation.Visible = false;
                    guna2ShadowPanelRegister.Visible = false;
                }
                else
                    MessageBox.Show("پسورد ها با هم مطابقت ندارند", "پیغام امنیتی", MessageBoxButtons
                            .OK, MessageBoxIcon.Error);
            }
        }

        private void guna2ButtonRegister_Click(object sender, EventArgs e)// برای ایجاد حساب کاربری
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
                MessageBox.Show("حساب کاربری شما با موفقیت ایجاد شد", "پیغام", MessageBoxButtons
                        .OK, MessageBoxIcon.Information);
                linkLabelActivation.Visible = false;
                guna2ShadowPanelRegister.Visible = false;
            }
            else
                MessageBox.Show("پسورد ها با هم مطابقت ندارند", "پیغام امنیتی", MessageBoxButtons
                        .OK, MessageBoxIcon.Error);
        }

        private void guna2ButtonClose3_Click(object sender, EventArgs e)
        {
            guna2ShadowPanelAvtivation.Visible = false;
                guna2ShadowPanelRegister.Visible = false;
                     guna2ShadowPanelPasswordrecovery.Visible = false;
        }

        private void guna2TextBoxPhoneNumberRecovery_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                guna2TextBoxEmailRicovery.Focus();
            }
        }

        private void guna2TextBoxEmailRicovery_KeyDown(object sender, KeyEventArgs e)// بازیابی رمز با زدن کلید اینتر
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (guna2CheckBoxConfirmRecovery.Checked == true)
                {
                    if (bll.Exist(guna2TextBoxPhoneNumberRecovery.Text, guna2TextBoxEmailRicovery.Text) == true)
                    {
                        if (Properties.Settings.Default.RememberPNSetting != string.Empty)
                        {
                            if (MessageBox.Show("پسورد شما (" + Properties.Settings.Default.RememberPDSetting + ")", "پیغام",
                                MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                            {
                                guna2TextBoxPhoneNumberRecovery.Clear();
                                guna2TextBoxEmailRicovery.Clear();
                                guna2ShadowPanelPasswordrecovery.Visible = false;
                            }
                        }
                    }
                    else
                        MessageBox.Show("اطلاعات وارد شده صحیح نمی باشد", "پیغام امنیتی", MessageBoxButtons.OK
                            , MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("اطلاعات را تایید و دوباره تلاش کنید", "پیغام امنیتی", MessageBoxButtons.OK
                           , MessageBoxIcon.Error);
            }
        }

        private void guna2ButtonRecovery_Click(object sender, EventArgs e)//برای بازیابی رمز عبور
        {
            if (guna2CheckBoxConfirmRecovery.Checked == true)
            {
                if (bll.Exist(guna2TextBoxPhoneNumberRecovery.Text, guna2TextBoxEmailRicovery.Text) == true)
                {
                    if (Properties.Settings.Default.RememberPNSetting != string.Empty)
                    {
                        if (MessageBox.Show("پسورد شما (" + Properties.Settings.Default.RememberPDSetting + ")", "پیغام امنیتی",
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
                    MessageBox.Show("اطلاعات وارد شده صحیح نمی باشد", "پیغام امنیتی", MessageBoxButtons.OK
                        , MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("اطلاعات را تایید و دوباره تلاش کنید", "پیغام امنیتی", MessageBoxButtons.OK
                       , MessageBoxIcon.Error);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            guna2ShadowPanelPasswordrecovery.Visible = false;
            guna2TextBoxPhoneNumberRecovery.Clear();
            guna2TextBoxEmailRicovery.Clear();
        }

        private void linkLabelActivation_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            guna2ShadowPanelAvtivation.Visible = true;
        }

        private void labelXShowAndHide_MouseMove(object sender, MouseEventArgs e)//نمایش پسورد
        {
            guna2TextBoxPasswordLogin.PasswordChar = '\0';
            labelXShowAndHide.Symbol = "59637";
        }

        private void labelXShowAndHide_MouseLeave(object sender, EventArgs e)//پنهان کردن پسورد
        {
            guna2TextBoxPasswordLogin.PasswordChar = '•';
            labelXShowAndHide.Symbol = "59636";
        }

        private void FormLogin_Load_1(object sender, EventArgs e)//چک کردن اطلاعات داخل دیتا برای دسترسی به فعال سازی برنامه
        {
            if (bll.Login("", "") == 0)
            {
                linkLabelActivation.Visible = true;
            }
            else
            {
                linkLabelActivation.Visible = false;
            }
            if (Properties.Settings.Default.UserNameSetting != string.Empty)// برای خواندن اطلاعات و نمایش در حال بخاطر سپردن
            {
                guna2TextBoxUserNameLogin.Text = Properties.Settings.Default.UserNameSetting;
                guna2TextBoxPasswordLogin.Text = Properties.Settings.Default.PasswordSetting;
            }
        }

        private void guna2ButtonExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("برای خروج از نرم افزار اطمینان دارید؟","پیغام", MessageBoxButtons.YesNo
          , MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void guna2TextBoxNameAndFamilyRegister_KeyPress(object sender, KeyPressEventArgs e)//وارد کردن حروف فارسی در سی شارپ
        {
            if ((e.KeyChar >= 'a' && e.KeyChar <= 'z') || (e.KeyChar >= 'A' && e.KeyChar <= 'Z') || (e.KeyChar >= '0' && e.KeyChar <= '9'))
            e.Handled = true;
        }

        private void guna2TextBoxPhoneNumberRegister_KeyPress(object sender, KeyPressEventArgs e)//وارد کردن عدد در سی شارپ
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void guna2TextBoxEmailRegister_KeyPress(object sender, KeyPressEventArgs e)//وارد کردن حروف انگلیسی در تسکت باکس
        {
            if ((e.KeyChar >= 'آ' && e.KeyChar <= 'ی'))
            e.Handled = true;
        }

        private void guna2TextBoxUserNameRegister_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 'آ' && e.KeyChar <= 'ی'))
                e.Handled = true;
        }

        private void guna2TextBoxRepeatpasswordRegister_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 'آ' && e.KeyChar <= 'ی'))
                e.Handled = true;
        }

        private void guna2TextBoxPasswordRegister_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 'آ' && e.KeyChar <= 'ی'))
                e.Handled = true;
        }

        private void guna2TextBoxPhoneNumberRecovery_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void guna2TextBoxEmailRicovery_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 'آ' && e.KeyChar <= 'ی'))
            e.Handled = true;
        }
    }
}
