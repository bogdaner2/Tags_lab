using System.Collections.Generic;

namespace OOP_Lab_2_Tag
{
    public class GameHistory
    {
        public Stack<MoveMemento> History { get; private set; }
        public GameHistory()
        {
            History = new Stack<MoveMemento>();
        }
    }
}
