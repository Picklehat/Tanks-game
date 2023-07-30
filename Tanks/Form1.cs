using System.Runtime.CompilerServices;
using System.Timers;
using Tanks.Classes;

namespace Tanks
{
    public partial class Form1 : Form
    {
        private Graphics graphics;
        private GameArea area;
        private System.Timers.Timer aTimer;
        Game game;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            area = new GameArea();
            game = new Game(area);
            SetTimer();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            graphics = CreateGraphics();
            graphics.SetClip(area.gameArea);
            game.Draw(graphics);
            game.ShowCurrentStats(Player1Label, Player2Label);
        }

        private void SetTimer()
        {
            aTimer = new System.Timers.Timer(500);
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            game.NextTurn();
            Invalidate();
            if (game.CheckWin())
            {
                aTimer.Enabled = false;

                DialogResult result = MessageBox.Show(
                "Game over. Play again?",
                "Choose",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.None,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly);

                if (result == DialogResult.Yes)
                {
                    game = new Game(area);
                    aTimer.Enabled = true;
                }
                else
                {
                    Application.Exit();
                }
            }
        }
    }
}