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
    public class Tank : Entity
    {
        public override void LoadContent()
        {
            base.LoadContent();

            sprite = Game1.Instance.Content.Load<Texture2D>("smalltank");
        }

        public override void Update(GameTime gameTime) 
        {
            float timeDelta = (float)gameTime.ElapsedGameTime.TotalSeconds;

            KeyboardState keyState = Keyboard.GetState();
            float speed = 100.0f;

            // Calculate the correct look vector for the tank

            //

            

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
        }

        public override void Draw(GameTime gameTime)
        {
            Vector2 origin;
            origin.X = sprite.Width / 2;
            origin.Y = sprite.Height / 2;

            Game1.Instance.spriteBatch.Draw(sprite, pos, null, Color.White, rotation, origin, 1.0f, SpriteEffects.None, 1);
            //Game1.Instance.spriteBatch.Draw(sprite, pos, Color.White);
        }
    }
}
