using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanks.Interfaces
{
    interface IBullet
    {
        public string BulletInfo { get; }
        public int Damage { get; }
        public int Range { get; }
    }

    struct ShortRangeBullet : IBullet
    {
        public string BulletInfo => "Short range";
        public int Damage => 80;
        public int Range => 400;
    }

    struct MiddleRangeBullet : IBullet
    {
        public string BulletInfo => "Middle range";
        public int Damage => 50;
        public int Range => 500;
    }

    struct LongRangeBullet : IBullet
    {
        public string BulletInfo => "Long range";
        public int Damage => 25;
        public int Range => 650;
    }
}