using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex05.ReversedTicTacToe.Logic
{
    public class GameBoard
    {
        public enum eSymbols
        {
            Symbol1 = 'X',
            Symbol2 = 'O'
        }

        private readonly int r_NumOfRows;
        private readonly int r_NumOfCols;
        private readonly int r_BoardSize;
        // $G$ NTT-999 (-5) This member should have been readonly.
        private Cell<eSymbols>[,] m_Board = null;

        public GameBoard(int i_NumOfRowsInBoard, int i_NumOfColsInBoard)
        {
            r_NumOfRows = i_NumOfRowsInBoard;
            r_NumOfCols = i_NumOfColsInBoard;
            r_BoardSize = r_NumOfRows * r_NumOfCols;
            m_Board = new Cell<eSymbols>[r_NumOfRows, r_NumOfCols];
            initializeBoard();
        }

        public Cell<eSymbols>[,] Board
        {
            get { return m_Board; }
        }

        public int NumOfRows
        {
            get { return r_NumOfRows; }
        }

        public int NumOfCols
        {
            get { return r_NumOfCols; }
        }

        public int BoardSize
        {
            get { return r_BoardSize; }
        }

        private void initializeBoard()
        {
            for (int i = 0; i < r_NumOfRows; ++i)
            {
                for (int j = 0; j < r_NumOfCols; ++j)
                {
                    m_Board[i, j] = new Cell<eSymbols>();
                }
            }
        }

        public void SetCellValue(int i_Row, int i_Col, eSymbols i_Value)
        {
            m_Board[i_Row, i_Col].Value = i_Value;
            m_Board[i_Row, i_Col].Available = false;
        }

        public bool FullLeftDiagonal(eSymbols i_PlayerSymbol)
        {
            int numberOfSymbolInDiagonal = 0;

            for (int i = 0; i < r_NumOfRows; ++i)
            {
                if (Board[i, i].Value == i_PlayerSymbol)
                {
                    numberOfSymbolInDiagonal++;
                }
            }

            return (numberOfSymbolInDiagonal == r_NumOfRows) ? true : false;
        }

        public bool FullRightDiagonal(eSymbols i_PlayerSymbol)
        {
            int numberOfSymbolInDiagonal = 0;
            int columIndex = r_NumOfCols - 1;

            for (int i = 0; i < r_NumOfRows; ++i)
            {
                if (Board[i, columIndex].Value == i_PlayerSymbol)
                {
                    numberOfSymbolInDiagonal++;
                }

                columIndex--;
            }

            return (numberOfSymbolInDiagonal == r_NumOfRows) ? true : false;
        }

        public bool FullRow(eSymbols i_PlayerSymbol)
        {
            int numberOfSymbolInRow = 0;
            bool thereIsFullRow = false;

            for (int i = 0; i < r_NumOfRows; ++i)
            {
                numberOfSymbolInRow = 0;
                for (int j = 0; j < r_NumOfCols; ++j)
                {
                    if (Board[i, j].Value == i_PlayerSymbol)
                    {
                        numberOfSymbolInRow++;
                    }
                }

                if (numberOfSymbolInRow == r_NumOfRows)
                {
                    thereIsFullRow = true;
                    break;
                }
            }

            return thereIsFullRow;
        }

        public bool FullColum(eSymbols i_PlayerSymbol)
        {
            int numberOfSymbolInColum = 0;
            bool thereIsFullColum = false;

            for (int i = 0; i < r_NumOfRows; ++i)
            {
                numberOfSymbolInColum = 0;
                for (int j = 0; j < r_NumOfCols; ++j)
                {
                    if (Board[j, i].Value == i_PlayerSymbol)
                    {
                        numberOfSymbolInColum++;
                    }
                }

                if (numberOfSymbolInColum == r_NumOfCols)
                {
                    thereIsFullColum = true;
                    break;
                }
            }

            return thereIsFullColum;
        }

        public bool BoradIsFull(int i_MoveCounter)
        {
            return r_BoardSize == i_MoveCounter;
        }
    }
}