using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TacTicToe
{
    public class TickTackGame
    {
        char[] gameboard;
        int[] gameboard_Num15;
        int gameNumber;
        int round = 0;
        int roundTurnCount = 0;
        bool HumanPlayerTurn = true;
        char CurrChar = ' ';
        char[] AllowedCharacters;
        int[,] tctcto;
        void makeArray()
        {
            int[,] array = new int[3, 3];
            Random rand = new Random();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    array[i, j] = rand.Next(10);
                }
            }
            Console.WriteLine("The 3x3 int array is:");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(array[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        public TickTackGame()
        {
            InittAll();
        }
        public void Run()
        {
            StartLoop();
        }
        void InittAll()
        {
            tctcto = new int[3, 3] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
            tctcto[0, 0] = 0;
            tctcto[0, 1] = 0;
            tctcto[0, 2] = 0;
            tctcto[1, 0] = 1;
            tctcto[1, 1] = 2;
            tctcto[1, 2] = 3;
            tctcto[2, 0] = 4;
            tctcto[2, 1] = 5;
            tctcto[2, 2] = 6;

            AllowedCharacters = new char[18] { '1', '2', '3', '4', '5', '6', '7', '8', '9', 'q', 'w', 'e', 'a', 's', 'd', 'z', 'x', 'c' };
            gameboard = new char[9] { '.', '.', '.', '.', '.', '.', '.', '.', '.' };
            gameboard_Num15 = new int[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            gameNumber = 0;
            round = 0;
            roundTurnCount = 0;
            HumanPlayerTurn = true;
            CurrChar = ' ';
        }

        void DrawBoardMap_andUI()
        {
            CurrChar = HumanPlayerTurn == true ? 'X' : 'O';
            Console.WriteLine(" 8 | 1 | 6 " + "    game " + gameNumber);
            Console.WriteLine("---+---+---" + "    round " + roundTurnCount);
            Console.WriteLine(" 3 | 5 | 7 " + "    Player " + CurrChar);
            Console.WriteLine("---+---+---");
            Console.WriteLine(" 4 | 9 | 2 ");
            Console.WriteLine("");
        }
        void DrawEmptyGameBoard()
        {
            string s0 = " ";
            string s1 = " ";
            string s2 = " ";
            string s3 = " ";
            string s4 = " ";
            string s5 = " ";
            string s6 = " ";
            string s7 = " ";
            string s8 = " ";
            Console.WriteLine(" " + s0 + " | " + s1 + " | " + s2 + " ");
            Console.WriteLine("---+---+---");
            Console.WriteLine(" " + s3 + " | " + s4 + " | " + s5 + " ");
            Console.WriteLine("---+---+---");
            Console.WriteLine(" " + s6 + " | " + s7 + " | " + s8 + " ");
            Console.WriteLine("");
        }

        void Verify_ifWin(int diag)
        {
            int row_0_Total = tctcto[0, 0] + tctcto[0, 1] + tctcto[0, 2];
            int row_1_Total = tctcto[1, 0] + tctcto[1, 1] + tctcto[1, 2];
            int row_2_Total = tctcto[2, 0] + tctcto[2, 1] + tctcto[2, 2];
            int Col_0_Total = tctcto[0, 0] + tctcto[1, 0] + tctcto[2, 0];
            int Col_1_Total = tctcto[0, 1] + tctcto[1, 1] + tctcto[2, 1];
            int Col_2_Total = tctcto[0, 2] + tctcto[1, 2] + tctcto[2, 2];
            int Diag_1_Total = tctcto[0, 0] + tctcto[1, 1] + tctcto[2, 2];
            int Diag_2_Total = tctcto[0, 2] + tctcto[1, 1] + tctcto[2, 0];
            if (Diag_1_Total == 3 || Diag_2_Total == 3 || row_0_Total == 3 || row_1_Total == 3 || row_2_Total == 3 || Col_0_Total == 3 || Col_1_Total == 3 || Col_2_Total == 3)
            {
                Console.WriteLine("POS WIN");
            }
            else
                  if (Diag_1_Total == -3 || Diag_2_Total == -3 || row_0_Total == -3 || row_1_Total == -3 || row_2_Total == -3 || Col_0_Total == -3 || Col_1_Total == -3 || Col_2_Total == -3)
            {
                Console.WriteLine("NEG WIN");
            }
            else
            {
                Console.WriteLine("diagz NULL");
            }
        }
        void DrawUNDERGameBoard()
        {
            Console.WriteLine(" " + tctcto[0, 0] + " | " + tctcto[0, 1] + " | " + tctcto[0, 2] + " ");
            Console.WriteLine("---+---+---");
            Console.WriteLine(" " + tctcto[1, 0] + " | " + tctcto[1, 1] + " | " + tctcto[1, 2] + " ");
            Console.WriteLine("---+---+---");
            Console.WriteLine(" " + tctcto[2, 0] + " | " + tctcto[2, 1] + " | " + tctcto[2, 2] + " ");
            Console.WriteLine("");
        }
        void StartLoop()
        {
            roundTurnCount = 0;
            while (roundTurnCount < 9)
            {
                RoundLoop();
            }
            Console.WriteLine("Finished");
        }
        void RoundLoop()
        {
            DrawBoardMap_andUI();
            DrawUNDERGameBoard();
            Player_Human_Roll();
            roundTurnCount++;
            DrawBoardMap_andUI();
            DrawUNDERGameBoard();
            Player_AI_Roll();
            roundTurnCount++;
        }
        bool Validate_characterAllowed(char argchar)
        {
            bool ArgCharIsAllowed = false;
            foreach (char c in AllowedCharacters)
            {
                if (argchar == c)
                {
                    ArgCharIsAllowed = true;
                }
            }
            return ArgCharIsAllowed;
        }
        bool VAlidate_Spot_isOpen(char argchar)
        {
            bool spotIsOpen = false;
            char Char_15 = ' ';
            int IndexTocheck = -1;
            switch (argchar)
            {
                case '8':
                    IndexTocheck = 0;
                    break;
                case '1':
                    IndexTocheck = 1;
                    break;
                case '6':
                    IndexTocheck = 2;
                    break;
                case '3':
                    IndexTocheck = 3;
                    break;
                case '5':
                    IndexTocheck = 4;
                    break;
                case '7':
                    IndexTocheck = 5;
                    break;
                case '4':
                    IndexTocheck = 6;
                    break;
                case '9':
                    IndexTocheck = 7;
                    break;
                case '2':
                    IndexTocheck = 8;
                    break;

                case 'q':
                    IndexTocheck = 0;
                    break;
                case 'w':
                    IndexTocheck = 1;
                    break;
                case 'e':
                    IndexTocheck = 2;
                    break;
                case 'a':
                    IndexTocheck = 3;
                    break;
                case 's':
                    IndexTocheck = 4;
                    break;
                case 'd':
                    IndexTocheck = 5;
                    break;
                case 'z':
                    IndexTocheck = 6;
                    break;
                case 'x':
                    IndexTocheck = 7;
                    break;
                case 'c':
                    IndexTocheck = 8;
                    break;
            }
            if (gameboard_Num15[IndexTocheck] == 0)
                spotIsOpen = true;

            return spotIsOpen;
        }
        bool ValidateBoth(char argchar)
        {
            bool _1_isOk = false;
            bool _2_isOk = false;
            bool BothAreOK = false;
            if (Validate_characterAllowed(argchar))
            {
                _1_isOk = true;
                if (VAlidate_Spot_isOpen(argchar))
                {
                    _2_isOk = true;
                }
                else
                {
                    Console.WriteLine(" ALREADY PLAYED !");
                }
            }
            else
            {
                Console.WriteLine("CHARACTER NOT ALLOWED!!");
            }
            if (_1_isOk && _2_isOk) BothAreOK = true;

            return BothAreOK;
        }
        void Player_Human_Roll()
        {
            Console.WriteLine($"Press one of the following keys: {string.Join(", ", AllowedCharacters)}");
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);

            while (!ValidateBoth(keyInfo.KeyChar))
            {
                keyInfo = Console.ReadKey(true);
            }
            Console.WriteLine($"You pressed: {keyInfo.KeyChar}");
            ProcessEntry_resetChar(keyInfo.KeyChar);
        }
        void Player_AI_Roll()
        {
            char charpcked = ' ';
            while (!ValidateBoth(charpcked))
            {
                Random random = new Random();
                int index = random.Next(0, AllowedCharacters.Length);
                charpcked = AllowedCharacters[index];
            }
            ProcessEntry_resetChar(charpcked);
        }
        void WaitForUserInput()
        {
            Console.WriteLine("Press any alphanumeric key to continue...");
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            while (!char.IsLetterOrDigit(keyInfo.KeyChar))
            {
                Console.WriteLine("Invalid input. Please enter an alphanumeric key...");
                keyInfo = Console.ReadKey(true);
            }
            CurrChar = keyInfo.KeyChar;
        }
        void ProcessEntry_resetChar(char _charX_O)
        {
            switch (CurrChar)
            {
                case '8':
                    gameboard[0] = _charX_O;
                    gameboard_Num15[0] = 8;
                    break;
                case '1':
                    gameboard[1] = _charX_O;
                    gameboard_Num15[1] = 1;
                    break;
                case '6':
                    gameboard[2] = _charX_O;
                    gameboard_Num15[2] = 6;
                    break;
                case '3':
                    gameboard[3] = _charX_O;
                    gameboard_Num15[3] = 3;
                    break;
                case '5':
                    gameboard[4] = _charX_O;
                    gameboard_Num15[4] = 5;
                    break;
                case '7':
                    gameboard[5] = _charX_O;
                    gameboard_Num15[5] = 7;
                    break;
                case '4':
                    gameboard[6] = _charX_O;
                    gameboard_Num15[6] = 4;
                    break;
                case '9':
                    gameboard[7] = _charX_O;
                    gameboard_Num15[7] = 9;
                    break;
                case '2':
                    gameboard[8] = _charX_O;
                    gameboard_Num15[8] = 2;
                    break;
            }
        }
    }
}
