using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace SnakeGame
{
    public class Snake
    {
        private List<Vector2> body;
        private Vector2 direction;
        private int gridSize = 20;

        public Snake(Vector2 startPosition)
        {
            body = new List<Vector2> { startPosition };
            direction = new Vector2(1, 0); // 初始向右
        }

        public void Update(GameTime gameTime)
        {
            var keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(Keys.W)) direction = new Vector2(0, -1);
            if (keyboardState.IsKeyDown(Keys.S)) direction = new Vector2(0, 1);
            if (keyboardState.IsKeyDown(Keys.A)) direction = new Vector2(-1, 0);
            if (keyboardState.IsKeyDown(Keys.D)) direction = new Vector2(1, 0);

            // 移动身体
            for (int i = body.Count - 1; i > 0; i--)
            {
                body[i] = body[i - 1];
            }
            body[0] += direction * gridSize;
        }

        public void Grow()
        {
            body.Add(body[^1]);
        }

        public void Draw(SpriteBatch spriteBatch, Texture2D texture)
        {
            foreach (var segment in body)
            {
                spriteBatch.Draw(texture, new Rectangle((int)segment.X, (int)segment.Y, gridSize, gridSize), Color.Green);
            }
        }

        public bool CollidesWith(Food food)
        {
            return Vector2.Distance(body[0], food.Position) < gridSize;
        }

        public bool CollidesWith(Spider spider)
        {
            return Vector2.Distance(body[0], spider.Position) < gridSize;
        }
    }
}
