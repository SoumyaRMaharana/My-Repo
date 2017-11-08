using DeltaXRegistration.Page_Object;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeltaXRegistration.Test
{
    [TestFixture]
    public class AllTests : BrowserSetup
    {
        
        public IWebDriver Driver
        {
            get
            {
                return this.WebDriver;
            }
        }

        [Test(Description = "Validate if the page is loaded"), Order(1)]
        public void ValidateIsPageLoaded()
        {
            RegistrationPage Registration = new RegistrationPage(Driver);
            Assert.IsTrue(Registration.ValidatePageLoad());
            Registration.SubmitForm();
        }      

        [Test(Description = "Validate the presence of First Name textbox",Author = "Soumya Maharana"), Order(2)]
        public void ValidateFirstNameTxtBoxIsPresent()
        {
            RegistrationPage Registration = new RegistrationPage(Driver);
            Assert.IsTrue(Registration.IsFirstNameTxtBoxPresent());
        }

        [TestCase("S", Description = "Validate message by entering invalid input", Author = "Soumya Maharana"), Order(3)]
        public void ValidateFirstNameTxtBoxWithValidInput(string inputValue)
        {
            RegistrationPage Registration = new RegistrationPage(Driver);           
            Assert.AreEqual("Please enter your First Name", Registration.IsMandatoryValueEntered(0));
            Assert.AreEqual("This value is not valid", Registration.FirstNameTxtBoxFieldValidation(inputValue));
        }

        [Test(Description = "Validate the presence of Last Name textbox", Author = "Soumya Maharana"), Order(4)]
        public void ValidateLastNameTxtBoxIsPresent()
        {
            RegistrationPage Registration = new RegistrationPage(Driver);
            Assert.IsTrue(Registration.IsLastNameTxtBoxPresent());
        }

        [TestCase("M", Description = "Validate message by entering invalid input", Author = "Soumya Maharana"), Order(5)]
        public void ValidateLastNameTxtBoxWithValidInput(string inputValue)
        {
            RegistrationPage Registration = new RegistrationPage(Driver);
            Assert.AreEqual("Please enter your Last Name", Registration.IsMandatoryValueEntered(1));
            Assert.AreEqual("This value is not valid", Registration.LastNameTxtBoxFieldValidation(inputValue));
        }

        [Test(Description = "Validate the presence of Username textbox", Author = "Soumya Maharana"), Order(6)]
        public void ValidateUsernameTxtBoxIsPresent()
        {
            RegistrationPage Registration = new RegistrationPage(Driver);
            Assert.IsTrue(Registration.IsUsernameTxtBoxPresent());
        }

        [TestCase("soumyaR", Description = "Validate message by entering invalid input", Author = "Soumya Maharana"), Order(7)]
        public void ValidateUsernameTxtBoxWithValidInput(string inputValue)
        {
            RegistrationPage Registration = new RegistrationPage(Driver);
            Assert.AreEqual("Please enter your Username", Registration.IsMandatoryValueEntered(2));
            Assert.AreEqual("This value is not valid", Registration.UsernameTxtBoxFieldValidation(inputValue));
        }

        [Test(Description = "Validate the presence of Password textbox", Author = "Soumya Maharana"), Order(8)]
        public void ValidatePasswordTxtBoxIsPresent()
        {
            RegistrationPage Registration = new RegistrationPage(Driver);
            Assert.IsTrue(Registration.IsPasswordTxtBoxPresent());
        }

        [TestCase("Soumya6", Description = "Validate message by entering invalid input", Author = "Soumya Maharana"), Order(9)]
        public void ValidatePasswordTxtBoxWithValidInput(string inputValue)
        {
            RegistrationPage Registration = new RegistrationPage(Driver);
            Assert.AreEqual("Please enter your Password", Registration.IsMandatoryValueEntered(3));
            Assert.AreEqual("This value is not valid", Registration.PasswordTxtBoxFieldValidation(inputValue));
        }

        [Test(Description = "Validate the presence of Confirm Password textbox", Author = "Soumya Maharana"), Order(10)]
        public void ValidateCnfmPasswordTxtBoxIsPresent()
        {
            RegistrationPage Registration = new RegistrationPage(Driver);
            Assert.IsTrue(Registration.IsCnfmPasswordTxtBoxPresent());
        }

        [TestCase("Soumy6", Description = "Validate message by entering invalid input", Author = "Soumya Maharana"), Order(11)]
        public void ValidateCnfmPasswordTxtBoxWithValidInput(string inputValue)
        {
            RegistrationPage Registration = new RegistrationPage(Driver);
            Assert.AreEqual("Please confirm your Password", Registration.IsMandatoryValueEntered(4));
            Assert.AreEqual("This value is not valid", Registration.CnfmPasswordTxtBoxFieldValidation(inputValue));
        }

        [Test(Description = "Validate the presence of E-Mail textbox", Author = "Soumya Maharana"), Order(12)]
        public void ValidateEmailTxtBoxIsPresent()
        {
            RegistrationPage Registration = new RegistrationPage(Driver);
            Assert.IsTrue(Registration.IsEmailTxtBoxPresent());
        }

        [TestCase("soumya.", Description = "Validate message by entering invalid input", Author = "Soumya Maharana"), Order(13)]
        public void ValidateEmailTxtBoxWithValidInput(string inputValue)
        {
            RegistrationPage Registration = new RegistrationPage(Driver);
            Assert.AreEqual("Please enter your Email Address", Registration.IsMandatoryValueEntered(5));
            Assert.AreEqual("This value is not valid", Registration.EmailTxtBoxFieldValidation(inputValue));
        }

        [Test(Description = "Validate the presence of Contact No. textbox", Author = "Soumya Maharana"), Order(14)]
        public void ValidateContactNoTxtBoxIsPresent()
        {
            RegistrationPage Registration = new RegistrationPage(Driver);
            Assert.IsTrue(Registration.IsContactNoTxtBoxPresent());
        }

        [TestCase("9880035", Description = "Validate message by entering invalid input", Author = "Soumya Maharana"), Order(15)]
        public void ValidateContactNoTxtBoxWithValidInput(string inputValue)
        {
            RegistrationPage Registration = new RegistrationPage(Driver);
            Assert.AreEqual("This value is not valid", Registration.ContactNoTxtBoxFieldValidation(inputValue));
        }

        [TestCase("Soumya","Maharana","soumyaRM","Password123","Password123","soumya.maharana@gmail.com","9880035174", Description = "Form submission with valid inputs"), Order(16)]
        public void ValidateFormSubmissionWithValidInputs(string firstName, string lastName, string userName, string password, string cnfmPassword, string email, string contactNo)
        {
            RegistrationPage Registration = new RegistrationPage(Driver);
            Assert.AreEqual("Thanks", Registration.FillValidDetails(firstName, lastName, userName, password, cnfmPassword, email, contactNo));
            Registration.NavigatePage();
        }

        [Test(Description = "Form submission without entering any values", Author = "Soumya Maharana"), Order(17)]
        public void ValidateFormSubmissionWithoutEnteringAnyValueInAllTheFields()
        {
            RegistrationPage Registration = new RegistrationPage(Driver);
            Assert.AreEqual("Registration Form", Registration.SubmitFormWithoutAnyValueInAllTheFields());
        }

        [TestCase("Maharana", "soumyaRM", "Password123", "Password123", "soumya.maharana@gmail.com", "9880035174", Description = "Form submission without entering values in all the mandatory fields", Author = "Soumya Maharana"), Order(18)]
        public void ValidateFormSubmissionWithSomeValueInTheFields(string lastName, string userName, string password, string cnfmPassword, string email, string contactNo)
        {
            RegistrationPage Registration = new RegistrationPage(Driver);
            Assert.IsTrue(Registration.SubmitFormWithSomeValueInTheFields(lastName, userName, password, cnfmPassword, email, contactNo));
        }
    }
}
