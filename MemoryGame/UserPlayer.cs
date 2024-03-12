using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryGame
{
    public class UserPlayer : Player
    {
        public override int ChooseCard(int size)
        {
            Console.WriteLine("enter card number");
            int n = int.Parse(Console.ReadLine());
            while (n < 1 || n > size)
            {
                Console.WriteLine("enter a valid card number");
                n = int.Parse(Console.ReadLine());

            }
            return n;

        }
        public UserPlayer()
        {
            InitName();
        }
        public override void InitName()
        {
            Console.WriteLine("enter your name");
            base.Name = Console.ReadLine();
        }


    }
}