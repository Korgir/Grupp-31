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
    }
}
