using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Ball : GameObject
    {
        public override string Character => "*";

        public Position Force { get; set; } = new Position(0, 0);

        private int SlowdownCounter = 0;

        public Ball((int, int) pos, string name, (int x, int y) force, ConsoleColors col = null, char? newChar = null) : base(pos, name, col, null)
        {
            // set force to be (1,1) or (1,-1) or (-1,1) or (-1,-1)
            this.Force.X = force.x == 0 ? -1 : force.x;
            this.Force.Y = force.y == 0 ? -1 : force.y;
        }

        public override void Move()
        {
            if (this.SlowdownCounter <= 1)
            {
                this.SlowdownCounter++;
                return;
            }
            this.SlowdownCounter = 0;

            this.CheckCollisionWithWalls();

            this.Position += this.Force;
        }

        private void CheckCollisionWithWalls()
        {
            if (this.Position.X <= 0 && this.Position.X >= this.game.ConsoleDim.X)
                this.game.EndOfGame = true;
            if (this.Position.Y <= 0 || this.Position.Y >= this.game.ConsoleDim.Y)
                this.Force.Y *= -1;
        }

        public void BounceFromPlayer()
        {
            this.Force.X *= -1;
        }
    }
}
