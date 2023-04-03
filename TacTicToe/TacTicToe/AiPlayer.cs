using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TacTicToe
{
   public class AiPlayer : IPlayer
    {
        BoardGame _TheBoardGame;
        char _mySymb;
        Random rand_r; Random rand_c;
        int _r = 0;
        int _c = 0;
        int _IamPlayer = -1;
        bool UsePause = true;
        public AiPlayer(BoardGame argGoardGame, char argSymb, bool argUsePause)
        {
            UsePause = argUsePause;
            rand_r = new Random();
            rand_c = new Random();
            _mySymb = argSymb;
            _TheBoardGame = argGoardGame;
        }

        public void IamPlayer(int argPos)
        {
            _IamPlayer = argPos;
        }
        public void Play()
        {
            //have i seen this board with a win for my turn

            //if not do a randome shot
            //   Console.WriteLine("I is layer " + _IamPlayer.ToString());
            if (UsePause)
            {
                Thread.Sleep(800);
            }


            string nextnum = _TheBoardGame.Helpme(_IamPlayer);

            if (nextnum == "?")
            {

                PlayRandom();
            }
            else
            {
                switch (nextnum)
                {
                    case "1":
                        _r = 0; _c = 0;
                        break;
                    case "2":
                        _r = 0; _c = 1;
                        break;
                    case "3":
                        _r = 0; _c = 2;
                        break;

                    case "4":
                        _r = 1; _c = 0;
                        break;
                    case "5":
                        _r = 1; _c = 1;
                        break;
                    case "6":
                        _r = 1; _c = 2;
                        break;

                    case "7":
                        _r = 2; _c = 0;
                        break;
                    case "8":
                        _r = 2; _c = 1;
                        break;
                    case "9":
                        _r = 2; _c = 2;
                        break;
                }
            }
            _TheBoardGame.PlayerPlayes(_mySymb, _r, _c);
        }

        void PlayRandom()
        {
            _r = rand_r.Next(0, 3);
            _c = rand_c.Next(0, 3);
            while (!_TheBoardGame.IsOpen(_r, _c))
            {
                Random _rand_r; Random _rand_c;
                _rand_r = new Random();
                _rand_c = new Random();
                _r = _rand_r.Next(0, 3);
                _c = _rand_c.Next(0, 3);
            }
        }
        void PlayMemory()
        {


        }
        public char MySymbol()
        {
            return _mySymb;
        }
    }
}
