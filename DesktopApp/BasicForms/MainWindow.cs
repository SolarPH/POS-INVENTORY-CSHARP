using DesktopApp.BasicForms;
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

namespace DesktopApp
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
            new MainDatabase().InitDatabase();
        }

        private void button1_Click(object sender, EventArgs e) // Cashier Client Window
        {
            Hide();
            LoginForm lif = new LoginForm();
            lif.setAccessMode(1);
            lif.ShowDialog();
            if (lif.loginStatus() == true)
            {
                new Forms.CashierClient().ShowDialog();
                new MainDatabase().InteractDB_clearCurrentSalesPerson();
            }
            else {}
            Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            LoginForm lif = new LoginForm();
            lif.setAccessMode(2);
            lif.ShowDialog();
            if (lif.loginStatus() == true)
            {
                new Forms.InventoryClient().ShowDialog();
                new MainDatabase().InteractDB_clearCurrentSalesPerson();
            }
            else {}
            Show();
        }


        private void button4_Click(object sender, EventArgs e)
        {
            Hide();
            LoginForm lif = new LoginForm();
            lif.setAccessMode(3);
            lif.ShowDialog();
            if (lif.loginStatus() == true)
            {
                new DiscountsForm().ShowDialog();
                new MainDatabase().InteractDB_clearCurrentSalesPerson();
            }
            else {}
            Show();
        }

        private void button3_Click(object sender, EventArgs e) => Application.Exit();
    }
}
