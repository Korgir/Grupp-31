using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp_31_SystemUtveckling
{
    public static class Prompt
    {
        public static string ShowMapSelector()
        {
            MapSelector prompt = new MapSelector();
            prompt.ShowDialog();
            return prompt.value;
        }

        public static string ShowDialogSelector()
        {
            DialogSelector prompt = new DialogSelector();
            prompt.ShowDialog();
            return prompt.value;
        }

        public static string ShowEnemySelector()
        {
            EnemySelector prompt = new EnemySelector();
            prompt.ShowDialog();
            return prompt.value;
        }

        public static string ShowItemSelector()
        {
            ItemSelector prompt = new ItemSelector();
            prompt.ShowDialog();
            return prompt.value;
        }

        public static string ShowZoneSelector()
        {
            ZoneSelector prompt = new ZoneSelector();
            prompt.ShowDialog();
            return prompt.value;
        }
    }
}
