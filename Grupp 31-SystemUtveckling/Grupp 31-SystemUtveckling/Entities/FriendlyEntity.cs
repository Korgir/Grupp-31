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
    class FriendlyEntity : Entity
    {
        public Dialog dialog;

        public FriendlyEntity(Texture2D texture, Vector2 position, Dialog dialog) : base(texture, position)
        {
            this.dialog = dialog;
        }

        public bool CanTalk(Player player)
        {
            int distanceX = (int)(player.position.X - (int)position.X) / Archive.tileSize;
            int distanceY = (int)(player.position.Y - (int)position.Y) / Archive.tileSize;
            if (distanceX <= 1 && distanceX >= -1 && distanceY <= 1 && distanceY >= -1)
            {
                return true;
            }
            return false;
        }

        public void DrawDialog(SpriteBatch spriteBatch, Vector2 position)
        {
            dialog.Draw(spriteBatch, position);
        }
    }
}
