using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumPracticeKonturCourse
{
    internal class MainForm
    {
        protected ChromeDriver Driver;

        public MainForm(ChromeDriver driver)
        {
            this.Driver = driver;
        }

        private readonly By _maleRadioLocator = By.Id("boy");
        private readonly By _femaleRadioLocator = By.Id("girl");
        private readonly By _emailInputLocator = By.Name("email");
        private readonly By _formErrorLocator = By.ClassName("form-error");
        private readonly By _submitButtonLocator = By.Id("sendMe");
        private readonly By _resultTextLocator = By.ClassName("result-text");
        private readonly By _yourEmailLocator = By.ClassName("your-email");
        private readonly By _anotherEmailLinkLocator = By.Id("anotherEmail");
        
        public void TypeEmail(String email)
        {
            var emailInput = Driver.FindElement(_emailInputLocator);
            emailInput.Click();
            emailInput.SendKeys(email);
        }

        public void ChooseMale()
        {
            var maleRadioButton = Driver.FindElement(_maleRadioLocator);
            maleRadioButton.Click();
        }

        public void ChooseFemale()
        {
            var maleRadioButton = Driver.FindElement(_femaleRadioLocator);
            maleRadioButton.Click();
        }

        public void ClickSubmitButton()
        {
            var submitButton = Driver.FindElement(_submitButtonLocator);
            submitButton.Click();
        }

        public string GetYourEmail()
        {
            return Driver.FindElement(_yourEmailLocator).Text;
        }

        public string GetResultText()
        {
            return Driver.FindElement(_resultTextLocator).Text;
        }

        public string GetErrorText()
        {
            return Driver.FindElement(_formErrorLocator).Text;
        }
    }
}
