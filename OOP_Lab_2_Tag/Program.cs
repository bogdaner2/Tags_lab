using static System.Console;
namespace OOP_Lab_2_Tag
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Use arrows for move tags. \n" +
                      "Input map size:");
            int.TryParse(ReadLine(),out int size);
            WriteLine("Choose level : \n" +
                      "1)Normal \n" +
                      "2)Hard");
            int.TryParse(ReadLine(), out int level);

            Game.Instance.Start(size, (Game.Level)(level - 1));
        }
    }
}
