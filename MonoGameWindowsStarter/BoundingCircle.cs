using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace MonoGameWindowsStarter
{
    public struct BoundingCircle
    {
        /// <summary>
        /// The center X coordinate of the circle
        /// </summary>
        public float X;

        /// <summary>
        /// The center Y coordinate of the circle
        /// </summary>
        public float Y;

        /// <summary>
        /// The radius of the circle
        /// </summary>
        public float Radius;

        /// <summary>
        /// Gets or sets the circle's center vector
        /// </summary>
        public Vector2 Center {
            get => new Vector2(X, Y);
            set { 
                X = value.X; 
                Y = value.Y; 
            }
        }

        /// <summary>
        /// Casts the circle into a rectangle with tangental sides
        /// </summary>
        /// <param name="c"></param>
        public static implicit operator Rectangle(BoundingCircle c)
        {
            return new Rectangle(
                (int)(c.X - c.Radius),
                (int)(c.Y - c.Radius),
                (int)(2 * c.Radius),
                (int)(2 * c.Radius)
                );
        }

    }
}
