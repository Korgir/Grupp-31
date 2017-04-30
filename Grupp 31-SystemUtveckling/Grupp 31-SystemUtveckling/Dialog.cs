﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp_31_SystemUtveckling
{
    class Dialog
    {
        SpriteFont font;
        List<string> dialogLines;
        int currentLine;
        bool finished;

        public Dialog()
        {
            font = Archive.fontDictionary["dialogFont"];
            dialogLines = new List<string>();
            currentLine = 0;
            finished = false;
        }

        public void AddLine(string text)
        {
            dialogLines.Add(text);
        }

        public void Update()
        {
            if (KeyMouseReader.KeyPressed(Keybinds.binds["talk"]))
            {
                currentLine++;
                if (currentLine >= dialogLines.Count())
                {
                    currentLine = 0;
                    finished = true;
                }
            }
        }

        public void StopTalking()
        {
            currentLine = 0;
            finished = false;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            spriteBatch.DrawString(font, dialogLines[currentLine], position, Color.White, 0.0f,
                font.MeasureString(dialogLines[currentLine]) / 2, 1.0f, SpriteEffects.None, 0);
        }
    }
}