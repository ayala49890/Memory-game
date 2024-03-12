using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryGame
{
    public enum State { Open, Close, Taked };
    public abstract class Card
    {


        public bool IsFirst { get; set; }
        public State State { get; set; }
        public override abstract bool Equals(object? obj);
        public abstract bool IsMathc(Card c);

        public abstract void DrowCard();

        public void PrintCard()
        {
            switch (State)
            {
                case State.Open:
                    DrowCard();
                    break;
                case State.Close:
                    Console.Write("?");
                    break;
                default:
                    Console.Write("!");
                    break;

            }
        }

    }
}
