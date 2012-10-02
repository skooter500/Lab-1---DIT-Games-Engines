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
    public class AITank:Tank
    {
        float targetRotation = 0.0f;
        bool rotating = false;
        Vector2 basis = new Vector2(0, -1);
        public override void Initialize()
        {
            base.Initialize();
            pos.X = 200;
            pos.Y = 400;
        }

        public override void Update(GameTime gameTime)
        {
            float timeDelta = (float)gameTime.ElapsedGameTime.TotalSeconds;

            float speed = 20.0f;

            Tank otherTank = Game1.Instance.Tank;
            // Calculate the distance to the other tank
            Vector2 toTarget = otherTank.pos - pos;
            float dist = toTarget.Length();
            if (dist < 150.0f)
            {
                // Calculate the angle to rotate to
                targetRotation = (float) Math.Acos(Vector2.Dot(basis, Vector2.Normalize(toTarget)));
                if (toTarget.X < 0 )
                {
                    targetRotation = (MathHelper.Pi * 2.0f) - targetRotation;
                }
                rotating = true;
            }
            else
            {
                rotating = false;
            }
            float epsylon = 0.1f;
            float rotAmount = 1.0f;
            if (rotating)
            {
                float direction = targetRotation - rotation;
                if (direction < 0)
                {
                    rotation -= rotAmount * timeDelta;
                }
                else
                {
                    rotation += rotAmount * timeDelta;
                }
                look.X = (float)Math.Sin(rotation);
                look.Y = - (float)Math.Cos(rotation);
                pos += look * speed * timeDelta;
            }
        }
    }
}
