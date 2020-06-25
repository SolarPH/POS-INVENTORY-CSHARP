using System;
using System.Data;
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
            label3.Hide();
            label4.Hide();
            label7.Hide();
            label8.Hide();
        }

        private void button3_Click(object sender, EventArgs e) => Close(); //Exit

        private void button2_Click(object sender, EventArgs e) // Pay
        {
            if (dataGridView1.RowCount > 0)
            {
                while (true)
                {
                    PaymentWindow source = new PaymentWindow();
                    source.UpdateTotal(String.Format("{0:0.00}", new Calculator().UpdatePayment(label6, label4)));
                    source.ShowDialog();
                    if (source.getPayment() != "0.00")
                    {
                        label4.Text = new Calculator().AddPrevPayment(Convert.ToDouble(label4.Text), Convert.ToDouble(source.getPayment()));
                        label6.Text = source.getDiscountedPrice();
                    }
                    if (source.discountMode() == false)
                    {
                        Show();
                        break;
                    }
                    else
                    {
                        Hide();
                        DiscountPicker discPick = new DiscountPicker();
                        discPick.ShowDialog();
                        Show();
                    }
                }

                double change = new Calculator().ChangeCalculation(Convert.ToDouble(label4.Text), Convert.ToDouble(label6.Text));
                label8.Text = String.Format("{0:0.00}", change); 

                if (change >= 0.00)
                {
                    string ORNOgenerated = new ORNOGEN().ORNOGENstring();
                    string Salesperson = new MainDatabase().InteractDB_getCurrentSalesPerson();
                    inventorySub();
                    logSales(ORNOgenerated);
                    ReceiptWindow rw = new ReceiptWindow();
                    rw.setContents(dataGridView1);
                    string VATpercent = Convert.ToString(Convert.ToDouble(getVatPercentage())*100);
                    string DiscountPercent = getDiscPercentage();
                    double[] PriceList = getUpdatedValues();
                    rw.setTransactionDetails(ORNOgenerated, Salesperson, label4, label8, VATpercent, DiscountPercent, PriceList[0], PriceList[1], PriceList[2]);
                    Hide();
                    rw.ShowDialog();
                    Show();
                    ClearAll();
                }
            }
        }

        private void textBox1_KeyType(object sender, KeyEventArgs e)
        {
            new IntegerOnly().integer_validator(e, textBox1);
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
                    if ((textBox2.Text == "") || (Convert.ToInt32(textBox2.Text) < 1)) { textBox2.Text = "1"; }
                    string[] res = new MainDatabase().InteractDB_DisplayUpdate(Convert.ToInt32(textBox1.Text));
                    string productName = res[1];
                    double price = Convert.ToDouble(res[2]);
                    int row = 0;
                    int scannedMatch = new TableScanner().scanMatch(dataGridView1, textBox1.Text, 0);
                    int quantityPrev = 0;
                    if (scannedMatch != -1)
                    {
                        row = scannedMatch;
                        quantityPrev = Convert.ToInt32(dataGridView1.Rows[row].Cells["Item_Quantity"].Value);
                    }
                    else
                    {
                        row = dataGridView1.Rows.Add();
                    }
                    dataGridView1.Rows[row].Cells["Item_ID"].Value = textBox1.Text;
                    dataGridView1.Rows[row].Cells["Item_Name"].Value = productName;
                    dataGridView1.Rows[row].Cells["Item_Quantity"].Value = Convert.ToString(Convert.ToInt32(textBox2.Text) + quantityPrev);
                    dataGridView1.Rows[row].Cells["Price_Raw"].Value = String.Format("{0:0.00}", price);
                    dataGridView1.Rows[row].Cells["Price_Total"].Value = String.Format("{0:0.00}", Convert.ToDouble(Convert.ToInt32(dataGridView1.Rows[row].Cells["Item_Quantity"].Value) * price));

                    textBox1.Text = "";
                    textBox2.Text = "";
                    dataGridView1.CurrentCell = dataGridView1.Rows[row].Cells[0];
                    dataGridView1.CurrentCell = null;
                    new Calculator().UpdateTotal(dataGridView1, 4, label6);
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
            if (dataGridView1.CurrentRow != null)
            {
                dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
            }
            new Calculator().UpdateTotal(dataGridView1, 4, label6);
            double change = new Calculator().ChangeCalculation(Convert.ToDouble(label4.Text), Convert.ToDouble(label6.Text));
            label8.Text = String.Format("{0:0.00}", change);
        }

        private void button4_Click(object sender, EventArgs e) // Clear
        {
            ClearAll();
        }

        private void ClearAll()
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
                dataGridView1.Rows.Clear();
                new MainDatabase().InteractDB_resetDiscStat();
                label4.Text = "0.00";
                label6.Text = "0.00";
                label8.Text = "0.00";
            }
        }

        private void inventorySub() // Adds Stocks by Table Content for TABLE_STOCKS
        {
            int RowCount = dataGridView1.RowCount;
            int indexID = 0;
            int indexQuan = 2;
            for (int i = 0; i < RowCount; i++)
            {
                int ID = Convert.ToInt32(dataGridView1.Rows[i].Cells[indexID].Value);
                int Quan = Convert.ToInt32(dataGridView1.Rows[i].Cells[indexQuan].Value);
                new MainDatabase().InteractDB_ManageStocks(ID, "", 0.00, Quan, "SOLD");
            }
        }

        private double VATable;
        private double DiscountTotal;
        private double VATadd;
        private double[] getUpdatedValues()
        {
            double[] res = {VATable,DiscountTotal,VATadd};
            return res;
        }
        private string VatPercentage;
        private string DiscountPercentage;
        private string getVatPercentage()
        {
            return VatPercentage;
        }
        private string getDiscPercentage()
        {
            return DiscountPercentage;
        }
        private void setUpdatedValues(string VP, string DP, double V1, double V2, double V3)
        {
            VATable = V1;
            DiscountTotal = V2;
            VATadd = V3;
            VatPercentage = VP;
            DiscountPercentage = DP;
        }

        private void logSales(string ORNO)
        {
            int RowCount = dataGridView1.RowCount;
            int indexID = 0;
            int indexName = 1;
            int indexQuan = 2;
            int indexPriceTotal = 4;
            for (int i = 0; i < RowCount; i++)
            {
                int ID = Convert.ToInt32(dataGridView1.Rows[i].Cells[indexID].Value);
                string Name = Convert.ToString(dataGridView1.Rows[i].Cells[indexName].Value);
                int Quan = Convert.ToInt32(dataGridView1.Rows[i].Cells[indexQuan].Value);
                double priceTotal = Convert.ToDouble(dataGridView1.Rows[i].Cells[indexPriceTotal].Value);
                new MainDatabase().InteractDB_logSales(ID, Name, Quan, priceTotal, ORNO);
            }
            double remainingBalance = new Calculator().UpdateTotal(dataGridView1,4);
            double totalDiscounts = 0;
            double discountPercentage = 0;
            string[][] ActiveDiscounts = new MainDatabase().InteractDB_ActiveDisc();
            int activeCount = ActiveDiscounts.Length;
            for (int i = 0; i < activeCount; i++)
            {
                int ID = Convert.ToInt32(ActiveDiscounts[i][0]);
                string Name = Convert.ToString(ActiveDiscounts[i][1]);
                int Quan = 1;
                double priceTotal = -(new Calculator().UpdateTotal(dataGridView1,4) * Convert.ToDouble(ActiveDiscounts[i][2]));
                remainingBalance = remainingBalance + priceTotal;
                totalDiscounts = totalDiscounts + priceTotal;
                discountPercentage = discountPercentage + Convert.ToDouble(ActiveDiscounts[i][2]);
                new MainDatabase().InteractDB_logSales(ID,Name,Quan,priceTotal,ORNO);
            }
            string[] VATdetails = new MainDatabase().InteractDB_GetVat();
            int ID_VAT = Convert.ToInt32(VATdetails[0]);
            string Name_VAT = Convert.ToString(VATdetails[1]);
            double VatDeduction = -(remainingBalance*(Convert.ToDouble(VATdetails[2])));
            new MainDatabase().InteractDB_logSales(ID_VAT,Name_VAT,1,VatDeduction,ORNO);

            double V1 = remainingBalance + VatDeduction;
            double V2 = totalDiscounts;
            double V3 = -(VatDeduction);
            string VP = Convert.ToString(VATdetails[2]);
            string DP = Convert.ToString(discountPercentage*100);
            setUpdatedValues(VP, DP, V1, V2, V3);
        }

        private void button6_Click(object sender, EventArgs e) // Product List
        {
            Hide();
            ProductList PLsource = new ProductList();
            PLsource.ShowDialog();
            textBox1.Text = PLsource.getSelectedID();
            Show();
        }
    }
}
