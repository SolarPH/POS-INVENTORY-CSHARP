using DesktopApp.DatabaseManager;
using DesktopApp.Functions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopApp.BasicForms
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
            textBox2.UseSystemPasswordChar = true;
            textBox3.UseSystemPasswordChar = true;
            comboBox1.SelectedIndex = 0;
        }

        private void button2_Click(object sender, EventArgs e) // Cancel
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e) // Confirm
        {
            Boolean field1 = new TextBoxChecker().checkTextBox(textBox1);
            Boolean field2 = new TextBoxChecker().checkTextBox(textBox4);
            Boolean field3 = new TextBoxChecker().checkTextBox(textBox2);
            Boolean field4 = new TextBoxChecker().checkTextBox(textBox3);
            int UserLevel = comboBox1.SelectedIndex + 1;

            if ((field1 == true) && (field2 == true) && (field3 == true) && (field4 == true))
            {
                Boolean exists = new MainDatabase().InteractDB_doesCredentialsExist(textBox1.Text);
                if (exists == false)
                {
                    if ((textBox2.Text == textBox3.Text))
                    {
                        new MainDatabase().InteractDB_addAccount(textBox1.Text, textBox2.Text, UserLevel, textBox4.Text);
                        // Pop-up Account Registered Successfully.
                        Close();
                    }
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textBox2.UseSystemPasswordChar = false;
            }
            else
            {
                textBox2.UseSystemPasswordChar = true;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                textBox3.UseSystemPasswordChar = false;
            }
            else
            {
                textBox3.UseSystemPasswordChar = true;
            }
        }
    }
}
