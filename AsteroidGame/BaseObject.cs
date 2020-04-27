using System;
using System.Drawing;

namespace AsteroidGame
{
    abstract class BaseObject : ICollision
    {
        protected Point pos;
        protected Point dir;
        protected Size size;

        public BaseObject(Point pos, Point dir, Size size)
        {
            this.pos = pos;
            this.dir = dir;
            this.size = size;
        }

        
        public virtual void Draw()
        {
            Game.Buffer.Graphics.DrawEllipse(Pens.White, pos.X, pos.Y, size.Width, size.Height);
        }

        public abstract void Update();

        public Rectangle Rect => new Rectangle(pos, size);

        public bool Collision(ICollision obj) => obj.Rect.IntersectsWith(this.Rect);

    }
}
