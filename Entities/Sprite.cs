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
        public Vector2 origin = Vector2.Zero;
        public Vector2 velocity = Vector2.Zero;
        public Vector2 acceleration = Vector2.Zero;
        public Rectangle collisionRectangle;
        public Texture2D texture;
        public Sprite(string textureName)
        {
            Game1.textureAtlas.TryGetValue(textureName, out texture);
            if (texture == null)
                throw new NullReferenceException("The requested texture is not in the textureAtlas");
            collisionRectangle = new Rectangle(0, 0, texture.Width, texture.Height);
        }
        public Sprite(string textureName, Vector2 origin,Vector2 velocity,Vector2 acceleration)
        {
            Game1.textureAtlas.TryGetValue(textureName, out texture);
            collisionRectangle = new Rectangle((int)origin.X + texture.Width/2, (int)origin.Y + texture.Height/2, texture.Width, texture.Height);
        }

        public virtual void Update(GameTime gameTime)
        {
            //set the center of the collision rectangle equal to the origin.
            collisionRectangle.X = (int)origin.X - collisionRectangle.Width/2;
            collisionRectangle.Y = (int)origin.Y - collisionRectangle.Height/2;
        }
        public virtual void Draw(GameTime gameTime,SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, collisionRectangle, Color.White);
        }
    }
}
