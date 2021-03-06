﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopApp.Functions
{
    class Calculator
    {
        public double RowPrice(int quantity,double price) {
            double result = 0.00;
            result = price * quantity;
            return result;
        }

        public double ChangeCalculation(double total, double payment) {
            double change = 0.00;
            change = total - payment;
            return change;
        }

        public void UpdateTotal(DataGridView table,int index, Label label)
        {
            double total = 0.00;
            for (int i = 0; i < table.RowCount; i++)
            {
                total = total + Convert.ToDouble(table.Rows[i].Cells[4].Value.ToString());
            }
            label.Text = String.Format("{0:0.00}", total);
        }

        public double UpdateTotal(DataGridView table, int index)
        {
            double total = 0.00;
            for (int i = 0; i < table.RowCount; i++)
            {
                total = total + Convert.ToDouble(table.Rows[i].Cells[4].Value.ToString());
            }
            return total;
        }

        public double UpdatePayment(Label label1, Label label2)
        {
            return Convert.ToDouble(label1.Text)-Convert.ToDouble(label2.Text);
        }

        public string AddPrevPayment(double prev, double newpayment)
        {
            double total = prev + newpayment;
            return String.Format("{0:0.00}",total);
        }
    }
}
