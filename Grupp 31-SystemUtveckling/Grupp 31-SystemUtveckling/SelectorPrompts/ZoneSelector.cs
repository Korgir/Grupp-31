using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grupp_31_SystemUtveckling
{
    public partial class ZoneSelector : Form
    {
        public string value;
        public ZoneSelector()
        {
            InitializeComponent();
            value = "";
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            value = tb_map.Text;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
