using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaigiamasisVCSDarbas.Page
{
    class LoginBbPage : BasePage
    {
        private const string PageAddress = "https://www.beautybee.lt/";
        private IWebElement _loginMenuBtn => Driver.FindElement(By.CssSelector("#masthead > div.header-inner.flex-row.container.logo-left.medium-logo-center > div.flex-col.hide-for-medium.flex-right > ul > li.account-item.has-icon > a > span"));
        private IWebElement _inputUsername => Driver.FindElement(By.Id("username"));
        private IWebElement _inputPassword => Driver.FindElement(By.Id("password"));
        private IWebElement _loginBtn => Driver.FindElement(By.Name("login"));
        private IWebElement _myAccountBtn => Driver.FindElement(By.ClassName("header-account-title"));

        public LoginBbPage(IWebDriver webdriver) : base(webdriver) { }

        public LoginBbPage NavigateToDefaultPage()
        {
            if (Driver.Url != PageAddress)
            {
                Driver.Url = PageAddress;
            }

            return this;
        }

        public LoginBbPage ClickLogInMenuBtn()
        {
            _loginMenuBtn.Click();

            return this;
        }
        public LoginBbPage InsertUsername(string username)
        {
            _inputUsername.Clear();
            _inputUsername.SendKeys(username);

            return this;
        }

        public LoginBbPage InsertPassword(string password)
        {
            _inputPassword.Clear();
            _inputPassword.SendKeys(password);

            return this;
        }

        public LoginBbPage ClickLogIn()
        {
            _loginBtn.Click();

            return this;
        }

        public void VerifyIfLoggedIn(string expectedResult)
        {
            Assert.AreEqual($"{expectedResult}", _myAccountBtn.Text, "You're not logged in");
        }

    }
}
