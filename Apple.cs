using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_WinForms_
{
    class Apple
    {
        public Vector2i Position { get; set; }

        public Apple(Vector2i border)
        {
            Random rand = new Random((int)DateTime.Now.Ticks);
           
            Position = new Vector2i(rand.Next(border.X), rand.Next(border.Y));
        }
    }
}
