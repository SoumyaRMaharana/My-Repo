using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DeltaXRegistration.Page_Object
{
    class RegistrationPage
    {
        private IWebDriver WebDriver = null;

        //Initialize the page in the constructor
        public RegistrationPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            WebDriver = driver;
        }

        [FindsBy(How = How.Name, Using = "first_name")]
        public IWebElement FirsNameTxtBox { get; private set; }

        [FindsBy(How = How.Name, Using = "last_name")]
        public IWebElement LastNameTxtBox { get; private set; }

        [FindsBy(How = How.Name, Using = "department")]
        public IWebElement DeptDD { get; private set; }

        [FindsBy(How = How.Name, Using = "user_name")]
        public IWebElement UserNameTxtBox { get; private set; }

        [FindsBy(How = How.Name, Using = "user_password")]
        public IWebElement PasswordTxtBox { get; private set; }

        [FindsBy(How = How.Name, Using = "confirm_password")]
        public IWebElement ConfirmPwdTxtBox { get; private set; }

        [FindsBy(How = How.Name, Using = "email")]
        public IWebElement EmailTxtBox { get; private set; }

        [FindsBy(How = How.Name, Using = "contact_no")]
        public IWebElement ContactTxtBox { get; private set; }

        [FindsBy(How = How.XPath, Using = "//button[@class='btn btn-warning']")]
        public IWebElement SubmitBtn { get; private set; }

        //Enter a text in First Name textbox
        public void EnterValueInFirstNameTxtBox(string value)
        {
            FirsNameTxtBox.Clear();
            FirsNameTxtBox.SendKeys(value);
        }

        //Enter a text in Last Name textbox
        public void EnterValueInLastNameTxtBox(string value)
        {
            LastNameTxtBox.Clear();
            LastNameTxtBox.SendKeys(value);
        }

        //Select a value from the dropdown
        public void SelectDDValue(string value)
        {
            SelectElement SelectValue = new SelectElement(DeptDD);
            SelectValue.SelectByValue(value);
        }

        //Enter a text in Username textbox
        public void EnterValueInUsernameTxtBox(string value)
        {
            UserNameTxtBox.Clear();
            UserNameTxtBox.SendKeys(value);
        }

        //Enter a text in Password textbox
        public void EnterValueInPasswordTxtBox(string value)
        {
            PasswordTxtBox.Clear();
            PasswordTxtBox.SendKeys(value);
        }

        //Enter a text in Confirm Password textbox
        public void EnterValueInConfirmPasswordTxtBox(string value)
        {
            ConfirmPwdTxtBox.Clear();
            ConfirmPwdTxtBox.SendKeys(value);
        }

        //Enter a text in Email textbox
        public void EnterValueInEmailTxtBox(string value)
        {
            EmailTxtBox.Clear();
            EmailTxtBox.SendKeys(value);
        }

        //Enter a text in Contact# textbox
        public void EnterValueInContactNumTxtBox(string value)
        {
            ContactTxtBox.Clear();
            ContactTxtBox.SendKeys(value);
        }

        //Click the Submit button to submit the registration form
        public void SubmitForm()
        {
            SubmitBtn.Click();
        }

        //Navigating back to the home page
        public void NavigatePage()
        {
            WebDriver.Navigate().Back();
        }

        //This method verifies if the page has loaded or not
        public bool ValidatePageLoad()
        {
            if(!(WebDriver.FindElement(By.XPath("//form//h2")).Text == "Registration Form"))
            {
                return false;
            }

            return true;
        }

        //This method will get the error message when the form is submitted without entering
        //the mandatory values.
        public string IsMandatoryValueEntered(int fieldOrder)
        {
            Thread.Sleep(5000);
            string message = null;
            try
            {
                switch (fieldOrder)
                {
                    case 0:
                        message = WebDriver.FindElements(By.XPath("//div[@class='col-md-4 inputGroupContainer']"))[fieldOrder].FindElements(By.XPath("small[@class='help-block']"))[1].Text;
                        break;
                    case 1:
                        message = WebDriver.FindElements(By.XPath("//div[@class='col-md-4 inputGroupContainer']"))[fieldOrder].FindElements(By.XPath("small[@class='help-block']"))[1].Text;
                        break;
                    case 2:
                        message = WebDriver.FindElements(By.XPath("//div[@class='col-md-4 inputGroupContainer']"))[fieldOrder].FindElements(By.XPath("small[@class='help-block']"))[1].Text;
                        break;
                    case 3:
                        message = WebDriver.FindElements(By.XPath("//div[@class='col-md-4 inputGroupContainer']"))[fieldOrder].FindElements(By.XPath("small[@class='help-block']"))[1].Text;
                        break;
                    case 4:
                        message = WebDriver.FindElements(By.XPath("//div[@class='col-md-4 inputGroupContainer']"))[fieldOrder].FindElements(By.XPath("small[@class='help-block']"))[1].Text;
                        break;
                    case 5:
                        message = WebDriver.FindElements(By.XPath("//div[@class='col-md-4 inputGroupContainer']"))[fieldOrder].FindElements(By.XPath("small[@data-bv-validator='notEmpty']"))[0].Text;
                        break;
                    default:
                        break;
                }
                return message;
            }
            catch (Exception)
            {
                return message;
            }       
         }

        //This method will take screenshots after performing an operation
        public void TakeScreenshot(string fileName)
        {
            Screenshot screenshot = ((ITakesScreenshot)WebDriver).GetScreenshot();
            screenshot.SaveAsFile("E:\\Soumya_Selenium_Projects\\DeltaXRegistration\\Screenshot\\"+fileName+ ".jpeg", ScreenshotImageFormat.Jpeg);
        }

        //This method checks the presence of First name textbox
        public bool IsFirstNameTxtBoxPresent()
        {
            WebDriverWait wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(5));
            try
            {
                //This statement is checking is the textbox is displayed or not and 
                //The inner test is "First Name" or not.
                if (!(FirsNameTxtBox.Displayed && FirsNameTxtBox.GetAttribute("placeholder") == "First Name"))
                    return false;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            return true;
        }

        //This method will return the error message when an invalid input is enter in the
        //First Name textbox
        public string FirstNameTxtBoxFieldValidation(string value)
        {
            EnterValueInFirstNameTxtBox(value);
            WebDriverWait wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(5));
            string message = WebDriver.FindElements(By.XPath("//div[@class='col-md-4 inputGroupContainer']"))[0].FindElements(By.XPath("small[@class='help-block']"))[0].Text;
            return message;
        }

        //This method checks the presence of Last name textbox
        public bool IsLastNameTxtBoxPresent()
        {
            WebDriverWait wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(5));
            try
            {
                //This statement is checking is the textbox is displayed or not and 
                //The inner test is "Last Name" or not.
                if (!(LastNameTxtBox.Displayed && LastNameTxtBox.GetAttribute("placeholder") == "Last Name"))
                    return false;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            return true;
        }

        //This method will return the error message when an invalid input is enter in the
        //Last Name textbox
        public string LastNameTxtBoxFieldValidation(string value)
        {
            EnterValueInLastNameTxtBox(value);
            WebDriverWait wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(5));
            string message = WebDriver.FindElements(By.XPath("//div[@class='col-md-4 inputGroupContainer']"))[1].FindElements(By.XPath("small[@class='help-block']"))[0].Text;
            return message;
        }

        //This method checks the presence of Username textbox
        public bool IsUsernameTxtBoxPresent()
        {
            WebDriverWait wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(5));
            try
            {
                //This statement is checking is the textbox is displayed or not and 
                //The inner test is "Username" or not.
                if (!(UserNameTxtBox.Displayed && UserNameTxtBox.GetAttribute("placeholder") == "Username"))
                    return false;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            return true;
        }

        //This method will return the error message when an invalid input is entered in the
        //Username textbox
        public string UsernameTxtBoxFieldValidation(string value)
        {
            EnterValueInUsernameTxtBox(value);
            WebDriverWait wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(5));
            string message = WebDriver.FindElements(By.XPath("//div[@class='col-md-4 inputGroupContainer']"))[2].FindElements(By.XPath("small[@class='help-block']"))[0].Text;
            return message;
        }

        //This method checks the presence of Password textbox
        public bool IsPasswordTxtBoxPresent()
        {
            WebDriverWait wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(5));
            try
            {
                //This statement is checking is the textbox is displayed or not and 
                //The inner test is "Password" or not.
                if (!(PasswordTxtBox.Displayed && PasswordTxtBox.GetAttribute("placeholder") == "Password"))
                    return false;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            return true;
        }

        //This method will return the error message when an invalid input is entered in the
        //Password textbox
        public string PasswordTxtBoxFieldValidation(string value)
        {
            EnterValueInPasswordTxtBox(value);
            WebDriverWait wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(5));
            string message = WebDriver.FindElements(By.XPath("//div[@class='col-md-4 inputGroupContainer']"))[3].FindElements(By.XPath("small[@class='help-block']"))[0].Text;
            return message;
        }

        //This method checks the presence of Confirm password textbox
        public bool IsCnfmPasswordTxtBoxPresent()
        {
            WebDriverWait wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(5));
            try
            {
                //This statement is checking is the textbox is displayed or not and 
                //The inner test is "Confirm Password" or not.
                if (!(ConfirmPwdTxtBox.Displayed && ConfirmPwdTxtBox.GetAttribute("placeholder") == "Confirm Password"))
                    return false;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            return true;
        }

        //This method will return the error message when an invalid input is entered in the
        //Confirm Password textbox
        public string CnfmPasswordTxtBoxFieldValidation(string value)
        {
            EnterValueInConfirmPasswordTxtBox(value);
            WebDriverWait wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(5));
            string message = WebDriver.FindElements(By.XPath("//div[@class='col-md-4 inputGroupContainer']"))[4].FindElements(By.XPath("small[@class='help-block']"))[0].Text;
            return message;
        }

        //This method checks the presence of Email textbox
        public bool IsEmailTxtBoxPresent()
        {
            WebDriverWait wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(5));
            try
            {
                //This statement is checking is the textbox is displayed or not and 
                //The inner test is "E-Mail Address" or not.
                if (!(EmailTxtBox.Displayed && EmailTxtBox.GetAttribute("placeholder") == "E-Mail Address"))
                    return false;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            return true;
        }

        //This method will return the error message when an invalid input is entered in the
        //E-Mail textbox
        public string EmailTxtBoxFieldValidation(string value)
        {
            EnterValueInEmailTxtBox(value);
            Thread.Sleep(3000);
            string message = WebDriver.FindElements(By.XPath("//div[@class='col-md-4 inputGroupContainer']"))[5].FindElements(By.XPath("small[@class='help-block']"))[1].Text;
            return message;
        }

        //This method checks the presence of Contact No. textbox
        public bool IsContactNoTxtBoxPresent()
        {
            WebDriverWait wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(5));
            try
            {
                //This statement is checking is the textbox is displayed or not and 
                //The inner test is "E-Mail Address" or not.
                if (!(ContactTxtBox.Displayed && ContactTxtBox.GetAttribute("placeholder") == "(+91)"))
                    return false;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            return true;
        }

        //This method will return the error message when an invalid input is entered in the
        //E-Mail textbox
        public string ContactNoTxtBoxFieldValidation(string value)
        {
            EnterValueInContactNumTxtBox(value);
            WebDriverWait wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(5));
            string message = WebDriver.FindElements(By.XPath("//div[@class='col-md-4 inputGroupContainer']"))[6].FindElements(By.XPath("small[@class='help-block']"))[0].Text;
            return message;
        }

        //This method will submit the form without entering any values in the fields
        //and return a confirmation message.
        public string SubmitFormWithoutAnyValueInAllTheFields()
        {
            FirsNameTxtBox.Clear();
            LastNameTxtBox.Clear();
            UserNameTxtBox.Clear();
            PasswordTxtBox.Clear();
            ConfirmPwdTxtBox.Clear();
            EmailTxtBox.Clear();
            ContactTxtBox.Clear();
            SubmitForm();
            TakeScreenshot("NoValuesEntered");
            return WebDriver.FindElement(By.XPath("//form//h2")).Text;
        }

        //This method will submit the form without entering all the mandatory field values
        public bool SubmitFormWithSomeValueInTheFields(string lname, string uname, string pwd, string cnfmpwd, string email, string contact)
        {
            EnterValueInLastNameTxtBox(lname);
            EnterValueInUsernameTxtBox(uname);
            EnterValueInPasswordTxtBox(pwd);
            EnterValueInConfirmPasswordTxtBox(cnfmpwd);
            EnterValueInEmailTxtBox(email);
            EnterValueInContactNumTxtBox(contact);
            SubmitForm();
            TakeScreenshot("SomeValuesEntered");
            if (!(SubmitBtn.GetAttribute("disabled") == "true"))
            {
                return false;
            }
            return true;
        }

        //This method will submit the form by entering values in all the fields
        public string FillValidDetails(string fname, string lname, string uname, string pwd, string cnfmpwd, string email, string contact)
        {
            EnterValueInFirstNameTxtBox(fname);
            EnterValueInLastNameTxtBox(lname);
            EnterValueInUsernameTxtBox(uname);
            EnterValueInPasswordTxtBox(pwd);
            EnterValueInConfirmPasswordTxtBox(cnfmpwd);
            EnterValueInEmailTxtBox(email);
            EnterValueInContactNumTxtBox(contact);
            SubmitForm();
            WebDriverWait wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//form//h2")));
            TakeScreenshot("AllValuesEntered");
            return WebDriver.FindElement(By.XPath("//form//h2")).Text;
        }
    }
}
