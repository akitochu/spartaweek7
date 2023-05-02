using System.Security.Cryptography.X509Certificates;

namespace Lambdas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var myList = new List<int>{3,7,1,2,8,3,0,4,5};

            int allCount = myList.Count();
            int evenCount = myList.Count(IsEven);
            int sum = myList.Sum();

            var peoples = new List<Person>
            {
                new Person {Name = "Aaron", Age = 40, City = "Ottawa"},
                new Person {Name = "Joe", Age = 55, City = "Manchester"},
                new Person {Name = "Nish", Age = 20, City = "London"},
            };

            var youngPeopleCount = peoples.Count(IsYoung);
            
            Console.WriteLine(allCount);
            Console.WriteLine(evenCount);
            Console.WriteLine(sum);

            //Anonymous methods are inline methods which are only used once, NOT REUSABLE!!!

            var evenDCount = myList.Count(delegate (int n) { return n % 2 == 0; });
            var evenLCount = myList.Count(x => x % 2 == 0);

            var youngPeopleCount2 = peoples.Count(x => x.Age < 30);
            var totalAge = peoples.Sum(x => x.Age);
            var oldPeopleTotalAge = peoples.Sum(x => x.Age > 30 ? x.Age : 0);
            var oldPeopleTotalAge2 = peoples.Where(x => x.Age % 2 == 0).Select(x => x.Age).Sum();
            
            //Does not hold any Person objects!!!
            //the query needs to be executed
            //this is called deferred execution
            IEnumerable<Person> peopleLondonQuery = peoples.Where(x => x.City == "London");

            //Execute query - when we iterate over it. Iterating over anything that implements IEnumerable means that the GetEnumerable method is called
            foreach (var item in peopleLondonQuery)
            {
                Console.WriteLine(item);
            }

            //Iterating through a query and adding the people based off the query to a list
            var peopleLondonList = peopleLondonQuery.ToList();
        }

        public static bool IsEven(int n) 
        {
            return n % 2 == 0;
        }

        public static bool IsYoung(Person person)
        {
            return person.Age < 30;

        }
    }

    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
        public override string ToString()
        {
            return $"{Name} - {Age} - {City}";
        }
    }
}