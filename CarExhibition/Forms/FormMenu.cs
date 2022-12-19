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

namespace CarExhibition.Forms
{
    public partial class FormMenu : Form
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
        public FormMenu()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;//To round the form
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 32, 32));//To round the form
        }
        private void labelXShowPeofile_Click(object sender, EventArgs e)
        {
            FormProfile ff = new FormProfile();
            ff.Show();
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("آیا قصد خروج از نرم افزار را دارید", "پیغام", MessageBoxButtons.YesNo
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
        public void DGVPersian()
        {
            dataGridViewX1.ClearSelection();
            dataGridViewX1.Columns["id"].Visible = false;
            dataGridViewX1.Columns["Type"].HeaderText = "نوع";
            dataGridViewX1.Columns["System"].HeaderText = "سیستم";
            dataGridViewX1.Columns["User"].HeaderText = "کاربری";
            dataGridViewX1.Columns["Style"].HeaderText = "تیپ";
            dataGridViewX1.Columns["Model"].HeaderText = "مدل";
            dataGridViewX1.Columns["Color"].HeaderText = "رنگ";
            dataGridViewX1.Columns["Country"].HeaderText = "کشور";
            dataGridViewX1.Columns["Capacity"].HeaderText = "ظرفیت";
            dataGridViewX1.Columns["engineNumber"].HeaderText = "شماره موتور";
            dataGridViewX1.Columns["PlaqueNumber"].HeaderText = "شماره پلاک";
            dataGridViewX1.Columns["BodyNumber"].HeaderText = "شماره بدنه";
            dataGridViewX1.Columns["NumberOfCylinders"].HeaderText = "تعداد سیلندر";
            dataGridViewX1.Columns["NumberOfAxes"].HeaderText = "تعداد محور";
            dataGridViewX1.Columns["Accessories"].HeaderText = "لوازم جانبی";
            dataGridViewX1.Columns["MachineConDition"].HeaderText = "مشکلات";
            dataGridViewX1.Columns["Insurance"].HeaderText = "بیمه";
            dataGridViewX1.Columns["Violation"].HeaderText = "خلافی";
            dataGridViewX1.Columns["TLApproval"].HeaderText = "معاینه فنی";
            dataGridViewX1.Columns["MachineCode"].HeaderText = "کد ماشین";
            dataGridViewX1.Columns["CarOwner"].HeaderText = "نام مالک";
            dataGridViewX1.Columns["IdentificationCode"].HeaderText = "کدملی مالک";
            dataGridViewX1.Columns["FixedNumber"].HeaderText = "شماره مالک";
            dataGridViewX1.Columns["EmailOwner"].HeaderText = "ایمیل مالک";
            dataGridViewX1.Columns["Price"].HeaderText = "قیمت";
            dataGridViewX1.Columns["PaymentType"].HeaderText = "نوع پرداخت";
            dataGridViewX1.Columns["PaymentSteps"].HeaderText = "تعداد پرداخت";
            dataGridViewX1.Columns["TransactionDate"].HeaderText = "تاریخ ورود";
            dataGridViewX1.Columns["Fuel"].HeaderText = "سوخت";
        }
        private void FormMenu_Load(object sender, EventArgs e)
        {
            PersianCalendar pc = new PersianCalendar();
            labelTarikh.Text = pc.GetYear(DateTime.Now) + " / " + pc.GetMonth(DateTime.Now) + " / " + pc.GetDayOfMonth(DateTime.Now
                ).ToString();
            BLL.BLLS.BLL_NewCarArrival bll = new BLL.BLLS.BLL_NewCarArrival();
            dataGridViewX1.DataSource = null;
            dataGridViewX1.DataSource=bll.ReadAll();
            DGVPersian();
        }
    }
}
