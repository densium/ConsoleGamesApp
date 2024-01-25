using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGamesApp.Main
{
    internal interface IScorableGame
    {
        public int Score { get; set; }
        public string Name { get; set; }
        public string Result { get; set; }
    }
}
