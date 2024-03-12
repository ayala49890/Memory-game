using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryGame
{
    internal class SignCard : Card
    {
        public static List<SignCard> signs = new List<SignCard>
       { new('*',ConsoleColor.DarkCyan),new('*',ConsoleColor.DarkCyan),new('&',ConsoleColor.Magenta),new('&',ConsoleColor.Magenta),new('@',ConsoleColor.Red),new('@',ConsoleColor.Red),new('#',ConsoleColor.DarkBlue),new('#',ConsoleColor.DarkBlue), new('$',ConsoleColor.DarkGreen),new('$',ConsoleColor.DarkGreen),new('%',ConsoleColor.Gray),new('%',ConsoleColor.Gray), new('^',ConsoleColor.White), new('^',ConsoleColor.White) };

        public SignCard(char sign, ConsoleColor color)
        {
            Sign = sign;
            Color = color;
            State = State.Close;

        }

        public char Sign { get; set; }
        public ConsoleColor Color { get; set; }

        public override void DrowCard()
        {
            Console.ForegroundColor = Color;
            Console.Write(Sign);
            Console.ForegroundColor = ConsoleColor.White;

        }

        public override bool Equals(object? obj)
        {
            SignCard signCard = obj as SignCard;
            if (signCard == null)
                return false;
            return true;
        }

        public override bool IsMathc(Card c)
        {
            if (!Equals(c))
                return false;
            SignCard c1 = c as SignCard;
            return this.Sign == c1.Sign && this.Color == c1.Color;
        }
    }
}
