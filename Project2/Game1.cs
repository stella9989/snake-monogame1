using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SnakeGame
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Snake snake;
        private Food food;
        private Spider spider;
        private Texture2D pixelTexture; // 单像素纹理，用于绘制矩形
        private int score; // 分数

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            base.Initialize();

            // 初始化游戏对象
            snake = new Snake(new Vector2(200, 200));
            food = new Food(new Vector2(300, 300));
            spider = new Spider(new Vector2(400, 400));
            score = 0;

            // 创建单像素纹理用于绘制矩形
            pixelTexture = new Texture2D(GraphicsDevice, 1, 1);
            pixelTexture.SetData(new[] { Color.White });
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void Update(GameTime gameTime)
        {
            // 退出游戏
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // 更新蛇、食物和障碍物的状态
            snake?.Update(gameTime);

            // 食物碰撞检测
            if (snake != null && food != null && snake.CollidesWith(food))
            {
                score += 10; // 加分
                food.Respawn(); // 食物重生
                snake.Grow();  // 蛇变长
            }

            // 障碍物碰撞检测
            if (snake != null && spider != null && snake.CollidesWith(spider))
            {
                Exit(); // 游戏结束
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // 绘制所有对象
            _spriteBatch.Begin();

            // 绘制蛇、食物和障碍物
            snake?.Draw(_spriteBatch, pixelTexture);
            food?.Draw(_spriteBatch, pixelTexture);
            spider?.Draw(_spriteBatch, pixelTexture);

            // 绘制分数（可选）
            DrawScore();

            _spriteBatch.End();

            base.Draw(gameTime);
        }

        private void DrawScore()
        {
            // 在屏幕上绘制分数，这里假设字体资源加载后才能实现
            // 建议加载 SpriteFont 资源后补充此方法
        }
    }
}
