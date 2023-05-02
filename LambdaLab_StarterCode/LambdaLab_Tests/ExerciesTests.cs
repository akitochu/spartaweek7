namespace LambdaLab_Tests
{
    public class Tests
    {
        private List<Spartan> spartans = new List<Spartan>();

        [OneTimeSetUp]
        public void Setup()
        {
            spartans.Add(new Spartan { SpartanId = "FRENCH", FirstName = "Cathy", LastName = "French", City = "Ottawa", Country = "Canada", DateOfBirth = new DateOnly(1999, 12, 31), SpartaMark = 99 });
            spartans.Add(new Spartan { SpartanId = "MANDAL", FirstName = "Nish", LastName = "Mandal", City = "Birmingham", Country = "U.K.", DateOfBirth = new DateOnly(1979, 11, 2), SpartaMark = 83 });
            spartans.Add(new Spartan { SpartanId = "BELLAB", FirstName = "Peter", LastName = "Bellaby", City = "Kyoto", Country = "Japan", DateOfBirth = new DateOnly(1985, 3, 9), SpartaMark = 79 });
            spartans.Add(new Spartan { SpartanId = "BOOT", FirstName = "Lee", LastName = "Boot", City = "Birmingham", Country = "U.K.", DateOfBirth = new DateOnly(1993, 6, 14), SpartaMark = 45 });
            spartans.Add(new Spartan { SpartanId = "HARVEY", FirstName = "David", LastName = "Harvey", City = "Seattle", Country = "U.S.A.", DateOfBirth = new DateOnly(1983, 3, 27), SpartaMark = 50 });
            spartans.Add(new Spartan { SpartanId = "DONNEL", FirstName = "Gary", LastName = "Donnelly", City = "Manchester", Country = "U.K.", DateOfBirth = new DateOnly(1969, 9, 22), SpartaMark = 49 });
            spartans.Add(new Spartan { SpartanId = "GADHVI", FirstName = "Manish", LastName = "Gadhvi", City = "Berlin", Country = "Germany", DateOfBirth = new DateOnly(1987, 3, 16), SpartaMark = 73 });
        }

        [Test]
        public void GivenAListOfSpartans_CountTotalNumberOfSpartans_ReturnsTotalNumber()
        {
            Assert.That(Exercsises.CountTotalNumberOfSpartans(spartans), Is.EqualTo(7));
        }


        [Test]
        public void GivenAListOfSpartans_CountTotalNumberOfSpartansInUKAndUSA_ReturnsTotalNumberFromUKandUSA()
        {
            Assert.That(Exercsises.CountTotalNumberOfSpartansInUKAndUSA(spartans), Is.EqualTo(4));
        }

        [Test]
        public void GivenAListOfSpartans_NumberOfSpartansBornAfter1980_ReturnsListOfSpartansBornAfter1980()
        {
            Assert.That(Exercsises.NumberOfSpartansBornAfter1980(spartans), Is.EqualTo(5));
        }


        [Test]
        public void GivenAListOfSpartans_AverageSpartanMark_ReturnsAverageSpartanMarkOfAllSpartans()
        {
            Assert.That(Exercsises.AverageSpartanMark(spartans), Is.EqualTo(68.29));
        }


        [Test]
        public void GivenAListOfSpartans_SumOfAllSpartaMarksMoreThan50Inclusive_ReturnsCorrectValue()
        {
            Assert.That(Exercsises.SumOfAllSpartaMarksMoreThan50Inclusive(spartans), Is.EqualTo(384));
        }


        [Test]
        public void GivenAListOfSpartans_SortByAlphabeticallyByLastName_ReturnsCorrectlyOrderedList()
        {
            Assert.That(Exercsises.SortByAlphabeticallyByLastName(spartans), Is.Ordered.By("LastName"));
        }


        [Test]
        public void GivenAListOfSpartans_ListAllDistinctCities_ReturnsListOfDistinctCities()
        {
            var actual = Exercsises.ListAllDistinctCities(spartans);
            var expected = new List<string>
            {
                "Ottawa",
                "Birmingham",
                "Kyoto",
                "Seattle",
                "Manchester",
                "Berlin"
            };
            Assert.That(actual, Is.EqualTo(expected));            
        }


        // Write more tests
        [Test]
        public void GivenAListOfSpartans_ListAllSpartansWithIdBeginingWithB_ReturnsLisSpartansWithIdBeginningWithB()
        {
            var actual = Exercsises.ListAllSpartansWithIdBeginingWithB(spartans);
            Assert.That(actual.Count, Is.EqualTo(2));
            Assert.That(actual.Contains(spartans.Where(x => x.SpartanId == "BELLAB").FirstOrDefault()));
            Assert.That(actual.Contains(spartans.Where(x => x.SpartanId == "BOOT").FirstOrDefault()));
        }
    }
}