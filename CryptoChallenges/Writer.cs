using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoChallenges
{
    public static class Writer
    {
        public static void WriteHelp() {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("| Press a number to run that challenge |");
            Console.WriteLine("| Press q or Escape to exit            |");
            Console.WriteLine("----------------------------------------");
        }

        public static void WriteResult(string expected, string actual)
        {
            Console.WriteLine("Should be: {0}", expected);
            Console.WriteLine("Is:        {0}", actual);
            IsEqual(actual, expected);
        }

        public static void IsEqual(string first, string second)
        {
            Console.WriteLine("Are equal: {0}", first.Equals(second, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}
