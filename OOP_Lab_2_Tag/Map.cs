using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using static System.Console;

namespace OOP_Lab_2_Tag
{
    public class Map
    {
        public MapField MapField { get; set; }
        public bool IsDevelopment { get; set; }
        public int Size { get; set; }
        public GameHistory History { get; set; }
        private Game.Level _level;
        private readonly MoveCommand _command;

        public Map(Game.Level level = Game.Level.Normal)
        {
            History = new GameHistory();
            MapField = new MapField();
            _command = new MoveCommand(MapField,History);
            _level = level;
        }

        public void SetLevel(Game.Level level)
        {
            _level = level;
        }

        public void Move(MoveDirection direction)
        {
            switch (direction)
            {
                case MoveDirection.Up:
                    _command.MoveUp();
                    break;
                case MoveDirection.Down:
                    _command.MoveDown();
                    break;
                case MoveDirection.Right:
                    _command.MoveRight();
                    break;
                case MoveDirection.Left:
                    _command.MoveLeft();
                    break;
            }

            if(_level == Game.Level.Hard)
                RandomMove(3);

            if(!IsDevelopment)
                ShowMap();

        }

        public void RandomMove(int count)
        {
            Random rand = new Random();
            int[] moves = new int[count];

            for (int i = 0; i < count; i++)
            {
                moves[i] = rand.Next(0, 3);
            }

            foreach (var move in moves)
            {
                Thread.Sleep(500);
                switch ((MoveDirection)move)
                {
                    case MoveDirection.Up:
                        _command.MoveUp();
                        break;
                    case MoveDirection.Down:
                        _command.MoveDown();
                        break;
                    case MoveDirection.Right:
                        _command.MoveRight();
                        break;
                    case MoveDirection.Left:
                        _command.MoveLeft();
                        break;
                }
                ShowMap();
                WriteLine($"Randome move: {((MoveDirection)move).ToString()}");
            }
        } 

        public void UndoMove()
        {
            _command.Undo();
            if (!IsDevelopment)
                ShowMap();
        }

        public enum MoveDirection
        {
            Up,Down,Left,Right
        }

        public int[,] CreateMap(int size)
        {
            int[,] arr = new int[size, size];

            Random rand = new Random();
            List<int> uniqeNumbers = new List<int>();

            for (int i = 1; i <= size * size - 1; i++)
            {
                uniqeNumbers.Add(i);
            }


            uniqeNumbers = uniqeNumbers.OrderBy(x => rand.Next()).ToList();

            uniqeNumbers.Add(0);

            int сounter = 0;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    arr[i, j] = uniqeNumbers[сounter];
                    сounter++;
                }
            }

            return arr;
        }

        public void ShowMap()
        {
            Clear();

            int winCounter = 1;

            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    
                    if (MapField.Field[i, j] == winCounter)
                    {
                        winCounter++;
                    }
                    else
                    {
                        if(MapField.Field[Size - 1,Size - 1] != 0)
                            winCounter = 1;
                    }

                    if (MapField.Field[i, j] != 0)
                    {
                        Write("{0,-5}", "|" + MapField.Field[i, j] + "|");
                    }
                    else
                    {
                        Write("{0,-5}", string.Empty);
                    }
                }
                WriteLine();
            }

            if(winCounter == Size * Size)
                ShowWin();
        }

        public void ShowWin()
        {
            Clear();
            ForegroundColor = ConsoleColor.Red;
            WriteLine("YOU WIN!");
            Environment.Exit(0);
        }
    }
}
