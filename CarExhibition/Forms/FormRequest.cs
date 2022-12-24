using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using BE;

namespace CarExhibition.Forms
{
    public partial class FormRequest : Form
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
        public FormRequest()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 22, 22));
        }
        BLL.BLLS.BLL_Request bll = new BLL.BLLS.BLL_Request();
        T_Request t = new T_Request();
        public void closeform()
        {
            this.Close();
        }
        private void pictureBoxExit_Click(object sender, EventArgs e)
        {
           closeform(); 
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            closeform();
        }
        private void guna2ButtonCancel_Click(object sender, EventArgs e)
        {
            closeform();
        }
        private void guna2ButtonSaveTransction_Click(object sender, EventArgs e)
        {
            t.adrees = guna2TextBoxAdress.Text;
            t.code = guna2TextBoxCode.Text;
            t.codemeli = guna2TextBoxCodemeli.Text;
            t.color = guna2TextBoxColor.Text;
            t.email = guna2TextBoxemail.Text;
            t.model = guna2NumericUpDownModel.Value.ToString();
            t.type = guna2TextBoxType.Text;
            t.user = guna2ComboBoxUser.Text;
            t.tamas = guna2TextBoxMoble.Text;
            t.system = guna2ComboBoxSystem.Text;
            t.tip = guna2TextBoxCountry.Text;
            t.sookht = guna2ComboBoxFuel.Text;
            t.name = guna2TextBoxName.Text;
            bll.register(t);
            MessageBox.Show("ثبت تقاضا با موفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
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
            if (e.KeyCode == Keys.Enter) { guna2ComboBoxSystem.Focus(); }
        }
        private void guna2ComboBoxSystem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { guna2TextBoxCountry.Focus(); }
        }
        private void guna2TextBoxCountry_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { guna2TextBoxColor.Focus(); }
        }
        private void guna2TextBoxColor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { guna2TextBoxCode.Focus(); }
        }
        private void guna2TextBoxName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { guna2TextBoxCodemeli.Focus(); }
        }
        private void guna2TextBoxCodemeli_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { guna2TextBoxMoble.Focus(); }
        }
        private void guna2TextBoxAdress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { guna2ButtonSaveTransction.Focus(); }
        }
        private void guna2TextBoxMoble_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { guna2TextBoxemail.Focus(); }
        }
        private void guna2TextBoxemail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { guna2TextBoxAdress.Focus(); }
        }
    }
}
