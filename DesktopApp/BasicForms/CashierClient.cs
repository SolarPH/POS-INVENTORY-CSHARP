using System;
using System.Windows.Forms;
using DesktopApp.BasicForms;
using DesktopApp.DatabaseManager;
using DesktopApp.Functions;
using DesktopApp.TextBoxManager;

namespace DesktopApp.Forms
{
    public partial class CashierClient : Form
    {
        public CashierClient()
        {
            InitializeComponent();
			tableLayoutPanel1.Controls.Add(new Label() { Text = "ID" }, 0, 0);
			tableLayoutPanel1.Controls.Add(new Label() { Text = "Name" }, 1, 0);
			tableLayoutPanel1.Controls.Add(new Label() { Text = "Quantity"}, 2, 0);
            tableLayoutPanel1.Controls.Add(new Label() { Text = "Price" }, 3, 0);
            tableLayoutPanel1.Controls.Add(new Label() { Text = " " }, 4, 0);

		}

        private void button3_Click(object sender, EventArgs e) => Application.Exit(); //Exit

        private void button2_Click(object sender, EventArgs e) // Pay
        {
            if (tableLayoutPanel1.RowCount>1)
            {
                PaymentWindow source = new PaymentWindow();
                source.UpdateTotal(String.Format("{0:0.00}", new Calculator().UpdatePayment(label6, label4)));
                source.ShowDialog();
                if (source.getPayment() != "0.00")
                {
                    label4.Text = new Calculator().AddPrevPayment(Convert.ToDouble(label4.Text), Convert.ToDouble(source.getPayment()));
                }
                double change = new Calculator().ChangeCalculation(Convert.ToDouble(label4.Text), Convert.ToDouble(label6.Text));
                label8.Text = String.Format("{0:0.00}", change);
            }
        }

        private void textBox1_KeyType(object sender, KeyEventArgs e)
        {
            new IntegerOnly().integer_validator(e,textBox1);
        }

        private void textBox2_KeyType(object sender, KeyEventArgs e)
        {
            new IntegerOnly().integer_validator(e, textBox2);
        }

		private void button1_Click(object sender, EventArgs e) // Add
		{
            if (textBox1.Text != "")
            {
                if (new MainDatabase().InteractDB_CheckMatch(Convert.ToInt32(textBox1.Text)) == true)
                {
                    if (textBox2.Text == "") { textBox2.Text = "1"; }
                    string[] res = new MainDatabase().InteractDB_DisplayUpdate(Convert.ToInt32(textBox1.Text));
                    string productName = res[1];
                    double price = Convert.ToDouble(res[2]);
                    tableLayoutPanel1.RowCount = tableLayoutPanel1.RowCount + 1;
                    tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                    tableLayoutPanel1.Controls.Add(new Label() { Text = textBox1.Text }, 0, tableLayoutPanel1.RowCount - 1);
                    tableLayoutPanel1.Controls.Add(new Label() { Text = productName }, 1, tableLayoutPanel1.RowCount - 1);
                    tableLayoutPanel1.Controls.Add(new Label() { Text = textBox2.Text }, 2, tableLayoutPanel1.RowCount - 1);
                    tableLayoutPanel1.Controls.Add(new Label() { Text = String.Format("{0:0.00}", price) }, 3, tableLayoutPanel1.RowCount - 1);
                    tableLayoutPanel1.Controls.Add(new Label() { Text = String.Format("{0:0.00}", Convert.ToDouble(Convert.ToInt32(textBox2.Text) * price)) }, 4, tableLayoutPanel1.RowCount - 1);
                    textBox1.Text = "";
                    textBox2.Text = "";
                    tableLayoutPanel1.VerticalScroll.Value = tableLayoutPanel1.VerticalScroll.Maximum;
                    new Calculator().UpdateTotal(tableLayoutPanel1, 4, label6);
                }
                else
                {
                    // Alert Form -> ID not found
                }
			}
            double change = new Calculator().ChangeCalculation(Convert.ToDouble(label4.Text), Convert.ToDouble(label6.Text));
            label8.Text = String.Format("{0:0.00}", change);
        }

        private void button5_Click(object sender, EventArgs e) // Void
        {
            if (tableLayoutPanel1.RowCount > 1)
            {
                for (int i = 0; i <= 4; i++) {
                    tableLayoutPanel1.Controls.RemoveAt((tableLayoutPanel1.RowCount - 1) * 5);
                }
                tableLayoutPanel1.RowCount = tableLayoutPanel1.RowCount - 1;
                new Calculator().UpdateTotal(tableLayoutPanel1,4,label6);
            }
            double change = new Calculator().ChangeCalculation(Convert.ToDouble(label4.Text), Convert.ToDouble(label6.Text));
            label8.Text = String.Format("{0:0.00}", change);
        }

        private void button4_Click(object sender, EventArgs e) // Clear
        {
            while (tableLayoutPanel1.RowCount > 1)
            {
                for (int i = 0; i <= 4; i++)
                {
                    tableLayoutPanel1.Controls.RemoveAt((tableLayoutPanel1.RowCount - 1) * 5);
                }
                tableLayoutPanel1.RowCount = tableLayoutPanel1.RowCount-1;
                new Calculator().UpdateTotal(tableLayoutPanel1,4,label6);
            }
            label4.Text = "0.00";
            label8.Text = "0.00";
        }

        private void button6_Click(object sender, EventArgs e) // Next Transaction
        {
            Boolean checkPayment = (Convert.ToDouble(label4.Text) >= Convert.ToDouble(label6.Text));
            Boolean clearConfirm = false;
            if (checkPayment == true)
            {
                clearConfirm = true;
            }
            else
            {
                // Warning Window
                ConfirmWindow CW = new ConfirmWindow();
                CW.ShowDialog();
                if (CW.getResponse() == DialogResult.OK)
                {
                    clearConfirm = true;
                }
                else
                {
                    
                }
            }
            if (clearConfirm == true)
            {
                this.inventorySub();
                while (tableLayoutPanel1.RowCount > 1)
                {
                    for (int i = 0; i <= 4; i++)
                    {
                        tableLayoutPanel1.Controls.RemoveAt((tableLayoutPanel1.RowCount - 1) * 5);
                    }
                    tableLayoutPanel1.RowCount = tableLayoutPanel1.RowCount - 1;
                    new Calculator().UpdateTotal(tableLayoutPanel1, 4, label6);
                }
                label4.Text = "0.00";
                label8.Text = "0.00";
            }
        }

        private void inventorySub()
        {
            int RowCount = tableLayoutPanel1.RowCount;
            int indexID = 0;
            int indexQuan = 2;
            for (int i = 1; i < RowCount; i++)
            {
                int ID = Convert.ToInt32(tableLayoutPanel1.GetControlFromPosition(indexID, i).Text);
                int Quan = Convert.ToInt32(tableLayoutPanel1.GetControlFromPosition(indexQuan, i).Text);
                new MainDatabase().InteractDB_ManageStocks(ID,"",0.00,Quan,"SOLD");
                Console.WriteLine("Deduction of ID " + Convert.ToString(ID) + " with Quantity of " + Convert.ToString(Quan));
            }
        }
    }
}
