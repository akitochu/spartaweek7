using NUnit.Framework;
using Moq;
using NorthwindBusiness;
using NorthwindData;
using NorthwindData.Services;
using System.Data;
using Castle.Core.Resource;

namespace NorthwindTests
{
    public class CustomerManagerShould
    {
        private CustomerManager _sut;

        //Dummy
        [Test]
        [Category("Happy")]
        public void BeAbleToBeConstructed()
        {
            //Arange
            var mockCustomerService = new Mock<ICustomerService>();
            //Act
            _sut = new CustomerManager(mockCustomerService.Object);
            //Assert
            Assert.That(_sut, Is.InstanceOf<CustomerManager>());
        }

        //Stubs
        [Test]
        [Category("Happy")]
        public void ReturnTrue_WhenUpdateIsCalled_WithValidId()
        {
            //Arrange
            var mockCustomerService = new Mock<ICustomerService>();
            var originalCustomer = new Customer
            {
                CustomerId = "MANDAL"
            };
            mockCustomerService.Setup(cs => cs.GetCustomerById("MANDAL")).Returns(originalCustomer);
            _sut = new CustomerManager(mockCustomerService.Object);
            //Act
            var result = _sut.Update("MANDAL", It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>());
            //Assert
            Assert.That(result);
        }

        [Test]
        [Category("Happy")]
        public void UpdateSelectedCustomer_WhenUpdateIsCalled_WithValidId()
        {
            //Arrange
            var mockCustomerService = new Mock<ICustomerService>();
            var originalCustomer = new Customer
            {
                CustomerId = "MANDAL",
                ContactName = "Nish Mandal",
                CompanyName = "Sparta Global",
                City = "Birmingham"
            };
            mockCustomerService.Setup(cs => cs.GetCustomerById("MANDAL")).Returns(originalCustomer);
            _sut = new CustomerManager(mockCustomerService.Object);
            //Act
            var result = _sut.Update("MANDAL", "Nish Kumar", "UK", "London", null);
            //Assert
            Assert.That(_sut.SelectedCustomer.ContactName, Is.EqualTo("Nish Kumar"));
            Assert.That(_sut.SelectedCustomer.CompanyName, Is.EqualTo("Sparta Global"));
            Assert.That(_sut.SelectedCustomer.Country, Is.EqualTo("UK"));
            Assert.That(_sut.SelectedCustomer.City, Is.EqualTo("London"));
        }

        [Test]
        [Category("Sad")]
        public void ReturnFalse_WhenUpdateIsCalled_WithInvalidId()
        {
            //Arrange
            var mockCustomerService = new Mock<ICustomerService>();
          
            mockCustomerService.Setup(cs => cs.GetCustomerById("MANDAL")).Returns((Customer)null);
            _sut = new CustomerManager(mockCustomerService.Object);
            //Act
            var result = _sut.Update("MANDAL", It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>());
            //Assert
            Assert.That(result, Is.False);
        }

        [Test]
        [Category("Sad")]
        public void NotChangeTheSelectedCustomer_WhenUpdateIsCalled_WithInvalidId()
        {
            //Arrange
            var mockCustomerService = new Mock<ICustomerService>();
            var originalCustomer = new Customer
            {
                CustomerId = "MANDAL",
                ContactName = "Nish Mandal",
                CompanyName = "Sparta Global",
                City = "Birmingham"
            };
            mockCustomerService.Setup(cs => cs.GetCustomerById("MANDAL")).Returns((Customer)null);
            _sut = new CustomerManager(mockCustomerService.Object);
            //Act
            _sut.SelectedCustomer = originalCustomer;
            _sut.Update("MANDAL", "Nish Kumar", "UK", "London", null);
            //Assert
            Assert.That(_sut.SelectedCustomer.ContactName, Is.EqualTo("Nish Mandal"));
            Assert.That(_sut.SelectedCustomer.CompanyName, Is.EqualTo("Sparta Global"));
            Assert.That(_sut.SelectedCustomer.Country, Is.EqualTo(null));
            Assert.That(_sut.SelectedCustomer.City, Is.EqualTo("Birmingham"));
        }

        [Test]
        [Category("Happy")]
        public void DeleteSelectedCustomer_WhenDeleteIsCalled_WithValidId()
        {
            //Arrange
            var mockCustomerService = new Mock<ICustomerService>();
            var originalCustomer = new Customer
            {
                CustomerId = "MANDAL",
                ContactName = "Nish Mandal",
                CompanyName = "Sparta Global",
                City = "Birmingham"
            };
            mockCustomerService.Setup(cs => cs.GetCustomerById("MANDAL")).Returns(originalCustomer);
            _sut = new CustomerManager(mockCustomerService.Object);
            //Act
            var result = _sut.Delete("MANDAL");
            //Assert
            Assert.That(_sut.SelectedCustomer, Is.EqualTo(null));
            Assert.That(result);
           
        }

        [Test]
        [Category("Sad")]
        public void NotDeleted_WhenDeleteIsCalled_WithInvalidId()
        {
            //Arrange
            var mockCustomerService = new Mock<ICustomerService>();
            var originalCustomer = new Customer
            {
                CustomerId = "MANDAL",
                ContactName = "Nish Mandal",
                CompanyName = "Sparta Global",
                City = "Birmingham"
            };
            mockCustomerService.Setup(cs => cs.GetCustomerById("MANDAL")).Returns(originalCustomer);
            _sut = new CustomerManager(mockCustomerService.Object);
            //Act
            _sut.SelectedCustomer = originalCustomer;
            var result = _sut.Delete("1498234");
            //Assert
            Assert.That(_sut.SelectedCustomer.ContactName, Is.EqualTo("Nish Mandal"));
            Assert.That(_sut.SelectedCustomer.CompanyName, Is.EqualTo("Sparta Global"));
            Assert.That(_sut.SelectedCustomer.City, Is.EqualTo("Birmingham"));
            Assert.That(result, Is.False);

        }

        [Test]
        [Category("Sad")]
        public void ReturnFalse_WhenUpdateIsCalled_AndADatabaseExceptionIsThrown()
        {
            var mockCustomerService = new Mock<ICustomerService>();
            mockCustomerService.Setup(cs => cs.GetCustomerById(It.IsAny<string>())).Returns(new Customer());
            mockCustomerService.Setup(cs => cs.SaveCustomerChanges()).Throws<DataException>();
            _sut = new CustomerManager(mockCustomerService.Object);
            var result = _sut.Update(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>());
            Assert.That(result, Is.False);

            
            var originalCustomer = new Customer
            {
                CustomerId = "MANDAL",
                ContactName = "Nish Mandal",
                CompanyName = "Sparta Global",
                City = "Birmingham"
            };
            mockCustomerService.Setup(cs => cs.GetCustomerById("MANDAL")).Returns((Customer)null);
            _sut = new CustomerManager(mockCustomerService.Object);
            //Act
            _sut.SelectedCustomer = originalCustomer;
            _sut.Update("MANDAL", "Nish Kumar", "UK", "London", null);
            //Assert that customer stays unchanged
            Assert.That(_sut.SelectedCustomer.ContactName, Is.EqualTo("Nish Mandal"));
            Assert.That(_sut.SelectedCustomer.CompanyName, Is.EqualTo("Sparta Global"));
            Assert.That(_sut.SelectedCustomer.Country, Is.EqualTo(null));
            Assert.That(_sut.SelectedCustomer.City, Is.EqualTo("Birmingham"));
        }

        // Spies
        [Test]
        public void CallSaveCustomerChanges_WhenUpdateIsCalled_WithValidId()
        {
            var mockCustomerService = new Mock<ICustomerService>();
            mockCustomerService.Setup(cs => cs.GetCustomerById("MANDAL")).Returns(new Customer());
            _sut = new CustomerManager(mockCustomerService.Object);
            var result = _sut.Update("MANDAL", It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>());
            mockCustomerService.Verify(cs => cs.SaveCustomerChanges(), Times.Exactly(1));
        }

        [Test]
        public void LetsSeeWhatHappens_WhenUpdateIsCalled_IfAllMethodCallsAreNotSetup()
        {
            var mockCustomerService = new Mock<ICustomerService>();
            mockCustomerService.Setup(cs => cs.GetCustomerById("MANDAL")).Returns(new Customer());
            mockCustomerService.Setup(cs => cs.SaveCustomerChanges());
            _sut = new CustomerManager(mockCustomerService.Object);
            var result = _sut.Update("MANDAL", It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>());
            Assert.That(result);
        }

        //[Test]
        //[Category("Happy")]
        //public void RetrieveCustomerList_WhenRetrieveAllIsCalled()
        //{
        //    //Arrange
        //    var mockCustomerService = new Mock<ICustomerService>();
        //    var originalCustomer = new Customer
        //    {
        //        CustomerId = "MANDAL",
        //        ContactName = "Nish Mandal",
        //        CompanyName = "Sparta Global",
        //        City = "Birmingham"
        //    };
        //    var originalCustomerList = new List<Customer>() { originalCustomer };
        //    mockCustomerService.Setup(cs => cs.GetCustomerList()).Returns( List<Customer>);

        //    //Act
        //    _sut = new CustomerManager(mockCustomerService.Object);
        //    var result = _sut.RetrieveAll();
        //    //Assert
        //    Assert.That(result, Is.EqualTo(originalCustomerList));

        //}

        [Test]
        [Category("Happy")]
        public void SetSelectedCustomer_WhenSetSelectedCustomer_IsCalledWithValidSelectedItem()
        {
            //Arrange
            var mockCustomerService = new Mock<ICustomerService>();
            var originalCustomer = new Customer
            {
                CustomerId = "MANDAL",
                ContactName = "Nish Mandal",
                CompanyName = "Sparta Global",
                City = "Birmingham"
            };

            //Act
            _sut = new CustomerManager(mockCustomerService.Object);
            _sut.SetSelectedCustomer(originalCustomer);
            //Assert
            Assert.That(_sut.SelectedCustomer, Is.EqualTo(originalCustomer));

        }

        [Test]
        [Category("Happy")]
        public void RemoveCustomerCalled_WhenDeleteIsCalled_WithValidId()
        {
            //Arrange
            var mockCustomerService = new Mock<ICustomerService>();
            var originalCustomer = new Customer
            {
                CustomerId = "MANDAL",
                ContactName = "Nish Mandal",
                CompanyName = "Sparta Global",
                City = "Birmingham"
            };

            mockCustomerService.Setup(cs => cs.GetCustomerById("MANDAL")).Returns(originalCustomer);
            _sut = new CustomerManager(mockCustomerService.Object);
            _sut.Delete("MANDAL");

            mockCustomerService.Verify(cs => cs.RemoveCustomer(It.IsAny<Customer>()), Times.Exactly(1));

        }

        [Test]
        [Category("Happy")]
        public void CreateCustomerCalled_WhenCreateIsCalled_WithValidCustomer()
        {
            //Arrange
            var mockCustomerService = new Mock<ICustomerService>();
            var originalCustomer = new Customer
            {
                CustomerId = "MANDAL",
                ContactName = "Nish Mandal",
                CompanyName = "Sparta Global",
                City = null
            };

            _sut = new CustomerManager(mockCustomerService.Object);
            _sut.Create("MANDAL", "Nish Mandal", "Sparta Global", null);

            mockCustomerService.Verify(cs => cs.CreateCustomer(It.IsAny<Customer>()), Times.Exactly(1));
        }

    }
}

