using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tanks.Interfaces;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace Tanks.Classes
{
    internal class TankController
    {
        //Поля
        private Tank tank;

        //Свойства
        public bool Alive
        {
            get { return tank.Health > 0; }
        }

        public int Health
        {
            get { return tank.Health; }
        }

        public Point Position
        {
            get { return tank.Position; }
        }
        public string TankBodyInfo
        {
            get { return tank.TankBodyInfo; }
        }

        public string CurrentBulletInfo
        {
            get
            {
                return tank.CurrentBulletInfo;
            }
        }
        // гетеры для статы и для класса game

        //Конструктор
        public TankController(int x, int y)
        {
            tank = new Tank(x, y);
        }

        //Методы
        public void Draw(Graphics graphics)
        {
            Rectangle tankFrame = new Rectangle(tank.Position.X - Tank.size, tank.Position.Y - Tank.size, Tank.size * 2, Tank.size * 2);
            if (tank.Health > 65)
                graphics.FillRectangle(Brushes.Green, tankFrame);
            else if (tank.Health > 30 && tank.Health <= 65)
                graphics.FillRectangle(Brushes.Orange, tankFrame);
            else if (tank.Health <= 30)
                graphics.FillRectangle(Brushes.Red, tankFrame);
        }

        public void Hit(IBullet bullet, double distanse)
        {
            tank.GetHit(bullet, distanse);
        }

        public void TakeTurn(TankController enemyTank, double distanse, GameArea area)
        {
            if (tank.AmmoIsEmpty)
                tank.Reload();
            else if (distanse <= tank.CurrentAmmo.Range)
                tank.Shoot(enemyTank.tank, distanse);
            else
                tank.Move(area.StartOfX, area.EndOfX, area.StartOfY, area.EndOfY);
        }
    }
}
