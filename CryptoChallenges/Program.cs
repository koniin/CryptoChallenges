using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CryptoChallenges {
    class Program {
        static void Main(string[] args) {
            Writer.WriteHelp();

            var cm = new ChallengeManager();

            while (true)
            {
                while (Console.KeyAvailable == false)
                    Thread.Sleep(250); 
                ConsoleKeyInfo cki = Console.ReadKey(true);
                if (cki.Key == ConsoleKey.Escape || cki.Key == ConsoleKey.Q)
                    return;

                cm.RunChallenge(cki.KeyChar);

                Writer.WriteHelp();
            }
        }
    }
}
