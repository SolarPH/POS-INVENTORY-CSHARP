using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopApp.Pop_ups
{
    public partial class ViewStockUpdate : Form
    {
        public ViewStockUpdate()
        {
            InitializeComponent();
        }

        public void InitLabels(int ID, string Name, double Price, int Available, int Returned, int Rejected, int Sold)
        {
            this.label1.Text = "Product ID #: " + Convert.ToString(ID);
            this.label2.Text = "Product Name: " + Name;
            this.label3.Text = "Price: " + String.Format("{0:0.00}", Price);
            this.label7.Text = "Available: " + Convert.ToString(Available);
            this.label5.Text = "Returned: " + Convert.ToString(Returned);
            this.label4.Text = "Rejected: " + Convert.ToString(Rejected);
            this.label6.Text = "Sold: " + Convert.ToString(Sold);
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
