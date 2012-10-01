using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TankGame
{
    class Bullet : Entity
    {
        Vector2 center;
        public override void LoadContent()
        {
            speed = 200.0f;
            sprite = Game1.Instance.Content.Load<Texture2D>("bullet");
            center.X = sprite.Width / 2;
            center.Y = sprite.Height / 2;
            Alive = true;
        }
        public override void Update(GameTime gameTime)
        {
            float timeDelta = (float)gameTime.ElapsedGameTime.TotalSeconds;
            pos += speed * look * timeDelta;

            if ((pos.X < 0) || (pos.X >= Game1.Instance.ScreenWidth) || (pos.Y < 0) || (pos.Y >= Game1.Instance.ScreenHeight))
            {
                Alive = false;
            }
        }
        public override void Draw(GameTime gameTime)
        {
            Game1.Instance.spriteBatch.Draw(sprite, pos, null, Color.White, rotation, center, Vector2.One, SpriteEffects.None, 0);
        }
    }
}
