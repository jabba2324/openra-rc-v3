using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using OpenRA.ResourceCenter.Web.Dtos;
using OpenRA.ResourceCenter.Web.Pages;
using OpenRA.ResourceCenter.Web.Providers;

namespace OpenRA.ResourceCenter.Tests
{
    public class Tests
    {
        private Mock<ISmtpClient> _mockSmtpClient;
        private Mock<ILogger<MapsModel>> _logger;
        
        [SetUp]
        public void Setup()
        {
            _mockSmtpClient = new Mock<ISmtpClient>();
            _logger = new Mock<ILogger<MapsModel>>();
        }

        [Test]
        public async Task ValidEmailSubmissionShouldReturnPage()
        {
            //Arrange
            var page = new ContactModel(_logger.Object, _mockSmtpClient.Object);
            page.Email = new Email
            {
                EmailAddress = "stalin@sovietunion.ru",
                Subject = "Elba Island",
                Message = "We have detected Allied activity on Elba Island. The Allies plan to use this island to stage an attack on the Soviet Empire. You must ensure that the island ceases to be under Allied control. Destroy all Allied units on and around the island. The local population has been aiding the Allies as well. There is only one punishment for helping the enemy - Death."
            };
            //Act
            PageResult action = (PageResult) await page.OnPostAsync();
            
            //Assert
            Assert.AreEqual("Message sent comrade!",page.FormMessage);
            Assert.AreEqual(true,page.FormSuccess);

        }
        
        [Test]
        public async Task InvalidEmailShouldReturnErrorMessage()
        {
            //Arrange
            var page = new ContactModel(_logger.Object, _mockSmtpClient.Object);
            page.Email = new Email
            {
                EmailAddress = "stalin",
                Subject = "Elba Island",
                Message = "We have detected Allied activity on Elba Island. The Allies plan to use this island to stage an attack on the Soviet Empire. You must ensure that the island ceases to be under Allied control. Destroy all Allied units on and around the island. The local population has been aiding the Allies as well. There is only one punishment for helping the enemy - Death."
            };
            
            //Act
            PageResult action = (PageResult) await page.OnPostAsync();
            
            //Assert
            Assert.AreEqual("'Email Address' is not a valid email address.",page.FormMessage);
            Assert.AreEqual(false,page.FormSuccess);
        }
        
        [Test]
        public async Task NullEmailShouldReturnErrorMessage()
        {
            //Arrange
            var page = new ContactModel(_logger.Object, _mockSmtpClient.Object);
            page.Email = new Email
            {
                EmailAddress = null,
                Subject = "Elba Island",
                Message = "We have detected Allied activity on Elba Island. The Allies plan to use this island to stage an attack on the Soviet Empire. You must ensure that the island ceases to be under Allied control. Destroy all Allied units on and around the island. The local population has been aiding the Allies as well. There is only one punishment for helping the enemy - Death."
            };
            
            //Act
            PageResult action = (PageResult) await page.OnPostAsync();
            
            //Assert
            Assert.AreEqual("'Email Address' must not be empty.",page.FormMessage);
            Assert.AreEqual(false,page.FormSuccess);
        }
        
        [Test]
        public async Task NullSubjectShouldReturnErrorMessage()
        {
            //Arrange
            var page = new ContactModel(_logger.Object, _mockSmtpClient.Object);
            page.Email = new Email
            {
                EmailAddress = "stalin@sovietunion.ru",
                Subject = null,
                Message = "We have detected Allied activity on Elba Island. The Allies plan to use this island to stage an attack on the Soviet Empire. You must ensure that the island ceases to be under Allied control. Destroy all Allied units on and around the island. The local population has been aiding the Allies as well. There is only one punishment for helping the enemy - Death."
            };
            
            //Act
            PageResult action = (PageResult) await page.OnPostAsync();
            
            //Assert
            Assert.AreEqual("'Subject' must not be empty.",page.FormMessage);
            Assert.AreEqual(false,page.FormSuccess);
        }
        
        [Test]
        public async Task NullMessageShouldReturnErrorMessage()
        {
            //Arrange
            var page = new ContactModel(_logger.Object, _mockSmtpClient.Object);
            page.Email = new Email
            {
                EmailAddress = "stalin@sovietunion.ru",
                Subject = "Elba Island",
                Message = null
            };
            
            //Act
            PageResult action = (PageResult) await page.OnPostAsync();
            
            //Assert
            Assert.AreEqual("'Message' must not be empty.",page.FormMessage);
            Assert.AreEqual(false,page.FormSuccess);
        }
        
        [Test]
        public async Task LargeMessageShouldReturnErrorMessage()
        {
            //Arrange
            var page = new ContactModel(_logger.Object, _mockSmtpClient.Object);
            page.Email = new Email
            {
                EmailAddress = "stalin@sovietunion.ru",
                Subject = "Elba Island",
                Message = new string('☭', 5000)
            };
            
            //Act
            PageResult action = (PageResult) await page.OnPostAsync();
            
            //Assert
            Assert.AreEqual("The length of 'Message' must be 2000 characters or fewer. You entered 5000 characters.",page.FormMessage);
            Assert.AreEqual(false,page.FormSuccess);
        }
        
        [Test]
        public async Task LargeSubjectShouldReturnErrorMessage()
        {
            //Arrange
            var page = new ContactModel(_logger.Object, _mockSmtpClient.Object);
            page.Email = new Email
            {
                EmailAddress = "stalin@sovietunion.ru",
                Subject = new string('☭', 500),
                Message = "We have detected Allied activity on Elba Island. The Allies plan to use this island to stage an attack on the Soviet Empire. You must ensure that the island ceases to be under Allied control. Destroy all Allied units on and around the island. The local population has been aiding the Allies as well. There is only one punishment for helping the enemy - Death."
            };
            
            //Act
            PageResult action = (PageResult) await page.OnPostAsync();
            
            //Assert
            Assert.AreEqual("The length of 'Subject' must be 200 characters or fewer. You entered 500 characters.",page.FormMessage);
            Assert.AreEqual(false,page.FormSuccess);
        }
    }
}