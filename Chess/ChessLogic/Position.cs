using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLogic
{
    internal class Position
    {
        public int Row { get; }
        public int Column { get; }

        public Position(int row, int column)
        { //констр
            Row = row;
            Column = column;
        }

        public Player SquareColor()
        { //колір коітки, парні - білий
            if ((Row + Column) % 2 == 0)
            {
                return Player.White;
            }

            return Player.Black;
        }

        //Овверайд для використання Порівняння
        public override bool Equals(object obj)
        { 
            return obj is Position position &&
                   Row == position.Row &&
                   Column == position.Column;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Row, Column);
        }

        public static bool operator ==(Position left, Position right)
        {
            return EqualityComparer<Position>.Default.Equals(left, right);
        }

        public static bool operator !=(Position left, Position right)
        {
            return !(left == right);
        }

        public static Position operator +(Position pos, Direction dir)
        { //куда фігура піде, для підсвітки ходу
            return new Position(pos.Row + dir.RowDelta, pos.Column + dir.ColumnDelta);
        }
    }
}
