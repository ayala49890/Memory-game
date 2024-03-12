using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryGame
{
    internal class Game
    {

        List<Player> players = new List<Player>();
        int index = 0;

        Board board = new Board();
        public void InitPlayers()
        {
            Console.WriteLine("enter number of players ");
            int num = int.Parse(Console.ReadLine());
            if (num == 1)
            {
                players.Add(new CompPlayer());
                players.Add(new UserPlayer());
            }
            else
            {
                for (int i = 0; i < num; i++)
                {
                    players.Add(new UserPlayer());
                }
            }
            board.InitBoard();
        }
        public void ToPlay()
        {
            int first = 0, second = 0;
            while (!board.IsFinished())
            {
                Thread.Sleep(1500);
                Console.Clear();
                board.PrintBoard();
                Console.WriteLine($"now it is {players[index].Name} turn");
                for (int i = 0; i < 2; i++)
                {
                    if (i == 0) first = board.UntilValid(players[index]);
                    else second = board.UntilValid(players[index]);
                    board.PrintBoard();
                }
                if (IsPair(first, second))
                {
                    string st = board.GetCards()[first].GetType().ToString().Substring(board.GetCards()[first].GetType().ToString().IndexOf('.') + 1);
                    switch (st)
                    {
                        case "LeterCard":
                            players[index].PlayerCards.Add(new LetterCard('e'));
                            break;
                        case "SignCard":
                            players[index].PlayerCards.Add(new SignCard('@', ConsoleColor.White));
                            break;
                        default:
                            players[index].PlayerCards.Add(new ExCard("2+2", 8, true));
                            break;
                    }
                    players[index].PlayerCards[players[index].PointsCounter++] = board.GetCards()[first];
                    index--;
                }
                if (++index == players.Count)
                    index = 0;
            }
            GameOver();
        }

        public void GameOver()
        {
            Thread.Sleep(1000);
            Console.Clear();
            Console.WriteLine("game over!!!");
            int max = 0;
            for (int i = 0; i < players.Count(); i++)
            {
                max = players.Max(player => player.PointsCounter);
            }
            for (int i = 0; i < players.Count(); i++)
            {
                if (players[i].PointsCounter == max)
                {
                    Console.WriteLine($"{players[i].Name} is win!!!!");
                    Console.WriteLine($"cards of : {players[i].Name}");
                    for (int j = 0; j < players[i].PointsCounter; j++)
                    {
                        players[i].PlayerCards[j].DrowCard();
                        Console.Write("\t");
                    }
                    Console.WriteLine();
                }
            }
        }

        public bool IsPair(int first, int second)
        {

            if (board.GetCards()[first].IsMathc(board.GetCards()[second]))
            {
                board.GetCards()[first].State = State.Taked;
                board.GetCards()[second].State = State.Taked;
                Console.WriteLine("well done!!");
                return true;
            }
            board.GetCards()[first].State = State.Close;
            board.GetCards()[second].State = State.Close;
            return false;
        }


    }
}
