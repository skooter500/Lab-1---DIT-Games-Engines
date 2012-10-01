using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace TankGame
{
    class Tank : Entity
    {
        // Fire 10 bullets per second
        float fireRate = 10.0f;
        float elapsed = 100.0f; // Set this to a high number so it lets me start firing straight away...

        Vector2 centre;
        public override void LoadContent()
        {
            base.LoadContent();
            Alive = true;

            sprite = Game1.Instance.Content.Load<Texture2D>("smalltank");

            centre.X = sprite.Width / 2;
            centre.Y = sprite.Height / 2;
        }

        public override void Update(GameTime gameTime)
        {
            float timeDelta = (float)gameTime.ElapsedGameTime.TotalSeconds;

            KeyboardState keyState = Keyboard.GetState();
            float speed = 100.0f;

            look.X = (float)Math.Sin(rotation);
            look.Y = (float)-Math.Cos(rotation);

            if (keyState.IsKeyDown(Keys.Q))
            {
                rotation -= (5.0f * timeDelta);
            }
            if (keyState.IsKeyDown(Keys.E))
            {
                rotation += (5.0f * timeDelta);
            }

            if (keyState.IsKeyDown(Keys.W))
            {
                pos += look * speed * timeDelta;
            }
            if (keyState.IsKeyDown(Keys.A))
            {
                pos.X -= (speed * timeDelta);
            }
            if (keyState.IsKeyDown(Keys.S))
            {
                pos.Y += (speed * timeDelta);
            }
            if (keyState.IsKeyDown(Keys.D))
            {
                pos.X += (speed * timeDelta);
            }

            if (keyState.IsKeyDown(Keys.Space))
            {
                if (elapsed > (1.0f / fireRate))
                {
                    Bullet bullet = new Bullet();
                    bullet.LoadContent();
                    bullet.look = look;
                    bullet.pos = pos + (look * (sprite.Height / 2));
                    Game1.Instance.children.Add(bullet);
                    elapsed = 0.0f;
                }
            }
            elapsed += timeDelta;
            if (elapsed >= 100.0f)
            {
                elapsed = 100.0f;
            }
        }

        public override void Draw(GameTime gameTime)
        {
            Game1.Instance.spriteBatch.Draw(sprite, pos, null, Color.White, rotation, centre, 1.0f, SpriteEffects.None, 1);
            //Game1.Instance.spriteBatch.Draw(sprite, pos, Color.White);
        }
    }
}
