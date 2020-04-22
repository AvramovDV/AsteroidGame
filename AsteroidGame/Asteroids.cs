using System;
using System.Drawing;
using System.IO;


namespace AsteroidGame
{
    class Asteroids : BaseObject
    {
        private string _fileName = "Asteroid.png";
        private Image _image;
        
        public Asteroids(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            _image = Image.FromFile(_fileName);
        }

        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(_image, pos.X, pos.Y, size.Width, size.Height);
        }

    }
}
