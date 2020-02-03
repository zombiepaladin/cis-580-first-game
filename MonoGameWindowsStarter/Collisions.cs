using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameWindowsStarter
{
    public static class Collisions
    {
        public static bool CollidesWith(this BoundingRectangle a, BoundingRectangle b)
        {
            return !(a.X > a.X + b.Width
                  || a.X + a.Width < b.X
                  || a.Y > b.Y + b.Height
                  || a.Y + a.Height < b.Y);
        }
    }
}
