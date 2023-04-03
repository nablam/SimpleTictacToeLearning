using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TacTicToe
{
    public interface IPlayer
    {
        void Play();
        char MySymbol();
        void IamPlayer(int argPos);
    }
}
