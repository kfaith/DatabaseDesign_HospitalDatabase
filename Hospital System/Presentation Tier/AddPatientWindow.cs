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
    public partial class AddPatientWindow : Form
    {
        DBmanager dbm;
        public AddPatientWindow()
        {
            dbm = new DBmanager();
            InitializeComponent();
        }

        private void addPatientButton_Click(object sender, EventArgs e)
        {
            dbm.addPatient(firstNameTextBox.Text, lastNameTextBox.Text, Int16.Parse(ageTextBox.Text), emailTextBox.Text, 
                phoneTextBox.Text, dbm.addMedicalHistory(pastIllnessTextBox.Text, allergiesTextBox.Text, medicationsTextBox.Text));

            this.Dispose();
        }
    }
}
