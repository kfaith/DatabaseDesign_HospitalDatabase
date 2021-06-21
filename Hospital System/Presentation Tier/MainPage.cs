using System;
using System.Data;
using System.Windows.Forms;

namespace Hospital_System.Presentation_Tier
{
    public partial class MainPage : Form
    {
        private AddAppointmentWindow addAppointment;
        private AddPatientWindow addPatient;
        private UpdatePatientWindow updatePatient;
        private DBmanager dbm;
        private DataTable appointmentTable;
        private DataTable patientTable;
        private DataTable inventoryTable;
        private string[] origValues = new string[4];
        public MainPage()
        {
            InitializeComponent();
            this.dbm = new DBmanager();

            appointmentTable = dbm.fillAppointmentTable();
            appointmentGridView.DataSource = appointmentTable;
            appointmentGridView.DataMember = appointmentTable.TableName;

            patientTable = dbm.fillPatientTable();
            patientGridView.DataSource = patientTable;
            patientGridView.DataMember = patientTable.TableName;

            inventoryTable = dbm.fillInventoryTable();
            inventoryDataGrid.DataSource = inventoryTable;
            inventoryDataGrid.DataMember = inventoryTable.TableName;

            addAppointment = new AddAppointmentWindow();
            addPatient = new AddPatientWindow();
        }

        /*
         * Fill the appointment table with all appointments ordered by time 
         */
        private void viewAppointmentsButton_Click(object sender, EventArgs e)
        {
            appointmentTable = dbm.fillAppointmentTable();
            appointmentGridView.DataSource = appointmentTable;
            appointmentGridView.DataMember = appointmentTable.TableName;
        }

        private void viewPatientsAllButton_Click(object sender, EventArgs e)
        {
            patientTable = dbm.fillPatientTable();
            patientGridView.DataSource = patientTable;
            patientGridView.DataMember = patientTable.TableName;
        }

        private void patientSearchButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(lastNameTextBox.Text) && !String.IsNullOrEmpty(firstNameTextBox.Text))
                patientTable = dbm.fillPatientTableByName(firstNameTextBox.Text, "");
            else if (String.IsNullOrEmpty(firstNameTextBox.Text) && !String.IsNullOrEmpty(lastNameTextBox.Text))
                patientTable = dbm.fillPatientTableByName("", lastNameTextBox.Text);
            else
                patientTable = dbm.fillPatientTableByName(firstNameTextBox.Text, lastNameTextBox.Text);

            patientGridView.DataSource = patientTable;
            patientGridView.DataMember = patientTable.TableName;
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            updatePatient = new UpdatePatientWindow(patientGridView.SelectedRows[0].Cells["First Name"].Value.ToString(), patientGridView.SelectedRows[0].Cells["Last Name"].Value.ToString(),
                patientGridView.SelectedRows[0].Cells["Email"].Value.ToString(), patientGridView.SelectedRows[0].Cells["Phone #"].Value.ToString());
            updatePatient.ShowDialog();

            patientTable = dbm.fillPatientTable();
            patientGridView.DataSource = patientTable;
            patientGridView.DataMember = patientTable.TableName;
        }

        private void MainPage_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime date = dateTimePicker1.Value;

            appointmentTable = dbm.fillAppointmentTableByDate(date);
            appointmentGridView.DataSource = appointmentTable;
            appointmentGridView.DataMember = appointmentTable.TableName;
        }

        private void inventoryFillButton_Click(object sender, EventArgs e)
        {
            inventoryTable = dbm.fillInventoryTable();
            inventoryDataGrid.DataSource = inventoryTable;
            inventoryDataGrid.DataMember = inventoryTable.TableName;

            if (!String.IsNullOrEmpty(itemTextBox.Text))
                itemTextBox.Text = "";
            if (!String.IsNullOrEmpty(vendorTextBox.Text))
                vendorTextBox.Text = "";
        }

        private void MainPage_Load(object sender, EventArgs e)
        {

        }

        private void addToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
            addAppointment.ShowDialog();

            appointmentTable = dbm.fillAppointmentTable();
            appointmentGridView.DataSource = appointmentTable;
            appointmentGridView.DataMember = appointmentTable.TableName;

        }

        private void exitApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void appointmentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
        }

        private void patientsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
        }

        private void itemTextBox_TextChanged(object sender, EventArgs e)
        {
            inventoryTable = dbm.fillInventoryTableSearch(itemTextBox.Text, vendorTextBox.Text);

            inventoryDataGrid.DataSource = inventoryTable;
            inventoryDataGrid.DataMember = inventoryTable.TableName;
        }

        private void vendorTextBox_TextChanged(object sender, EventArgs e)
        {
            inventoryTable = dbm.fillInventoryTableSearch(itemTextBox.Text, vendorTextBox.Text);

            inventoryDataGrid.DataSource = inventoryTable;
            inventoryDataGrid.DataMember = inventoryTable.TableName;
        }

        private void itemTextBox_TextChanged_1(object sender, EventArgs e)
        {
            inventoryTable = dbm.fillInventoryTableSearch(itemTextBox.Text, vendorTextBox.Text);

            inventoryDataGrid.DataSource = inventoryTable;
            inventoryDataGrid.DataMember = inventoryTable.TableName;
        }

        private void firstNameTextBox_TextChanged(object sender, EventArgs e)
        {
            patientTable = dbm.fillPatientTableByName(firstNameTextBox.Text, lastNameTextBox.Text);

            patientGridView.DataSource = patientTable;
            patientGridView.DataMember = patientTable.TableName;
        }

        private void lastNameTextBox_TextChanged(object sender, EventArgs e)
        {
            patientTable = dbm.fillPatientTableByName(firstNameTextBox.Text, lastNameTextBox.Text);

            patientGridView.DataSource = patientTable;
            patientGridView.DataMember = patientTable.TableName;
        }


        // Add a patient button
        private void patientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
            addPatient.ShowDialog();

            patientTable = dbm.fillPatientTable();
            patientGridView.DataSource = patientTable;
            patientGridView.DataMember = patientTable.TableName;
        }

        private void deleteAppointmentButton_Click(object sender, EventArgs e)
        {
            int appointmentID = (int)appointmentGridView.CurrentRow.Cells["Appointment ID"].Value;

            dbm.deleteAppointmentByID(appointmentID);

            appointmentTable = dbm.fillAppointmentTable();
            appointmentGridView.DataSource = appointmentTable;
            appointmentGridView.DataMember = appointmentTable.TableName;
        }

        private void incrementButton_Click(object sender, EventArgs e)
        {
            string currentCell = inventoryDataGrid.CurrentCell.Value.ToString();
            int amount = (int)adjustSelecter.Value;
            dbm.updateInventoryQuantity(amount, currentCell, 1);
            dbm.fillInventoryTable();

            inventoryTable = dbm.fillInventoryTable();
            inventoryDataGrid.DataSource = inventoryTable;
            inventoryDataGrid.DataMember = inventoryTable.TableName;
        }

        private void decrementButton_Click(object sender, EventArgs e)
        {
            string currentCell = inventoryDataGrid.CurrentCell.Value.ToString();
            int amount = (int)adjustSelecter.Value;
            dbm.updateInventoryQuantity(amount, currentCell, 2);

            inventoryTable = dbm.fillInventoryTable();
            inventoryDataGrid.DataSource = inventoryTable;
            inventoryDataGrid.DataMember = inventoryTable.TableName;
        }

        private void patientGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (patientGridView.SelectedCells.Count == 5)
            {
                string fname = patientGridView.SelectedCells[1].Value.ToString();
                string lname = patientGridView.SelectedCells[0].Value.ToString();
                string email = patientGridView.SelectedCells[3].Value.ToString();
                string phone = patientGridView.SelectedCells[4].Value.ToString();

                string[] data = dbm.fillMedicalHistory(fname, lname, email, phone);

                illnessTextBox.Text = data[0];
                allergiesTextBox.Text = data[1];
                medicationsTextBox.Text = data[2];
            }
        }
    }
}
