using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TacTicToe
{
    public class TictacApp
    {
        BoardGame gb;
        GameSession _session;
        int SessionNumber = 0;
        char Choice = ' ';
        char ChoiceTestOrGame= ' ';
        AiPlayer _aiGuy;
        AiPlayer _aiGuy_XX, _aiGuy_OO;
        HumanPlayer _humanGuy;
        GameDataTracker _datatracker;
        public TictacApp()
        {
            _datatracker = new GameDataTracker();
            gb = new BoardGame(_datatracker);
            _aiGuy = new AiPlayer(gb, 'O', true);
            _humanGuy = new HumanPlayer(gb, 'X');
            _aiGuy_XX = new AiPlayer(gb, 'X', false);
            _aiGuy_OO = new AiPlayer(gb, 'O', false);

            _session = new GameSession(_humanGuy, _aiGuy, gb, 0);
        }
        void Do10000()
        {
            _datatracker.LoadListFromFile();
            for (int x = 0; x < 3; x++)
            {
                ;
                Console.WriteLine("_ " + x);
                _session = new GameSession(_aiGuy_XX, _aiGuy_OO, gb, SessionNumber);
                SessionNumber++;
                if (gb.LastWinner == 2)
                {
                    _session.RunSession(false, false, true);
                }
                else
                if (gb.LastWinner == 1)
                {
                    _session.RunSession(true, false, true);
                }

            }
            Console.WriteLine("thanks");
            _datatracker.SaveListToFile();
        }

        public void RunTestOrGame() {
            bool lern = false;
            while (ChoiceTestOrGame != 'n')
            {
                Console.WriteLine("Run Learning  -> L ");
                Console.WriteLine("run Play Game -> P");
             
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                while (!DoVAlidations_L_P(keyInfo.KeyChar))
                {
                    Console.WriteLine("press  L  or   P    plz");
                    keyInfo = Console.ReadKey(true);
                }
                ChoiceTestOrGame = keyInfo.KeyChar;
                if (ChoiceTestOrGame == 'l')
                {
                    lern = true;
                    Console.WriteLine("let s learn");
                    Thread.Sleep(400);
                    break;

                }
               
                else
                    if (ChoiceTestOrGame == 'p')
                {
                    lern = false;
                    Console.WriteLine("let me show you what i learned ");
                    Thread.Sleep(400);
                    break;
                }
            }


            RunMultiSessions(lern);


            Console.WriteLine(".");

        }

         void RunMultiSessions(bool argistraining)
        {
            if (argistraining) {
                Do10000();
                return;
            }
            
            _datatracker.LoadListFromFile();
            while (Choice != 'n')
            {
                Do_you_want_to_Play_AGame();
                if (Choice == 'y')
                {
                    _session = new GameSession(_humanGuy, _aiGuy, gb, SessionNumber);
                    SessionNumber++;
                    if (gb.LastWinner == 2)
                    {
                        _session.RunSession(false, true, argistraining);
                    }
                    else
                    if (gb.LastWinner == 1)
                    {
                        _session.RunSession(true, true, argistraining);
                    }
                }
                else
                    if (Choice == 'h')
                {
                    _session = new GameSession(_aiGuy_XX, _aiGuy_OO, gb, SessionNumber);
                    SessionNumber++;
                    if (gb.LastWinner == 2)
                    {
                        _session.RunSession(false, false, argistraining);
                    }
                    else
                    if (gb.LastWinner == 1)
                    {
                        _session.RunSession(true, false, argistraining);
                    }
                }
                else
                    if (Choice == 'n')
                {
                    Console.WriteLine("---------------------NO ws chosen");
                    Thread.Sleep(400);
                }
            }

            _datatracker.SaveListToFile();
            Console.WriteLine("thanks all moves shall be remembered !");
            Thread.Sleep(600);
            Console.WriteLine(".");

        }
        void Do_you_want_to_Play_AGame()
        {
            if (SessionNumber == 0)
                Console.WriteLine("Do_you_want_to_Play_AGame? Yes No Homesafe");
            else
                Console.WriteLine("Do_you_want_to_Play_Another_Game? Yes No Homesafe");
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            while (!DoVAlidations(keyInfo.KeyChar))
            {
                Console.WriteLine("chose Y N or H plz");
                keyInfo = Console.ReadKey(true);
            }
            Choice = keyInfo.KeyChar;
        }
        bool DoVAlidations(char arginout_Y_N_H)
        {
            bool is_YNH = false;
            if (arginout_Y_N_H == 'y' || arginout_Y_N_H == 'n' || arginout_Y_N_H == 'h')
                is_YNH = true;

            return is_YNH;
        }

        bool DoVAlidations_L_P(char arginout_L_P)
        {
            bool is_LP = false;
            if (arginout_L_P == 'l' || arginout_L_P == 'p' )
                is_LP = true;

            return is_LP;
        }

    }
}
