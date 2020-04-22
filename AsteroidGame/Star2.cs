using System;
using System.Drawing;


namespace AsteroidGame
{
    class Star2 :BaseObject
    {
        private float _maxSize = 30f;
        public Star2 (Point pos, Point dir, Size size) : base(pos, dir, size)
        {

        }

        public override void Draw()
        {
            Game.Buffer.Graphics.DrawLine(Pens.White, pos.X - size.Width / 2, pos.Y - size.Height / 2, pos.X + size.Width / 2, pos.Y + size.Height / 2);
            Game.Buffer.Graphics.DrawLine(Pens.White, pos.X + size.Width / 2, pos.Y - size.Height / 2, pos.X - size.Width / 2, pos.Y + size.Height / 2);

            Game.Buffer.Graphics.DrawLine(Pens.White, pos.X - size.Width / 2, pos.Y, pos.X + size.Width / 2, pos.Y);
            Game.Buffer.Graphics.DrawLine(Pens.White, pos.X, pos.Y - size.Height / 2, pos.X, pos.Y + size.Height / 2);
        }

        public override void Update()
        {
            size.Width += dir.X;
            size.Height += dir.Y;
            if (size.Width >= _maxSize || size.Height >= _maxSize)
            {
                dir.X = -dir.X;
                dir.Y = -dir.Y;
            }
            if (size.Width <= 0 || size.Height <= 0)
            {
                dir.X = -dir.X;
                dir.Y = -dir.Y;
            }
        }
    }
}
