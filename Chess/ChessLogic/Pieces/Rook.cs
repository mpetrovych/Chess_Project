﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLogic.Pieces
{
    namespace ChessLogic
    {
        public class Rook : Piece
        {
            public override PieceType Type => PieceType.Rook;
            public override Player Color { get; }

            private static readonly Direction[] dirs = new Direction[]
            {
            Direction.North,
            Direction.South,
            Direction.East,
            Direction.West
            };

            public Rook(Player color)
            {
                Color = color;
            }

            public override Piece Copy()
            {
                Rook copy = new Rook(Color);
                copy.HasMoved = HasMoved;
                return copy;
            }
        }
    }
}
