using System;
using Ex02.ConsoleUtils;

namespace C17_Ex02
{
    public class UserInterface
    {
        private enum eGameMode
        {
            PlayerVSComputer,
            PlayerVSPlayer
        }

        private enum ePlayers
        {
            Player1 = 1,
            Player2
        }

        private const int k_MinBoardValue = 3;
        private const int k_MaxBoardValue = 9;
        private TicTacToeLogic m_Game;
        private int m_BoardGameLenght;

        public void StartGame()
        {
            Console.WriteLine(@"Welcome to Reverse Tic Tac Toe game! :){0}", Environment.NewLine);
            setBoradSize();
            printToConsoleStartGameMsg();
            int userSelectedChoice = int.Parse(Console.ReadLine());

            switch (userSelectedChoice)
            {
                case 0:
                    {
                        printGoodbyeMsg();
                        break;
                    }

                case 1:
                    {
                        playerVsComputerGame();
                        break;
                    }

                case 2:
                    {
                        playerVsPlayerGame();
                        break;
                    }

                default:
                    {
                        Console.WriteLine("You entered an invalid input, please try again.");
                        printToConsoleStartGameMsg();
                        break;
                    }
            }
        }

        private void printGoodbyeMsg()
        {
            string goodbyeMsg = string.Format(@"It was a pleasure to play with you!
Goodbye :)
");

            Screen.Clear();
            Console.WriteLine(goodbyeMsg);
        }

        private void printToConsoleStartGameMsg()
        {
            string entryGameMsg = string.Format(@"
For 'Player VS Computer' game - press 1
For 'Player VS Player' game - press 2
For exit - press 0");

            Console.WriteLine(entryGameMsg);
        }

        private void playerVsComputerGame()
        {
            Console.WriteLine();
            string playerName = enterPlayerName();
            GameBoard.eSymbols playerSymbol = enterPlayerSymbol();
            GameBoard.eSymbols computerSymbol = (playerSymbol == GameBoard.eSymbols.Symbol1) ? GameBoard.eSymbols.Symbol2 : GameBoard.eSymbols.Symbol1;
            PlayerDetails player1 = new PlayerDetails(playerName, playerSymbol);
            PlayerDetails computer = new PlayerDetails("Computer", computerSymbol);

            m_Game = new TicTacToeLogic(player1, computer);
            m_Game.SetNewBoard(m_BoardGameLenght, m_BoardGameLenght);
            play((int)eGameMode.PlayerVSComputer);
            printGoodbyeMsg();
        }

        private void playerVsPlayerGame()
        {
            Console.Write("{0}Player 1 - ", Environment.NewLine);
            string player1Name = enterPlayerName();

            Console.Write("Player 2 - ");
            string player2Name = enterPlayerName();

            Console.Write("{0}{1} : ", Environment.NewLine, player1Name);
            GameBoard.eSymbols player1Symbol = enterPlayerSymbol();
            GameBoard.eSymbols player2Symbol = (player1Symbol == GameBoard.eSymbols.Symbol1) ? GameBoard.eSymbols.Symbol2 : GameBoard.eSymbols.Symbol1;
            PlayerDetails player1 = new PlayerDetails(player1Name, player1Symbol);
            PlayerDetails Player2 = new PlayerDetails(player2Name, player2Symbol);

            m_Game = new TicTacToeLogic(player1, Player2);
            m_Game.SetNewBoard(m_BoardGameLenght, m_BoardGameLenght);
            play((int)eGameMode.PlayerVSPlayer);
            printGoodbyeMsg();
        }

        private string enterPlayerName()
        {
            Console.WriteLine("Please enter your name: ");
            return Console.ReadLine();
        }

        private GameBoard.eSymbols enterPlayerSymbol()
        {
            char userSymbol;
            bool validInput = false;

            for(;;)
            {
                Console.WriteLine("Choose a symbol - X or O: ");
                validInput = char.TryParse(Console.ReadLine(), out userSymbol);
                if (validInput)
                {
                    userSymbol = char.ToUpper(userSymbol);
                    if (userSymbol != 'X' && userSymbol != 'O')
                    {
                        Console.WriteLine("You entered an invalid input, please try again.");
                    }
                    else
                    {
                        return (GameBoard.eSymbols)userSymbol;
                    }
                }
            }
        }

        private void play(int i_GameMode)
        {
            bool firstPlayerTurn = true;
            string gameOverReason = null;

            do
            {
                m_Game.NewGame();
                while (!m_Game.GameOver(out gameOverReason))
                {
                    printBoard();
                    if (firstPlayerTurn)
                    {
                        Console.WriteLine("It's {0} turn: ", m_Game.Player1.PlayerName);
                        if(updatePlayerMoveAndCheckIfQuit(m_Game.Player1.PlayerSymbol))
                        {
                            break;
                        }

                        m_Game.PlayerMove((int)ePlayers.Player1);
                        firstPlayerTurn = false;
                    }
                    else
                    {
                        Console.WriteLine("It's {0} turn: ", m_Game.Player2.PlayerName);
                        if (i_GameMode == (int)eGameMode.PlayerVSComputer)
                        {
                            System.Threading.Thread.Sleep(250); // for the user interface - see the computer move in slow
                            m_Game.ComputerMove();
                        }
                        else
                        {
                            if (updatePlayerMoveAndCheckIfQuit(m_Game.Player2.PlayerSymbol))
                            {
                                break;
                            }

                            m_Game.PlayerMove((int)ePlayers.Player2);
                        }

                        firstPlayerTurn = true;
                    }
                }

                printBoard();
                printGameDitails(gameOverReason);
            }
            while(checkIfPlayerWantAnotherGame());
        }

        private bool updatePlayerMoveAndCheckIfQuit(GameBoard.eSymbols i_PlayerSymbol)
        {
            bool userQuit = false;

            for (;;)
            {
                int chosenRow = enterValidRowInput();
                int chosenCol = enterValidColumInput();

                if (chosenCol == -1)
                {
                    userQuit = true;
                    break;
                }

                if (m_Game.CheckIfCellIsAvailable(chosenRow, chosenCol))
                {
                    m_Game.UpdateCellInBoardGame(chosenRow, chosenCol, i_PlayerSymbol);
                    break;
                }
                else
                {
                    Console.WriteLine(@"This cell isn't available, please try another.{0}", Environment.NewLine);
                }
            }

            return userQuit;
        }

        private int enterValidRowInput()
        {
            bool rowValidInput;
            int chosenRow;

            for (;;)
            {
                Console.WriteLine("Please Enter the row in board you wish: ");
                rowValidInput = int.TryParse(Console.ReadLine(), out chosenRow);
                if (!rowValidInput || chosenRow < 1 || chosenRow > m_Game.Board.NumOfRows)
                {
                    Console.WriteLine("You entered an invalid input, please try again.");
                }
                else
                {
                    chosenRow--;
                    break;
                }
            }

            return chosenRow;
        }

        private int enterValidColumInput()
        {
            bool validInput = false;
            string userInputToCheck;
            int userInput;

            for (;;)
            {
                wantToQuitOrEnterColumMsg();
                userInputToCheck = Console.ReadLine();

                if (userInputToCheck == "Q" || userInputToCheck == "q")
                {
                    userInput = -1;
                    break;
                }

                validInput = int.TryParse(userInputToCheck, out userInput);
                if (!validInput || userInput < 1 || userInput > m_Game.Board.NumOfCols)
                {
                    Console.WriteLine("You entered an invalid input, please try again.");
                    validInput = false;
                }
                else
                {
                    userInput--;
                    break;
                }
            }

            return userInput;
        }

        private void printBoard()
        {
            Screen.Clear();
            Console.WriteLine(m_Game.GetDrawBoard());
        }

        private void wantToQuitOrEnterColumMsg()
        {
            string msg = string.Format(@"
If you want to quit, press Q
If not, Please Enter the col in board you wish:");

            Console.WriteLine(msg);
        }

        private void printGameDitails(string i_GameOverReason)
        {
            switch (i_GameOverReason)
            {
                case "FullBoard":
                    {
                        Console.WriteLine("You filled the board so it's a tie!{0}", Environment.NewLine);
                        break;
                    }

                case "PlayerWin":
                    {
                        if (m_Game.LastPlayer == m_Game.Player1)
                        {
                            Console.WriteLine("The winner is: {0}{1}", m_Game.Player2.PlayerName, Environment.NewLine);
                        }
                        else
                        {
                            Console.WriteLine("The winner is: {0}{1}", m_Game.Player1.PlayerName, Environment.NewLine);
                        }

                        break;
                    }

                case "GameNotOver":
                    {
                        Console.WriteLine("The game not over.{0}", Environment.NewLine);
                        break;
                    }
            }

            showResults(m_Game.Player1, m_Game.Player2);
        }

        private void showResults(PlayerDetails i_Player1, PlayerDetails i_Player2)
        {
            Console.WriteLine("The results until now is: ");
            printPlayerDetails(i_Player1);
            printPlayerDetails(i_Player2);
        }

        private void printPlayerDetails(PlayerDetails i_Player)
        {
            string detailsMsg = string.Format(@"Player name: {0}  |  Player score: {1}", i_Player.PlayerName, i_Player.GamePoints);

            Console.WriteLine(detailsMsg);
        }

        private bool checkIfPlayerWantAnotherGame()
        {
            char playerInput;
            bool validInput = false;
            bool wantAnotherGame = false;

            while(!validInput)
            {
                Console.WriteLine(@"{0}Do you want to play another game? press y / n", Environment.NewLine);
                validInput = char.TryParse(Console.ReadLine(), out playerInput);
                if (!validInput)
                {
                    continue;
                }

                switch (playerInput)
                {
                    case 'y':
                        {
                            wantAnotherGame = true;
                            break;
                        }

                    case 'n':
                        {
                            wantAnotherGame = false;
                            break;
                        }

                    default:
                        {
                            Console.WriteLine("You entered an invalid input, please try again.");
                            validInput = false;
                            break;
                        }
                }
            }

            return wantAnotherGame;
        }

        private void setBoradSize()
        {
            int userBoardSizeInput;
            bool validInput = false;

            while (!validInput)
            {
                enterSizeOfBoardMsg();
                validInput = int.TryParse(Console.ReadLine(), out userBoardSizeInput);
                if (!validInput || userBoardSizeInput < k_MinBoardValue || userBoardSizeInput > k_MaxBoardValue)
                {
                    Console.WriteLine("You entered invalid input, please try again.");
                    validInput = false;
                }
                else
                {
                    m_BoardGameLenght = userBoardSizeInput;
                }
            }
        }

        private void enterSizeOfBoardMsg()
        {
            string sizeBoardMsg = string.Format(@"Enter the size of the board (number between {0}-{1}) please: ", k_MinBoardValue, k_MaxBoardValue);

            Console.WriteLine(sizeBoardMsg);
        }
    }
}