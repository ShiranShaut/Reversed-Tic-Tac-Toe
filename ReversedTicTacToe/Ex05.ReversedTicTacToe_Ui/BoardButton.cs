using System.Drawing;
using System.Windows.Forms;

namespace Ex05.ReversedTicTacToe_Ui
{
    internal class BoardButton : Button
    {
        private readonly Point r_LocationInLogicMatrix;

        internal BoardButton(int i_X, int i_Y)
            : base()
        {
            r_LocationInLogicMatrix = new Point(i_X, i_Y);
        }

        public Point LocationInBoard
        {
            get { return r_LocationInLogicMatrix; }
        }

        public int X
        {
            get { return r_LocationInLogicMatrix.X; }
        }

        public int Y
        {
            get { return r_LocationInLogicMatrix.Y; }
        }
    }
}