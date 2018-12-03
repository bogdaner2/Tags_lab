using System;

namespace OOP_Lab_2_Tag
{
    public class Game
    {
        public Map Map { get; set; }
        private static readonly Lazy<Game> Lazy = new Lazy<Game>(() => new Game());
        public static Game Instance => Lazy.Value;

        private Game() { Map = new Map();}

        public void SetSize(int mapSize)
        {
            Map.Size = mapSize;
            Map.MapField.Size = mapSize - 1;
            Map.MapField.Field = Map.CreateMap(mapSize);
            Map.MapField.EmptyCell = new Cell { X = mapSize - 1, Y = mapSize - 1 };
        }

        public void Start(int mapSize, Level gameLevel)
        {
            SetSize(mapSize);
            Map.ShowMap();

            if (gameLevel == Level.Hard)
            {
                Map.SetLevel(Level.Hard);
            }

            bool isExit = true;
            do
            {
                var key = Console.ReadKey().Key;
                isExit = Move(key);

            } while (isExit);
        }

        public bool Move(ConsoleKey key)
        {      
                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        Map.Move(Map.MoveDirection.Up);
                        break;
                    case ConsoleKey.DownArrow:
                        Map.Move(Map.MoveDirection.Down);
                        break;
                    case ConsoleKey.LeftArrow:
                        Map.Move(Map.MoveDirection.Left);
                        break;
                    case ConsoleKey.RightArrow:
                        Map.Move(Map.MoveDirection.Right);
                        break;
                    case ConsoleKey.Backspace:
                        Map.UndoMove();
                        break;
                    case ConsoleKey.Escape:
                        return false;
                }
            return true;
        }

        public enum Level
        {
            Normal,Hard
        }
    }


}
