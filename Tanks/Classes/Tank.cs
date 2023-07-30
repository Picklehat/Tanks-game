using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Tanks.Interfaces;

namespace Tanks.Classes
{
    class Tank
    {
        //Поля
        private Stack<IBullet> ammo;
        private ITankBody body;
        private int health;
        private Point position;
        public static int size = 50;// потом разберусь

        //Свойства
        public int Health
        {
            get { return health; }
            set
            {
                if (value < 0)
                    health = 0;
                else
                    health = value;
            }
        }

        public Point Position
        {
            get => position;
            private set => position = value;
        }

        public IBullet CurrentAmmo
        {
            get
            {
                return ammo.Peek();
            }
        }

        public bool AmmoIsEmpty
        {
            get
            {
                return ammo.Count == 0;
            }
        }

        public string TankBodyInfo
        {
            get
            {
                return body.TankBodyInfo;
            }
        }

        public string CurrentBulletInfo
        {
            get
            {
                if (ammo.Count == 0)
                    return "Empty";
                else
                    return ammo.Peek().BulletInfo;
            }
        }
        public int Speed
        {
            get
            {
                return (int)(-1.0 * (1.0 / 30.0) * body.Weight + 60.0);
              //  return Convert.ToInt32(-1.0 * (1.0 / 30.0) * body.Weight + 60.0); //Функция скорости от веса (вес от 20 до 1000)
            }
        }

        //Конструктор
        public Tank(int x, int y)
        {
            Random rnd = new Random();

            Position = new Point(x, y);

            health = 100;



            body = rnd.Next(0, 3) switch
            {
                0 => new LightTankBody(),
                1 => new NormalTankBody(),
                2 => new HeavyTankBody(),

            };

            ammo = new Stack<IBullet>();
            Reload();
        }

        //Методы
        public void Reload()
        {
            Random rnd = new Random();
            ammo.Clear();
            for (int i = 0; i < 10; i++)
            {
                switch (rnd.Next(0, 3))
                {
                    case 0:
                        ammo.Push(new ShortRangeBullet());
                        break;
                    case 1:
                        ammo.Push(new MiddleRangeBullet());
                        break;
                    case 2:
                        ammo.Push(new LongRangeBullet());
                        break;
                }
            }
        }

        public void Move(int StartOfX, int EndOfX, int StartOfY, int EndOfY)
        {

            Random rnd = new Random();
            double angle = Convert.ToDouble(rnd.Next(0, 4) * (Math.PI / 2));
            position.X += Convert.ToInt32(Speed * Math.Sin(angle));
            position.Y += Convert.ToInt32(Speed * Math.Cos(angle));

            if (position.X < StartOfX + size)
                position.X = StartOfX + size;

            if (position.X > EndOfX - size)
                position.X = EndOfX - size;

            if (position.Y < StartOfY + size)
                position.Y = StartOfY + size;

            if (position.Y > EndOfY - size)
                position.Y = EndOfY - size;
        } 

        public void Shoot(Tank enemyTank, double distanse)
        {
            enemyTank.GetHit(ammo.Pop(), distanse);
        }

        public void GetHit(IBullet bullet, double distanse)
        {
            Random rnd = new Random();
            if (bullet.Range / distanse * rnd.Next(20) > 13)
                Health -= (int)(bullet.Damage * (1 - body.Hardness));
        }
    }
}