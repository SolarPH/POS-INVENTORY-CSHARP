using System;
using System.Windows.Forms;

namespace DesktopApp.TextBoxManager
{
    class DoubleOnly
    {
        public void money_validator(KeyEventArgs k, TextBox t) {
            string value = t.Text;
            bool suppress = true;
            bool isNumber = false;
            try {
                if (k.KeyCode != Keys.OemPeriod)
                {
                    Convert.ToInt32(Convert.ToString(Convert.ToChar(k.KeyCode)));
                }
                isNumber = true;
            }
            catch (Exception) {}

            if ((k.KeyCode == Keys.OemPeriod) && (value.IndexOf(".") == -1))
            {
                suppress = false;
            }
            else if ((k.KeyCode == Keys.Left) || (k.KeyCode == Keys.Right) || (k.KeyCode == Keys.Up) || (k.KeyCode == Keys.Down))
            {
                suppress = false;
            }
            else if ((k.KeyCode == Keys.Back) || (k.KeyCode == Keys.Delete))
            {
                suppress = false;
            }

            if (isNumber == true)
            {
                if ((value.IndexOf(".") != -1) && (t.SelectionStart <= value.IndexOf(".")))
                {
                    suppress = false;
                }
                else if ((value.IndexOf(".") != -1) && (t.SelectionStart > value.IndexOf(".")) && (value.Length <= value.IndexOf(".") + 2))
                {
                    suppress = false;
                }
                else if (value.IndexOf(".") == -1)
                {
                    suppress = false;
                }
            }

            k.SuppressKeyPress = suppress;
        }
    }
}