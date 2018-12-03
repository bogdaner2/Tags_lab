using System;

namespace OOP_Lab_2_Tag
{
    public class Cell : ICloneable
    {
        public int X { get; set; }
        public int Y { get; set; }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
