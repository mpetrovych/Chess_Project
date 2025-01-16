﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLogic
{
    public abstract class Move
    { //Клас предок всіх рухів
        public abstract MoveType Type { get; }
        public abstract Position FromPos { get; }
        public abstract Position ToPos { get; }

        public abstract bool Execute(Board board);

        public virtual bool IsLegal(Board board)
        {
            Player player = board[FromPos].Color;
            Board boardCopy = board.Copy();
            Execute(boardCopy);
            return !boardCopy.IsInCheck(player);
        }
    }
}
