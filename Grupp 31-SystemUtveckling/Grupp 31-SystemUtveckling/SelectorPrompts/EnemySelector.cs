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
    public partial class EnemySelector : Form
    {
        public string value;
        public EnemySelector()
        {
            InitializeComponent();
            value = "";

            foreach (KeyValuePair<string, Team> team in CombatTeamDatabase.teamDictionary)
            {
                cb_map.Items.Add(team.Key);
            }
        }

        private void btn_ok_Click(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
