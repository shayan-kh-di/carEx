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
    public partial class FormCarArrival : Form
    {
        public FormCarArrival()
        {
            InitializeComponent();
        }
        private void pictureBoxExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        BLL.BLLS.BLL_NewCarArrival BLL = new BLL.BLLS.BLL_NewCarArrival();
        T_NewCarArrival t = new T_NewCarArrival();
        private void guna2ButtonSaveTransction_Click(object sender, EventArgs e)
        {
            if (guna2TextBoxMachineCode.Text != null)
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
                if (radioButtonHasInsurance.Checked == true)
                {
                    t.Insurance = "Has it";
                }
                else
                {
                    t.Insurance = "Does not have it";
                }
                t.MachineCode = guna2TextBoxMachineCode.Text;
                t.MachineConDition = guna2TextBoxMachineCondition.Text;
                t.Model = guna2NumericUpDownModel.Value.ToString();
                t.TransactionDate = guna2TextBoxTransactionDate.Text;
                t.Type = guna2TextBoxType.Text;
                t.User = guna2ComboBoxUser.Text;
                if (radioButtonHasViolation.Checked == true)
                {
                    t.Violation = "Has it";
                }
                else
                {
                    t.Violation = "Does not have it";
                }
                t.NumberOfCylinders = guna2NumericUpDownNumberOfCylinders.Value.ToString();
                t.PaymentSteps = guna2NumericUpDownPaymentSteps.Value.ToString();
                t.PaymentType = guna2ComboBoxPaymentType.Text;
                t.PlaqueNumber = guna2TextBoxPlaqueNumber.Text;
                t.Price = guna2TextBoxPrice.Text;
                t.Style = guna2TextBoxStyla.Text;
                t.System = guna2ComboBoxSystem.Text;
                if (radioButtonHasTLApproval.Checked == true)
                {
                    t.TLApproval = "Has it";
                }
                else
                {
                    t.TLApproval = "Does not have it";
                }
                BLL.NewCarArrival(t);
                MessageBox.Show("The vehicle was successfully registered", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
