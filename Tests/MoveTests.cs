using NUnit.Framework;
using OOP_Lab_2_Tag;

namespace Tests
{
    [TestFixture]
    public class MoveTests
    {
        private readonly Map _map;
        public MoveTests()
        {
            _map = new Map();
            var mapSize = 4;
            _map.Size = mapSize;
            _map.MapField.Size = mapSize - 1;
            _map.MapField.Field = _map.CreateMap(mapSize);
            _map.MapField.EmptyCell = new Cell { X = mapSize - 1, Y = mapSize - 1 };
            _map.IsDevelopment = true;
        }

        [Test]
        public void Down_Move_Change_Map_Test()
        {
            var initial = _map.MapField.Field.Clone();
            _map.Move(Map.MoveDirection.Down);
            var current = _map.MapField.Field.Clone();
            Assert.AreNotEqual(initial,current);
        }

        [Test]
        public void Up_Move_Change_Map_Test()
        {
            var initial = _map.MapField.Field.Clone();
            _map.Move(Map.MoveDirection.Up);
            var current = _map.MapField.Field.Clone();
            Assert.AreNotEqual(initial, current);
        }

        [Test]
        public void Right_Move_Change_Map_Test()
        {
            var initial = _map.MapField.Field.Clone();
            _map.Move(Map.MoveDirection.Right);
            var current = _map.MapField.Field.Clone();
            Assert.AreNotEqual(initial, current);
        }

        [Test]
        public void Undo_State_Test()
        {
            var initial = _map.MapField.Field.Clone();
            _map.Move(Map.MoveDirection.Right);
            var afterMove = _map.MapField.Field.Clone();
            _map.UndoMove();
            var current = _map.MapField.Field.Clone();

            Assert.AreEqual(initial,current);
            Assert.AreNotEqual(initial, afterMove);
        }

        [Test]
        public void Down_Move_In_Border_Dont_Change_Map_Test()
        {
            _map.Move(Map.MoveDirection.Down);
            var notInBorder = _map.MapField.Field.Clone();
            _map.Move(Map.MoveDirection.Down);
            _map.Move(Map.MoveDirection.Down);
           
            var initial = _map.MapField.Field.Clone();
            _map.Move(Map.MoveDirection.Down);
            var current = _map.MapField.Field.Clone();

            Assert.AreEqual(initial, current);
            Assert.AreNotEqual(notInBorder, current);
        }

        [Test]
        public void Left_Move_In_Border_Dont_Change_Map_Test()
        {
            var initial = _map.MapField.Field.Clone();
            _map.Move(Map.MoveDirection.Left);
            var current = _map.MapField.Field.Clone();
            Assert.AreEqual(initial, current);
        }

    }
}
