using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_WinForms_
{
    struct Vector2i
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Vector2i(int x = 0, int y = 0)
        {
            X = x;
            Y = y;
        }

        public static Vector2i operator +(Vector2i left, Vector2i right)
        {
            return new Vector2i(left.X + right.X, left.Y + right.Y);
        }
        public static Vector2i operator -(Vector2i left, Vector2i right)
        {
            return new Vector2i(left.X - right.X, left.Y - right.Y);
        }
        public static Vector2i operator *(Vector2i left, Vector2i right)
        {
            return new Vector2i(left.X * right.X, left.Y * right.Y);
        }
        public static Vector2i operator *(Vector2i left, int right)
        {
            return new Vector2i(left.X * right, left.Y * right);
        }
        public static Vector2i operator /(Vector2i left, Vector2i right)
        {
            return new Vector2i(left.X / right.X, left.Y / right.Y);
        }
        public static Vector2i operator /(Vector2i left, int right)
        {
            return new Vector2i(left.X / right, left.Y / right);
        }
        public static Vector2i operator %(Vector2i left, Vector2i right)
        {
            return new Vector2i(left.X % right.X, left.Y % right.Y);
        }
        public static bool operator ==(Vector2i left, Vector2i right)
        {
            if (left.X == right.X && left.Y == right.Y)
                return true;
            else
                return false;
        }
        public static bool operator !=(Vector2i left, Vector2i right)
        {
            if (left.X != right.X || left.Y != right.Y)
                return true;
            else
                return false;
        }
        public override bool Equals(object obj)
        {
            if (!(obj is Vector2i))
            {
                return false;
            }

            var i = (Vector2i)obj;
            return X == i.X &&
                   Y == i.Y;
        }
        public override int GetHashCode()
        {
            var hashCode = 1861411795;
            hashCode = hashCode * -1521134295 + X.GetHashCode();
            hashCode = hashCode * -1521134295 + Y.GetHashCode();
            return hashCode;
        }
    }
}
