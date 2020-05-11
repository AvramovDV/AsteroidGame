using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsteroidGame
{
    internal abstract class BaseCollisionObject : BaseObject, ICollision
    {

        public delegate void Message();

        public BaseCollisionObject(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }
                
        public Rectangle Rect => new Rectangle(pos, size);

        public bool Collision(ICollision obj) => obj.Rect.IntersectsWith(this.Rect);

        public abstract void OnCollisionEnter();

    }
}
