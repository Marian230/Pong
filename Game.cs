using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Game
    {
        public Random MyRandom { get; set; } = new Random();

        public Position ConsoleDim { get; set; }

        public ConsoleColors Colors { get; set; } = new ConsoleColors(Console.BackgroundColor, Console.ForegroundColor);


        private List<GameObject> GameObjects { get; set; }

        public Ball Ball { get; private set; }
        private Player Player1 { get; set; }
        private Player Player2 { get; set; }


        public ConsoleKey? Input { get; set; } = null;

        public List<ConsoleKey> Output { get; set; } = new List<ConsoleKey>();

        // in milliseconds
        private int RefreshRate { get; set; }
        public bool EndOfGame { get; set; } = false;

        private Game()
        {
            this.InitializeGame();
        }
        private static readonly Game instance = new();
        public static Game Instance => Game.instance;


        private void InitializeGame()
        {
            Drawing.InitializeConsole();

            this.ConsoleDim = new Position(Console.WindowWidth, Console.WindowHeight);

            // GAME SETTINGS
            this.RefreshRate = 5;
            Player.Length = 10;

            this.Ball = new Ball((this.ConsoleDim.X / 2, this.GetRandCoord().Item2),  "Ball", (this.MyRandom.Next(2), this.MyRandom.Next(2)));
            this.Player1 = new Player((1, this.ConsoleDim.Y / 2),                     "Player 1", (ConsoleKey.W, ConsoleKey.S));
            this.Player2 = new Player((this.ConsoleDim.X - 2, this.ConsoleDim.Y / 2), "Player 2", (ConsoleKey.UpArrow, ConsoleKey.DownArrow));

            this.GameObjects = new List<GameObject>()
            {
                this.Ball,
                this.Player1,
                this.Player2,
            };
        }

        public void Play()
        {
            do
            {
                this.GetInput();
                this.Move();
                this.Draw();
                Thread.Sleep(this.RefreshRate);
                Drawing.Clear();
            } while (!this.EndOfGame);
        }

        public void Move()
        {
            this.GameObjects.ForEach(x => x.Move());
        }

        public void Draw()
        {
            this.GameObjects.ForEach(x => x.Draw());
        }

        public void GetInput()
        {
            this.Input = Console.KeyAvailable ? Console.ReadKey(true).Key : null;
        }

        private (int, int) GetRandCoord()
        {
            int x = this.MyRandom.Next(this.ConsoleDim.X);
            int y = this.MyRandom.Next(this.ConsoleDim.Y);

            return (x, y);
        }
    }
}
    