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
    class AITank:Tank
    {
        public override void Initialize()
        {
            base.Initialize();
            pos.X = 200;
            pos.Y = 400;
        }

        public override void Update(GameTime gameTime)
        {
            float timeDelta = (float)gameTime.ElapsedGameTime.TotalSeconds;

            float speed = 100.0f;

            pos += look * speed * timeDelta;

            look.X = (float)-Math.Cos(rotation);
            look.Y = (float)-Math.Sin(rotation);

            if (pos.X < 20)
            {
                rotation = MathHelper.Pi;
            }
            if (pos.X > 600)
            {
                rotation = 0.0f;
            }
        }
    }
}
