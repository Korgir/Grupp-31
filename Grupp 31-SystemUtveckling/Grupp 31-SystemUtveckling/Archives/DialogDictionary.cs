using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp_31_SystemUtveckling
{
    static class DialogDictionary
    {
        public static Dictionary<string, Dialog> dialogDictionary = new Dictionary<string, Dialog>();

        public static void Initialize()
        {
            // -------------------
            // Goblin slayer
            // -------------------
            dialogDictionary["goblinSlayer"] = new Dialog();
            dialogDictionary["goblinSlayer"].givingQuest = new Quest(1, "Goblin slayer", null);
            dialogDictionary["goblinSlayer"].givingQuest.objectives.Add(new KillObjective(50, "Kill goblin teams.", 1));
            // Pick up
            dialogDictionary["goblinSlayer"].AddLinePickupQuest("We have been at wars with the goblins");
            dialogDictionary["goblinSlayer"].AddLinePickupQuest("For 20 years!");
            dialogDictionary["goblinSlayer"].AddLinePickupQuest("And now they are raiding our city.");
            dialogDictionary["goblinSlayer"].AddLinePickupQuest("Get rid of em.");
            // In Progress
            dialogDictionary["goblinSlayer"].AddLineQuestInProgress("Go on, we are still at war.");
            // Handing In
            dialogDictionary["goblinSlayer"].AddLineHandingInQuest("What took you so long?");
            dialogDictionary["goblinSlayer"].AddLineHandingInQuest("Have this.");
            dialogDictionary["goblinSlayer"].AddLineHandingInQuest("<You have received Goblin Mail>");

            // -------------------
            // Furniture chopping
            // -------------------
            dialogDictionary["furnitureChopping"] = new Dialog();
            dialogDictionary["furnitureChopping"].givingQuest = new Quest(2, "Furniture chopping", null);
            dialogDictionary["furnitureChopping"].givingQuest.objectives.Add(new ItemObjective(15, "Find the lost furniture", 999));
            // Pick up
            dialogDictionary["furnitureChopping"].AddLinePickupQuest("The goblins have stolen all our furniture.");
            dialogDictionary["furnitureChopping"].AddLinePickupQuest("Find them for me.");
            dialogDictionary["furnitureChopping"].AddLinePickupQuest("You will be rewarded with something special.");
            dialogDictionary["furnitureChopping"].AddLinePickupQuest("Get rid of em.");
            // In Progress
            dialogDictionary["furnitureChopping"].AddLineQuestInProgress("Have you found them yet?");
            dialogDictionary["furnitureChopping"].AddLineQuestInProgress("My house is so empty.");
            // Handing In
            dialogDictionary["furnitureChopping"].AddLineHandingInQuest("Thank you!");
            dialogDictionary["furnitureChopping"].AddLineHandingInQuest("Now for your special reward.");
            dialogDictionary["furnitureChopping"].AddLineHandingInQuest("<You have received Meatballs>");

            // -------------------
            // Demon slayer
            // -------------------
            dialogDictionary["demonSlayer"] = new Dialog();
            dialogDictionary["demonSlayer"].givingQuest = new Quest(3, "Demon slayer", null);
            dialogDictionary["demonSlayer"].givingQuest.objectives.Add(new KillObjective(1, "Kill Oogaezal & Sidmoch", 2));
            dialogDictionary["demonSlayer"].givingQuest.objectives.Add(new KillObjective(1, "Kill Eeziulur & Scierocho", 3));
            // Pick up
            dialogDictionary["demonSlayer"].AddLinePickupQuest("Hello stranger.");
            dialogDictionary["demonSlayer"].AddLinePickupQuest("My name is Uwuwewewe ");
            dialogDictionary["demonSlayer"].AddLinePickupQuest("I'm the keeper of this dungeon.");
            dialogDictionary["demonSlayer"].AddLinePickupQuest("Unfortunately it has been invaded"); 
            dialogDictionary["demonSlayer"].AddLinePickupQuest("by some nasty demons.");
            dialogDictionary["demonSlayer"].AddLinePickupQuest("Please slay them for me");
            dialogDictionary["demonSlayer"].AddLinePickupQuest("so I can get my dungeon back.");
            // In Progress
            dialogDictionary["demonSlayer"].AddLineQuestInProgress("Go into the dungeon and slay the demons.");
            // Handing In
            dialogDictionary["demonSlayer"].AddLineHandingInQuest("Thank you stranger.");
            dialogDictionary["demonSlayer"].AddLineHandingInQuest("Have this as a token for my gratitude.");
            dialogDictionary["demonSlayer"].AddLineHandingInQuest("<You have received Eeziulur's Head>");
        }
    }
}
