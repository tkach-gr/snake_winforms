using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Snake_WinForms_
{
    class SnakeForm : Form
    {
        Timer timer;
        Size buttonSize;

        public Button[][] Buttons { get; set; }

        public event Action OnTimerTick;

        public SnakeForm(int xButtonsAmount, int yButtonsAmount)
        {
            buttonSize = new Size(30, 30);

            ClientSize = new Size(xButtonsAmount * buttonSize.Width, yButtonsAmount * buttonSize.Height);
            BackColor = Color.LightGreen;
            KeyPreview = true;

            Buttons = new Button[yButtonsAmount][];
            for (int y = 0; y < Buttons.Length; y++)
            {
                Buttons[y] = new Button[xButtonsAmount];

                for (int i = 0; i < Buttons[y].Length; i++)
                {
                    Button but = new Button();
                    but = new Button();
                    but.Size = buttonSize;
                    but.Location = new Point(i * but.Size.Width, y * but.Size.Height);
                    Buttons[y][i] = but;
                    Controls.Add(but);
                }
            }

            timer = new Timer();
            timer.Interval = 50;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            OnTimerTick.Invoke();
            timer.Start();
        }
    }
}
