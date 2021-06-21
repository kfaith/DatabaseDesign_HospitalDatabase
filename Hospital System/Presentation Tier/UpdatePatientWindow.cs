using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hospital_System.Presentation_Tier
{
    public partial class UpdatePatientWindow : Form
    {
        DBmanager dbm;
        private string[] origValues = new string[4];

        public UpdatePatientWindow(string fname, string lname, string email, string phone)
        {
            dbm = new DBmanager();
            InitializeComponent();

            updateFnameTextBox.Text = fname;
            updateLnameTextBox.Text = lname;
            updateEmailTextBox.Text = email;
            updatePhoneTextBox.Text = phone;

            origValues[0] = updateFnameTextBox.Text;
            origValues[1] = updateLnameTextBox.Text;
            origValues[2] = updateEmailTextBox.Text;
            origValues[3] = updatePhoneTextBox.Text;
        }


        private void updateButton_Click_1(object sender, EventArgs e)
        {
            dbm.updatePatientInfo(origValues, updateFnameTextBox.Text, updateLnameTextBox.Text, updateEmailTextBox.Text, updatePhoneTextBox.Text);
            this.Dispose();
        }

        private void patientClearButton_Click_1(object sender, EventArgs e)
        {
            updateFnameTextBox.Text = origValues[0];
            updateLnameTextBox.Text = origValues[1];
            updateEmailTextBox.Text = origValues[2];
            updatePhoneTextBox.Text = origValues[3];
        }
    }
}
