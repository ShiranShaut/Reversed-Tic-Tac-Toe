using System;
using System.Drawing;

namespace Ex05.ReversedTicTacToe.Logic
{
    public class GameLogic
    {
        private readonly Random r_ComputerRand = new Random();
        private readonly PlayerDetails r_Player1, r_Player2;
        private GameBoard m_Board;
        private PlayerDetails m_LastPlayer;
        private int m_MovesCounter = 0;

        public GameLogic(PlayerDetails i_Player1, PlayerDetails i_Player2)
        {
            r_Player1 = i_Player1;
            r_Player2 = i_Player2;
            m_LastPlayer = null;
        }

        public void SetNewBoard(int i_BoardRows, int i_BoardCols)
        {
            m_Board = new GameBoard(i_BoardRows, i_BoardCols);
        }

        public GameBoard Board
        {
            get { return m_Board; }
        }

        public PlayerDetails Player1
        {
            get { return r_Player1; }
        }

        public PlayerDetails Player2
        {
            get { return r_Player2; }
        }

        public PlayerDetails LastPlayer
        {
            get { return m_LastPlayer; }
        }

        public bool GameOver(out string o_Reason)
        {
            bool gameOver = false;
            o_Reason = null;

            if (m_LastPlayer != null)
            {
                GameBoard.eSymbols symbol = m_LastPlayer.PlayerSymbol;
                if (m_Board.FullColum(symbol) || m_Board.FullRow(symbol) || m_Board.FullLeftDiagonal(symbol) || m_Board.FullRightDiagonal(symbol))
                {
                    o_Reason = "A Win!";
                    if (m_LastPlayer == r_Player1)
                    {
                        r_Player2.GamePoints++;
                    }
                    else
                    {
                        r_Player1.GamePoints++;
                    }

                    gameOver = true;
                }
            }

            if (!gameOver && m_Board.BoradIsFull(m_MovesCounter))
            {
                o_Reason = "A Tie!";
                gameOver = true;
            }

            return gameOver;
        }

        public void PlayerMove(PlayerDetails i_CurrentPlayer)
        {
            m_MovesCounter++;
            m_LastPlayer = i_CurrentPlayer;
        }

        public Point ComputerMove()
        {
            m_MovesCounter++;
            m_LastPlayer = r_Player2;
            int randRow, randCol;
            Point computerChosenCell;

            for (;;)
            {
                randRow = r_ComputerRand.Next(0, m_Board.NumOfRows);
                randCol = r_ComputerRand.Next(0, m_Board.NumOfCols);
                if (CheckIfCellIsAvailable(randRow, randCol))
                {
                    computerChosenCell = new Point(randRow, randCol);
                    m_Board.SetCellValue(randRow, randCol, m_LastPlayer.PlayerSymbol);
                    break;
                }
            }

            return computerChosenCell;
        }

        public void UpdateCellInBoardGame(int i_ChosenRow, int i_ChosenColum, GameBoard.eSymbols i_PlayerSymbol)
        {
            m_Board.SetCellValue(i_ChosenRow, i_ChosenColum, i_PlayerSymbol);
        }

        public bool CheckIfCellIsAvailable(int i_Row, int i_Col)
        {
            return m_Board.Board[i_Row, i_Col].Available;
        }

        public void NewGame()
        {
            m_MovesCounter = 0;
            SetNewBoard(m_Board.NumOfRows, m_Board.NumOfCols);
        }
    }
}