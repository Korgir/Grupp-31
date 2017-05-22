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
        public static Dictionary<string, Team> teamDictionary = new Dictionary<string, Team>();

        public static void Initialize()
        {
            // No team IDs can be the same
            teamDictionary["goblin5"] = new Team(1);
            for (int i = 0; i < 5; i++)
            {
                teamDictionary["goblin5"].characters.Add(new Character(Archive.textureDictionary["goblinCombat"], Archive.textureDictionary["goblinCombatOutline"],
                Vector2.Zero, false, "Goblin", 20, 3, 2, 3, 5, 10, 100, 5, 50));
            }

            teamDictionary["demon1"] = new Team(2);
            teamDictionary["demon1"].characters.Add(new Character(Archive.textureDictionary["demonDaggers"], Archive.textureDictionary["demonDaggersOutline"],
                Vector2.Zero, false, "Sidmoch", 500, 30, 20, 20, 30, 4, 100, 5, 80));
            teamDictionary["demon1"].characters.Add(new Character(Archive.textureDictionary["demonSpear"], Archive.textureDictionary["demonSpearOutline"],
                Vector2.Zero, false, "Oogaezal", 800, 30, 20, 15, 20, 4, 100, 5, 80));

            teamDictionary["demon2"] = new Team(2);
            teamDictionary["demon2"].characters.Add(new Character(Archive.textureDictionary["demonMage"], Archive.textureDictionary["demonMageOutline"],
                Vector2.Zero, false, "Scierocho", 500, 30, 20, 20, 30, 4, 100, 5, 80));
            teamDictionary["demon2"].characters.Add(new Character(Archive.textureDictionary["demonWarlock"], Archive.textureDictionary["demonWarlockOutline"],
                Vector2.Zero, false, "Eeziulur", 800, 30, 20, 15, 20, 4, 100, 5, 80));
        }

        public static Team GetTeam(string teamName)
        {
            Team newTeam = new Team(teamDictionary[teamName].ID);
            foreach (Character c in teamDictionary[teamName].characters)
            {
                Character newCharacter = c.Clone();
                newTeam.characters.Add(newCharacter);
            }
            return newTeam;
        }
    }
}
