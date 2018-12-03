using NUnit.Framework;
using OOP_Lab_2_Tag;

namespace Tests
{
    [TestFixture]
    public class MementoTest
    {
        private readonly MoveCommand _command;
        public MementoTest()
        {
            //Map m = new Map();
            _command = new MoveCommand(
                new MapField
                {
                    Field = new int[4,4],
                    EmptyCell = new Cell { X = 3, Y = 3 }
                },
                new GameHistory());
        }

        [Test]
        public void Undo_Move_Decrease_History_Stack_Count_Test()
        {
            
            _command.MoveDown();
            var initialCount = _command.HistoryStackItemsCount();

            _command.Undo();
            var currentCount = _command.HistoryStackItemsCount();

            Assert.AreEqual(initialCount - 1, currentCount);
        }

        [Test]
        public void Move_Create_New_Memmento_Test()
        {
            var initialCount = _command.HistoryStackItemsCount();

            _command.MoveDown();
            var currentCount = _command.HistoryStackItemsCount();

            Assert.AreNotEqual(initialCount, currentCount);
        }
    }
}
