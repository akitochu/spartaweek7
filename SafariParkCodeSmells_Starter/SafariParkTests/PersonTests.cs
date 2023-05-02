using NUnit.Framework;
using ClassesApp;

namespace ClassesTests
{
   
    public class PersonTests
    {
        [TestCase("Cathy", "French", "Cathy French") ]
        [TestCase("", "", " ")]
        public void GetFullNameTest(string fName, string lName, string expected)
        {
            // create a new BaseClass object, which represents a person
            var subject = new Person(fName, lName);
            var result = subject.GetFullName();
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void AgeTest()
        {
            var address = new Address(4, "High Street", "Stafford");
            var subject = new Person("A", "B", address);
            subject.Age = 35;
            Assert.AreEqual(35, subject.Age);
        }

        [Test]
        public void ToStringTest()
        {
            var address = new Address(4, "High Street", "Stafford");
            var subject = new Person("Cathy", "French", address);
            subject.Age = 22;
            var result = subject.ToString();
            Assert.AreEqual("ClassesApp.Person Name: Cathy French Age: 22. Address: 4 High Street, Stafford", result);
        }
    }
}
