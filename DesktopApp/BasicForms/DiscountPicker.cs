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

namespace DesktopApp.BasicForms
{
    public partial class DiscountPicker : Form
    {
        public DiscountPicker()
        {
            InitializeComponent();
            ReInitializeTables(dataGridView1, dataGridView2);
        }

        private void ReInitializeTables(DataGridView dgv1, DataGridView dgv2)
        {
            dgv1.Rows.Clear();
            dgv2.Rows.Clear();
            string[][] inactiveList = new MainDatabase().InteractDB_InactiveDisc();
            string[][] activeList = new MainDatabase().InteractDB_ActiveDisc();
            int inactiveRows = inactiveList.Length;
            int activeRows = activeList.Length;
            for (int i = 0; i < inactiveRows; i++)
            {
                dgv1.Rows.Add();
                dgv1.Rows[i].Cells["Name1"].Value = inactiveList[i][1];
                dgv1.Rows[i].Cells["Percentage1"].Value = Convert.ToString(Convert.ToDouble(inactiveList[i][2])*100);
            }
            for (int i = 0; i < activeRows; i++)
            {
                dgv2.Rows.Add();
                dgv2.Rows[i].Cells["Name2"].Value = activeList[i][1];
                dgv2.Rows[i].Cells["Percentage2"].Value = Convert.ToString(Convert.ToDouble(activeList[i][2])*100);
            }
        }

        private void button2_Click(object sender, EventArgs e) // ADD
        {
            Boolean hasSelected = (dataGridView1.CurrentRow != null);
            if (hasSelected)
            {
                int selected = dataGridView1.CurrentCell.OwningRow.Index;
                string Name = Convert.ToString(dataGridView1.Rows[selected].Cells[0].Value);
                new MainDatabase().InteractDB_setStatusDiscVat(Name, 1);
                ReInitializeTables(dataGridView1,dataGridView2);
            }
        }

        private void button3_Click(object sender, EventArgs e) // REMOVE
        {
            Boolean hasSelected = (dataGridView2.CurrentRow != null);
            if (hasSelected)
            {
                int selected = dataGridView2.CurrentCell.OwningRow.Index;
                string Name = Convert.ToString(dataGridView2.Rows[selected].Cells[0].Value);
                new MainDatabase().InteractDB_setStatusDiscVat(Name, 0);
                ReInitializeTables(dataGridView1,dataGridView2);
            }
        }

        private void button1_Click(object sender, EventArgs e) => Close();
    }
}
