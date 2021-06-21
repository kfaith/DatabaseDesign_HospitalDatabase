
namespace Hospital_System.Presentation_Tier
{
    partial class UpdatePatientWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.patientClearButton = new System.Windows.Forms.Button();
            this.updateButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.updatePhoneTextBox = new System.Windows.Forms.TextBox();
            this.updateEmailTextBox = new System.Windows.Forms.TextBox();
            this.updateLnameTextBox = new System.Windows.Forms.TextBox();
            this.updateFnameTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // patientClearButton
            // 
            this.patientClearButton.Location = new System.Drawing.Point(299, 309);
            this.patientClearButton.Name = "patientClearButton";
            this.patientClearButton.Size = new System.Drawing.Size(104, 23);
            this.patientClearButton.TabIndex = 29;
            this.patientClearButton.Text = "Reset";
            this.patientClearButton.UseVisualStyleBackColor = true;
            this.patientClearButton.Click += new System.EventHandler(this.patientClearButton_Click_1);
            // 
            // updateButton
            // 
            this.updateButton.Location = new System.Drawing.Point(177, 309);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(104, 23);
            this.updateButton.TabIndex = 28;
            this.updateButton.Text = "Update";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click_1);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(296, 262);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 13);
            this.label6.TabIndex = 27;
            this.label6.Text = "Phone Number";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(110, 262);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 13);
            this.label7.TabIndex = 26;
            this.label7.Text = "Email";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(296, 170);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "Last Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(110, 170);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "First Name";
            // 
            // updatePhoneTextBox
            // 
            this.updatePhoneTextBox.Location = new System.Drawing.Point(299, 230);
            this.updatePhoneTextBox.Name = "updatePhoneTextBox";
            this.updatePhoneTextBox.Size = new System.Drawing.Size(171, 20);
            this.updatePhoneTextBox.TabIndex = 23;
            // 
            // updateEmailTextBox
            // 
            this.updateEmailTextBox.Location = new System.Drawing.Point(110, 230);
            this.updateEmailTextBox.Name = "updateEmailTextBox";
            this.updateEmailTextBox.Size = new System.Drawing.Size(171, 20);
            this.updateEmailTextBox.TabIndex = 22;
            // 
            // updateLnameTextBox
            // 
            this.updateLnameTextBox.Location = new System.Drawing.Point(299, 143);
            this.updateLnameTextBox.Name = "updateLnameTextBox";
            this.updateLnameTextBox.Size = new System.Drawing.Size(171, 20);
            this.updateLnameTextBox.TabIndex = 21;
            // 
            // updateFnameTextBox
            // 
            this.updateFnameTextBox.Location = new System.Drawing.Point(110, 143);
            this.updateFnameTextBox.Name = "updateFnameTextBox";
            this.updateFnameTextBox.Size = new System.Drawing.Size(171, 20);
            this.updateFnameTextBox.TabIndex = 20;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(213, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 20);
            this.label3.TabIndex = 19;
            this.label3.Text = "Update Patient Info";
            // 
            // UpdatePatientWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 441);
            this.Controls.Add(this.patientClearButton);
            this.Controls.Add(this.updateButton);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.updatePhoneTextBox);
            this.Controls.Add(this.updateEmailTextBox);
            this.Controls.Add(this.updateLnameTextBox);
            this.Controls.Add(this.updateFnameTextBox);
            this.Controls.Add(this.label3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UpdatePatientWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "UpdatePatientWindow";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button patientClearButton;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox updatePhoneTextBox;
        private System.Windows.Forms.TextBox updateEmailTextBox;
        private System.Windows.Forms.TextBox updateLnameTextBox;
        private System.Windows.Forms.TextBox updateFnameTextBox;
        private System.Windows.Forms.Label label3;
    }
}