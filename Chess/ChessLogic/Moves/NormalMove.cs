using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLogic
{
    public class NormalMove : Move
    {
        public override MoveType Type => MoveType.Normal;
        public override Position FromPos { get; }
        public override Position ToPos { get; }

        public NormalMove(Position from, Position to)
        {
            FromPos = from;
            ToPos = to;
        }
        public override bool Execute(Board board)
        { //пер і хід
            Piece piece = board[FromPos];           // з 
            bool capture = !board.IsEmpty(ToPos);   
            board[ToPos] = piece;                   // до           
            board[FromPos] = null;                  //дел з стар місця
            piece.HasMoved = true;

            return capture || piece.Type == PieceType.Pawn;
        }
    }
}
