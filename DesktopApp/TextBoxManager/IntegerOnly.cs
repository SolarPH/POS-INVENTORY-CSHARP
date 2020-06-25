using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopApp.TextBoxManager
{
    class IntegerOnly
    {
        public void integer_validator(KeyEventArgs k, TextBox t)
        {
            string value = t.Text;
            bool suppress = true;
            try
            {
                if (k.KeyCode != Keys.OemPeriod)
                {
                    Convert.ToInt32(Convert.ToString(Convert.ToChar(k.KeyCode)));
                    suppress = false;
                }
            }
            catch (Exception) { }

            if ((k.KeyCode == Keys.Left) || (k.KeyCode == Keys.Right) || (k.KeyCode == Keys.Up) || (k.KeyCode == Keys.Down))
            {
                suppress = false;
            }
            else if ((k.KeyCode == Keys.Back) || (k.KeyCode == Keys.Delete))
            {
                suppress = false;
            }

            k.SuppressKeyPress = suppress;
        }
    }
}
