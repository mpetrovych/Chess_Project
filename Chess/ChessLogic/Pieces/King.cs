﻿using ChessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLogic
{
    public class King : Piece
    {
        public override PieceType Type => PieceType.King;
        public override Player Color { get; }

        private static readonly Direction[] dirs = new Direction[]
        {
            Direction.North,
            Direction.South,
            Direction.East,
            Direction.West,
            Direction.NorthWest,
            Direction.NorthEast,
            Direction.SouthWest,
            Direction.SouthEast
        };

        public King(Player color)
        {
            Color = color;
        }

        public override Piece Copy()
        {
            King copy = new King(Color);
            copy.HasMoved = HasMoved;
            return copy;
        }

        private static bool IsUnmovedRook(Position pos, Board board)
        { //Чи є не рухана башня
            if (board.IsEmpty(pos))
            {
                return false;
            }

            Piece piece = board[pos];
            return piece.Type == PieceType.Rook && !piece.HasMoved;
        }

        private static bool AllEmpty(IEnumerable<Position> positions, Board board)
        {
            return positions.All(pos => board.IsEmpty(pos));
        }

        private bool CanCastleKingSide(Position from, Board board)
        { //Рокіровка в ліво
            if (HasMoved)
            {
                return false;
            }

            Position rookPos = new Position(from.Row, 7);
            Position[] betweenPositions = new Position[] { new(from.Row, 5), new(from.Row, 6) };

            return IsUnmovedRook(rookPos, board) && AllEmpty(betweenPositions, board);
        }

        private bool CanCastleQueenSide(Position from, Board board)
        { //Рокіровка в право
            if (HasMoved)
            {
                return false;
            }

            Position rookPos = new Position(from.Row, 0);
            Position[] betweenPositions = new Position[] { new(from.Row, 1), new(from.Row, 2), new(from.Row, 3) };

            return IsUnmovedRook(rookPos, board) && AllEmpty(betweenPositions, board);
        }

        private IEnumerable<Position> MovePositions(Position from, Board board)
        { //вілн поз
            foreach (Direction dir in dirs)
            {
                Position to = from + dir;

                if (!Board.IsInside(to))
                {
                    continue;
                }

                if (board.IsEmpty(to) || board[to].Color != Color)
                {
                    yield return to;
                }
            }
        }

        public override IEnumerable<Move> GetMoves(Position from, Board board)
        { //можливі ходи
            foreach (Position to in MovePositions(from, board))
            {
                yield return new NormalMove(from, to);
            }

            if (CanCastleKingSide(from, board))
            {
                yield return new Castle(MoveType.CastleKS, from);
            }

            if (CanCastleQueenSide(from, board))
            {
                yield return new Castle(MoveType.CastleQS, from);
            }
        }

        public override bool CanCaptureOpponentKing(Position from, Board board)
        {
            return MovePositions(from, board).Any(to =>
            {
                Piece piece = board[to];
                return piece != null && piece.Type == PieceType.King;
            });
        }
    }
}

