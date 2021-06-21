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
    public partial class LoginPage : Form
    {
        DBmanager dbm;

        public LoginPage()
        {
            dbm = new DBmanager();
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(usernameTextBox.Text) && !String.IsNullOrEmpty(passwordTextBox.Text))
            {
                int login = dbm.loginUser(usernameTextBox.Text, passwordTextBox.Text);

                if (login == 0 || login == -1)
                    displayErrorMessage(errorLabel, "Username or Password is incorrect");
                else
                {
                    MainPage mainPage = new MainPage();
                    this.Hide();
                    mainPage.Show();
                }
            }
            else
                displayErrorMessage(errorLabel, "Username or Password cannot be blank");
        }

        private void showPasswordCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            passwordTextBox.PasswordChar = showPasswordCheckBox.Checked ? '\0' : '*';
        }

        private void displayErrorMessage(Label errorlabel, string message)
        {
            errorlabel.Text = message;

            var t = new Timer();
            t.Interval = 5000;
            t.Tick += (s, f) =>
            {
                errorlabel.Visible = false;
                t.Stop();
            };
            t.Start();
            errorlabel.Visible = true;
        }
    }
}
