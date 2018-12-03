namespace OOP_Lab_2_Tag
{
    public class MoveMemento
    {
        public int[,] Field { get; set; }
        public Cell EmptyCell { get; set; }

        public MoveMemento(int[,] field,Cell emptyCell)
        {
            Field = field;
            EmptyCell = emptyCell;
        }
    }
}
