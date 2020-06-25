using DesktopApp.DatabaseManager;
using DesktopApp.Pop_ups;
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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            textBox2.UseSystemPasswordChar = true;
            checkBox1.Checked = false;
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

        private void button2_Click(object sender, EventArgs e) // Cancel
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e) // Login
        {
            Boolean match = new MainDatabase().InteractDB_isCredentialsMatch(textBox1.Text,textBox2.Text);
            int userlevel = new MainDatabase().InteractDB_getUserLevel(textBox1.Text,textBox2.Text);
            Boolean CashierAccess = ((userlevel == 1) || (userlevel >= 3)) && (label4.Text == "1");
            Boolean InventoryAccess = ((userlevel == 2) || (userlevel >= 3)) && (label4.Text == "2");
            Boolean ManagerAccess = ((userlevel >= 3)) && (label4.Text == "3");
            if ((match == true) && ((CashierAccess == true) || (InventoryAccess == true) || (ManagerAccess == true)))
            {
                new MainDatabase().InteractDB_setCurrentSalesPerson(textBox1.Text,textBox2.Text);
                loginStat = true;
                Close();
            }
            else
            {
                Hide();
                new Alert_ProfileNotFound().ShowDialog();
                Show();
            }
        }

        private void button1_Click_1(object sender, EventArgs e) // Register
        {
            Hide();
            new RegisterForm().ShowDialog();
            Show();
        }

        private Boolean loginStat = false;
        public Boolean loginStatus()
        {
            return loginStat;
        }

        public void setAccessMode(int AccessLevel)
        {
            label4.Text = AccessLevel.ToString();
        }
    }
}
