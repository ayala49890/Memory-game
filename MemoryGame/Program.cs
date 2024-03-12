namespace MemoryGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Game g = new Game();
            g.InitPlayers();
            g.ToPlay();
        }
    }
}