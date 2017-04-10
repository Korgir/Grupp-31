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
        public bool active;
        public Texture2D scenaryTexture;
        protected List<Character> allCharacters;
        protected List<Character> team1;
        protected List<Character> team2;
        protected List<Character> initiativeOrder;
        protected int currentTurn;
        protected CombatState currentState;

        protected List<Vector2> positionsTeam1;
        protected List<Vector2> positionsTeam2;

        protected Character selectingCharacter;
        protected Spell selectingSpell;

        public enum CombatState { ChoseAction, PlayActions, SelectUnit }
        public enum ActionType { NoAction = -1, PassTurn = 0, BasicAttack = 1,
            CastSpell = 2, UseItem = 3 }

        public Combat(List<Character> team1, List<Character> team2)
        {
            active = true;
            this.scenaryTexture = Archive.textureDictionary["combatScenary"];
            this.team1 = team1;
            this.team2 = team2;
            allCharacters = new List<Character>();
            allCharacters.AddRange(team1);
            allCharacters.AddRange(team2);
            initiativeOrder = new List<Character>();
            positionsTeam1 = new List<Vector2>();
            positionsTeam2 = new List<Vector2>();

            this.currentTurn = 0;
            this.currentState = CombatState.ChoseAction;

            SetCharacterPositions();
        }

        protected void SetCharacterPositions()
        {
            int horizontalGrowth = 50;
            int verticalGrowth = 100;
            int startHeight = 500;

            int charactersAmount = team1.Count();
            for (int i = 0; i < charactersAmount; i++)
            {
                Vector2 startPoint = new Vector2(500, startHeight - 50 * charactersAmount);
                team1[i].Position = startPoint + new Vector2(horizontalGrowth * i + Archive.randomizer.Next(-100, 100), verticalGrowth * i);
            }
            charactersAmount = team2.Count();
            for (int i = 0; i < charactersAmount; i++)
            {
                Vector2 startPoint = new Vector2(1420, startHeight - 50 * charactersAmount);
                team2[i].Position = startPoint + new Vector2(-horizontalGrowth * i + Archive.randomizer.Next(-100, 100), verticalGrowth * i);
            }
        }

        public void Update(GameTime gameTime)
        {
            if (active)
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

                active = IsCombatActive();
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
                            selectingCharacter = actingCharacter;
                            selectingSpell = actingCharacter.spells[0];
                            currentState = CombatState.SelectUnit;
                            return;
                        }

                        if (actingCharacter.action == (int)ActionType.CastSpell)
                        {
                            if (actingCharacter.spells[actingCharacter.spellToCast] is TargetSpell)
                            {
                                selectingCharacter = actingCharacter;
                                selectingSpell = actingCharacter.spells[actingCharacter.spellToCast];
                                currentState = CombatState.SelectUnit;
                            }
                            return;
                        }
                        currentTurn++;
                    }
                }
                else if (!actingCharacter.playerControlled)
                {
                    // AI decide action
                    actingCharacter.action = (int)ActionType.BasicAttack;
                    TargetSpell attackSpell = (TargetSpell)actingCharacter.spells[0];
                    attackSpell.target = team1[0]; // Attack first character
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

                if (actingCharacter.action == (int)ActionType.PassTurn)
                {
                    actingCharacter.action = (int)ActionType.NoAction;
                }

                if (actingCharacter.action == (int)ActionType.BasicAttack)
                {
                    actingCharacter.spells[0].CastSpell();
                    actingCharacter.action = (int)ActionType.NoAction;
                }

                if (actingCharacter.action == (int)ActionType.CastSpell)
                {
                    actingCharacter.spells[actingCharacter.spellToCast].CastSpell();
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

        protected bool IsCombatActive()
        {
            int survivorsTeam1 = 0;
            foreach (Character c in team1)
            {
                if (c.alive)
                {
                    survivorsTeam1++;
                }
            }
            if (survivorsTeam1 == 0)
            {
                return false;
            }

            int survivorsTeam2 = 0;
            foreach (Character c in team2)
            {
                if (c.alive)
                {
                    survivorsTeam2++;
                }
            }
            if (survivorsTeam2 == 0)
            {
                return false;
            }

            return true;
        }

        protected void SelectUnitState()
        {
            TargetSpell spellToChange = (TargetSpell)selectingSpell;
            Character previousCharacter = null;
            Color outlineColor = Color.Yellow;

            foreach (Character c in allCharacters)
            {
                if (team1.Contains(c))
                {
                    if (spellToChange.targetTeam == TargetSpell.TargetTeam.Enemy)
                    {
                        c.outlineColor = Color.Red;
                    }
                }
                else
                {
                    c.outlineColor = Color.Yellow;
                }

                if (c.hitbox.Contains(KeyMouseReader.mousePosition))
                {
                    if (previousCharacter != null)
                    {
                        previousCharacter.drawOutline = false;
                    }
                    c.drawOutline = true;
                }
                else
                {
                    c.drawOutline = false;
                }
                previousCharacter = c;

                if (c.hitbox.Contains(KeyMouseReader.mousePosition) && KeyMouseReader.LeftClick())
                {
                    if (team2.Contains(c))
                    {
                        if (spellToChange.targetTeam == TargetSpell.TargetTeam.Enemy)
                        {
                            spellToChange.target = c;

                            c.drawOutline = false;

                            currentState = CombatState.ChoseAction;
                        }
                    }
                }
            }
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
                if (actor.spells.Count >= 2)
                {
                    actor.action = (int)ActionType.CastSpell;
                    actor.spellToCast = 1;
                    return true;
                }
            }
            if (KeyMouseReader.KeyPressed(Keys.D3))
            {
                if (actor.spells.Count >= 3)
                {
                    actor.action = (int)ActionType.CastSpell;
                    actor.spellToCast = 2;
                    return true;
                }
            }
            if (KeyMouseReader.KeyPressed(Keys.D4))
            {
                if (actor.spells.Count >= 4)
                {
                    actor.action = (int)ActionType.CastSpell;
                    actor.spellToCast = 3;
                    return true;
                }
            }
            if (KeyMouseReader.KeyPressed(Keys.D5))
            {
                if (actor.spells.Count >= 5)
                {
                    actor.action = (int)ActionType.CastSpell;
                    actor.spellToCast = 4;
                    return true;
                }
            }
            //if (KeyMouseReader.KeyPressed(Keys.D6))
            //{
            //    actor.action = (int)ActionType.UseItem;
            //    return true;
            //}
            if (KeyMouseReader.KeyPressed(Keys.D7))
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
            spriteBatch.Draw(scenaryTexture, Vector2.Zero, Color.White);
            int offsettingString = 80; // Remove later only test
            spriteBatch.DrawString(Archive.fontDictionary["defaultFont"], "Press 1 for normal attack and 2 for fireball attack.", new Vector2(0, 64), Color.Purple);
            spriteBatch.DrawString(Archive.fontDictionary["defaultFont"], "Active: " + active +  "; State: " + currentState, new Vector2(0, offsettingString), Color.Red);
            offsettingString += 16;
            foreach (Character c in allCharacters)
            {
                c.Draw(spriteBatch);
                HealthBar.Draw(spriteBatch, c, Color.Green);
                spriteBatch.DrawString(Archive.fontDictionary["defaultFont"], "[" + c.name + "] HP: " + c.health + "; Alive: " + c.alive, new Vector2(0, offsettingString), Color.Yellow);
                offsettingString += 16;
            }

            spriteBatch.Draw(Archive.textureDictionary["uiCombat"], Vector2.Zero, Color.White);
        }
    }
}
