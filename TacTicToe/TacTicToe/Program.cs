using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TacTicToe
{
    class Program
    {
        static void Main(string[] args)
        {
            TictacApp tg = new TictacApp();

            tg.RunTestOrGame();
            Console.WriteLine("Done");
        }
    }
}
