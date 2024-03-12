using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryGame
{
    internal class LetterCard : Card
    {
        public char Letter { get; set; }

       public static List<LetterCard> leters = new List<LetterCard>
       { new('a'),new('a'), new('b'),new('b'), new('c'),new('c'), new('d'),new('d'), new('e'),new('e'), new('f'), new('f'), new('g'),new('g'), new('h'), new('h') };

        public override void DrowCard()
        {
            Console.Write(Letter);
        }

        public override bool Equals(object? obj)
        {
            LetterCard leterCard = obj as LetterCard;
            if (leterCard == null)
                return false;
            return true;
        }

        public override bool IsMathc(Card c)
        {
            if (!Equals(c))
                return false;
            LetterCard c1 = c as LetterCard;
            return this.Letter == c1.Letter;
        }
        public LetterCard(char l)
        {
            Letter = l;
            State = State.Close;
        }
    }
}
