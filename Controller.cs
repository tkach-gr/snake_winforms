using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Snake_WinForms_
{
    class Controller
    {
        GameLogic gameLogic;
        SnakeForm snakeForm;

        public Controller()
        {
            gameLogic = new GameLogic(new Vector2i(30, 19), 5);

            snakeForm = new SnakeForm(30, 19);
            snakeForm.KeyDown += MyForm_KeyDown;
            snakeForm.OnTimerTick += GameIteration;
        }

        private void MyForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
                gameLogic.SnakeDirection = new Vector2i(0, -1);
            else if (e.KeyCode == Keys.A)
                gameLogic.SnakeDirection = new Vector2i(-1, 0);
            else if (e.KeyCode == Keys.D)
                gameLogic.SnakeDirection = new Vector2i(1, 0);
            else if (e.KeyCode == Keys.S)
                gameLogic.SnakeDirection = new Vector2i(0, 1);
        }

        public void Run()
        {
            Application.Run(snakeForm);
        }

        private void GameIteration()
        {
            CellType[][] map = gameLogic.Map;
            Button[][] buttons = snakeForm.Buttons;

            for (int y = 0; y < map.Length; y++)
            {
                for (int i = 0; i < map[y].Length; i++)
                {
                    Button button = buttons[y][i];
                    CellType cell = map[y][i];
                    Color color;

                    if (cell == CellType.Snake)
                        color = Color.Green;
                    else if (cell == CellType.Apple)
                        color = Color.Red;
                    else
                        color = Color.LightGreen;

                    if (button.BackColor != color)
                        button.BackColor = color;
                }
            }

            gameLogic.NextFrame();
        }
    }
}
