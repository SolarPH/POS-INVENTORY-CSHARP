using DesktopApp.DatabaseManager;
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

        private void button1_Click(object sender, EventArgs e)
        {
            new Forms.CashierClient().Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Forms.InventoryClient().Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e) => Application.Exit();
    }
}
