using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystemPrototyp
{
    static class AssetsManager
    {
        public static Texture2D redSwordTex, steelSwordTex, tabTex;

        public static void LoadContent(ContentManager content)
        {
            redSwordTex = content.Load<Texture2D>("RedSword");
            steelSwordTex = content.Load<Texture2D>("SteelSword");
            tabTex = content.Load<Texture2D>("tabTestTex");
        }
    }
}
