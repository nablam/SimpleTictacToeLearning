using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TacTicToe
{
    public class HumanPlayer : IPlayer
    {

        char[] AllowedCharacters;
        int _r = 0;
        int _c = 0;
        char _mySymb;
        int _IamPlayer = -1;

        BoardGame _TheBoardGame;

        public HumanPlayer(BoardGame argGoardGame, char argSymb)
        {
            // UsePause = argUsePause;
            _mySymb = argSymb;
            _TheBoardGame = argGoardGame;
            //___________________________________________________________________________________________________________________________yes,no,ok,Finish
            //            AllowedCharacters = new char[22] { '1', '2', '3', '4', '5', '6', '7', '8', '9', 'q', 'w', 'e', 'a', 's', 'd', 'z', 'x', 'c', 'y', 'n', 'o', 'f' };
            AllowedCharacters = new char[9] { 'q', 'w', 'e', 'a', 's', 'd', 'z', 'x', 'c' };
        }

        bool RunVAlidations(char argInputChar)
        {
            bool BothAreOK = false;
            bool _1_isOk = false;
            bool _2_isOk = false;

            _1_isOk = Validate_characterAllowed(argInputChar);

            if (_1_isOk)
            {

                switch (argInputChar)
                {
                    case 'q':
                        _r = 0; _c = 0;
                        break;
                    case 'w':
                        _r = 0; _c = 1;
                        break;
                    case 'e':
                        _r = 0; _c = 2;
                        break;

                    case 'a':
                        _r = 1; _c = 0;
                        break;
                    case 's':
                        _r = 1; _c = 1;
                        break;
                    case 'd':
                        _r = 1; _c = 2;
                        break;

                    case 'z':
                        _r = 2; _c = 0;
                        break;
                    case 'x':
                        _r = 2; _c = 1;
                        break;
                    case 'c':
                        _r = 2; _c = 2;
                        break;

                }

                _2_isOk = _TheBoardGame.IsOpen(_r, _c);
            }


            if (_1_isOk && _2_isOk) BothAreOK = true;
            else
                BothAreOK = false;
            return BothAreOK;
        }

        bool Validate_characterAllowed(char argchar)
        {
            bool ArgCharIsAllowed = false;
            int foundMatches = 0;
            for (int i = 0; i < AllowedCharacters.Length; i++)
            {
                if (AllowedCharacters[i] == argchar)
                {
                    foundMatches++;
                }
            }
            if (foundMatches > 0)
            {
                ArgCharIsAllowed = true;
            }
            else
                ArgCharIsAllowed = false;

            return ArgCharIsAllowed;
        }


        public void Play()
        {
            Console.WriteLine("I AM Player " + _IamPlayer.ToString());


            ConsoleKeyInfo keyInfo = Console.ReadKey(true);

            while (!RunVAlidations(keyInfo.KeyChar))
            {

                keyInfo = Console.ReadKey(true);
            }
            char ValidPressedChar = keyInfo.KeyChar;
            _TheBoardGame.PlayerPlayes(_mySymb, _r, _c);


        }

        public char MySymbol()
        {
            return _mySymb;
        }

        public void IamPlayer(int argPos)
        {
            _IamPlayer = argPos;
        }
    }
}
