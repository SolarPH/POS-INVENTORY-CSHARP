using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopApp.Functions
{
    class TextBoxChecker
    {
        public Boolean checkTextBox(TextBox textbox)
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
    }
}
