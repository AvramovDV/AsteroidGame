﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsteroidGame
{
    internal class Ship : BaseCollisionObject
    {
        private int _energy = 100;

        public static event Message MessageDie;

        public int Energy { get => _energy; }

        public Ship(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }

        public void EnergyLow(int n)
        {
            _energy -= n;
        }

        public override void Draw()
        {
            Game.Buffer.Graphics.FillEllipse(Brushes.Wheat, pos.X, pos.Y, size.Width, size.Height);
        }

        public override void OnCollisionEnter()
        {
            Random rnd = new Random();
            EnergyLow(rnd.Next(1, 10));
            System.Media.SystemSounds.Asterisk.Play();
            if (Energy <= 0)
            {
                Die();
            }
        }

        public override void Update()
        {
            
        }

        public void Up()
        {
            if (pos.Y > 0) 
            {
                pos.Y = pos.Y - dir.Y;
            }
        }

        public void Down()
        {
            if (pos.Y < Game.Height)
            {
                pos.Y = pos.Y + dir.Y;
            }
        }

        public void Die()
        {
            MessageDie?.Invoke();
        }

    }
}
