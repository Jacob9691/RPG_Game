namespace RPG_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            RPG_GameLogic.GameManagement.Game game = new();
            game.Start();

        }
    }
}