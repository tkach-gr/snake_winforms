using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_WinForms_
{
    class GameLogic
    {
        Vector2i snakeDirection;
        Snake snake;
        Apple apple;

        public Vector2i SnakeDirection {
            get
            {
                return snakeDirection;
            }
            set
            {
                if (value * -1 != snakeDirection)
                    snakeDirection = value;
            }
        }
        public CellType[][] Map { get; private set; }

        public GameLogic(Vector2i mapSize, int snakeSize)
        {
            snake = new Snake(snakeSize);
            snake.MoveTo(mapSize / 2);

            SnakeDirection = new Vector2i(1, 0);

            apple = new Apple(mapSize);

            Map = new CellType[mapSize.Y][];

            for (int y = 0; y < Map.Length; y++)
            {
                Map[y] = new CellType[mapSize.X];

                for (int i = 0; i < Map[y].Length; i++)
                {
                    Map[y][i] = CellType.Empty;
                }
            }

            DrawSnake();
            Map[apple.Position.Y][apple.Position.X] = CellType.Apple;
        }

        public void NextFrame()
        {
            NextFrame(SnakeDirection);
        }
        public void NextFrame(Vector2i snakeDirection)
        {
            if (snakeDirection.X != 0 || snakeDirection.Y != 0)
            {
                ClearSnake();
                
                if (GetNextSnakeHeadPosition(SnakeDirection) == apple.Position)
                {
                    snake.Feed(snakeDirection);
                    GenerateNewApple();
                }
                else
                {
                    snake.Move(snakeDirection);
                }

                ReturnSnakeToMap();

                DrawSnake();

                Map[apple.Position.Y][apple.Position.X] = CellType.Apple;
            }
        }
        public void ClearSnake()
        {
            for (int i = 0; i < snake.Parts.Count; i++)
            {
                Map[snake.Parts[i].Y][snake.Parts[i].X] = CellType.Empty;
            }
        }
        public void DrawSnake()
        {
            for (int i = 0; i < snake.Parts.Count; i++)
            {
                Map[snake.Parts[i].Y][snake.Parts[i].X] = CellType.Snake;
            }
        }
        public void ReturnSnakeToMap()
        {
            Vector2i head = snake.Parts[0];

            if (head.X < 0)
                head.X = Map[0].Length - 1;

            if (head.Y < 0)
                head.Y = Map.Length - 1;

            if (head.X >= Map[0].Length)
                head.X = 0;

            if (head.Y >= Map.Length)
                head.Y = 0;

            snake.Parts[0] = head;
        }
        public void GenerateNewApple()
        {
            bool check = true;
            while (check)
            {
                apple = new Apple(new Vector2i(Map[0].Length, Map.Length));

                check = false;
                foreach (Vector2i part in snake.Parts)
                {
                    if (part == apple.Position)
                        check = true;
                }
            }
        }
        private Vector2i GetNextSnakeHeadPosition(Vector2i dir)
        {
            Vector2i head = snake.Parts[0] + dir;

            if (head.X < 0)
                head.X = Map[0].Length - 1;

            if (head.Y < 0)
                head.Y = Map.Length - 1;

            if (head.X >= Map[0].Length)
                head.X = 0;

            if (head.Y >= Map.Length)
                head.Y = 0;

            return head;
        }
    }
}
