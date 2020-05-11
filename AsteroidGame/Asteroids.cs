using System;
using System.Drawing;
using System.IO;


namespace AsteroidGame
{
    class Asteroids : BaseCollisionObject
    {
        private const string _fileName = "Asteroid.png";
        private Image _image;
        
        public Asteroids(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            _image = Image.FromFile(_fileName);
        }

        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(_image, pos.X, pos.Y, size.Width, size.Height);
        }
                
        public override void Update()
        {
            pos.X = pos.X - dir.X;
            if (pos.X < 0) pos.X = Game.Width + size.Width;
        }

        public override void OnCollisionEnter()
        {
            //pos.X = Game.Width;
            Game.DestroyAsteroid(this);
        }

    }
}
