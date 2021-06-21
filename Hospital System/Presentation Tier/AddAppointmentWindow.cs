using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hospital_System.Presentation_Tier
{
    public partial class AddAppointmentWindow : Form
    {
        private DataTable patientTable;
        private DBmanager dbm;
        private List<string> timeList;
        private List<int> roomList;
        private List<string> doctorList;
        private List<string> symptomList;
        public AddAppointmentWindow()
        {
            dbm = new DBmanager();
            InitializeComponent();

            patientTable = dbm.fillAddAppointmentTable();
            patientSelectionTable.DataSource = patientTable;
            patientSelectionTable.DataMember = patientTable.TableName;

            timeList = new List<string>();
            fillTimes(timeList);
            timeBox.DataSource = timeList;

            roomList = new List<int>();
            fillRooms(roomList);
            roomBox.DataSource = roomList;

            doctorList = new List<string>();
            fillDoctors(doctorList);
            doctorBox.DataSource = doctorList;

            symptomList = new List<string>();
            fillSymptoms(symptomList);
            symptomBox.DataSource = symptomList;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(lastNameTextBox.Text) && !String.IsNullOrEmpty(firstNameTextBox.Text))
                patientTable = dbm.fillAddAppointmentPatientTableByName(firstNameTextBox.Text, "", 1);
            else if (String.IsNullOrEmpty(firstNameTextBox.Text) && !String.IsNullOrEmpty(lastNameTextBox.Text))
                patientTable = dbm.fillAddAppointmentPatientTableByName("", lastNameTextBox.Text, 2);
            else
                patientTable = dbm.fillAddAppointmentPatientTableByName(firstNameTextBox.Text, lastNameTextBox.Text, 3);

            patientSelectionTable.DataSource = patientTable;
            patientSelectionTable.DataMember = patientTable.TableName;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(lastNameTextBox.Text) && !String.IsNullOrEmpty(firstNameTextBox.Text))
                patientTable = dbm.fillAddAppointmentPatientTableByName(firstNameTextBox.Text, "", 1);
            else if (String.IsNullOrEmpty(firstNameTextBox.Text) && !String.IsNullOrEmpty(lastNameTextBox.Text))
                patientTable = dbm.fillAddAppointmentPatientTableByName("", lastNameTextBox.Text, 2);
            else
                patientTable = dbm.fillAddAppointmentPatientTableByName(firstNameTextBox.Text, lastNameTextBox.Text, 3);

            patientSelectionTable.DataSource = patientTable;
            patientSelectionTable.DataMember = patientTable.TableName;
        }

        // Add Appointment button was clicked
        private void button1_Click(object sender, EventArgs e)
        {
            if (patientSelectionTable.SelectedCells.Count == 3)
            {
                string first_name = patientSelectionTable.SelectedRows[0].Cells[1].Value.ToString();
                string last_name = patientSelectionTable.SelectedRows[0].Cells[0].Value.ToString(); ;
                string email = patientSelectionTable.SelectedRows[0].Cells[2].Value.ToString(); ;
                string doctor_name = doctorBox.Text;
                string date = dateTimePicker1.Value.ToString("yyyy-MM-dd") + " " + (DateTime.ParseExact(timeBox.Text, "hh:mm tt", CultureInfo.InvariantCulture)).ToString("HH:mm:ss");
                string symptom = symptomBox.Text;
                int room = int.Parse(roomBox.Text);

                dbm.addAppointment(first_name, last_name, email, doctor_name, date, symptom, room);

                this.Dispose();
            }
        }

        public void fillTimes(List<string> list)
        {
            list.Add(DateTime.Parse("07:00:00 AM").ToString("hh:mm tt"));
            list.Add(DateTime.Parse("08:00:00 AM").ToString("hh:mm tt"));
            list.Add(DateTime.Parse("09:00:00 AM").ToString("hh:mm tt"));
            list.Add(DateTime.Parse("10:00:00 AM").ToString("hh:mm tt"));
            list.Add(DateTime.Parse("11:00:00 AM").ToString("hh:mm tt"));
            list.Add(DateTime.Parse("12:00:00 PM").ToString("hh:mm tt"));
            list.Add(DateTime.Parse("01:00:00 PM").ToString("hh:mm tt"));
            list.Add(DateTime.Parse("02:00:00 PM").ToString("hh:mm tt"));
            list.Add(DateTime.Parse("03:00:00 PM").ToString("hh:mm tt"));
            list.Add(DateTime.Parse("04:00:00 PM").ToString("hh:mm tt"));
            list.Add(DateTime.Parse("05:00:00 PM").ToString("hh:mm tt"));
            list.Add(DateTime.Parse("06:00:00 PM").ToString("hh:mm tt"));
            list.Add(DateTime.Parse("07:00:00 PM").ToString("hh:mm tt"));
            list.Add(DateTime.Parse("08:00:00 PM").ToString("hh:mm tt"));
            list.Add(DateTime.Parse("09:00:00 PM").ToString("hh:mm tt"));
        }

        public void fillDoctors(List<string> list)
        {
            list.Add("Ahlrichs");
            list.Add("Cherry");
            list.Add("Faith");
            list.Add("Kollmann");
        }

        public void fillSymptoms(List<string> list)
        {
            list.Add("Difficulty Breathing");
            list.Add("Fever");
            list.Add("Chest Pain");
            list.Add("Stomach Ache");
        }

        public void fillRooms(List<int> list)
        {
            list.Add(101);
            list.Add(201);
            list.Add(301);
            list.Add(401);
            list.Add(501);
            list.Add(601);
        }
    }
}
