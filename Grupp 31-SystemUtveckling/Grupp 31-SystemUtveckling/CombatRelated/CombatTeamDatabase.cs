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
            for (int i = 0; i < 2; i++)
            {
                teamDictionary["goblin5"].characters.Add(new Character(Archive.textureDictionary["goblinCombat"], Archive.textureDictionary["goblinCombatOutline"],
                Vector2.Zero, false, "Goblin", 6, 3, 2, 3, 5, 10, 100, 5, 50));
            }
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
