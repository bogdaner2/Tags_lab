namespace OOP_Lab_2_Tag
{
    public class MoveCommand 
    {
        private readonly MapField _field;
        private readonly GameHistory _history;
        public MoveCommand(MapField field, GameHistory history)
        {
            _field = field;
            _history = history;
        }

        public void MoveUp()
        {
            var emptyCell = _field.EmptyCell;
            if (emptyCell.X != _field.Size)
            {
                MoveSwap(emptyCell, 1, 0);
                _field.EmptyCell.X++;
            }
        }

        public void MoveDown()
        {
            var emptyCell = _field.EmptyCell;
            if (emptyCell.X != 0)
            {
                MoveSwap(emptyCell,-1,0);
                _field.EmptyCell.X--;
            }
        }

        public void MoveLeft()
        {
            var emptyCell = _field.EmptyCell;
            if (emptyCell.Y != _field.Size)
            {
                MoveSwap(emptyCell, 0, 1);
                _field.EmptyCell.Y++;
            }
        }

        public void MoveRight()
        {
            var emptyCell = _field.EmptyCell;
            if (emptyCell.Y != 0)
            {
                MoveSwap(emptyCell, 0, -1);
                _field.EmptyCell.Y--;
            }
        }

        public void Undo()
        {
            if (_history.History.Count != 0)
            {
                var mommento = _history.History.Pop();
                _field.Field = mommento.Field;
                _field.EmptyCell = mommento.EmptyCell;
            }
        }

        private void MoveSwap(Cell emptyCell,int x,int y)
        {
            _history.History.Push(new MoveMemento((int[,])_field.Field.Clone(), (Cell)emptyCell.Clone()));
            var cell = _field.Field[emptyCell.X + x, emptyCell.Y + y];
            _field.Field[emptyCell.X, emptyCell.Y] = cell;
            _field.Field[emptyCell.X + x, emptyCell.Y + y] = 0;
        }

        public int HistoryStackItemsCount() => _history.History.Count;
    }
}
