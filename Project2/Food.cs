using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace SnakeGame
{
    public class Food
    {
        public Vector2 Position { get; private set; }
        private int gridSize = 20;

        public Food(Vector2 startPosition)
        {
            Position = startPosition;
        }

        public void Update(GameTime gameTime)
        {
            // 可添加动画或效果
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
            spriteBatch.Draw(texture, new Rectangle((int)Position.X, (int)Position.Y, gridSize, gridSize), Color.Red);
        }
    }
}
