using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp_31_SystemUtveckling
{
    class PortalEntity : Entity
    {
        public string zoneName;
        public Vector2 spawnPosition;

        public PortalEntity(Texture2D texture, Vector2 position, string zoneName, Vector2 spawnPosition)
            : base(texture, position)
        {
            this.zoneName = zoneName;
            this.spawnPosition = spawnPosition;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }
    }
}
