using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using OpenQA.Selenium.Support.UI;

namespace SeleniumPracticeKonturCourse
{
    public class SeleniumPracticeTest
    {
        private ChromeDriver driver;
        private WebDriverWait wait;

        [SetUp]
        public void SetUp()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            driver = new ChromeDriver(options);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [Test]
        public void Send_Male_Parrot_Name_Success()
        {
            var seleniumPracticePage = new SeleniumPracticePage(driver);
            seleniumPracticePage.Open();

            var mainForm = seleniumPracticePage.GetMainForm();

            mainForm.ChooseMale();

            const string expectedEmail = "test@mail.ru";
            mainForm.TypeEmail(expectedEmail);

            mainForm.ClickSubmitButton();

            var resultEmailText = mainForm.GetYourEmail();

            Assert.AreEqual(expectedEmail, resultEmailText, "Сделали заявку не на тот email");

            const string expectedResultText = "Хорошо, мы пришлём имя для вашего мальчика на e-mail:";

            var resultResultText = mainForm.GetResultText();

            Assert.AreEqual(expectedResultText, resultResultText, "Не совпадает текст результата отправки заявки");
        }

        [Test]
        public void Send_Female_Parrot_Name_Success()
        {
            var seleniumPracticePage = new SeleniumPracticePage(driver);
            seleniumPracticePage.Open();

            var mainForm = seleniumPracticePage.GetMainForm();

            mainForm.ChooseFemale();

            const string expectedEmail = "test@mail.ru";
            mainForm.TypeEmail(expectedEmail);

            mainForm.ClickSubmitButton();

            var resultEmailText = mainForm.GetYourEmail();

            Assert.AreEqual(expectedEmail, resultEmailText, "Сделали заявку не на тот email");

            const string expectedResultText = "Хорошо, мы пришлём имя для вашей девочки на e-mail:";

            var resultResultText = mainForm.GetResultText();

            Assert.AreEqual(expectedResultText, resultResultText, "Не совпадает текст результата отправки заявки");
        }

        [Test]
        public void Empty_Email_Field_Success()
        {
            var seleniumPracticePage = new SeleniumPracticePage(driver);
            seleniumPracticePage.Open();

            var mainForm = seleniumPracticePage.GetMainForm();

            mainForm.ClickSubmitButton();

            const string expectedErrorText = "Введите email";
            var resultErrorText = mainForm.GetErrorText();

            Assert.AreEqual(expectedErrorText, resultErrorText, "Не совпадает текст валидации пустого поля Email");
        }

        [Test]
        public void Choose_Another_Email_Success()
        {
            var seleniumPracticePage = new SeleniumPracticePage(driver);
            seleniumPracticePage.Open();

            var mainForm = seleniumPracticePage.GetMainForm();

            mainForm.SendRequestFirstTime();

            mainForm.ClickAnotherEmail();

            Assert.AreEqual(string.Empty, driver.FindElement(mainForm.EmailInputLocator).Text, "Поле emailInput не очистилось после клика по ссылке Указать другой Email");
            Assert.IsFalse(driver.FindElement(mainForm.AnotherEmailLinkLocator).Displayed, "Не исчезла ссылка");
        }

        [TearDown]
        public void TeadDown()
        {
            driver.Quit();
        }
    }
}
