using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DesktopApp.DatabaseManager;
using DesktopApp.Pop_ups;
using DesktopApp.TextBoxManager;

namespace DesktopApp.Forms
{
    public partial class PaymentWindow : Form
    {
        public PaymentWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) // Pay
        {
             if (textBox1.Text != "")
            {
                if (Convert.ToDouble(textBox1.Text) >= Convert.ToDouble(label3.Text))
                {
                    textBox1.Text = String.Format("{0:0.00}", Convert.ToDouble(textBox1.Text));
                    Close();
                }
                else
                {
                    Hide();
                    new Alert_InsufficientFunds().ShowDialog();
                    Show();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e) // Cancel
        {
            textBox1.Text = "0.00";
            Close();
        }

        public string getPayment() {
			return textBox1.Text;
        }

        private Boolean discountModeActivated = false;
        public Boolean discountMode()
        {
            return discountModeActivated;
        }

        public string getDiscountedPrice()
        {
            return label3.Text;
        }

        public void UpdateTotal(string total) {
            string[][] ActiveDiscounts = new MainDatabase().InteractDB_ActiveDisc();
            int activeCount = ActiveDiscounts.Length;
            double DiscountPercent = 0;
            for (int i = 0; i < activeCount; i++)
            {
                DiscountPercent = DiscountPercent + Convert.ToDouble(ActiveDiscounts[i][2]);
            }
            double totalDouble = Convert.ToDouble(total);
            double discountPrice = totalDouble * DiscountPercent;
            label3.Text = String.Format("{0:0.00}",totalDouble-discountPrice);
        }

        private void textBox1_KeyType(object sender, KeyEventArgs e)
        {
            new DoubleOnly().money_validator(e, textBox1);
        }

        private void button3_Click(object sender, EventArgs e) // Discounts Window
        {
            discountModeActivated = true;
            textBox1.Text = "0.00";
            Close();
        }
    }
}