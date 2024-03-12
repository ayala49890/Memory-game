using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
namespace MemoryGame
{
    
    internal class Board
    {
        static Random rnd = new();
        //TODO:מתאים יותר שכל מחלקה תגדיר לעצמה את שלה
      
        public int Size { get; set; }


        List<Card> cards = new List<Card>();
        public List<Card> GetCards()
        {
            return cards;
        }

        public void InitBoard()
        {
            Console.WriteLine("enter size of pair btween 2-7");
            int x = int.Parse(Console.ReadLine()) ;
            while(x<2||x>7)
            {
                Console.WriteLine("enter size of pair btween 2-7");
                x = int.Parse(Console.ReadLine());
            }

            Size = x*2;
            Console.WriteLine("enter game num: 1 for sign, 2 for leters, 3 for ex");
            switch (Console.ReadLine())
            {
                case "1":
                    for (int i = 0; i < Size; i++)
                    {
                        cards.Add(SignCard.signs[i]);
                    }
                    break;
                case "2":
                    for (int i = 0; i < Size; i++)
                    {
                        cards.Add(LetterCard.leters[i]);
                    }
                    break;
                case "3":
                    for (int i = 0; i < Size; i++)
                    {
                        cards.Add(ExCard.exs[i]);
                    }
                    break;
                default:
                    Console.WriteLine("error");
                    break;

            }
            cards = cards.OrderBy(c => rnd.Next()).ToList();
        }
        public void PrintBoard()
        {
            for (int i = 0; i < Size; i++)
            {
                cards[i].PrintCard();
                Console.Write("\t");
            }
            Console.WriteLine();
        }
        public int UntilValid(Player pl)
        {

            int p = pl.ChooseCard(Size)-1;
            bool flag = true;
            while (flag)
            {
                if (cards[p].State == State.Close)
                {
                    cards[p].State = State.Open;
                    flag = false;
                }
                else
                {
                    Console.WriteLine("the place is not valid enter new place");
                    p = pl.ChooseCard(Size);
                }
            }
            return p;
        }
     
        public bool IsFinished()
        {
            return cards.All(card => card.State == State.Taked);
        }

    }
}
