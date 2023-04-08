using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TacTicToe
{
    public class GameSession
    {
        int curTurn = 0;
        char PlayerChar = 'j';
        IPlayer _player1;
        IPlayer _player2;
        BoardGame _thegameboard;
        int _sessionNumber;
        bool GameWon = false;//should be 0 while playing 1 for player 1 win 2 player2 win 3 null

        public GameSession(IPlayer argplayer1, IPlayer argplayer2, BoardGame argBoard, int argSessionNumber)
        {
            GameWon = false;
            _sessionNumber = argSessionNumber;
            _player1 = argplayer1;
            _player2 = argplayer2;
            _thegameboard = argBoard;
            curTurn = 0;
        }


        void P1Play(int argpos)
        {
            _player1.IamPlayer(argpos);
            _player1.Play();
            //  Console.Clear();
            _thegameboard.DrawBoard(_sessionNumber, curTurn, _player1.MySymbol(), true);
            GameWon = _thegameboard.Verify_ifWin();
        }
        void P2Play(int argpos)
        {
            _player2.IamPlayer(argpos);
            _player2.Play();
            // Console.Clear();
            _thegameboard.DrawBoard(_sessionNumber, curTurn, _player2.MySymbol(), false);
            GameWon = _thegameboard.Verify_ifWin();
        }

        public void RunSession(bool player1First, bool argUsePasue)
        {

            _thegameboard.NewSession();

            while (curTurn < 9)
            {


                if (curTurn == 0)
                {
                    Console.Clear();
                    _thegameboard.DrawEmptyBoard(_sessionNumber, curTurn, _player1.MySymbol(), true);
                }

                curTurn++;//turn 1 
                //tu++

                if (player1First)
                {
                    if (curTurn % 2 == 1)
                    {
                        P1Play(0);

                    }
                    else
                    {
                        P2Play(1);
                    }
                }
                else
                {
                    if (curTurn % 2 == 1)
                    {
                        P2Play(0);

                    }
                    else
                    {
                        P1Play(1);
                    }

                }

                if (argUsePasue)
                {
                    Thread.Sleep(600);
                }

                if (curTurn == 9)
                {
                    _thegameboard.EndSession(3);
                    break;
                }


                if (GameWon)
                {


                    {
                        int playerwinner = 9;
                        if (curTurn % 2 == 0) playerwinner = 1;
                        else
                            playerwinner = 0;
                        _thegameboard.EndSession(playerwinner);
                        break;
                    }

                }

            }

        }
    }
}
