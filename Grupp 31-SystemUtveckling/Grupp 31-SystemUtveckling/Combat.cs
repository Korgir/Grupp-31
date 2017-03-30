using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp_31_SystemUtveckling
{
    class Combat
    {
        protected List<Character> allCharacters;
        protected List<Character> team1;
        protected List<Character> team2;
        protected List<Character> initiativeOrder;
        protected int currentTurn;
        protected CombatState currentState;

        public enum CombatState { ChoseAction, PlayActions, SelectUnit }
        public enum ActionType { NoAction = -1, PassTurn = 0, BasicAttack = 1, CastSpell = 2, UseItem = 3 }

        public Combat(List<Character> team1, List<Character> team2)
        {
            this.team1 = team1;
            this.team2 = team2;
            allCharacters = new List<Character>();
            allCharacters.AddRange(team1);
            allCharacters.AddRange(team2);
            initiativeOrder = new List<Character>();
            
            this.currentTurn = 0;
            this.currentState = CombatState.ChoseAction;
        }

        public void Update(GameTime gameTime)
        {
            switch (currentState)
            {
                case (CombatState.ChoseAction):
                    ChoseActionState();
                    break;
                case (CombatState.PlayActions):
                    PlayActionState();
                    break;
                case (CombatState.SelectUnit):
                    SelectUnitState();
                    break;
            }
        }

        protected void ChoseActionState()
        {
            SetInitiativeOrder();
            if (currentTurn < initiativeOrder.Count)
            {
                Character actingCharacter = initiativeOrder[currentTurn];
                if (actingCharacter.action != (int)ActionType.NoAction)
                {
                    currentTurn++;
                }
                else if (actingCharacter.playerControlled)
                {
                    if (ChoseAction(actingCharacter))
                    {
                        if (actingCharacter.action == (int)ActionType.BasicAttack)
                        {
                            currentState = CombatState.SelectUnit;
                            return;
                        }
                        currentTurn++;
                    }
                }
                else if (!actingCharacter.playerControlled)
                {
                    // AI decide action
                    actingCharacter.action = (int)ActionType.BasicAttack;
                    currentTurn++;
                }
            }
            else
            {
                currentState = CombatState.PlayActions;
                currentTurn = 0;
            }
        }

        protected void PlayActionState()
        {
            if (currentTurn < initiativeOrder.Count)
            {
                Character actingCharacter = initiativeOrder[currentTurn];
                if (!actingCharacter.alive)
                {
                    actingCharacter.action = (int)ActionType.PassTurn;
                }

                if (actingCharacter.action == (int)ActionType.BasicAttack)
                {
                    if (team1.Contains(actingCharacter))
                    {
                        foreach (Character enemy in team2)
                        {
                            actingCharacter.AttackTarget(enemy);
                        }
                    }

                    if (team2.Contains(actingCharacter))
                    {
                        foreach (Character enemy in team1)
                        {
                            actingCharacter.AttackTarget(enemy);
                        }
                    }
                    actingCharacter.action = (int)ActionType.NoAction;
                }
                currentTurn++;
            }
            else
            {
                currentState = CombatState.ChoseAction;
                currentTurn = 0;
            }
        }

        protected void SelectUnitState()
        {
        }

        protected bool ChoseAction(Character actor)
        {
            if (KeyMouseReader.KeyPressed(Keys.D1))
            {
                actor.action = (int)ActionType.BasicAttack;
                return true;
            }
            if (KeyMouseReader.KeyPressed(Keys.D2))
            {
                actor.action = (int)ActionType.CastSpell;
                return true;
            }
            if (KeyMouseReader.KeyPressed(Keys.D3))
            {
                actor.action = (int)ActionType.UseItem;
                return true;
            }
            if (KeyMouseReader.KeyPressed(Keys.D4))
            {
                actor.action = (int)ActionType.PassTurn;
                return true;
            }

            return false;
        }

        protected void SetInitiativeOrder()
        {
            initiativeOrder.Clear();
            while (initiativeOrder.Count != allCharacters.Count)
            {
                Character fastestCharacter = null;
                foreach (Character c in allCharacters)
                {
                    if (fastestCharacter == null)
                    {
                        if (!initiativeOrder.Contains(c))
                        {
                            fastestCharacter = c;
                        }
                        else
                        {
                            continue;
                        }
                    }

                    if (!initiativeOrder.Contains(c) && c != fastestCharacter)
                    {
                        if (c.speed > fastestCharacter.speed)
                        {
                            fastestCharacter = c;
                        }
                    }
                }
                initiativeOrder.Add(fastestCharacter);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            int offsettingString = 0; // Remove later only test
            foreach (Character c in allCharacters)
            {
                c.Draw(spriteBatch);
                spriteBatch.DrawString(Archive.fontDictionary["defaultFont"], "[" + c.name + "] HP: " + c.health + "; Alive: " + c.alive, new Vector2(0, offsettingString), Color.Yellow);
                offsettingString += 16;
            }
        }

    }
}
