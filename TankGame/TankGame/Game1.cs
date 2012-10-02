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
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        public static Game1 Instance;
        public GraphicsDeviceManager graphics;
        public SpriteBatch spriteBatch;
        private Tank tank;
        private AITank aiTank;

        public AITank AITank
        {
            get { return aiTank; }
            set { aiTank = value; }
        }

        public Tank Tank
        {
            get { return tank; }
            set { tank = value; }
        }

        public int ScreenWidth
        {
            get { return GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width; }
        }

        public int ScreenHeight
        {
            get { return GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height; }
        }

        public List<Entity> children = new List<Entity>();
        public Game1()
        {
            Instance = this;
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            tank = new Tank();
            aiTank = new AITank();
            aiTank.pos = new Vector2(600, 400);
            children.Add(tank);
<<<<<<< HEAD
            children.Add(aiTank);
            
=======

>>>>>>> Solution
            foreach (Entity entity in children)
            {
                entity.Initialize();
            }

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            for (int i = 0; i < children.Count; i++)
            {
                children[i].LoadContent();
            }
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            for (int i = 0; i < children.Count; i++)
            {
                children[i].Update(gameTime);
                if (!children[i].Alive)
                {
                    children.Remove(children[i]);
                }
            }
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            spriteBatch.Begin();
            for (int i = 0; i < children.Count; i++)
            {
                children[i].Draw(gameTime);
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
