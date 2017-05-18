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
    public partial class MapSelector : Form
    {
        public string value;
        public MapSelector()
        {
            InitializeComponent();
            value = "";

            foreach (string file in Directory.EnumerateFiles("Content\\Maps", "*.txt"))
            {
                cb_map.Items.Add(file);
            }
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            if (rb_1.Checked)
            {
                try
                {
                    value = cb_map.SelectedItem.ToString();
                }
                catch
                {
                    Console.WriteLine("Non, string value instead of string.");
                }
                this.Close();
            }
            else if (rb_2.Checked)
            {
                value = tb_map.Text;
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
