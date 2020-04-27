using System;
using System.Drawing;

namespace AsteroidGame
{
    abstract class BaseObject
    {
        protected Point pos;
        protected Point dir;
        protected Size size;

        public BaseObject(Point pos, Point dir, Size size)
        {
            this.pos = pos;
            this.dir = dir;
            this.size = size;
            if (size.Width < 0 || size.Height < 0)
            {
                throw new GameObjectException("Объект не может иметь отрицательный размер");
            }
            
        }

        
        public virtual void Draw()
        {
            Game.Buffer.Graphics.DrawEllipse(Pens.White, pos.X, pos.Y, size.Width, size.Height);
        }

        public abstract void Update();
               

    }
}
