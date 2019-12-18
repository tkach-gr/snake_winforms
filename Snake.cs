using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_WinForms_
{
    class Snake
    {
        public List<Vector2i> Parts { get; private set; }

        public Snake(int length = 3)
        {
            Parts = new List<Vector2i>();

            for (int i = 0; i < length; i++)
            {
                Parts.Add(new Vector2i(-i, 0));
            }
        }

        public void Move(Vector2i dir)
        {
            Parts.Remove(Parts.Last());
            for (int i = 0; i < Parts.Count; i++)
            {
                if (Parts[0] + dir == Parts[i])
                {
                    while(Parts.Count > i)
                    {
                        Parts.Remove(Parts[i]);
                    }
                }
            }
            Parts.Insert(0, Parts[0] + dir);
        }
        public void MoveTo(Vector2i coords)
        {
            Vector2i difference = Parts[0] - coords;
            for (int i = 0; i < Parts.Count; i++)
            {
                Parts[i] -= difference;
            }
        }
        public void Feed(Vector2i dir)
        {
            Parts.Insert(0, Parts[0] + dir);
        }
        public override string ToString()
        {
            string output = string.Empty;
            for (int i = 0; i < Parts.Count; i++)
            {
                output += $"{i}: {{ X: {Parts[i].X}, Y: {Parts[i].Y} }}\n";
            }
            return output;
        }
    }
}
