using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SeleniumPracticeKonturCourse
{
    internal class SeleniumPracticePage
    {
        protected ChromeDriver Driver;

        public SeleniumPracticePage(ChromeDriver driver)
        {
            this.Driver = driver;
        }

        public void Open()
        {
            Driver.Navigate().GoToUrl("https://qa-course.kontur.host/selenium-practice/");
        }

        public MainForm GetMainForm()
        {
            return new MainForm(this.Driver);
        }
    }
}
