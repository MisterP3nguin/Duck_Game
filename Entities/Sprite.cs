using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Duck_Game.Entities
{
    public class Sprite
    {
        public Vector2 position = Vector2.Zero;
        public Vector2 velocity = Vector2.Zero;
        public Vector2 acceleration = Vector2.Zero;
        public Rectangle collisionRectangle;
        public Texture2D texture;
        public Sprite(string textureName)
        {
            Game1.textureAtlas.TryGetValue(textureName, out texture);
            collisionRectangle = new Rectangle(0, 0, texture.Width, texture.Height);
        }
        public Sprite(string textureName, Vector2 position,Vector2 velocity,Vector2 acceleration)
        {
            Game1.textureAtlas.TryGetValue(textureName, out texture);
            collisionRectangle = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
        }

        public virtual void Update(GameTime gameTime)
        {
            collisionRectangle.X = (int)position.X;
            collisionRectangle.Y = (int)position.Y;
        }
        public virtual void Draw(GameTime gameTime)
        {

        }
    }
}
