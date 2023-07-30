using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanks.Interfaces
{
    interface ITankBody
    {
        public string TankBodyInfo { get; }
        public double Hardness { get; }
        public int Weight { get; }
    }

    struct LightTankBody : ITankBody
    {
        public string TankBodyInfo => "Light";
        public double Hardness => 0.2;
        public int Weight => 300;
    }

    struct NormalTankBody : ITankBody
    {
        public string TankBodyInfo => "Normal";
        public double Hardness => 0.6;
        public int Weight => 600;
    }

    struct HeavyTankBody : ITankBody
    {
        public string TankBodyInfo => "Heavy";
        public double Hardness => 0.9;
        public int Weight => 900;
    }
}
