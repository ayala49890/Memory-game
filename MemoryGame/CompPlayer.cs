using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryGame
{
    internal class CompPlayer : Player
    {
        const string name = "comp";
        public override int ChooseCard(int size)
        {
            Random random = new Random();
            return random.Next(1, size);
        }
        public CompPlayer()
        {
            InitName();
        }
        public override void InitName()
        {
            base.Name = name;
        }
    }
}
