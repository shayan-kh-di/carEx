using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using BLL;
using BE;

namespace CarExhibition.Forms
{
    public partial class FormMenu : Form
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
        public FormMenu()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 32, 32));
        }
        private void labelXShowPeofile_Click(object sender, EventArgs e)
        {
            FormProfile ff = new FormProfile();
            ff.Show();
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("برای خروج از نرم افزار اطمینان دارید", "پیغام", MessageBoxButtons.YesNo
            , MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        private void guna2ButtonNewCarArrival_Click(object sender, EventArgs e)
        {
            FormCarArrival fc = new FormCarArrival();
            fc.Show();
        }
        public void DGVPersian12()//برای فارسی کردن فیلد های دیتاگریدویو
        {
            dataGridViewX1.ClearSelection();
            dataGridViewX1.Columns["id"].Visible = false;
            dataGridViewX1.Columns["adrees"].HeaderText = "آدرس"; dataGridViewX1.Columns["adrees"].Width = 180;
            dataGridViewX1.Columns["code"].HeaderText = "کد سیستمی"; dataGridViewX1.Columns["code"].Width = 68;
            dataGridViewX1.Columns["codemeli"].HeaderText = "کدملی";
            dataGridViewX1.Columns["color"].HeaderText = "رنگ"; dataGridViewX1.Columns["color"].Width = 60;
            dataGridViewX1.Columns["email"].HeaderText = "ایمیل"; dataGridViewX1.Columns["email"].Width = 150;
            dataGridViewX1.Columns["model"].HeaderText = "مدل"; dataGridViewX1.Columns["model"].Width = 55;
            dataGridViewX1.Columns["type"].HeaderText = "نوع خودرو"; dataGridViewX1.Columns["type"].Width = 80;
            dataGridViewX1.Columns["user"].HeaderText = "کاربری"; dataGridViewX1.Columns["user"].Width = 55;
            dataGridViewX1.Columns["tamas"].HeaderText = "شماره تماس"; dataGridViewX1.Columns["tamas"].Width = 110;
            dataGridViewX1.Columns["system"].HeaderText = "سیستم"; dataGridViewX1.Columns["system"].Width = 70;
            dataGridViewX1.Columns["tip"].HeaderText = "تیپ"; dataGridViewX1.Columns["tip"].Width = 60;
            dataGridViewX1.Columns["sookht"].HeaderText =  "سوخت"; dataGridViewX1.Columns["sookht"].Width = 65;
            dataGridViewX1.Columns["name"].HeaderText = "نام"; dataGridViewX1.Columns["name"].Width = 100;
        }
        public void DGVPersian1()
        {
            dataGridViewX1.ClearSelection();
            dataGridViewX1.Columns["id"].Visible = false;
            dataGridViewX1.Columns["Type1"].HeaderText = "نوع خودرو"; dataGridViewX1.Columns["Type1"].Width = 80;
            dataGridViewX1.Columns["System"].HeaderText = "سیستم"; dataGridViewX1.Columns["System"].Width = 60;
            dataGridViewX1.Columns["User"].HeaderText = "کاربری"; dataGridViewX1.Columns["User"].Width = 55;
            dataGridViewX1.Columns["Style"].HeaderText = "تیپ"; dataGridViewX1.Columns["Style"].Width = 60;
            dataGridViewX1.Columns["Model"].HeaderText = "مدل"; dataGridViewX1.Columns["Model"].Width = 55;
            dataGridViewX1.Columns["Color"].HeaderText = "رنگ"; dataGridViewX1.Columns["Color"].Width = 60;
            dataGridViewX1.Columns["Country"].HeaderText = "سازننده"; dataGridViewX1.Columns["Country"].Width = 45;
            dataGridViewX1.Columns["engineNumber"].HeaderText = "شماره موتور"; dataGridViewX1.Columns["engineNumber"].Width = 100;
            dataGridViewX1.Columns["PlaqueNumber"].HeaderText = "شماره پلاک"; dataGridViewX1.Columns["PlaqueNumber"].Width = 105;
            dataGridViewX1.Columns["BodyNumber"].HeaderText = "شماره شاسی"; dataGridViewX1.Columns["BodyNumber"].Width = 128;
            dataGridViewX1.Columns["Capacity"].HeaderText = "ظرفیت"; dataGridViewX1.Columns["Capacity"].Width = 45;
            dataGridViewX1.Columns["vin"].Width = 118;
            dataGridViewX1.Columns["NumberOfCylinders"].HeaderText = "سیلندر"; dataGridViewX1.Columns["NumberOfCylinders"].Width = 55;
            dataGridViewX1.Columns["NumberOfAxes"].HeaderText = "محور"; dataGridViewX1.Columns["NumberOfAxes"].Width = 52;
            dataGridViewX1.Columns["Accessories"].HeaderText = "لوازم جانبی"; dataGridViewX1.Columns["Accessories"].Width = 150;
            dataGridViewX1.Columns["MachineConDition"].HeaderText = "وضعیت"; dataGridViewX1.Columns["MachineConDition"].Width = 55;
            dataGridViewX1.Columns["Insurance"].HeaderText = "بیمه"; dataGridViewX1.Columns["Insurance"].Width = 52;
            dataGridViewX1.Columns["Violation"].HeaderText = "خلافی"; dataGridViewX1.Columns["Violation"].Width = 52;
            dataGridViewX1.Columns["TLApproval"].HeaderText = "معاینه فنی"; dataGridViewX1.Columns["TLApproval"].Width = 80;
            dataGridViewX1.Columns["IdentificationCode"].HeaderText = "کدملی مالک";
            dataGridViewX1.Columns["FixedNumber"].HeaderText = "شماره مالک";
            dataGridViewX1.Columns["EmailOwner"].HeaderText = "ایمیل مالک"; dataGridViewX1.Columns["EmailOwner"].Width = 150;
            dataGridViewX1.Columns["Price"].HeaderText = "قیمت معامله";
            dataGridViewX1.Columns["pricematn"].HeaderText = "قیمت معامله"; dataGridViewX1.Columns["pricematn"].Width = 165;
            dataGridViewX1.Columns["TransactionDate"].HeaderText = "تاریخ معامله"; dataGridViewX1.Columns["TransactionDate"].Width = 95;
            dataGridViewX1.Columns["Fuel"].HeaderText = "سوخت"; dataGridViewX1.Columns["Fuel"].Width = 65;
            dataGridViewX1.Columns["sellmobile"].HeaderText = "تماس خریدار"; dataGridViewX1.Columns["sellmobile"].Width = 111;
            dataGridViewX1.Columns["sellemail"].HeaderText = "ایمیل خریدار"; dataGridViewX1.Columns["sellemail"].Width = 150;
            dataGridViewX1.Columns["sellname"].HeaderText = "نام خریدار"; dataGridViewX1.Columns["sellname"].Width = 100;
            dataGridViewX1.Columns["sellcodemeli"].HeaderText = "کدملی خریدار";
            dataGridViewX1.Columns["madarek"].HeaderText = "مدارک"; dataGridViewX1.Columns["madarek"].Width = 135;
            dataGridViewX1.Columns["pprice"].HeaderText = "قیمت خودرو";
            dataGridViewX1.Columns["ppricematn"].HeaderText = "قیمت خودرو"; dataGridViewX1.Columns["ppricematn"].Width = 165;
            dataGridViewX1.Columns["moshincode"].HeaderText = "کد سیستمی"; dataGridViewX1.Columns["moshincode"].Width = 68;
            dataGridViewX1.Columns["Carowner"].HeaderText =  "نام مالک"; dataGridViewX1.Columns["Carowner"].Width = 100;
        }
        public void DGVPersian()
        {
            dataGridViewX1.ClearSelection();
            dataGridViewX1.Columns["id"].Visible = false;
            dataGridViewX1.Columns["Type"].HeaderText = "نوع خودرو";  dataGridViewX1.Columns["Type"].Width = 80;
            dataGridViewX1.Columns["System"].HeaderText = "سیستم";  dataGridViewX1.Columns["System"].Width = 60;
            dataGridViewX1.Columns["User"].HeaderText = "کاربری"; dataGridViewX1.Columns["User"].Width = 55;
            dataGridViewX1.Columns["Style"].HeaderText = "سازنده"; dataGridViewX1.Columns["Style"].Width = 60;
            dataGridViewX1.Columns["Model"].HeaderText = "مدل"; dataGridViewX1.Columns["Model"].Width = 55;
            dataGridViewX1.Columns["Color"].HeaderText = "رنگ"; dataGridViewX1.Columns["Color"].Width = 60;
            dataGridViewX1.Columns["Country"].HeaderText = "تیپ"; dataGridViewX1.Columns["Country"].Width = 45;
            dataGridViewX1.Columns["Capacity"].HeaderText = "ظرفیت"; dataGridViewX1.Columns["Capacity"].Width = 45;
            dataGridViewX1.Columns["engineNumber"].HeaderText = "شماره موتور"; dataGridViewX1.Columns["engineNumber"].Width = 100;
            dataGridViewX1.Columns["PlaqueNumber"].HeaderText = "شماره پلاک"; dataGridViewX1.Columns["PlaqueNumber"].Width = 105;
            dataGridViewX1.Columns["BodyNumber"].HeaderText = "شماره شاسی"; dataGridViewX1.Columns["BodyNumber"].Width = 128;
            dataGridViewX1.Columns["vin"].Width = 118;
            dataGridViewX1.Columns["NumberOfCylinders"].HeaderText = "سیلندر"; dataGridViewX1.Columns["NumberOfCylinders"].Width = 55;
            dataGridViewX1.Columns["NumberOfAxes"].HeaderText = "محور"; dataGridViewX1.Columns["NumberOfAxes"].Width = 52;
            dataGridViewX1.Columns["Accessories"].HeaderText = "لوازم جانبی"; dataGridViewX1.Columns["Accessories"].Width = 150;
            dataGridViewX1.Columns["MachineConDition"].HeaderText = "وضعیت"; dataGridViewX1.Columns["MachineConDition"].Width = 55;
            dataGridViewX1.Columns["Insurance"].HeaderText = "بیمه"; dataGridViewX1.Columns["Insurance"].Width = 52;
            dataGridViewX1.Columns["Violation"].HeaderText = "خلافی"; dataGridViewX1.Columns["Violation"].Width = 52;
            dataGridViewX1.Columns["TLApproval"].HeaderText = "معاینه فنی"; dataGridViewX1.Columns["TLApproval"].Width = 80;
            dataGridViewX1.Columns["MachineCode"].HeaderText = "کد سیستمی"; dataGridViewX1.Columns["MachineCode"].Width = 68;
            dataGridViewX1.Columns["CarOwner"].HeaderText = "نام مالک"; dataGridViewX1.Columns["CarOwner"].Width = 100;
            dataGridViewX1.Columns["IdentificationCode"].HeaderText = "کدملی مالک";
            dataGridViewX1.Columns["FixedNumber"].HeaderText = "شماره مالک";
            dataGridViewX1.Columns["EmailOwner"].HeaderText = "ایمیل مالک"; dataGridViewX1.Columns["EmailOwner"].Width = 150;
            dataGridViewX1.Columns["Price"].HeaderText = "قیمت";
            dataGridViewX1.Columns["PaymentType"].HeaderText = "نوع پرداخت"; dataGridViewX1.Columns["PaymentType"].Width = 85;
            dataGridViewX1.Columns["PaymentSteps"].HeaderText = "تعداد پرداخت"; dataGridViewX1.Columns["PaymentSteps"].Width = 100;
            dataGridViewX1.Columns["TransactionDate"].HeaderText = "تاریخ ورود"; dataGridViewX1.Columns["TransactionDate"].Width = 85;
            dataGridViewX1.Columns["Fuel"].HeaderText = "سوخت"; dataGridViewX1.Columns["Fuel"].Width = 55;
            dataGridViewX1.Columns["madarek"].HeaderText = "مدارک"; dataGridViewX1.Columns["madarek"].Width = 135;
            dataGridViewX1.Columns["pricemetn"].HeaderText = "قیمت خودرو"; dataGridViewX1.Columns["pricemetn"].Width = 165;
        }
        private void guna2ButtonSellingNewCar_Click(object sender, EventArgs e)
        {
            FormSellCar f = new FormSellCar();
            f.Show();
        }
        private void FormMenu_Load_1(object sender, EventArgs e)
        {
            PersianCalendar pc = new PersianCalendar();
            labelTarikh.Text = pc.GetYear(DateTime.Now) + " / " + pc.GetMonth(DateTime.Now) + " / " + pc.GetDayOfMonth(DateTime.Now
                    ).ToString();
            BLL.BLLS.BLL_NewCarArrival bll = new BLL.BLLS.BLL_NewCarArrival();
            dataGridViewX1.DataSource = null;
            dataGridViewX1.DataSource = bll.ReadAll();
            DGVPersian();
            guna2.Visible = false;
            dataGridViewX1.Rows[1].DefaultCellStyle.BackColor = Color.Cyan;
            guna2PictureBoxDelete.Visible = true;
            guna2PictureBoxDelete2.Visible = false;
            guna2PictureBoxdelet3.Visible = false;
        }
        private void guna2ButtonRequestACar_MouseMove(object sender, MouseEventArgs e)
        {
            guna2.Visible = false;
        }
        private void guna2ButtonListOfSections_MouseMove(object sender, MouseEventArgs e)
        {
            guna2.Visible = true;
        }
        private void guna2ButtonSectionReport_MouseMove(object sender, MouseEventArgs e)
        {
            guna2.Visible = false;
        }
        private void dataGridViewX1_MouseMove(object sender, MouseEventArgs e)
        {
            guna2.Visible = false;
        }
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            BLL.BLLS.BLL_NewCarArrival bll = new BLL.BLLS.BLL_NewCarArrival();
            dataGridViewX1.DataSource = null;
            dataGridViewX1.DataSource = bll.ReadAll();
            DGVPersian();
            guna2.Visible = false;
            dataGridViewX1.Rows[1].DefaultCellStyle.BackColor = Color.Cyan;
            guna2PictureBoxDelete.Visible = true;
            guna2PictureBoxDelete2.Visible = false;
            guna2PictureBoxdelet3.Visible = false;
        }
        private void guna2Button3_Click_1(object sender, EventArgs e)
        {
            BLL.BLLS.BLL_SellCar d = new BLL.BLLS.BLL_SellCar();
            dataGridViewX1.DataSource = null;
            dataGridViewX1.DataSource = d.ReadAll();
            DGVPersian1();
            guna2.Visible = false;
            dataGridViewX1.Rows[1].DefaultCellStyle.BackColor = Color.Cyan;
            guna2PictureBoxDelete2.Visible = true;
            guna2PictureBoxDelete.Visible = false;
            guna2PictureBoxdelet3.Visible = false;
        }
        private void guna2Button4_Click(object sender, EventArgs e)
        {
            BLL.BLLS.BLL_Request bl = new BLL.BLLS.BLL_Request();
            dataGridViewX1.DataSource = null;
            dataGridViewX1.DataSource = bl.ReadAll();
            dataGridViewX1.Rows[1].DefaultCellStyle.BackColor = Color.Cyan;
            DGVPersian12();
            guna2PictureBoxdelet3.Visible = true;
            guna2PictureBoxDelete.Visible = false;
            guna2PictureBoxDelete2.Visible = false;
        }
        private void guna2ButtonRequestACar_Click(object sender, EventArgs e)
        {
            FormRequest f = new FormRequest();
            f.Show();
        }
        int id;
        private void guna2PictureBoxDelete_Click(object sender, EventArgs e)
        {
            T_NewCarArrival t = new T_NewCarArrival();
            BLL.BLLS.BLL_NewCarArrival b = new BLL.BLLS.BLL_NewCarArrival();
            b.Delete(t ,id);
            dataGridViewX1.DataSource = null;
            dataGridViewX1.DataSource = b.ReadAll();
            DGVPersian();
            dataGridViewX1.Rows[1].DefaultCellStyle.BackColor = Color.Cyan;
        }
        private void dataGridViewX1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = (int)dataGridViewX1.Rows[e.RowIndex].Cells[0].Value;
        }
        private void guna2PictureBoxDelete2_Click(object sender, EventArgs e)
        {
            T_SellCar t = new T_SellCar();
            BLL.BLLS.BLL_SellCar b = new BLL.BLLS.BLL_SellCar();
            b.Delete(t, id);
            dataGridViewX1.DataSource = null;
            dataGridViewX1.DataSource = b.ReadAll();
            DGVPersian1();
            dataGridViewX1.Rows[1].DefaultCellStyle.BackColor = Color.Cyan;
        }
        private void guna2PictureBoxdelet3_Click(object sender, EventArgs e)
        {
            T_Request t = new T_Request();
            BLL.BLLS.BLL_Request b = new BLL.BLLS.BLL_Request();
            b.Delete(t, id);
            dataGridViewX1.DataSource = null;
            dataGridViewX1.DataSource = b.ReadAll();
            DGVPersian12();
            dataGridViewX1.Rows[1].DefaultCellStyle.BackColor = Color.Cyan;
        }
    }
}        