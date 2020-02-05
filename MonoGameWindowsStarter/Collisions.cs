using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace MonoGameWindowsStarter
{
    public static class Collisions
    {
        /// <summary>
        /// Detects collisions between this BoundingRectangle and another BoundingRectangle
        /// </summary>
        /// <param name="a">This BoundingRectangle</param>
        /// <param name="b">The other BoundingRectangle</param>
        /// <returns>true if there is a collision, false otherwise</returns>
        public static bool CollidesWith(this BoundingRectangle a, BoundingRectangle b)
        {
            return !(a.X > a.X + b.Width
                  || a.X + a.Width < b.X
                  || a.Y > b.Y + b.Height
                  || a.Y + a.Height < b.Y);
        }

        /// <summary>
        /// Detects collisions between this BoundingCircle and another BoundingCircle
        /// </summary>
        /// <param name="a">This BoundingCircle</param>
        /// <param name="b">The other BoundingCircle</param>
        /// <returns>true if there is a collision, false otherwise</returns>
        public static bool CollidesWith(this BoundingCircle a, BoundingCircle b)
        {
            return Math.Pow(a.Radius + b.Radius, 2) >= Math.Pow(a.X - b.X, 2) + Math.Pow(a.Y - b.Y, 2);
        }

        /// <summary>
        /// Detects collisions between this BoundingCircle and a BoundingRectangle
        /// </summary>
        /// <param name="c">This BoundingCircle</param>
        /// <param name="r">The BoundingRectangle</param>
        /// <returns>true if there is a collision, false otherwise</returns>
        public static bool CollidesWith(this BoundingCircle c, BoundingRectangle r)
        {
            var closestX = Math.Max(Math.Min(c.X, r.X + r.Width), r.X);
            var closestY = Math.Max(Math.Min(c.Y, r.Y + r.Height), r.Y);
            return (Math.Pow(c.Radius, 2) >= Math.Pow(closestX - c.X, 2) + Math.Pow(closestY - c.Y, 2));
        }

        /// <summary>
        /// Detects collisions between this BoundingRectangle and a BoundingCircle
        /// </summary>
        /// <param name="r">This BoundingRectangle</param>
        /// <param name="c">The BoundingCircle</param>
        /// <returns>true if there is a collision, false otherwise</returns>
        public static bool CollidesWith(this BoundingRectangle r, BoundingCircle c)
        {
            return c.CollidesWith(r);
        }

        /// <summary>
        /// Detects if this Vector2 collides with another
        /// </summary>
        /// <param name="v">This Vector2</param>
        /// <param name="other">The other Vector2</param>
        /// <returns>true if there is a collision, false otherwise</returns>
        public static bool CollidesWith(this Vector2 v, Vector2 other)
        {
            return v == other;
        }

        /// <summary>
        /// Detects if this Vector2 collides with a BoundingRectangle
        /// </summary>
        /// <param name="v">This Vector2</param>
        /// <param name="r">The BoundingRectangle</param>
        /// <returns>true if there is a collision, false otherwise</returns>
        public static bool CollidesWith(this Vector2 v, BoundingRectangle r)
        {
            return (r.X <= v.X && v.X <= r.X + r.Width)
                && (r.Y <= v.Y && v.Y <= r.Y + r.Height);
        }

        /// <summary>
        /// Detects if this BoundingRectangle collides with a Vector2
        /// </summary>
        /// <param name="r">This BoundingRectangle</param>
        /// <param name="v">The Vector2</param>
        /// <returns>true if there is a collision, false otherwise</returns>
        public static bool CollidesWith(this BoundingRectangle r, Vector2 v)
        {
            return v.CollidesWith(r);
        }

        /// <summary>
        /// Detects if this Vector2 collides with a BoundingCircle
        /// </summary>
        /// <param name="v">This Vector2</param>
        /// <param name="c">The BoundingCircle</param>
        /// <returns>true if there is a collision, false otherwise</returns>
        public static bool CollidesWith(this Vector2 v, BoundingCircle c)
        {
            return Math.Pow(c.Radius, 2) >= Math.Pow(v.X - c.X, 2) + Math.Pow(v.Y - c.Y, 2);
        }

        // <summary>
        /// Detects if this BoundingCircle collides with a Vector2
        /// </summary>
        /// <param name="c">This BoundingCircle</param>
        /// <param name="v">The Vector2</param>
        /// <returns>true if there is a collision, false otherwise</returns>
        public static bool CollidesWith(this BoundingCircle c, Vector2 v)
        {
            return v.CollidesWith(c);
        }
    }
}
