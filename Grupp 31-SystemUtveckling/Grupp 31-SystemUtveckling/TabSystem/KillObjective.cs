using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp_31_SystemUtveckling
{
    class KillObjective : Objective
    {
        public int teamID;

        public KillObjective(int goal, string description, int teamID)
            : base(goal, description)
        {
            this.teamID = teamID;
        }

        public void CheckTeam(int teamID)
        {
            if (this.teamID == teamID)
            {
                progress++;
            }
        }
    }
}
