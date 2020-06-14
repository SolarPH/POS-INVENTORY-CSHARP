using DesktopApp.DatabaseManager;
using DesktopApp.Pop_ups;
using DesktopApp.TextBoxManager;
using System;
using System.Windows.Forms;

namespace DesktopApp.Forms
{
    public partial class InventoryClient : Form
    {
        public InventoryClient()
        {
            InitializeComponent();
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            button8.Enabled = false;
            label6.Text = "0";
        }

        private void button2_Click(object sender, EventArgs e) => FormCommands("EXIT");

        private void textBox1_KeyType(object sender, KeyEventArgs e)
        {
            new IntegerOnly().integer_validator(e, textBox1);
            if ((textBox1.Text != "") && (label6.Text == "2"))
            {
                string[] results = new MainDatabase().InteractDB_DisplayUpdate(Convert.ToInt32(textBox1.Text));
                textBox2.Text = Convert.ToString(results[1]);
                textBox3.Text = String.Format("{0:0.00}",results[2]);
            }
        }

        private void textBox3_KeyType(object sender, KeyEventArgs e)
        {
            new DoubleOnly().money_validator(e,textBox3);
        }

        private void textBox4_KeyPress(object sender, KeyEventArgs e)
        {
            new IntegerOnly().integer_validator(e, textBox1);
        }

        private void button1_Click(object sender, EventArgs e) // Register
        {
            FormCommands("REGISTER");
        }

        private void button3_Click(object sender, EventArgs e) // Add
        {
            FormCommands("ADD");
        }

        private void button4_Click(object sender, EventArgs e) // Return
        {
            FormCommands("RETURN");
        }

        private void button5_Click(object sender, EventArgs e) // Reject
        {
            FormCommands("REJECT");
        }

        private void button6_Click(object sender, EventArgs e) // Check
        {
            FormCommands("CHECK");
        }

        private void button7_Click(object sender, EventArgs e) // Update
        {
            FormCommands("UPDATE");
        }

        private void button8_Click(object sender, EventArgs e) // Confirm
        {
            string Mode = label6.Text;
            /* 0 = None/Locked
             * 1 = Register
             * 2 = Update
             * 3 = Add
             * 4 = Return
             * 5 = Reject
             * 6 = Check
             */
            Boolean status = false;
            switch (Mode)
            {
                case "1":
                    status = Script_Register();
                    break;
                case "2":
                    status = Script_Update();
                    break;
                case "3":
                    status = Script_Add();
                    break;
                case "4":
                    status = Script_Return();
                    break;
                case "5":
                    status = Script_Reject();
                    break;
                case "6":
                    status = Script_Check();
                    break;
                default:
                    break;
            }
            if (status == true)
            {
                FormRelock();
                ClearBoxes(true, true, true, true);
            }
        }

        private void CallVSU()
        {
            Hide();
            string[] res = new MainDatabase().InteractDB_DisplayUpdate(Convert.ToInt32(textBox1.Text));
            ViewStockUpdate vsu = new ViewStockUpdate();
            int A = Convert.ToInt32(res[0]);
            string B = res[1];
            double C = Convert.ToDouble(res[2]);
            int D = Convert.ToInt32(res[3]);
            int E = Convert.ToInt32(res[4]);
            int F = Convert.ToInt32(res[5]);
            int G = Convert.ToInt32(res[6]);
            vsu.InitLabels(A, B, C, D, E, F, G);
            vsu.ShowDialog();
            Show();
        }

        private void CallVSU_AE()
        {
            Hide();
            string[] res = new MainDatabase().InteractDB_DisplayUpdate(Convert.ToInt32(textBox1.Text));
            Alert_AlreadyRegistered aae = new Alert_AlreadyRegistered();
            int A = Convert.ToInt32(res[0]);
            string B = res[1];
            double C = Convert.ToDouble(res[2]);
            aae.InitLabels(A, B, C);
            aae.ShowDialog();
            Show();
        }

        private Boolean checkTextBox(TextBox textbox)
        {
            Boolean res = false;
            Boolean E = textbox.Enabled;
            string T = textbox.Text;

            if (E == true)
            {
                if (T != "")
                {
                    res = true;
                }
            }
            else
            {
                res = true;
            }

            return res;
        }
        
        private Boolean ManageCommand(string command)
        {
            Boolean status = false;
            Boolean TB1 = checkTextBox(textBox1);
            Boolean TB2 = checkTextBox(textBox2);
            Boolean TB3 = checkTextBox(textBox3);
            Boolean TB4 = checkTextBox(textBox4);
            if ((TB1 == true) && (TB2 == true) && (TB3 == true) && (TB4 == true))
            {
                if (new MainDatabase().InteractDB_CheckMatch(Convert.ToInt32(textBox1.Text)) == true)
                {
                    int ID = Convert.ToInt32(textBox1.Text);
                    string Name = textBox2.Text;
                    double Price = 0.00;
                    if (textBox3.Text != "")
                    {
                        Price = Convert.ToDouble(textBox3.Text);
                    }
                    int Quan = 1;
                    if (textBox4.Text != "")
                    {
                        Quan = Convert.ToInt32(textBox4.Text);
                    }
                    new MainDatabase().InteractDB_ManageStocks(ID,Name,Price, Quan, command);
                    CallVSU();
                    status = true;
                }
                else
                {
                    Hide();
                    new Alert_ItemNotFound().setID(textBox1.Text);
                    Show();
                }
            }
            else
            {
                // Fill ID and Quantity - Do Nothing
            }
            return status;
        }

        private void ClearBoxes(Boolean f1, Boolean f2, Boolean f3, Boolean f4)
        {
            if (f1 == true)
            {
                textBox1.Text = "";
            }
            if (f2 == true)
            {
                textBox2.Text = "";
            }
            if (f3 == true)
            {
                textBox3.Text = "";
            }
            if (f4 == true)
            {
                textBox4.Text = "";
            }
        }

        private void FormRelock()
        {
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            button8.Enabled = false;
            label6.Text = "0";
        }

        private void FormCommands(string Command)
        {
            switch (Command)
            {
                case "REGISTER": // ALL
                    FormRelock();
                    textBox1.Enabled = true;
                    textBox2.Enabled = true;
                    textBox3.Enabled = true;
                    textBox4.Enabled = true;
                    button8.Enabled = true;
                    label6.Text = "1";
                    break;
                case "UPDATE": // ID & Price
                    FormRelock();
                    textBox1.Enabled = true;
                    textBox2.Enabled = true;
                    textBox3.Enabled = true;
                    button8.Enabled = true;
                    ClearBoxes(false, false, false, true);
                    label6.Text = "2";
                    break;
                case "ADD": // ID & Quantity
                    FormRelock();
                    textBox1.Enabled = true;
                    textBox4.Enabled = true;
                    button8.Enabled = true;
                    ClearBoxes(false, true, true, false);
                    label6.Text = "3";
                    break;
                case "RETURN": // ID & Quantity
                    FormRelock();
                    textBox1.Enabled = true;
                    textBox4.Enabled = true;
                    button8.Enabled = true;
                    ClearBoxes(false,true,true,false);
                    label6.Text = "4";
                    break;
                case "REJECT": // ID & Quantity
                    FormRelock();
                    textBox1.Enabled = true;
                    textBox4.Enabled = true;
                    button8.Enabled = true;
                    ClearBoxes(false,true,true,false);
                    label6.Text = "5";
                    break;
                case "CHECK": // ID only
                    FormRelock();
                    textBox1.Enabled = true;
                    button8.Enabled = true;
                    ClearBoxes(false, true, true, true);
                    label6.Text = "6";
                    break;
                case "EXIT": // Close Application
                    Application.Exit();
                    break;
                default:
                    break;
            }
        }

        private Boolean Script_Register()
        {
            Boolean status = false;
            if ((textBox1.Text != "") && (textBox2.Text != "") && (textBox3.Text != "") && (textBox4.Text != ""))
            {
                if (new MainDatabase().InteractDB_CheckMatch(Convert.ToInt32(textBox1.Text)) == false)
                {
                    new MainDatabase().InteractDB_InsertEntry(Convert.ToInt32(textBox1.Text), textBox2.Text, Convert.ToDouble(textBox3.Text), Convert.ToInt32(textBox4.Text));
                    CallVSU();
                    status = true;
                }
                else
                {
                    CallVSU_AE();
                }
            }
            else
            {
                // Alert Form -> Fill Out All
            }
            return status;
        }

        private Boolean Script_Update()
        {
            return ManageCommand("UPDATE");
        }

        private Boolean Script_Add()
        {
            return ManageCommand("ADD");
        }

        private Boolean Script_Return()
        {
            return ManageCommand("RETURN");
        } 

        private Boolean Script_Reject()
        {
            return ManageCommand("REJECT");
        }

        private Boolean Script_Check()
        {
            Boolean status = false;
            if (textBox1.Text != "")
            {
                if (new MainDatabase().InteractDB_CheckMatch(Convert.ToInt32(textBox1.Text)) == true)
                {
                    CallVSU();
                    status = true;
                }
                else
                {
                    Hide();
                    new Alert_ItemNotFound().setID(textBox1.Text);
                    Show();
                }
            }
            else
            {
                // Alert Form -> Fill ID
            }
            return status;
        }
    }
}
