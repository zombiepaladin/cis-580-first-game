using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace MonoGameWindowsStarter
{
    /// <summary>
    /// A class representing a ball
    /// </summary>
    public class Ball
    {
        /// <summary>
        /// The game the ball belongs to
        /// </summary>
        Game1 game;

        /// <summary>
        /// The ball's texture
        /// </summary>
        Texture2D texture;

        /// <summary>
        /// The ball's bounds
        /// </summary>
        public BoundingCircle Bounds;

        /// <summary>
        /// The ball's velocity vector
        /// </summary>
        public Vector2 Velocity;

        /// <summary>
        /// Creates a new ball
        /// </summary>
        /// <param name="game">The game the ball belongs to</param>
        public Ball(Game1 game)
        {
            this.game = game;
        }

        /// <summary>
        /// Initializes the ball, placing it in the center 
        /// of the screen and giving it a random velocity
        /// vector of length 1.
        /// </summary>
        public void Initialize()
        {
            // Set the ball's radius
            Bounds.Radius = 25;

            // position the ball in the center of the screen
            Bounds.X = game.GraphicsDevice.Viewport.Width / 2;
            Bounds.Y = game.GraphicsDevice.Viewport.Height / 2;

            // give the ball a random velocity
            Velocity = new Vector2(
                (float)game.Random.NextDouble(),
                (float)game.Random.NextDouble()
            );
            Velocity = new Vector2(-1, -1);
            Velocity.Normalize();
        }

        /// <summary>
        /// Loads the ball's texture
        /// </summary>
        /// <param name="content">The ContentManager to use</param>
        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("ball");
        }

        /// <summary>
        /// Updates the ball's position and bounces it off walls
        /// </summary>
        /// <param name="gameTime">The current GameTime</param>
        public void Update(GameTime gameTime)
        {
            var viewport = game.GraphicsDevice.Viewport;

            Bounds.Center += 0.5f * (float)gameTime.ElapsedGameTime.TotalMilliseconds * Velocity;

            // Check for wall collisions
            if (Bounds.Center.Y < Bounds.Radius)
            {
                Velocity.Y *= -1;
                float delta = Bounds.Radius - Bounds.Y;
                Bounds.Y += 2 * delta;
            }

            if (Bounds.Center.Y > viewport.Height - Bounds.Radius)
            {
                Velocity.Y *= -1;
                float delta = viewport.Height - Bounds.Radius - Bounds.Y;
                Bounds.Y += 2 * delta;
            }

            if (Bounds.X < 0)
            {
                //Velocity.X *= -1;
                //float delta = Bounds.Radius - Bounds.X;
                //Bounds.X += 2 * delta;
                Velocity = Vector2.Zero;
            }

            if (Bounds.X > viewport.Width - Bounds.Radius)
            {
                Velocity.X *= -1;
                float delta = viewport.Width - Bounds.Radius - Bounds.X;
                Bounds.X += 2 * delta;
            }
        }

        /// <summary>
        /// Draws the ball
        /// </summary>
        /// <param name="spriteBatch">
        /// The SpriteBatch to use to draw the ball.  
        /// This method should be invoked between 
        /// SpriteBatch.Begin() and SpriteBatch.End() calls.
        /// </param>
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, Bounds, Color.White);
        }
    }
}
