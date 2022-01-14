using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaigiamasisVCSDarbas.Page
{
    class AddToWishlistBbPage : BasePage
    {
        private const string PageAddress = "https://beautybee.lt/";

        private IWebElement _findHoverButton => Driver.FindElement(By.CssSelector("#content > div.row.large-columns-3.medium-columns-.small-columns-2.row-collapse.row-full-width > div > div > div.product-small.box.has-hover.box-normal.box-text-bottom > div.box-image > div.image-tools.top.right.show-on-hover > div > div > div > div"));
        private IWebElement _myAccountBtn => Driver.FindElement(By.CssSelector("#masthead > div.header-inner.flex-row.container.logo-left.medium-logo-center > div.flex-col.hide-for-medium.flex-right > ul > li.account-item.has-icon.has-dropdown > a > span"));
        private IWebElement _wishlistBtn => Driver.FindElement(By.CssSelector("#my-account-nav > li.wishlist-account-element > a"));
        private IWebElement _checkIfProductOnWishlist => Driver.FindElement(By.CssSelector("#yith-wcwl-row-96 > td.product-name > a"));
        public AddToWishlistBbPage(IWebDriver webdriver) : base(webdriver) { }

        public AddToWishlistBbPage NavigateToDefaultPage()
        {
            if (Driver.Url != PageAddress)
            {
                Driver.Url = PageAddress;
            }

            return this;
        }

        public AddToWishlistBbPage FindHoverButton()
        {
            Actions action = new Actions(Driver);

            action.MoveToElement(_findHoverButton).Perform(); // Perform() = to make a move to the element
            _findHoverButton.Click();
            return this;
        }
        public AddToWishlistBbPage GoToMyAccount()
        {
            GetWait(5).Until(x => _myAccountBtn.Displayed);
            _myAccountBtn.Click();
            return this;
        }
        public AddToWishlistBbPage GoToWishlist()
        {
            _wishlistBtn.Click();
            return this;
        }

        public void CheckIfProductOnWishlist(string expectedResult)
        {
            Assert.AreEqual($"{expectedResult}", _checkIfProductOnWishlist.Text, "Products might be not added");
        }
    }
}
