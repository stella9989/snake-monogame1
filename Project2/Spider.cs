using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace SnakeGame
{
    public class Spider
    {
        public Vector2 Position { get; private set; }
        private float lifeTime = 5.0f; // 蜘蛛存在时间
        private float timer;
        private int gridSize = 20;

        public Spider(Vector2 startPosition)
        {
            Position = startPosition;
            timer = 0;
        }

        public void Update(GameTime gameTime)
        {
            timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (timer > lifeTime)
            {
                Respawn();
                timer = 0;
            }
        }

        public void Respawn()
        {
            Position = new Vector2(
                Random.Shared.Next(0, 800 / gridSize) * gridSize,
                Random.Shared.Next(0, 600 / gridSize) * gridSize
            );
        }

        public void Draw(SpriteBatch spriteBatch, Texture2D texture)
        {
            spriteBatch.Draw(texture, new Rectangle((int)Position.X, (int)Position.Y, gridSize, gridSize), Color.Purple);
        }
    }
}
