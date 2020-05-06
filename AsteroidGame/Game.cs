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
        private const int _bulletSize = 5;

        private const int _medHelpSpeed = 5;
        private const int _medHelpSize = 15;

        private static BufferedGraphicsContext _context;

        private static Timer _timer = new Timer();

        public static BufferedGraphics Buffer { get; set; }

        //public static BaseObject[] Objects;
        public static List<BaseObject> Objects { get; set; }
        public static List<BaseCollisionObject> CollisionObjects { get; set; }
        public static List<Bullet> Bullets { get; set; }

        public static Bullet _bullet { get; set; }

        public static Ship _ship { get; set; }

        public static MedHelp _medHelp { get; set; }

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

            _timer = new Timer { Interval = 100 };
            _timer.Start();
            _timer.Tick += Timer_Tick;

            form.KeyDown += Form_KeyDown;

            Ship.MessageDie += Finish;

        }

        public static void Load()
        {
            Random rand = new Random();
            //Objects = new BaseObject[45];
            Objects = new List<BaseObject>();
            CollisionObjects = new List<BaseCollisionObject>();
            Bullets = new List<Bullet>();

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

            //_bullet = new Bullet(new Point(0, rand.Next(10, Height - 10)), new Point(_bulletSpeed, 0), new Size(_bulletSize, _bulletSize));

            _ship = new Ship(new Point(10, 400), new Point(5, 5), new Size(10, 10));

            _medHelp = new MedHelp(new Point(Width, rand.Next(10, Height - 10)), new Point(_medHelpSpeed, 0), new Size(_medHelpSize, _medHelpSize));

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

            for (int i = 0; i < Bullets.Count; i++)
            {
                Bullets[i].Draw();
            }

            //_bullet?.Draw();

            _ship.Draw();

            _medHelp?.Draw();

            if (_ship != null)
            {
                Buffer.Graphics.DrawString($"Energy: {_ship.Energy}", SystemFonts.DefaultFont, Brushes.White, 0, 0);
            }

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

                for (int j = 0; j < Bullets.Count; j++)
                {
                    if (CollisionObjects[i].Collision(Bullets[j]))
                    {
                        System.Media.SystemSounds.Hand.Play();
                        CollisionObjects[i].OnCollisionEnter();
                        //_bullet.OnCollisionEnter();
                        //Bullets.RemoveAt(j);
                        Bullets[j].OnCollisionEnter();
                    }
                }

                //if (_bullet != null && CollisionObjects[i].Collision(_bullet))
                //{
                //    System.Media.SystemSounds.Hand.Play();
                //    CollisionObjects[i].OnCollisionEnter();
                //    //_bullet.OnCollisionEnter();
                //    _bullet = null;
                //}

                if (CollisionObjects[i].Collision(_ship))
                {
                    CollisionObjects[i].OnCollisionEnter();
                    _ship.OnCollisionEnter();
                }
            }

            for (int j = 0; j < Bullets.Count; j++)
            {
                Bullets[j].Update();
            }

            //_bullet?.Update();

            _medHelp.Update();

            if (_medHelp.Collision(_ship))
            {
                _medHelp.OnCollisionEnter();
            }

        }

        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }

        private static void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey) 
            {
                //_bullet = new Bullet(new Point(_ship.Rect.X + 10, _ship.Rect.Y + 4), new Point(4, 0), new Size(4, 1));
                Bullets.Add(new Bullet(new Point(_ship.Rect.X + 10, _ship.Rect.Y + 4), new Point(4, 0), new Size(4, 1)));
            }
            if (e.KeyCode == Keys.Up)
            {
                _ship.Up();
            }
            if (e.KeyCode == Keys.Down)
            {
                _ship.Down();
            }
        }

        public static void Finish()
        {
            _timer.Stop();
            Buffer.Graphics.DrawString("The End", new Font(FontFamily.GenericSansSerif, 60, FontStyle.Underline), Brushes.White, 200, 100);
            Buffer.Render();
        }

        public static void DestroyBullet(Bullet bullet)
        {
            Bullets.Remove(bullet);
        }

    }
}
