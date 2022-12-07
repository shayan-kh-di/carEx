using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        private void guna2ButtonNewCarArrival_MouseMove(object sender, MouseEventArgs e)
        {
            guna2ButtonNewCarArrival.FillColor = Color.Blue;
            labelXNewCarArrival.BackColor = Color.Blue;
        }
        private void labelXNewCarArrival_MouseMove(object sender, MouseEventArgs e)
        {
            guna2ButtonNewCarArrival.FillColor = Color.Blue;
            labelXNewCarArrival.BackColor = Color.Blue;
        }
        private void guna2ButtonNewCarArrival_MouseLeave(object sender, EventArgs e)
        {
            guna2ButtonNewCarArrival.FillColor = Color.FromArgb(26, 32, 40);
            labelXNewCarArrival.BackColor = Color.FromArgb(26, 32, 40);
        }
        private void labelXNewCarArrival_MouseLeave(object sender, EventArgs e)
        {
            guna2ButtonNewCarArrival.FillColor = Color.FromArgb(26, 32, 40);
            labelXNewCarArrival.BackColor = Color.FromArgb(26, 32, 40);
        }
        private void guna2ButtonSellingNewCar_MouseMove(object sender, MouseEventArgs e)
        {
            guna2ButtonSellingNewCar.FillColor = Color.Blue;
            labelXSellingNewCar.BackColor = Color.Blue;
        }
        private void labelXSellingNewCar_MouseMove(object sender, MouseEventArgs e)
        {
            guna2ButtonSellingNewCar.FillColor = Color.Blue;
            labelXSellingNewCar.BackColor = Color.Blue;
        }
        private void labelXSellingNewCar_MouseLeave(object sender, EventArgs e)
        {
            guna2ButtonSellingNewCar.FillColor = Color.FromArgb(26, 32, 40);
            labelXSellingNewCar.BackColor = Color.FromArgb(26, 32, 40);
        }
        private void guna2ButtonSellingNewCar_MouseLeave(object sender, EventArgs e)
        {
            guna2ButtonSellingNewCar.FillColor = Color.FromArgb(26, 32, 40);
            labelXSellingNewCar.BackColor = Color.FromArgb(26, 32, 40);
        }

        private void guna2ButtonRequestACar_MouseMove(object sender, MouseEventArgs e)
        {
            guna2ButtonRequestACar.FillColor = Color.Blue;
            labelXRequestACar.BackColor = Color.Blue;
        }
        private void labelXRequestACar_MouseMove(object sender, MouseEventArgs e)
        {
            guna2ButtonRequestACar.FillColor = Color.Blue;
            labelXRequestACar.BackColor = Color.Blue;
        }
        private void labelXRequestACar_MouseLeave(object sender, EventArgs e)
        {
            guna2ButtonRequestACar.FillColor = Color.FromArgb(26, 32, 40);
            labelXRequestACar.BackColor = Color.FromArgb(26, 32, 40);
        }
        private void guna2ButtonRequestACar_MouseLeave(object sender, EventArgs e)
        {
            guna2ButtonRequestACar.FillColor = Color.FromArgb(26, 32, 40);
            labelXRequestACar.BackColor = Color.FromArgb(26, 32, 40);
        }
        private void guna2ButtonListOfSections_MouseMove(object sender, MouseEventArgs e)
        {
            guna2ButtonListOfSections.FillColor = Color.Blue;
            labelXListOfSection.BackColor = Color.Blue;
        }
        private void labelXListOfSection_MouseMove(object sender, MouseEventArgs e)
        {
            guna2ButtonListOfSections.FillColor = Color.Blue;
            labelXListOfSection.BackColor = Color.Blue;
        }
        private void guna2ButtonListOfSections_MouseLeave(object sender, EventArgs e)
        {
            guna2ButtonListOfSections.FillColor = Color.FromArgb(26, 32, 40);
            labelXListOfSection.BackColor = Color.FromArgb(26, 32, 40);
        }
        private void labelXListOfSection_MouseLeave(object sender, EventArgs e)
        {
            guna2ButtonListOfSections.FillColor = Color.FromArgb(26, 32, 40);
            labelXListOfSection.BackColor = Color.FromArgb(26, 32, 40);
        }
        private void guna2ButtonSectionReport_MouseMove(object sender, MouseEventArgs e)
        {
            guna2ButtonSectionReport.FillColor = Color.Blue;
            labelXSectionRepot.BackColor = Color.Blue;
        }
        private void labelXSectionRepot_MouseMove(object sender, MouseEventArgs e)
        {
            guna2ButtonSectionReport.FillColor = Color.Blue;
            labelXSectionRepot.BackColor = Color.Blue;
        }
        private void guna2ButtonSectionReport_MouseLeave(object sender, EventArgs e)
        {
            guna2ButtonSectionReport.FillColor = Color.FromArgb(26, 32, 40);
            labelXSectionRepot.BackColor = Color.FromArgb(26, 32, 40);
        }
        private void labelXSectionRepot_MouseLeave(object sender, EventArgs e)
        {
            guna2ButtonSectionReport.FillColor = Color.FromArgb(26, 32, 40);
            labelXSectionRepot.BackColor = Color.FromArgb(26, 32, 40);
        }
        private void guna2ButtonSearchCars_MouseMove(object sender, MouseEventArgs e)
        {
            guna2ButtonSearchCars.FillColor = Color.Blue;
            labelXSearchCar.BackColor = Color.Blue;
        }
        private void labelXSearchCar_MouseMove(object sender, MouseEventArgs e)
        {
            guna2ButtonSearchCars.FillColor = Color.Blue;
            labelXSearchCar.BackColor = Color.Blue;
        }
        private void guna2ButtonSearchCars_MouseLeave(object sender, EventArgs e)
        {
            guna2ButtonSearchCars.FillColor = Color.FromArgb(26, 32, 40);
            labelXSearchCar.BackColor = Color.FromArgb(26, 32, 40);
        }
        private void labelXSearchCar_MouseLeave(object sender, EventArgs e)
        {
            guna2ButtonSearchCars.FillColor = Color.FromArgb(26, 32, 40);
            labelXSearchCar.BackColor = Color.FromArgb(26, 32, 40);
        }
        private void guna2ButtonSoftwareGuide_MouseMove(object sender, MouseEventArgs e)
        {
            guna2ButtonSoftwareGuide.FillColor = Color.Blue;
            labelXSoftwareGuidw.BackColor = Color.Blue;
        }
        private void labelXSoftwareGuidw_MouseMove(object sender, MouseEventArgs e)
        {
            guna2ButtonSoftwareGuide.FillColor = Color.Blue;
            labelXSoftwareGuidw.BackColor = Color.Blue;
        }
        private void labelXSoftwareGuidw_MouseLeave(object sender, EventArgs e)
        {
            guna2ButtonSoftwareGuide.FillColor = Color.FromArgb(26, 32, 40);
            labelXSoftwareGuidw.BackColor = Color.FromArgb(26, 32, 40);
        }
        private void guna2ButtonSoftwareGuide_MouseLeave(object sender, EventArgs e)
        {
            guna2ButtonSoftwareGuide.FillColor = Color.FromArgb(26, 32, 40);
            labelXSoftwareGuidw.BackColor = Color.FromArgb(26, 32, 40);
        }
        private void pictureBoxExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to exit the software?", "Message", MessageBoxButtons.YesNo
             , MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        private void labelXShowPeofile_Click(object sender, EventArgs e)
        {
            FormProfile ff = new FormProfile();
            ff.Show();
        }
    }
}
