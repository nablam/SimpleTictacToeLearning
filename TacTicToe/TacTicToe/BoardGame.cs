using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TacTicToe
{
   public class BoardGame
    {
        int[,] tctcto;
        int[,] gridForDataTracker;
        char[,] charTTC;
        char CharToDraw = ' ';
        int IntToSet = 0;
        bool lastplayerisAttacker = true;
        int lastWinner = 1;
        GameDataTracker _datatracker;

        public int LastWinner { get => lastWinner; set => lastWinner = value; }

        public BoardGame(GameDataTracker argdatatracker)
        {

            RestArrays();
            _datatracker = argdatatracker;
        }

        void RestArrays()
        {
            tctcto = new int[3, 3] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
            gridForDataTracker = new int[3, 3] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            charTTC = new char[3, 3] { { '.', '.', '.' }, { '.', '.', '.' }, { '.', '.', '.' } };
        }

        public bool IsOpen(int iR, int iC)
        {
            return tctcto[iR, iC] == 0;
        }
        public void PlayerPlayes(char argPlayerSymbol, int iR, int iC)
        {
            if (argPlayerSymbol == 'x' || argPlayerSymbol == 'X')
            {
                CharToDraw = 'X';
                IntToSet = 1;
            }
            else
            {
                CharToDraw = 'O';
                IntToSet = -1;
            }
            tctcto[iR, iC] = IntToSet;
            charTTC[iR, iC] = CharToDraw;
            char curmove = (char)(gridForDataTracker[iR, iC] + '0');
            _datatracker.BuildData(curmove);
        }

        public bool Verify_ifWin()
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
                lastWinner = 1;
                return true;
            }
            else
                  if (Diag_1_Total == -3 || Diag_2_Total == -3 || row_0_Total == -3 || row_1_Total == -3 || row_2_Total == -3 || Col_0_Total == -3 || Col_1_Total == -3 || Col_2_Total == -3)
            {
                lastWinner = 2;
                return true;
            }
            else
            {
                if (lastWinner == 1) lastWinner = 2;
                else
                {
                    if (lastWinner == 2) lastWinner = 1;
                }
                return false;
            }
        }

        public void NewSession()
        {
            _datatracker.ResetString();
        }
        public void EndSession(int argWhoWonEvenOrOdd)
        {
            if (argWhoWonEvenOrOdd == 3)
            {

            }
            else
            {

            }
            _datatracker.AddCurGame(argWhoWonEvenOrOdd);
            _datatracker.PrintSetElements();
        }
        public void DrawBoard(int arggameNumber, int argroundTurnCount, char argCurrChar, bool argAttacker)
        {
            string PlayerPos = "Attacker";
            if (argAttacker == false)
            {
                lastplayerisAttacker = false;
                PlayerPos = "Defender";
            }
            else
            {
                lastplayerisAttacker = true;
                PlayerPos = "Attacker";
            }



        }

        public void DrawEmptyBoard(int arggameNumber, int argroundTurnCount, char argCurrChar, bool argAttacker)
        {
            RestArrays();
            string PlayerPos = "Attacker";
            if (argAttacker == false)
            {
                PlayerPos = "Defender";
            }
        }

        public string Helpme(int argPlayerpos)
        {
            List<string> templist = new List<string>();
            if (argPlayerpos == 0)
            {
                foreach (string s in _datatracker.Games_0_win)
                {
                    templist.Add(s);
                }

            }
            else
                 if (argPlayerpos == 1)
            {
                foreach (string s in _datatracker.Games_1_win)
                {
                    templist.Add(s);
                }

            }


            string outStr = "?";
            string gamestringCur = _datatracker.GetCurGameString();
            if (gamestringCur == "")
            {
                return outStr;
            }
            List<string> possiblewins = FindMatchs(gamestringCur, templist);
            if (possiblewins == null || possiblewins.Count == 0)
            {
                return outStr;
            }
            Random r = new Random();
            int index = r.Next(possiblewins.Count);
            string ChosenString = possiblewins[index];
            int gamestrLen = gamestringCur.Length;
            outStr = ChosenString[gamestrLen].ToString();
            return outStr;
        }


        public List<string> FindMatchs(string input, List<string> arg_myList)
        {
            string outstr = "";
            List<string> outList = new List<string>();
            foreach (string s in arg_myList)
            {
                if (s.Length >= input.Length)
                {
                    var inputChars = new HashSet<char>(input);
                    bool isMatch = true;
                    foreach (char c in inputChars)
                    {
                        if (input.Count(x => x == c) != s.Take(input.Length).Count(x => x == c))
                        {
                            isMatch = false;
                            break;
                        }
                    }
                    if (isMatch)
                    {
                        outstr = s;
                        outList.Add(outstr);
                    }
                }
            }

            if (outList.Count > 0)
            {
                foreach (string str in outList)
                {
                }
            }
            else
            {
            }
            return outList;//return null; // or an empty string, depending on desired behavior when no match is found
        }
    }
}
