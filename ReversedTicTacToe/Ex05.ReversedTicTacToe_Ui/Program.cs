using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ex05.ReversedTicTacToe_Ui
{
    public static class Program
    {
        public static void Main()
        {
            GameBoardForm boardGame = new GameBoardForm();
            boardGame.ShowDialog();
        }
    }
}
