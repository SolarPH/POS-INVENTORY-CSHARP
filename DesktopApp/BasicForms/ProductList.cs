using DesktopApp.DatabaseManager;
using DesktopApp.TextBoxManager;
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
    public partial class ProductList : Form
    {
        public ProductList()
        {
            InitializeComponent();
            PopulateTable(dataGridView1);
            comboBox1.SelectedIndex = 0;
        }

        private void textBox1_KeyType(object sender, KeyEventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                new IntegerOnly().integer_validator(e, textBox1);
            }
            PopulateTable(dataGridView1);
        }

        private string SearchCommand()
        {
            string res = "";
            if (comboBox1.SelectedIndex == 0)
            {
                res = "ID";
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                res = "NAME";
            }
            return res;
        }

        private void PopulateTable(DataGridView dgv1)
        {
            dgv1.Rows.Clear();
            string[][] results = new MainDatabase().InteractDB_SearchProduct(textBox1.Text, SearchCommand());
            int rows = results.Length;
            for (int i = 0; i < rows; i++)
            {
                dgv1.Rows.Add();
                dgv1.Rows[i].Cells[0].Value = results[i][0];
                dgv1.Rows[i].Cells[1].Value = results[i][1];
                dgv1.Rows[i].Cells[2].Value = results[i][2];
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Clear();
            PopulateTable(dataGridView1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private string selectedID = "";
        private void setSelectedID(DataGridView dgv1)
        {
            selectedID = Convert.ToString(dgv1.CurrentCell.OwningRow.Cells[0].Value);
        }
        public string getSelectedID()
        {
            return selectedID;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell != null)
            {
                setSelectedID(dataGridView1);
                Close();
            }
        }
    }
}
