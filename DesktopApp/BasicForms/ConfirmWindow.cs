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
    public partial class ConfirmWindow : Form
    {
        public ConfirmWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) //Continue
        {
            this.setResponse("CONFIRM");
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e) //Cancel
        {
            this.setResponse("CANCEL");
            this.Close();
        }

        private DialogResult response;
        public void setResponse(string command)
        {
            if (command == "CONFIRM")
            {
                this.response = DialogResult.OK;
            }
            else if (command == "CANCEL")
            {
                this.response = DialogResult.Cancel;
            }
        }
        public DialogResult getResponse()
        {
            return response;
        }
    }
}
