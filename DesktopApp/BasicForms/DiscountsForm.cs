using DesktopApp.DatabaseManager;
using DesktopApp.Functions;
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
    public partial class DiscountsForm : Form
    {
        public DiscountsForm()
        {
            InitializeComponent();
            reInitialize();
        }

        private void reInitialize()
        {
            textBox2.Text = "";
            textBox3.Text = "";
            comboBox1.SelectedIndex = 0;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            comboBox1.Enabled = false;
            comboBox2.Enabled = false;
            comboBox2.Hide();
            label2.Hide();
            button3.Enabled = false;
        }

        private void formCommands(string command)
        {
            switch (command)
            {
                case "ADD":
                    textBox2.Show();
                    textBox2.Enabled = true;
                    textBox3.Enabled = true;
                    comboBox1.Enabled = true;
                    comboBox1.SelectedIndex = 0;
                    comboBox2.Enabled = false;
                    comboBox2.Hide();
                    label2.Hide();
                    button3.Enabled = true;
                    break;
                case "UPDATE":
                    textBox2.Enabled = true;
                    textBox3.Enabled = true;
                    comboBox1.Enabled = true;
                    comboBox2.Show();
                    label2.Show();
                    comboBox2.Enabled = true;
                    button3.Enabled = true;
                    InitializeUpdateForm(comboBox2, textBox2, textBox3, comboBox1);
                    textBox2.Text = comboBox2.Text;
                    break;
            }
        }

        private void InitializeUpdateForm(ComboBox cb1, TextBox tb1, TextBox tb2, ComboBox cb2)
        {
            cb1.Items.Clear();
            string[][] res = new MainDatabase().InteractDB_AllDiscVat();
            int rows = res.Length;
            for (int i = 0; i < rows; i++)
            {
                cb1.Items.Insert(i, res[i][1]);
            }
            if (rows != 0)
            {
                cb1.SelectedIndex = 0;
                tb1.Text = res[cb1.SelectedIndex][1];
                tb2.Text = Convert.ToString(Convert.ToDouble(res[cb1.SelectedIndex][2]) * 100);
                cb2.SelectedIndex = TypeTranslator_StringToIndex(res[cb1.SelectedIndex][5]);
            }
        }

        private void ReInitializeUpdateForm(ComboBox cb1, TextBox tb1, TextBox tb2, ComboBox cb2)
        {
            string[][] res = new MainDatabase().InteractDB_AllDiscVat();
            tb1.Text = res[cb1.SelectedIndex][1];
            tb2.Text = Convert.ToString(Convert.ToDouble(res[cb1.SelectedIndex][2])*100);
            cb2.SelectedIndex = TypeTranslator_StringToIndex(res[cb1.SelectedIndex][5]);
        }

        private string TypeTranslator_IndexToString(int typeIndex)
        {
            string[] res = {"DISC","VAT"};
            return res[typeIndex];
        }

        private int TypeTranslator_StringToIndex(string typeString)
        {
            int res = 0;
            if (typeString == "DISC")
            {
                res = 0;
            }
            else if (typeString == "VAT")
            {
                res = 1;
            }
            return res;
        }

        private void button4_Click(object sender, EventArgs e) => Close();

        private void button1_Click(object sender, EventArgs e) // Add
        {
            formCommands("ADD");
        }

        private void button2_Click(object sender, EventArgs e) // Update
        {
            formCommands("UPDATE");
        }

        private void button3_Click(object sender, EventArgs e) // Confirm
        {
            Boolean f1 = new TextBoxChecker().checkTextBox(textBox2);
            Boolean f2 = new TextBoxChecker().checkTextBox(textBox3);
            Boolean f1B = comboBox2.Enabled;
            Boolean hasMatch = new MainDatabase().InteractDB_DiscVatMatchedName(textBox2.Text);
            Boolean vatExist = new MainDatabase().InteractDB_VatExist();
            Boolean unchanged = comboBox2.Text == textBox2.Text;
            if ((f1 == true) && (f2 == true) && (f1B == false) && (hasMatch == false) && ((vatExist == false) || (comboBox1.SelectedIndex == 0)))
            {
                AddToDatabase();
                reInitialize();
            }
            else if ((f1 == true) && (f2 == true) && (f1B == true) && ((hasMatch == false) || (unchanged == true)) && ((vatExist == false) || (comboBox1.SelectedIndex == 0)))
            {
                UpdateToDatabase();
                reInitialize();
            }
            else
            {
                // None
            }
        }

        private void AddToDatabase()
        {
            string f3 = TypeTranslator_IndexToString(comboBox1.SelectedIndex);
            int active = 0;
            int alwaysActive = 0;
            if (comboBox1.SelectedIndex == 1)
            {
                active = 1;
                alwaysActive = 1;
            }
            string Name = textBox2.Text;
            double Percentage = Convert.ToDouble(textBox3.Text) / 100;
            new MainDatabase().InteractDB_InsertDiscVat(Name,Percentage,active,alwaysActive,f3);

        }

        private void UpdateToDatabase()
        {
            string[][] res = new MainDatabase().InteractDB_AllDiscVat();
            int selectedRow = comboBox2.SelectedIndex;
            int ID = Convert.ToInt32(res[selectedRow][0]);
            string newName = textBox2.Text;
            double newPercentage = Convert.ToDouble(textBox3.Text)/100;
            int active = 0;
            int alwaysActive = 0;
            string type = TypeTranslator_IndexToString(comboBox1.SelectedIndex);
            if (comboBox1.SelectedIndex == 1)
            {
                active = 1;
                alwaysActive = 1;
            }
            new MainDatabase().InteractDB_UpdateDiscVat(ID,newName,newPercentage,active,alwaysActive,type);
        }

        private void textBox3_KeyPress(object sender, KeyEventArgs e)
        {
            new IntegerOnly().integer_validator(e, textBox3);
            int signedInt;
            if (Int32.TryParse(textBox3.Text, out signedInt))
            {
                if (Convert.ToInt32(textBox3.Text) > 100)
                {
                    textBox3.Text = "100";
                }
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReInitializeUpdateForm(comboBox2,textBox2,textBox3,comboBox1);
        }
    }
}
