using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class GameObject
    {
        public virtual Position Position { get; set; }

        public virtual string Character { get; set; }

        // if this is null, than defualt color will be used
        public virtual ConsoleColors Colors { get; set; }

        public string Name { get; set; }

        protected Game game => Game.Instance;

        public GameObject((int, int) pos, string name, ConsoleColors col = null, string newChar = null)
        {
            if (newChar != null)
                this.Character = newChar;

            this.Character = newChar ?? this.Character;

            this.Position = new Position(pos);
            this.Colors = col;
            this.Name = name;
        }

        public virtual void Move()
        {
        }

        public virtual void Draw()
        {
            Drawing.Write(this.Position, this.Character, Colors);
        }
    }
}
