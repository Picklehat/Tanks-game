using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanks.Classes
{
    internal class Game
    {
        private TankController player1;
        private TankController player2;
        private bool turnOne;
        private GameArea area;

        public Game(GameArea area)
        {
            turnOne = true;
            Random rnd = new Random();
            this.area = area;
            Point player1StartPos = new Point();
            Point player2StartPos = new Point();
            do
            {
                player1StartPos.X = rnd.Next(area.StartOfX + Tank.size, area.XSize - Tank.size);
                player1StartPos.Y = rnd.Next(area.StartOfY + Tank.size, area.YSize - Tank.size);
                player2StartPos.X = rnd.Next(area.StartOfX + Tank.size, area.XSize - Tank.size);
                player2StartPos.Y = rnd.Next(area.StartOfY + Tank.size, area.YSize - Tank.size);
            }
            while (!(Math.Abs(player1StartPos.X - player2StartPos.X) >= Tank.size * 3 && Math.Abs(player1StartPos.Y - player2StartPos.Y) >= Tank.size * 3));
            player1 = new TankController(player1StartPos.X, player1StartPos.Y);
            player2 = new TankController(player2StartPos.X, player2StartPos.Y);
        }

        public bool CheckWin()
        {
            return player1.Health <= 0 || player2.Health <= 0;
        }
        public void Draw(Graphics graphics)
        {
            graphics.Clear(Color.Gray);
            player1.Draw(graphics);
            player2.Draw(graphics);
        }

        public void NextTurn()
        {
            if (turnOne)
            {
                player1.TakeTurn(player2, Distanse(), area);
                turnOne = false;
            }
            else
            {
                player2.TakeTurn(player1, Distanse(), area);
                turnOne = true;
            }

        }

        public void ShowCurrentStats(Label Player1Label, Label Player2Label)
        {
            Player1Label.Text = $"Tank1:\nHealth: {player1.Health}\nPosition:{player1.Position.X}, {player1.Position.Y}" +
                $"\nBody: {player1.TankBodyInfo}\nCurrent bullet: {player1.CurrentBulletInfo}\n";
            Player2Label.Text = $"Tank2:\nHealth: {player2.Health}\nPosition:{player2.Position.X}, {player2.Position.Y}" +
                $"\nBody: {player2.TankBodyInfo}\nCurrent bullet: {player2.CurrentBulletInfo}\n";
        }

        private double Distanse()
        {
            return Math.Sqrt(Math.Pow(player1.Position.X - player2.Position.X, 2) + Math.Pow(player1.Position.Y - player2.Position.Y, 2));
        }
    }
}
