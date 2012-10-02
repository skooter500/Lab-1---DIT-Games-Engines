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

        // Fire 10 bullets per second
        float fireRate = 10.0f;
        float elapsed = 100.0f; // Set this to a high number so it lets me start firing straight away...


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
                    targetRotation = - targetRotation;
                }
                rotating = true;
            }
            else
            {
                rotating = false;
            }
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
                // Move in the direction I am rotated to
                pos += look * speed * timeDelta;

                // Is it time to firs a bullet
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

    }
}
