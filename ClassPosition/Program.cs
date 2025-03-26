namespace ClassPosition
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Player player = new Player();
            Monster monster = new Monster();

            player.Attack(monster);
        }
    }
}
