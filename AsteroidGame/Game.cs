﻿using System;
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
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;

        public static BaseObject[] Objects;
        public static List<BaseObject> Lobjects;

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

            Buffer = _context.Allocate(graphics, new Rectangle(0, 0, Width, Height));
            Load();

            Timer timer = new Timer { Interval = 100 };
            timer.Start();
            timer.Tick += Timer_Tick;
        }

        public static void Load()
        {
            Random random = new Random();
            Objects = new BaseObject[45];
            for (int i = 0; i < Objects.Length * 2 / 3; i = i + 2)
            {
                Objects[i] = new Asteroids(new Point(600, i * 20), new Point(15 - i, 15 - i), new Size(20, 20));
            }
            for (int i = 1; i < Objects.Length * 2 / 3; i = i + 2)
            {
                Objects[i] = new Star(new Point(600, i * 20), new Point(i, 0), new Size(5, 5));
            }
            for (int i = Objects.Length * 2 / 3; i < Objects.Length; i++)
            {
                int x = 50 + (i - Objects.Length * 2 / 3) * (45);
                Objects[i] = new Star2(new Point(x, (int)(Math.Cos(0.04*x)*200 + 300)), new Point(4, 4), new Size(5, 5));
            }
        }

        public static void Draw()
        {
            //Buffer.Graphics.Clear(Color.Black);
            //Buffer.Graphics.DrawRectangle(Pens.White, new Rectangle(100, 100, 200, 200));
            //Buffer.Graphics.FillEllipse(Brushes.Wheat, new Rectangle(100, 100, 200, 200));
            //Buffer.Render();

            Buffer.Graphics.Clear(Color.Black);
            for (int i = 0; i < Objects.Length; i++)
            {
                Objects[i].Draw();
            }
            Buffer.Render();
        }

        public static void Update()
        {
            for (int i = 0; i < Objects.Length; i++)
            {
                Objects[i].Update();
            }
        }

        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }

    }
}
