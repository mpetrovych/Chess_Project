using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLogic
{
    public enum Player
    {//колір фігури
        None,
        White,
        Black
    }

    public static class PlayerExtensions
    {
        public static Player Opponent(this Player player)
        {// зміна ходу через switch/case
            return player switch
            {
                Player.White => Player.Black,
                Player.Black => Player.White,
                _ => Player.None,
            };
        }
    }
}
