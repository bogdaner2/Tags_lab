using NUnit.Framework;
using OOP_Lab_2_Tag;

namespace Tests
{
    [TestFixture]
    public class GameTests
    {
        private readonly Game _game;
        public GameTests()
        {
           _game = Game.Instance; 
        }

        [Test]
        public void Game_Instance_Create_Test()
        {
            var instance = Game.Instance;
            Assert.True(ReferenceEquals(_game, instance));
        }

        [Test]
        public void Set_Map_Size_Test()
        {
            var size = 3;
            _game.SetSize(size);

            Assert.True(_game.Map.MapField.Field.Length / size == 3);
        }
    }
}
