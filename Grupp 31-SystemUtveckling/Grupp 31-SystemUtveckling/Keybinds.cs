using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp_31_SystemUtveckling
{
    static class Keybinds
    {
        public static Dictionary<string, Keys> binds = new Dictionary<string, Keys>();

        public static void Initialize()
        {
            binds["toggleFullscreen"] = Keys.F11;
            binds["back"] = Keys.Escape;
            binds["goToEditor"] = Keys.E;
            binds["start"] = Keys.Enter;

            binds["moveUp"] = Keys.W;
            binds["moveDown"] = Keys.S;
            binds["moveLeft"] = Keys.A;
            binds["moveRight"] = Keys.D;
            binds["talk"] = Keys.Space;

            binds["characterTab"] = Keys.D1;
            binds["inventoryTab"] = Keys.D2;
            binds["questTab"] = Keys.D3;
            binds["mapTab"] = Keys.D4;

            binds["combatAction1"] = Keys.D1;
            binds["combatAction2"] = Keys.D2;
            binds["combatAction3"] = Keys.D3;
            binds["combatAction4"] = Keys.D4;
            binds["combatPass"] = Keys.D5;

            binds["editorFloor"] = Keys.D1;
            binds["editorWall"] = Keys.D2;
            binds["editorEntity"] = Keys.D3;
            binds["editorItem"] = Keys.D4;
            binds["editorSaveMap"] = Keys.F1;
            binds["editorLoadMap"] = Keys.F2;
            binds["editorToggleGrid"] = Keys.G;
        }
    }
}
