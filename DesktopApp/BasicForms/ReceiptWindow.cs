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
    public partial class ReceiptWindow : Form
    {
        public ReceiptWindow()
        {
            InitializeComponent();
            dataGridView1.CurrentCell = null;
        }

        public void setContents(DataGridView dgv1)
        {
            for (int i = 0; i < dgv1.RowCount; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = dgv1.Rows[i].Cells[1].Value;
                dataGridView1.Rows[i].Cells[1].Value = dgv1.Rows[i].Cells[2].Value;
                dataGridView1.Rows[i].Cells[2].Value = dgv1.Rows[i].Cells[3].Value;
                dataGridView1.Rows[i].Cells[3].Value = dgv1.Rows[i].Cells[4].Value;
            }
        }

        public void setTransactionDetails(string ORNO, string CashierName, Label payment, Label change, string VATAddPercentage, string DiscountPercentage, double VATable, double DiscountTotal, double VATadd)
        {
            label7.Text = ORNO;
            label12.Text = CashierName;
            label9.Text = payment.Text;
            label11.Text = change.Text;
            label15.Text = "Added Vat (" + VATAddPercentage + "%):";
            label13.Text = "Discounts (" + DiscountPercentage + "%):";
            label5.Text = String.Format("{0:0.00}",VATable);
            label14.Text = String.Format("{0:0.00}", DiscountTotal);
            label16.Text = String.Format("{0:0.00}",VATadd);
            double SubTotal = Convert.ToDouble(VATable) + Convert.ToDouble(VATadd);
            label18.Text = String.Format("{0:0.00}",SubTotal);
            label3.Text = new ORNOGEN().ORNOGENtoString(ORNO);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
