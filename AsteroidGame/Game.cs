using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace AsteroidGame
{
    static class Game
    {
        private const int _asteroidSize = 20;
        private const int _asteroidSpeed = 5;
        private const int _asteroidCount = 20;

        private const int _starSize = 5;
        private const int _starSpeed = 10;
        private const int _starCount = 20;

        private const int _star2Size = 5;
        private const int _star2Speed = 5;
        private const int _star2Count = 10;

        private const int _bulletSpeed = 5;
        private const int _bulletSize = 20;

        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer { get; set; }

        //public static BaseObject[] Objects;
        public static List<BaseObject> Objects { get; set; }
        public static List<BaseCollisionObject> CollisionObjects { get; set; }

        public static Bullet _bullet { get; set; }

        public static int Width { get; set; }
        public static int Height { get; set; }

        static Game()
        {

        }

        public static void Init(Form form)
        {
            Graphics graphics;
            graphics = form.CreateGraphics();

            _context = BufferedGraphicsManager.Current;
            
            Width = form.ClientSize.Width;
            Height = form.ClientSize.Height;

            if (Width > 1000 || Width < 0 || Height > 1000 || Height < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            Buffer = _context.Allocate(graphics, new Rectangle(0, 0, Width, Height));
            Load();

            Timer timer = new Timer { Interval = 100 };
            timer.Start();
            timer.Tick += Timer_Tick;
        }

        public static void Load()
        {
            Random rand = new Random();
            //Objects = new BaseObject[45];
            Objects = new List<BaseObject>();
            CollisionObjects = new List<BaseCollisionObject>();

            for (int i = 0; i < _asteroidCount; i++)
            {
                CollisionObjects.Add(new Asteroids(new Point(rand.Next(0, 600), (int)(i * (1f / (_asteroidCount - 1)) * Height)), new Point(_asteroidSpeed, 0), new Size(_asteroidSize, _asteroidSize)));
            }
            for (int i = 0; i < _starCount; i++)
            {
                Objects.Add(new Star(new Point(rand.Next(0, 600), (int)((i + 1) * (1f / (_starCount - 1)) * Height)), new Point(_starSpeed, 0), new Size(_starSize, _starSize)));
            }
            for (int i = 0; i < _star2Count; i++)
            {
                Objects.Add(new Star2(new Point((int)(Width * (i + 0.5f) / _star2Count), (int)rand.Next(0, Height)), new Point(_star2Speed, _star2Speed), new Size(_star2Size, _star2Size)));
            }

            _bullet = new Bullet(new Point(0, rand.Next(10, Height - 10)), new Point(_bulletSpeed, 0), new Size(_bulletSize, _bulletSize));

        }

        public static void Draw()
        {
            //Buffer.Graphics.Clear(Color.Black);
            //Buffer.Graphics.DrawRectangle(Pens.White, new Rectangle(100, 100, 200, 200));
            //Buffer.Graphics.FillEllipse(Brushes.Wheat, new Rectangle(100, 100, 200, 200));
            //Buffer.Render();

            Buffer.Graphics.Clear(Color.Black);
            for (int i = 0; i < Objects.Count; i++)
            {
                Objects[i].Draw();
            }

            for (int i = 0; i < CollisionObjects.Count; i++)
            {
                CollisionObjects[i].Draw();
            }
            _bullet.Draw();

            Buffer.Render();
        }

        public static void Update()
        {
            for (int i = 0; i < Objects.Count; i++)
            {
                Objects[i].Update();
                
            }

            for (int i = 0; i < CollisionObjects.Count; i++)
            {
                CollisionObjects[i].Update();

                if (CollisionObjects[i].Collision(_bullet))
                {
                    System.Media.SystemSounds.Hand.Play();
                    CollisionObjects[i].OnCollisionEnter();
                    _bullet.OnCollisionEnter();
                }
            }

            _bullet.Update();
        }

        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }

    }
}
