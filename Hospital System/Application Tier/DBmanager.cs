using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hospital_System
{
    class DBmanager
    {
        private Connection conn;
        private string query;
        private MySqlCommand cmd;
        private MySqlConnection connection;
        private MySqlDataReader reader;

        public DBmanager()
        {
            conn = new Connection();
        }

        public int loginUser(string username, string password)
        {
            int isStaff = -1;

            try
            {
                conn.Open();
                query = "SELECT is_staff FROM accounts WHERE username ='" + username + "' AND password ='" + password + "'";
                reader = conn.ExecuteReader(query);

                while (reader.Read())
                {
                    isStaff = Int16.Parse(reader["is_staff"].ToString());
                }

                return isStaff;
            }
            catch
            {
                return -1;
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }
        }

        public DataTable fillAppointmentTable()
        {
            connection = new MySqlConnection(conn.toString());
            query = ("SELECT A.appointment_id AS 'Appointment ID', A.time as 'Time', P.f_name AS 'Patient First Name', " +
                            "P.l_name AS 'Patient Last Name', S.f_name AS 'Doctor First Name', S.l_name AS 'Doctor Last Name', " +
                            "symptoms.name AS 'Symptoms', A.room_num AS 'Room #'\n" + "FROM appointments A JOIN patients P ON " +
                            "A.patient_id = P.patient_id JOIN staff S ON A.doctor_id = S.staff_id JOIN symptoms ON A.symptom_id = symptoms.symptom_id\n" +
                            "ORDER BY time ASC;");
            DataTable dataTable = new DataTable();

            try
            {
                cmd = new MySqlCommand(query, connection);
                conn.Open();

                using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                {
                    da.Fill(dataTable);
                }
                return dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("An error occurred {0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return dataTable;
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }
        }

        public DataTable fillAppointmentTableByDate(DateTime date)
        {
            connection = new MySqlConnection(conn.toString());
            query = "SELECT A.appointment_id AS 'Appointment ID', A.time as 'Time', P.f_name AS 'Patient First Name', " +
                            "P.l_name AS 'Patient Last Name', S.f_name AS 'Doctor First Name', S.l_name AS 'Doctor Last Name', " +
                            "symptoms.name AS 'Symptoms', A.room_num AS 'Room #'\n" + "FROM appointments A JOIN patients P ON " +
                            "A.patient_id = P.patient_id JOIN staff S ON A.doctor_id = S.staff_id JOIN symptoms ON A.symptom_id = symptoms.symptom_id\n" +
                            "WHERE YEAR(time) = " + date.Year + " AND MONTH(time) = " + date.Month + " AND DAY(time) = " + date.Day +
                            "\nORDER BY time ASC;";

            DataTable table = new DataTable();

            try
            {
                cmd = new MySqlCommand(query, connection);
                conn.Open();

                using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                {
                    da.Fill(table);
                }
                return table;
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("An error occurred {0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return table;
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }
        }

        public DataTable fillPatientTable()
        {
            connection = new MySqlConnection(conn.toString());
            query = ("SELECT l_name AS 'Last Name', f_name AS 'First Name', age AS 'Age', email AS 'Email', phone_num AS 'Phone #' \n" +
                            "FROM patients ORDER BY l_name, f_name ASC;");
            DataTable dataTable = new DataTable();

            try
            {
                cmd = new MySqlCommand(query, connection);
                conn.Open();

                using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                {
                    da.Fill(dataTable);
                }
                return dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("An error occurred {0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return dataTable;
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }
        }

        public DataTable fillPatientTableByName(string patientFirstName, string patientLastName)
        {
            query = "SELECT l_name AS 'Last Name', f_name AS 'First Name', age AS 'Age', email AS 'Email', phone_num AS 'Phone #' \n" +
                "FROM patients WHERE f_name LIKE '" + patientFirstName + "%' AND l_name LIKE '" + patientLastName + "%'\nORDER BY l_name, f_name ASC;";
            DataTable dataTable = new DataTable();

            try
            {
                cmd = new MySqlCommand(query, connection);
                conn.Open();

                using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                {
                    da.Fill(dataTable);
                }
                return dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("An error occurred {0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return dataTable;
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }
        }

        public DataTable fillAddAppointmentTable()
        {
            connection = new MySqlConnection(conn.toString());
            query = ("SELECT l_name AS 'Last Name', f_name AS 'First Name', email AS 'Email'\n" +
                            "FROM patients ORDER BY l_name, f_name ASC;");
            DataTable dataTable = new DataTable();

            try
            {
                cmd = new MySqlCommand(query, connection);
                conn.Open();

                using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                {
                    da.Fill(dataTable);
                }
                return dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("An error occurred {0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return dataTable;
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }
        }

        public DataTable fillAddAppointmentPatientTableByName(string patientFirstName, string patientLastName, int choice)
        {
            connection = new MySqlConnection(conn.toString());
            if (choice == 1)
                query = "SELECT l_name AS 'Last Name', f_name AS 'First Name', email AS 'Email'\n" +
                            "FROM patients WHERE f_name LIKE '" + patientFirstName + "%'\nORDER BY l_name, f_name ASC;";
            else if (choice == 2)
                query = "SELECT l_name AS 'Last Name', f_name AS 'First Name', email AS 'Email'\n" +
                            "FROM patients WHERE l_name LIKE '" + patientLastName + "%'\nORDER BY l_name, f_name ASC;";
            else
                query = "SELECT l_name AS 'Last Name', f_name AS 'First Name', email AS 'Email'\n" +
                            "FROM patients WHERE f_name LIKE '" + patientFirstName + "%' AND l_name LIKE '" + patientLastName + "%'\nORDER BY l_name, f_name ASC;";
            DataTable dataTable = new DataTable();

            try
            {
                cmd = new MySqlCommand(query, connection);
                conn.Open();

                using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                {
                    da.Fill(dataTable);
                }
                return dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("An error occurred {0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return dataTable;
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }
        }

        public void updatePatientInfo(string[] key, string fname, string lname, string email, string phone)
        {
            try
            {
                conn.Open();
                MySqlDataReader reader;
                query = "UPDATE patients\nSET f_name = '" + fname + "', l_name = '" + lname + "', email = '" + email + "', phone_num = '" + phone + "'\n"
                    + "WHERE f_name = '" + key[0] + "' AND l_name = '" + key[1] + "' AND email = '" + key[2] + "';";

                reader = conn.ExecuteReader(query);
                while (reader.Read())
                {
                }
                conn.Close();
            }
            catch (Exception ex)
            {
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }
        }

        public DataTable fillInventoryTable()
        {
            connection = new MySqlConnection(conn.toString());
            query = "SELECT S.description AS 'Item', S.quantity AS 'Quantity', L.company_name AS 'Location', V.name AS 'Vendor ID'\n" +
                "FROM supplies S\nINNER JOIN locations L ON S.location_id = L.location_id\nINNER JOIN vendors V ON S.vendor_id = V.vendor_id\n" +
                "ORDER BY S.description ASC;";
            DataTable dataTable = new DataTable();

            try
            {
                cmd = new MySqlCommand(query, connection);
                conn.Open();

                using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                {
                    da.Fill(dataTable);
                }
                return dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("An error occurred {0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return dataTable;
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }
        }

        public DataTable fillInventoryTableSearch(string itemName, string vendorName)
        {
            connection = new MySqlConnection(conn.toString());
            query = "SELECT S.description AS 'Item', S.quantity AS 'Quantity', L.company_name AS 'Location', V.name AS 'Vendor ID'\n" +
                "FROM supplies S\nINNER JOIN locations L ON S.location_id = L.location_id\nINNER JOIN vendors V ON S.vendor_id = V.vendor_id\n" +
                "WHERE S.description LIKE '" + itemName + "%' AND V.name LIKE '" + vendorName + "%'\nORDER BY S.description ASC;";
            DataTable dataTable = new DataTable();

            try
            {
                cmd = new MySqlCommand(query, connection);
                conn.Open();

                using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                {
                    da.Fill(dataTable);
                }
                return dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("An error occurred {0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return dataTable;
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }
        }

        public void addAppointment(string fname, string lname, string email, string doctorName, string date, string symptom, int room)
        {
            int locationID = 1;
            int roomNum = room;

            try
            {
                conn.Open();

                int patientID = -1;
                query = "SELECT patient_id FROM patients WHERE f_name  = '" + fname + "' AND l_name = '" + lname + "' AND email = '" + email + "';";
                reader = conn.ExecuteReader(query);
                while (reader.Read())
                    patientID = Int16.Parse(reader["patient_id"].ToString());
                conn.Close();

                conn.Open();
                int doctorID = -1;
                query = "SELECT staff_id FROM staff WHERE l_name = '" + doctorName + "';";
                reader = conn.ExecuteReader(query);
                while (reader.Read())
                    doctorID = Int16.Parse(reader["staff_id"].ToString());
                conn.Close();

                conn.Open();
                int symptomID = -1;
                query = "SELECT symptom_id FROM symptoms WHERE name = '" + symptom + "';";
                reader = conn.ExecuteReader(query);
                while (reader.Read())
                    symptomID = Int16.Parse(reader["symptom_id"].ToString());
                conn.Close();

                conn.Open();
                query = "INSERT INTO appointments (patient_id, doctor_id, location_id, time, symptom_id, room_num) " +
                        "VALUES (" + patientID + ", " + doctorID + ", " + locationID + ", '" + date + "', " + symptomID + ", " + room + ");";
                reader = conn.ExecuteReader(query);
                conn.Close();
            }
            catch
            {

            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }
        }

        public void deleteAppointmentByID(int id)
        {
            try
            {
                conn.Open();
                string query = "DELETE FROM appointments WHERE appointment_id = " + id + ";";

                reader = conn.ExecuteReader(query);
                while (reader.Read())
                {
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }
        }

        public int addMedicalHistory(string pastIllness, string allergy, string medication)
        {
            int historyID = -1;
            try
            {
                conn.Open();
                query = "INSERT INTO medical_history (past_illness, allergy, medications) " +
                        "VALUES ('" + pastIllness + "', '" + allergy + "', '" + medication + "');";
                reader = conn.ExecuteReader(query);
                conn.Close();
            }

            catch
            {

            }

            try
            {
                conn.Open();
                query = "SELECT history_id FROM medical_history WHERE past_illness = '" + pastIllness + "' "
                    + "AND allergy = '" + allergy + "' AND medications = '" + medication + "';";
                reader = conn.ExecuteReader(query);
                while (reader.Read())
                    historyID = Int16.Parse(reader["history_id"].ToString());
                conn.Close();

                return historyID;
            }

            catch
            {
                return historyID;
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }
        }


        public void addPatient(string fname, string lname, int age, string email, string phone, int medicalID)
        {
            try
            {
                conn.Open();
                query = "INSERT INTO patients (f_name, l_name, age, email, phone_num, medical_history_id) " +
                        "VALUES ('" + fname + "', '" + lname + "', " + age + ", '" + email + "', '" + phone + "', " + medicalID + ");";
                reader = conn.ExecuteReader(query);
                conn.Close();
            }

            catch
            {

            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }
        }

        public int getHistoryID(string fname, string lname, string email, string phone)
        {
            int historyID = -1;

            try
            {
                conn.Open();
                query = "SELECT medical_history_id FROM patients WHERE f_name = '" + fname + "' AND l_name = '" + lname +
                    "' AND email = '" + email + "' AND phone_num = '" + phone + "';";
                reader = conn.ExecuteReader(query);
                while (reader.Read())
                    historyID = Int16.Parse(reader["medical_history_id"].ToString());
                conn.Close();

                return historyID;
            }

            catch
            {
                return historyID;
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }
        }

        public string[] fillMedicalHistory(string fname, string lname, string email, string phone)
        {
            string[] data = new string[3];

            connection = new MySqlConnection(conn.toString());
            query = "SELECT past_illness, allergy, medications FROM medical_history WHERE history_id = "
                + getHistoryID(fname, lname, email, phone) + ";";

            try
            {
                conn.Open();

                reader = conn.ExecuteReader(query);
                while (reader.Read())
                {
                    data[0] = reader["past_illness"].ToString();
                    data[1] = reader["allergy"].ToString();
                    data[2] = reader["medications"].ToString();
                }
                return data;
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("An error occurred {0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return data;
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }
        }

        public void updateInventoryQuantity(int amount, string currentCell, int choice)
        {
            try
            {
                string query = "";
                int current = getCurrentAmount(currentCell);
                if (choice == 1)
                {
                    int supplySum = current + amount;
                    conn.Open();
                    query = "UPDATE supplies SET quantity = " + supplySum + " WHERE description = '" + currentCell + "';";
                }
                else if (choice == 2)
                {
                    int supplyDec = current - amount;
                    if (supplyDec < 0)
                    {
                        MessageBox.Show("Unable to decrement, value would be below 0");
                        return;
                    }
                    conn.Open();
                    query = "UPDATE supplies SET quantity = " + supplyDec + " WHERE description = '" + currentCell + "';";
                }

                reader = conn.ExecuteReader(query);
                while (reader.Read())
                {
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }
        }

        public int getCurrentAmount(string currentCell)
        {
            try
            {
                conn.Open();
                string query = "SELECT quantity FROM supplies WHERE description = '" + currentCell + "';";
                int currentAmount = 0;
                reader = conn.ExecuteReader(query);
                while (reader.Read())
                {
                    currentAmount = Int16.Parse(reader["quantity"].ToString());
                }
                conn.Close();
                return currentAmount;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }
            return 0;
        }


    }
}
