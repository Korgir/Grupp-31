using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp_31_SystemUtveckling
{
    class Team
    {
        public List<Character> characters;
        public int ID;

        public Team(int ID)
        {
            this.ID = ID;
            this.characters = new List<Character>();
        }
    }
}
