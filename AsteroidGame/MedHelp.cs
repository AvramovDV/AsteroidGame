using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsteroidGame
{
    internal class MedHelp : BaseCollisionObject
    {
        public MedHelp(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }

        public override void Draw()
        {
            Game.Buffer.Graphics.FillEllipse(Brushes.Red, pos.X, pos.Y, size.Width, size.Height);
            Game.Buffer.Graphics.DrawEllipse(Pens.White, pos.X, pos.Y, size.Width, size.Height);
            Game.Buffer.Graphics.DrawLine(Pens.White, pos.X + 5, pos.Y + size.Height / 2, pos.X + size.Width - 5, pos.Y + size.Height / 2);
            Game.Buffer.Graphics.DrawLine(Pens.White, pos.X + size.Width / 2, pos.Y + 5, pos.X + size.Width / 2, pos.Y + size.Height - 5);
        }

        public override void OnCollisionEnter()
        {
            Random rnd = new Random();
            Game._ship.EnergyLow(rnd.Next(-10, -1));
            pos = new Point(Game.Width, rnd.Next(10, Game.Height - 10));
        }

        public override void Update()
        {
            pos.X = pos.X - dir.X;
            if (pos.X <= 0)
            {
                Random rnd = new Random();
                pos = new Point(Game.Width, rnd.Next(10, Game.Height - 10));
            }
        }
    }
}
