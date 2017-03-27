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

        public enum CombatState { ChoseAction, PlayActions }

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
            if (currentState == CombatState.ChoseAction)
            {
                ChoseActionState();
            }

            if (currentState == CombatState.PlayActions)
            {
                PlayActionState();
            }
        }

        protected void ChoseActionState()
        {
            SetInitiativeOrder();
            if (currentTurn < initiativeOrder.Count)
            {
                if (initiativeOrder[currentTurn].playerControlled)
                {
                    if (ChoseAction(initiativeOrder[currentTurn]))
                    {
                        currentTurn++;
                    }
                }

                if (!initiativeOrder[currentTurn].playerControlled)
                {
                    // AI decide action
                    initiativeOrder[currentTurn].action = 1;
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
                if (initiativeOrder[currentTurn].action == 1)
                {
                    if (team1.Contains(initiativeOrder[currentTurn]))
                    {
                        foreach (Character enemy in team2)
                        {
                            enemy.Damage(5, Character.DamageType.Magical);
                        }
                    }

                    if (team2.Contains(initiativeOrder[currentTurn]))
                    {
                        foreach (Character enemy in team1)
                        {
                            enemy.Damage(5, Character.DamageType.Magical);
                        }
                    }
                    initiativeOrder[currentTurn].action = 0;
                }
                currentTurn++;
            }
            else
            {
                currentState = CombatState.ChoseAction;
                currentTurn = 0;
            }
        }

        protected bool ChoseAction(Character actor)
        {
            if (KeyMouseReader.KeyPressed(Keys.D1))
            {
                actor.action = 1;
                return true;
            }
            if (KeyMouseReader.KeyPressed(Keys.D2))
            {
                actor.action = 2;
                return true;
            }
            if (KeyMouseReader.KeyPressed(Keys.D3))
            {
                actor.action = 3;
                return true;
            }
            if (KeyMouseReader.KeyPressed(Keys.D4))
            {
                actor.action = 0;
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
                spriteBatch.DrawString(Archive.fontDictionary["defaultFont"], "HP: " + c.health, new Vector2(0, offsettingString), Color.Yellow);
                offsettingString += 16;
            }
        }

    }
}
