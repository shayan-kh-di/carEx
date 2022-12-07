using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CarExhibition_BLL;
using CarExhibition_BE;
using FoxLearn.License;

namespace CarExhibition_Per
{
    public partial class FormActivion : Form
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

        public FormActivion()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 32, 32));
        }

        private void gunaButtonRegister_Click(object sender, EventArgs e)
        {
            FormRegster fr = new FormRegster();
            fr.Show();
        }

        private void pictureBoxExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormActivion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.Close();
            }
        }

        private void gunaButtonRegister_Click_1(object sender, EventArgs e)
        {
                KeyManager km = new KeyManager(gunaTextBoxCodeDastgah.Text);
                string productkey = gunaTextBoxCodeRegister.Text;
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
                        MessageBox.Show("فعال سازی نرم افزار با موفقیت انجام شد", "!پیغام", MessageBoxButtons
                            .OK, MessageBoxIcon.Information);
                        FormRegster cer = new FormRegster();
                        cer.Show();
                    }
                }
                else
                    MessageBox.Show("کد فعال سازی نامعتبر است", "!پیغام امنیتی", MessageBoxButtons
                            .OK, MessageBoxIcon.Error);
        }

        private void gunaTextBoxCodeRegister_KeyDown(object sender, KeyEventArgs e)
        {
                KeyManager km = new KeyManager(gunaTextBoxCodeDastgah.Text);
                string productkey = gunaTextBoxCodeRegister.Text;
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
                        MessageBox.Show("فعال سازی نرم افزار با موفقیت انجام شد", "!پیغام", MessageBoxButtons
                            .OK, MessageBoxIcon.Information);
                        FormRegster cer = new FormRegster();
                        cer.Show();
                    }
                }
                else
                    MessageBox.Show("کد فعال سازی نامعتبر است", "!پیغام امنیتی", MessageBoxButtons
                            .OK, MessageBoxIcon.Error);
        }

        private void FormActivion_Load(object sender, EventArgs e)
        {
            gunaTextBoxCodeDastgah.Text = ComputerInfo.GetComputerId();
        }
    }
}
