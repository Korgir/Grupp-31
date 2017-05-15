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
            // Goblin Slayer dialog
            dialogDictionary["testDialog"] = new Dialog();
            dialogDictionary["testDialog"].givingQuest = new Quest(1, "Goblin slayer", ItemDatabase.items["redSword"]);
            dialogDictionary["testDialog"].givingQuest.objectives.Add(new KillObjective(3, "Kill goblin teams.", 1));
            // Pick up
            dialogDictionary["testDialog"].AddLinePickupQuest("Sup homie!");
            dialogDictionary["testDialog"].AddLinePickupQuest("Kill this goblin.");
            dialogDictionary["testDialog"].AddLinePickupQuest("plz, u get reward.");
            // In Progress
            dialogDictionary["testDialog"].AddLineQuestInProgress("Fucking goblins.");
            dialogDictionary["testDialog"].AddLineQuestInProgress("#NotRacist");
            // Handing In
            dialogDictionary["testDialog"].AddLineHandingInQuest("Ey!");
            dialogDictionary["testDialog"].AddLineHandingInQuest("You killed them");
            dialogDictionary["testDialog"].AddLineHandingInQuest("here");
            dialogDictionary["testDialog"].AddLineHandingInQuest("have this.");

            // Find the key dialog
            dialogDictionary["testQuestDialog"] = new Dialog();
            dialogDictionary["testQuestDialog"].givingQuest = new Quest(2, "Find the quest item", null);
            dialogDictionary["testQuestDialog"].givingQuest.objectives.Add(new ItemObjective(1, "Quest item found.", 999));
            // Pick up
            dialogDictionary["testQuestDialog"].AddLinePickupQuest("Hello.");
            dialogDictionary["testQuestDialog"].AddLinePickupQuest("Find my quest item.");
            dialogDictionary["testQuestDialog"].AddLinePickupQuest("It's a key.");
            // In Progress
            dialogDictionary["testQuestDialog"].AddLineQuestInProgress("Have you found it?");
            // Handing In
            dialogDictionary["testQuestDialog"].AddLineHandingInQuest("Thanks");

        }
    }
}
