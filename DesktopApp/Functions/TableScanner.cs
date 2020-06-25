using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopApp.Functions
{
    class TableScanner
    {

        public int scanMatch(DataGridView dgv, string textMatch, int index)
        {
            int row = -1;
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                if (Convert.ToString(dgv.Rows[i].Cells[index].Value) == textMatch)
                {
                    row = i;
                    break;
                }
            }
            return row;
        }

    }
}
