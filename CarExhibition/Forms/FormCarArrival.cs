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
using System.Globalization;

namespace CarExhibition.Forms
{
    public partial class FormCarArrival : Form
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
        public FormCarArrival()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 22, 22));
        }
        public void formclose()
        {
            this.Close();
        }
        BLL.BLLS.BLL_NewCarArrival BLL = new BLL.BLLS.BLL_NewCarArrival();
        T_NewCarArrival t = new T_NewCarArrival();
        private void guna2ButtonSaveTransction_Click(object sender, EventArgs e)
        {
            t.Accessories = guna2TextBoxAcccessories.Text;
            t.BodyNumber = guna2TextBoxBodyNumber.Text;
            t.Capacity = guna2NumericUpDownCapacity.Value.ToString();
            t.CarOwner = guna2TextBoxCarOwner.Text;
            t.Color = guna2TextBoxColor.Text;
            t.Country = guna2TextBoxCountry.Text;
            t.EmailOwner = guna2TextBoxOwnerEmail.Text;
            t.engineNumber = guna2TextBoxEngineNumber.Text;
            t.FixedNumber = guna2TextBoxFixedNumber.Text;
            t.Fuel = guna2ComboBoxFuel.Text;
            t.IdentificationCode = guna2TextBoxIdentification.Text;
            if (radioButtonHasInsurance.Checked == true) { t.Insurance = "دارد"; }
            else { t.Insurance = "ندارد"; }
            t.MachineCode = guna2TextBoxMachineCode.Text;
            t.MachineConDition = guna2TextBoxMachineCondition.Text;
            t.Model = guna2NumericUpDownModel.Value.ToString();
            t.TransactionDate = guna2TextBoxTransactionDate.Text;
            t.Type = guna2TextBoxType.Text;
            t.User = guna2ComboBoxUser.Text;
            if (radioButtonHasViolation.Checked == true) { t.Violation = "دارد"; }
            else { t.Violation = "ندارد"; }
            t.NumberOfCylinders = guna2NumericUpDownNumberOfCylinders.Value.ToString();
            t.PaymentSteps = guna2NumericUpDownPaymentSteps.Value.ToString();
            t.PaymentType = guna2ComboBoxPaymentType.Text;
            t.PlaqueNumber = guna2TextBoxPlaqueNumber.Text;
            t.Price = guna2TextBoxPrice.Text;
            t.Style = guna2TextBoxStyla.Text;
            t.System = guna2ComboBoxSystem.Text;
            if (radioButtonHasTLApproval.Checked == true) { t.TLApproval = "دارد"; }
            else { t.TLApproval = "ندارد"; }
            t.NumberOfAxes = guna2NumericUpDownNumberOfAxes.Value.ToString();
            t.pricemetn = guna2TextBoxpricematn.Text;
            t.madarek = guna2TextBoxadarek.Text;
            t.vin = guna2TextBoxvin.Text;
            BLL.NewCarArrival(t);
            MessageBox.Show("خودرو جدید با موفقیت ثبت شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
            formclose();
        }
        private void guna2ButtonCancel_Click(object sender, EventArgs e)
        {
            formclose();
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            formclose();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            formclose();
        }
        private void pictureBoxExit_Click(object sender, EventArgs e)
        {
            formclose();
        }
        private void guna2TextBoxStyla_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 'a' && e.KeyChar <= 'z') || (e.KeyChar >= 'A' && e.KeyChar <= 'Z') || (e.KeyChar >= '0' && e.KeyChar <= '9'))
                e.Handled = true;
        }
        private void guna2TextBoxMachineCondition_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 'a' && e.KeyChar <= 'z') || (e.KeyChar >= 'A' && e.KeyChar <= 'Z') || (e.KeyChar >= '0' && e.KeyChar <= '9'))
                e.Handled = true;
        }
        private void guna2TextBoxIdentification_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.') { e.Handled = true; }
        }
        private void guna2TextBoxType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { guna2ComboBoxUser.Focus(); }
        }
        private void guna2ComboBoxUser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { guna2NumericUpDownModel.Focus(); }
        }
        private void guna2NumericUpDownModel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { guna2ComboBoxFuel.Focus(); }
        }
        private void guna2ComboBoxFuel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { guna2TextBoxPlaqueNumber.Focus(); }
        }
        private void guna2TextBoxPlaqueNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { guna2ComboBoxSystem.Focus(); }
        }
        private void guna2ComboBoxSystem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { guna2TextBoxCountry.Focus(); }
        }
        private void guna2TextBoxStyla_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { guna2TextBoxStyla.Focus(); }
        }
        private void guna2TextBoxCountry_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { guna2TextBoxColor.Focus(); }
        }
        private void guna2TextBoxColor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { guna2TextBoxMachineCode.Focus(); }
        }
        private void guna2TextBoxEngineNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { guna2TextBoxBodyNumber.Focus(); }
        }
        private void guna2TextBoxBodyNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { guna2NumericUpDownNumberOfCylinders.Focus(); }
        }
        private void guna2NumericUpDownNumberOfCylinders_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { guna2NumericUpDownNumberOfAxes.Focus(); }
        }
        private void guna2NumericUpDownNumberOfAxes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { guna2TextBoxAcccessories.Focus(); }
        }
        private void guna2TextBoxAcccessories_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { guna2TextBoxvin.Focus(); }
        }
        private void guna2TextBoxvin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { guna2NumericUpDownCapacity.Focus(); }
        }
        private void guna2NumericUpDownCapacity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { guna2TextBoxMachineCondition.Focus(); }
        }
        private void guna2TextBoxCarOwner_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { guna2TextBoxIdentification.Focus(); }
        }
        private void guna2TextBoxIdentification_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { guna2TextBoxFixedNumber.Focus(); }
        }
        private void guna2TextBoxFixedNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { guna2TextBoxOwnerEmail.Focus(); }
        }
        private void guna2TextBoxOwnerEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { guna2TextBoxPrice.Focus(); }
        }
        private void guna2TextBoxPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { guna2TextBoxpricematn.Focus(); }
        }
        private void guna2TextBoxpricematn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { guna2ComboBoxPaymentType.Focus(); }
        }
        private void guna2ComboBoxPaymentType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { guna2NumericUpDownPaymentSteps.Focus(); }
        }
        private void guna2NumericUpDownPaymentSteps_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { guna2TextBoxadarek.Focus(); }
        }
        private void guna2TextBoxadarek_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { guna2TextBoxTransactionDate.Focus(); }
        }
        private void guna2TextBoxTransactionDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { guna2ButtonSaveTransction.Focus(); }
        }
    }
}
