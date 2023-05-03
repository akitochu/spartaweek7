using System;
using System.Threading;
using System.Threading.Tasks;

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
            Task<Cake> cakeTask = BakeCakeAsync();
            PlayPartyGames();
            Console.WriteLine("Adults play beer pong whilst children open presents");
            PlayBeerPong();
            OpenPresents();
            //Result is a property which is saying - wait for the task to be complete and return the actual resu
            var cake = cakeTask.Result;
            Console.WriteLine($"Happy birthday, {name}, {cake}!!");
        }

        //We want to get on with other stuff
        //As we wait for the cake to finish baking
        //Async methods - name of the method with Async at the end
        private async static Task<Cake> BakeCakeAsync()
        {
            Console.WriteLine("Cake is in the oven");
            //Thread.Sleep(TimeSpan.FromSeconds(5));
            //await - go back to the calling method (in this case HavePartyAsync) and return after 5 seconds
            await Task.Delay(TimeSpan.FromSeconds(5));
            Console.WriteLine("Cake is done");
            return new Cake();
        }

        private static void PlayPartyGames()
        {
            Console.WriteLine("Starting games");
            Thread.Sleep(TimeSpan.FromSeconds(2));
            Console.WriteLine("Finishing Games");
        }

        private static void PlayBeerPong()
        {
            Console.WriteLine("Plunk");
            Thread.Sleep(TimeSpan.FromSeconds(1));
            Console.WriteLine("Drink!");
            Thread.Sleep(TimeSpan.FromSeconds(2));
            Console.WriteLine("Miss!");
            Thread.Sleep(TimeSpan.FromSeconds(1));
            Console.WriteLine("Plunk!");
            Thread.Sleep(TimeSpan.FromSeconds(1));
            Console.WriteLine("Drink!");
            Thread.Sleep(TimeSpan.FromSeconds(2));
            Console.WriteLine("Everyones Tipsy");
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
