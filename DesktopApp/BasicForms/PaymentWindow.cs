using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DesktopApp.TextBoxManager;

namespace DesktopApp.Forms
{
    public partial class PaymentWindow : Form
    {
        public PaymentWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
			if (textBox1.Text == ""){
				textBox1.Text = "0.00";
			}
            else
            {
                textBox1.Text = String.Format("{0:0.00}", Convert.ToDouble(textBox1.Text));
            }
			Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0.00";
            Close();
        }

        public string getPayment() {
			return textBox1.Text;
        }

        public void UpdateTotal(string total) {
            label3.Text = total;
        }

        private void textBox1_KeyType(object sender, KeyEventArgs e)
        {
            new DoubleOnly().money_validator(e, textBox1);
        }
    }
}
