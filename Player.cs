using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Player : GameObject
    {
        // Lenght of player.
        public static int Length { get; set; }

        public override string Character => "#";

        private (ConsoleKey up, ConsoleKey down) Control { get; set; }

        public Player((int, int) pos, string name, (ConsoleKey up, ConsoleKey down) control, ConsoleColors col = null, string newChar = null)
            : base(pos, name, col, newChar)
        {
            this.Control = control;
        }

        public override void Move()
        {
            if (this.game.Input == this.Control.up && this.Position.Y > 0)
            {
                this.Position.Y--;
            }
            else if (this.game.Input == this.Control.down && this.Position.Y < this.game.ConsoleDim.Y - Player.Length)
            {
                this.Position.Y++;
            }

            this.CheckCollisionWithBall();
        }

        public override void Draw()
        {
            for (var i = 0; i < Player.Length; i++)
            {
                Drawing.Write(new Position(this.Position.X, this.Position.Y + i), this.Character);
            }
        }

        private void CheckCollisionWithBall()
        {
            var ballPos = this.game.Ball.Position;
            
            if (Math.Abs(ballPos.X - this.Position.X) != 1) 
                return;
            else if (this.Position.Y <= ballPos.Y && this.Position.Y + Player.Length >= ballPos.Y)
                this.game.Ball.BounceFromPlayer();
            else
            {
                throw new Exception("Game is lost");
            }
        }
    }
}