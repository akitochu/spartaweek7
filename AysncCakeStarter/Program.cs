using System;
using System.Threading;

namespace AysncCake
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to my birthday party");
            HaveAParty();
            Console.WriteLine("Thanks for a lovely party");
            Console.ReadLine();
        }

        private static void HaveAParty()
        {
            var name = "Cathy";
            var cake = BakeCake();
            PlayPartyGames();
            OpenPresents();
            Console.WriteLine($"Happy birthday, {name}, {cake}!!");
        }

        private static Cake BakeCake()
        {
            Console.WriteLine("Cake is in the oven");
            Thread.Sleep(TimeSpan.FromSeconds(5));
            Console.WriteLine("Cake is done");
            return new Cake();
        }

        private static void PlayPartyGames()
        {
            Console.WriteLine("Starting games");
            Thread.Sleep(TimeSpan.FromSeconds(2));
            Console.WriteLine("Finishing Games");
        }

        private static void OpenPresents()
        {
            Console.WriteLine("Opening Presents");
            Thread.Sleep(TimeSpan.FromSeconds(1));
            Console.WriteLine("Finished Opening Presents");
        }
    }

    public class Cake
    {
        public override string ToString()
        {
            return "Here's a cake";
        }
    }
}
