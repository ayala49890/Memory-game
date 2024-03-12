using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryGame
{
    internal class ExCard : Card
    {
       public static List<ExCard> exs = new List<ExCard>
       { new("5+2",7,true),new("5+2",7,false),new("1+5",6,true),new("1+5",6,false),new("5+5",10,true),new("5+5",10,false),new("7-3",4,true),new("7-3",4,false), new("9-4",5,true),new("9-4",5,false), new("8-5",3,true),new("8-5",3,false)  , new("1+1",2,true),new("1+1",2,false)  };

        public ExCard(string ex, int result, bool isEx)
        {
            Ex = ex;
            Result = result;
            IsEx = isEx;
            State = State.Close;

        }

        public string Ex { get; set; }
        public int Result { get; set; }
        public bool IsEx { get; set; }
        public override void DrowCard()
        {
            if (IsEx)
                Console.Write(Ex);
            else
                Console.Write(Result);
        }

        public override bool Equals(object? obj)
        {
            ExCard exCard = obj as ExCard;
            if (exCard == null)
                return false;
            return true;
        }

        public override bool IsMathc(Card c)
        {
            if (!Equals(c))
                return false;
            ExCard c1 = c as ExCard;
            return this.Ex == c1.Ex;
        }
    }
}
