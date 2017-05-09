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
        public bool fadingOut;
        public Texture2D scenaryTexture;
        protected List<Character> allCharacters;
        protected List<Character> team1;
        protected List<Character> team2;
        protected List<Character> initiativeOrder;
        protected int currentTurn;
        protected CombatState currentState;
        protected float timeFadeOutSeconds, totalTimeFadeOutSeconds;

        protected List<Vector2> positionsTeam1;
        protected List<Vector2> positionsTeam2;

        protected Character selectingCharacter;
        protected Spell selectingSpell;
        protected List<Button> buttons;

        public enum CombatState { ChoseAction, PlayActions, SelectUnit }
        public enum ActionType { NoAction = -1, PassTurn = 0, BasicAttack = 1,
            CastSpell = 2, UseItem = 3 }

        public int enemyID;
        public int winnerTeam;

        public Combat(List<Character> team1, List<Character> team2, int enemyID)
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

            AddButtons();

            timeFadeOutSeconds = 1.5f;
            totalTimeFadeOutSeconds = 1.5f;
            fadingOut = true;
            this.currentTurn = 0;
            this.currentState = CombatState.ChoseAction;

            winnerTeam = -1;
            this.enemyID = enemyID;

            SetCharacterPositions();
        }

        protected void AddButtons()
        {
            buttons = new List<Button>();
            for (int i = 0; i < 5; i++)
            {
                Point location = new Point(88 + i * 160, 880);
                Point size = new Point(144, 144);
                buttons.Add(new Button(new Rectangle(location, size), Archive.textureDictionary["iconEmpty"],
                    Archive.fontDictionary["defaultFont"], "", Keys.A));
            }

            buttons[0].keyBind = Keybinds.binds["combatAction1"];
            buttons[1].keyBind = Keybinds.binds["combatAction2"];
            buttons[2].keyBind = Keybinds.binds["combatAction3"];
            buttons[3].keyBind = Keybinds.binds["combatAction4"];
            buttons[4].keyBind = Keybinds.binds["combatPass"];
            buttons[4].texture = Archive.textureDictionary["iconPass"];
        }

        protected void UpdateButtonIcons(Character actor)
        {
            for (int i = 0; i < 4; i++)
            {
                if (i < actor.spells.Count())
                {
                    buttons[i].texture = actor.spells[i].iconTexture;
                }
                else
                {
                    buttons[i].texture = Archive.textureDictionary["iconEmpty"];
                }
            }
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
                        PlayActionState(gameTime);
                        break;
                    case (CombatState.SelectUnit):
                        SelectUnitState();
                        break;
                }

                foreach (Character c in allCharacters)
                {
                    foreach (Spell s in c.spells)
                    {
                        s.Update(gameTime);
                    }
                }

                active = IsCombatActive();
            }
            else
            {
                if (timeFadeOutSeconds > 0)
                {
                    fadingOut = true;
                    timeFadeOutSeconds -= (float)gameTime.ElapsedGameTime.TotalSeconds;
                }
                else
                {
                    fadingOut = false;
                }
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
                    UpdateButtonIcons(actingCharacter);
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
                    if (actingCharacter.action != (int)ActionType.PassTurn)
                    {
                        // AI decide action
                        actingCharacter.action = (int)ActionType.BasicAttack;
                        TargetSpell attackSpell = (TargetSpell)actingCharacter.spells[0];
                        attackSpell.target = team1[0]; // Attack first character
                    }
                    currentTurn++;
                }
            }
            else
            {
                currentState = CombatState.PlayActions;
                currentTurn = 0;
            }
        }

        protected bool AnimationsPlaying()
        {
            foreach (Character c in allCharacters)
            {
                foreach (Spell s in c.spells)
                {
                    if (s.playingAnimation)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        protected void PlayActionState(GameTime gameTime)
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
                if (!AnimationsPlaying())
                {
                    currentTurn++;
                }
            }
            else
            {
                currentState = CombatState.ChoseAction;
                currentTurn = 0;
                foreach (Character c in allCharacters)
                {
                    c.OnNewTurn();
                }
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
                winnerTeam = 2;
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
                winnerTeam = 1;
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

        protected bool TryCastSpell(Character actor, int spellIndex)
        {
            if (actor.spells.Count > spellIndex)
            {
                if (actor.mana >= actor.spells[spellIndex].manaCost)
                {
                    actor.mana -= actor.spells[spellIndex].manaCost;
                    actor.action = (int)ActionType.CastSpell;
                    actor.spellToCast = spellIndex;
                    return true;
                }
            }
            return false;
        }

        protected bool ChoseAction(Character actor)
        {
            if (buttons[0].IsClicked())
            {
                actor.action = (int)ActionType.BasicAttack;
                return true;
            }
            else if (buttons[4].IsClicked())
            {
                actor.action = (int)ActionType.PassTurn;
                return true;
            }
            else
            {
                for (int i = 1; i <= 3; i++)
                {
                    if (buttons[i].IsClicked())
                    {
                        if (TryCastSpell(actor, i))
                        {
                            return true;
                        }
                    }
                }
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
                foreach (Spell s in c.spells)
                {
                    s.Draw(spriteBatch);
                }
                HealthBar.Draw(spriteBatch, c, Color.Green);
                spriteBatch.DrawString(Archive.fontDictionary["defaultFont"], "[" + c.name + "] HP: " + c.health + "; Alive: " + c.alive, new Vector2(0, offsettingString), Color.Yellow);
                offsettingString += 16;
            }

            DrawUI(spriteBatch);

            if (fadingOut)
            {
                spriteBatch.Draw(Archive.textureDictionary["whitePixel"], new Rectangle(0, 0, 1920, 1080),
                    new Color(Color.Black, 1 - (timeFadeOutSeconds / totalTimeFadeOutSeconds)));
            }
        }

        protected void DrawUI(SpriteBatch spriteBatch)
        {
            foreach (Character c in allCharacters)
            {
                foreach (Spell s in c.spells)
                {
                    s.DrawUI(spriteBatch);
                }
            }

            spriteBatch.Draw(Archive.textureDictionary["uiCombat"], Vector2.Zero, Color.White);

            foreach (Button b in buttons)
            {
                b.Draw(spriteBatch);
            }

            DrawStats(spriteBatch);
        }

        protected void DrawStats(SpriteBatch spriteBatch)
        {
            Character actor = team1[0];
            Vector2 position = new Vector2(1030, 880);
            spriteBatch.DrawString(Archive.fontDictionary["infoFont"],
                "Health: " + actor.health + "/" + actor.maxHealth,
                position, Color.Black);
            position.Y += 36;
            spriteBatch.DrawString(Archive.fontDictionary["infoFont"],
                "Mana: " + actor.mana + "/" + actor.maxMana + "(+" + actor.manaRegeneration + ")",
                position, Color.Black);
            position.Y += 36;
            spriteBatch.DrawString(Archive.fontDictionary["infoFont"],
                "Armor: " + (actor.armor),
                position, Color.Black);
            position.Y += 36;
            spriteBatch.DrawString(Archive.fontDictionary["infoFont"],
                "Speed: " + (actor.speed),
                position, Color.Black);

            position = new Vector2(1460, 880);
            spriteBatch.DrawString(Archive.fontDictionary["infoFont"],
                "Damage: " + actor.physicalDamageMin + "-" + actor.physicalDamageMax +
                "(" + ((actor.physicalDamageMax + actor.physicalDamageMin) / 2) + ")",
                position, Color.Black);
            position.Y += 36;
            spriteBatch.DrawString(Archive.fontDictionary["infoFont"],
                "Magic amp: " + actor.magicAmplification,
                position, Color.Black);
        }
    }
}
