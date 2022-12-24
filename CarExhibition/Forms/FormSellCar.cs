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

namespace CarExhibition.Forms
{
    public partial class FormSellCar : Form
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
        public FormSellCar()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 22, 22));
        }
        BLL.BLLS.BLL_SellCar bll = new BLL.BLLS.BLL_SellCar();
        T_SellCar t = new T_SellCar();
        public void formclose()
        {
            this.Close();
        }
        private void pictureBoxExit_Click(object sender, EventArgs e)
        {
            formclose();
        }
        private void guna2ButtonCancel_Click(object sender, EventArgs e)
        {
            formclose();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            formclose();
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            formclose();
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            formclose();
        }
        private void guna2ButtonSaveTransction_Click_1(object sender, EventArgs e)
        {
            t.Type1 = guna2TextBoxType.Text;
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
            t.MachineConDition = guna2TextBoxMachineCondition.Text;
            t.Model = guna2NumericUpDownModel.Value.ToString();
            t.User = guna2ComboBoxUser.Text;
            if (radioButtonHasViolation.Checked == true) { t.Violation = "دارد"; }
            else { t.Violation = "ندارد"; }
            t.NumberOfCylinders = guna2NumericUpDownNumberOfCylinders.Value.ToString();
            t.PlaqueNumber = guna2TextBoxPlaqueNumber.Text;
            t.Price = guna2TextBoxGHeymat.Text;
            t.Style = guna2TextBoxStyla.Text;
            t.System = guna2ComboBoxSystem.Text;
            if (radioButtonHasTLApproval.Checked == true) { t.TLApproval = "دارد"; }
            else { t.TLApproval = "ندارد"; }
            t.TransactionDate = guna2TextBoxTarikhPardakht.Text;
            t.sellcodemeli = guna2TextBoxMeliKharidar.Text;
            t.sellemail = guna2TextBoxEmailKharidar.Text;
            t.sellmobile = guna2TextBoxTamasKharidar.Text;
            t.sellname = guna2TextBoxNameKharidar.Text;
            t.NumberOfAxes = guna2NumericUpDownNumberOfAxes.Value.ToString();
            t.moshincode = guna2TextBoxMachineCode.Text;
            t.madarek = guna2TextBoxadarek.Text;
            t.ppricematn = guna2TextBoxpricematn.Text;
            t.pprice = guna2TextBoxPrice.Text;
            t.ppricematn = guna2TextBoxpricematn.Text;
            t.pricematn = guna2TextBoxpricem.Text;
            t.vin = guna2TextBox1.Text;
            bll.register(t);
            MessageBox.Show("معامله خودرو با موفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
            formclose();
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
        private void guna2TextBoxCountry_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { guna2TextBoxStyla.Focus(); }
        }
        private void guna2TextBoxStyla_KeyDown(object sender, KeyEventArgs e)
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
            if (e.KeyCode == Keys.Enter) { guna2TextBox1.Focus(); }
        }
        private void guna2TextBox1_KeyDown(object sender, KeyEventArgs e)
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
            if (e.KeyCode == Keys.Enter) { guna2TextBoxadarek.Focus(); }
        }
        private void guna2TextBoxadarek_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { guna2ComboBoxPaymentType.Focus(); }
        }
        private void guna2ComboBoxPaymentType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { guna2NumericUpDownPaymentSteps.Focus(); }
        }
        private void guna2NumericUpDownPaymentSteps_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { guna2TextBoxpricematn.Focus(); }
        }
        private void guna2TextBoxNameKharidar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { guna2TextBoxMeliKharidar.Focus(); }
        }
        private void guna2TextBoxMeliKharidar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { guna2TextBoxTamasKharidar.Focus(); }
        }
        private void guna2TextBoxTamasKharidar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { guna2TextBoxEmailKharidar.Focus(); }
        }
        private void guna2TextBoxEmailKharidar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { guna2TextBoxGHeymat.Focus(); }
        }
        private void guna2TextBoxGHeymat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { guna2TextBoxpricem.Focus(); }
        }
        private void guna2TextBoxpricem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { guna2ComboBoxTypePardakht.Focus(); }
        }
        private void guna2ComboBoxTypePardakht_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { guna2TextBoxTarikhPardakht.Focus(); }
        }
        private void guna2TextBoxTarikhPardakht_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { guna2ButtonSaveTransction.Focus(); }
        }
    }
}
