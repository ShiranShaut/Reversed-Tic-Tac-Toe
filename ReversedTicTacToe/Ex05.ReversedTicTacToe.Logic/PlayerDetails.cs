using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex05.ReversedTicTacToe.Logic
{
    public class PlayerDetails
    {
        private readonly GameBoard.eSymbols r_PlayerSymbol;
        private readonly string r_PlayerName;
        private int m_GamePoints;

        public PlayerDetails(string i_PlayerName, GameBoard.eSymbols i_PlayerChoosedSymbol)
        {
            r_PlayerName = i_PlayerName;
            r_PlayerSymbol = i_PlayerChoosedSymbol;
            m_GamePoints = 0;
        }

        public string PlayerName
        {
            get { return r_PlayerName; }
        }

        public GameBoard.eSymbols PlayerSymbol
        {
            get { return r_PlayerSymbol; }
        }

        public int GamePoints
        {
            get { return m_GamePoints; }
            set { m_GamePoints = value; }
        }
    }
}