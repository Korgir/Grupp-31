using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp_31_SystemUtveckling
{
    static class CombatTeamDatabase
    {
        public static Dictionary<string, List<Character>> teamDictionary = new Dictionary<string, List<Character>>();

        public static void Initialize()
        {
            teamDictionary["goblin5"] = new List<Character>();
            for (int i = 0; i < 5; i++)
            {
                teamDictionary["goblin5"].Add(new Character(Archive.textureDictionary["goblinCombat"], Archive.textureDictionary["goblinCombatOutline"],
                Vector2.Zero, false, "Goblin", 30, 3, 2, 3, 5, 10, 100, 5, 50));
            }
        }
    }
}
