using System;
using System.Drawing;
using System.Windows.Forms;
using Ex05.ReversedTicTacToe.Logic;

namespace Ex05.ReversedTicTacToe_Ui
{
    partial class GameBoardForm : Form
    {
        private enum eGameMode
        {
            PlayerVSComputer,
            PlayerVSPlayer
        }

        private readonly BoardButton[,] r_ButtonsArray;
        private readonly int r_Rows;
        private readonly int r_Cols;
        private readonly Font r_BoldFont = new Font("Comic Sans MS", 12, FontStyle.Bold);
        private readonly Font r_RegularFont = new Font("Comic Sans MS", 12, FontStyle.Regular);
        private readonly GameSettingsForm r_SettingsForm = new GameSettingsForm();
        private readonly GameLogic r_GameLogic;
        private readonly eGameMode r_GameMode;
        private PlayerDetails m_CurrentPlayer;
    
        public GameBoardForm()
        {
            InitializeComponent();

            // The user press START
            if (r_SettingsForm.ShowDialog() == DialogResult.OK)
            {
                r_Rows = r_SettingsForm.NumOfRows;
                r_Cols = r_SettingsForm.NumOfCols;
                r_ButtonsArray = new BoardButton[r_Rows, r_Cols];
                r_GameMode = r_SettingsForm.Player2IsPlay ? eGameMode.PlayerVSPlayer : eGameMode.PlayerVSComputer;
                PlayerDetails player1 = new PlayerDetails(r_SettingsForm.Player1Name, GameBoard.eSymbols.Symbol1);
                PlayerDetails player2 = new PlayerDetails(r_SettingsForm.Player2Name, GameBoard.eSymbols.Symbol2);
                r_GameLogic = new GameLogic(player1, player2);

                m_CurrentPlayer = player1;
                startGame();
            }
            else
            {
                Environment.Exit(0);
            }
        }

        private void gameBoardForm_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
        }

        private void startGame()
        {
            r_GameLogic.SetNewBoard(r_Rows, r_Cols);
            buildBoard();
            newGame();
        }

        private void newGame()
        {
            foreach (BoardButton currentButton in r_ButtonsArray)
            {
                currentButton.Enabled = true;
                currentButton.Text = string.Empty;
                currentButton.Font = new Font("Segoe Print", 20, FontStyle.Bold);
                currentButton.BackColor = Color.LightSkyBlue;
            }

            m_Player1ScoreLabel.Font = r_BoldFont;
            setLabels();
            r_GameLogic.NewGame();
            m_CurrentPlayer = r_GameLogic.Player1;
        }

        private void buildBoard()
        {
            int spaceBetweenButtons = 10;
            int x = spaceBetweenButtons;
            int y = spaceBetweenButtons;
            int buttonWidth = 75;
            int buttonHeight = 60;
            int width = 0;
            int lablePlayer1X;

            for (int i = 0; i < r_Rows; i++)
            {
                for (int j = 0; j < r_Cols; j++)
                {
                    BoardButton newButton = new BoardButton(i, j);

                    newButton.Size = new Size(buttonWidth, buttonHeight);
                    newButton.Location = new Point(x, y);
                    r_ButtonsArray[i, j] = newButton;
                    this.Controls.Add(newButton);
                    newButton.Click += button_Click;
                    x += buttonWidth + spaceBetweenButtons;
                }

                width = x;
                y += buttonHeight + spaceBetweenButtons;
                x = spaceBetweenButtons;
            }

            lablePlayer1X = r_ButtonsArray[0, (r_Cols - 1) / 2].Location.X;

            if(r_Cols % 2 != 0)
            {
                lablePlayer1X -= buttonWidth / 2;
            }

            this.Size = new Size(width + (spaceBetweenButtons * 2), y + buttonHeight + 10);
            m_Player1ScoreLabel.Location = new Point(lablePlayer1X, this.ClientSize.Height - m_Player1ScoreLabel.Height);
            m_Player2ScoreLabel.Location = new Point(m_Player1ScoreLabel.Location.X + m_Player1ScoreLabel.Width + 25, this.ClientSize.Height - m_Player2ScoreLabel.Height);
            m_CurrentPlayer = r_GameLogic.Player1;
        }

        private string convertSymbolToString(GameBoard.eSymbols i_PlayerSymbol)
        {
            string symbol = null;

            switch (i_PlayerSymbol)
            {
                case GameBoard.eSymbols.Symbol1:
                    {
                        symbol = "X";
                        break;
                    }

                case GameBoard.eSymbols.Symbol2:
                    {
                        symbol = "O";
                        break;
                    }
            }

            return symbol;
        }

        private void button_Click(object sender, EventArgs e)
        {
            BoardButton currentButton = sender as BoardButton;

            currentButton.Text = convertSymbolToString(m_CurrentPlayer.PlayerSymbol);
            currentButton.Enabled = false;
            updatePlayerMove(currentButton.X, currentButton.Y, m_CurrentPlayer.PlayerSymbol);
            r_GameLogic.PlayerMove(m_CurrentPlayer);
            
            if (!checkIfGameOver())
            {
                updateTurn();
                if (r_GameMode == eGameMode.PlayerVSComputer)
                {
                    computerMove();
                }
            }
        }

        private void setLabels()
        {
            m_Player1ScoreLabel.Text = string.Format("{0} : {1}", r_GameLogic.Player1.PlayerName, r_GameLogic.Player1.GamePoints);
            m_Player2ScoreLabel.Text = string.Format("{0} : {1}", r_GameLogic.Player2.PlayerName, r_GameLogic.Player2.GamePoints);
        }

        private void setLabelsFont(Font i_Label1Font, Font i_Label2Font)
        {
            m_Player1ScoreLabel.Font = i_Label1Font;
            m_Player2ScoreLabel.Font = i_Label2Font;
        }

        private bool checkIfGameOver()
        {
            bool gameOver = false;
            string gameOverReason = null;

            if (r_GameLogic.GameOver(out gameOverReason))
            {
                gameOver = true;
                setLabelsFont(r_RegularFont, r_RegularFont);
                checkIfWantAnotherGame(gameOverReason);
            }

            return gameOver;
        }

        private void updatePlayerMove(int i_X, int i_Y, GameBoard.eSymbols i_PlayerSymbol)
        {
            r_GameLogic.UpdateCellInBoardGame(i_X, i_Y, i_PlayerSymbol);
        }

        private void checkIfWantAnotherGame(string gameOverReason)
        {
            string gameStatus = getGameDitails(gameOverReason);
            DialogResult anotherGameResult = MessageBox.Show(string.Format("{0}Would you like to play another round?", gameStatus), gameOverReason, MessageBoxButtons.YesNo);

            if (anotherGameResult == DialogResult.Yes)
            {
                newGame();
            }
            else
            {
                MessageBox.Show(string.Format("Thank you for playing!{0}Come back soon :)", Environment.NewLine), "Game Over");
                Application.Exit();
            }
        }

        private string getGameDitails(string i_GameOverReason)
        {
            string details = null;

            switch (i_GameOverReason)
            {
                case "A Tie!":
                    {
                        details = string.Format("You filled the board so it's a tie!{0}", Environment.NewLine);
                        break;
                    }

                case "A Win!":
                    {
                        if (r_GameLogic.LastPlayer == r_GameLogic.Player1)
                        {
                            details = string.Format("The winner is: {0}{1}", r_GameLogic.Player2.PlayerName, Environment.NewLine);
                        }
                        else
                        {
                            details = string.Format("The winner is: {0}{1}", r_GameLogic.Player1.PlayerName, Environment.NewLine);
                        }

                        break;
                    }
            }

            return details;
        }

        private void updateTurn()
        {
            if (m_CurrentPlayer == r_GameLogic.Player1)
            {
                m_CurrentPlayer = r_GameLogic.Player2;
                setLabelsFont(r_RegularFont, r_BoldFont);
            }
            else
            {
                m_CurrentPlayer = r_GameLogic.Player1;
                setLabelsFont(r_BoldFont, r_RegularFont);
            }

            this.Refresh();
        }

        private void computerMove()
        {
            System.Threading.Thread.Sleep(250);
            Point chosenCell = r_GameLogic.ComputerMove();
            BoardButton buttonToUpdate = r_ButtonsArray[chosenCell.X, chosenCell.Y];

            buttonToUpdate.Enabled = false;
            buttonToUpdate.Text = convertSymbolToString(m_CurrentPlayer.PlayerSymbol);
            if (!checkIfGameOver())
            {
                updateTurn();
            }
        }

        private void GameBoardForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}