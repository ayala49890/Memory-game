using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryGame
{
    public abstract class Player
    {
        public int PointsCounter { get; set; }

        public List<Card> PlayerCards { get; set; }
        public string Name { get; protected set; }
        public Player()
        {
            PlayerCards = new List<Card>();
            PointsCounter = 0;
        }
        public abstract void InitName();

        public abstract int ChooseCard(int size);

        public void print()
        {
            foreach (var item in PlayerCards)
            {
                item.DrowCard();
            }
        }
    }
}
