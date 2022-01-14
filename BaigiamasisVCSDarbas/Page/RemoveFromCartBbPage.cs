using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaigiamasisVCSDarbas.Page
{
    class RemoveFromCartBbPage : BasePage
    {
        private const string PageAddress = "https://beautybee.lt/";
        private IWebElement _searchField => Driver.FindElement(By.ClassName("icon-search"));
        private IWebElement _inputText => Driver.FindElement(By.Id("woocommerce-product-search-field-0"));
        private IWebElement _addToCart => Driver.FindElement(By.CssSelector("#product-96 > div > div.product-main > div > div.product-info.summary.col-fit.col.entry-summary.product-summary.text-center > form > div > div.woocommerce-variation-add-to-cart.variations_button.woocommerce-variation-add-to-cart-enabled > button"));
        private IWebElement _quantityBtn => Driver.FindElement(By.CssSelector("#main > div.cart-container.container.page-wrapper.page-checkout > div > div.woocommerce.row.row-large.row-divided > div.col.large-7.pb-0 > form > div > table > tbody > tr.woocommerce-cart-form__cart-item.cart_item > td.product-quantity > div > input.minus.button.is-form"));
        private IWebElement _updateCart => Driver.FindElement(By.CssSelector("#main > div.cart-container.container.page-wrapper.page-checkout > div > div.woocommerce.row.row-large.row-divided > div.col.large-7.pb-0 > form > div > table > tbody > tr:nth-child(2) > td > button"));
        private IWebElement _checkIfEmpty => Driver.FindElement(By.CssSelector("#main > div.cart-container.container.page-wrapper.page-checkout > div > div.woocommerce-notices-wrapper > p"));

        public RemoveFromCartBbPage(IWebDriver webdriver) : base(webdriver) { }

        public RemoveFromCartBbPage NavigateToDefaultPage()
        {
            if (Driver.Url != PageAddress)
            {
                Driver.Url = PageAddress;
            }

            return this;
        }

        public RemoveFromCartBbPage ClickOnSearchField()
        {
            _searchField.Click();
            return this;
        }
        public RemoveFromCartBbPage InsertTextOnHover(string text)
        {
            _inputText.SendKeys(text);
            _inputText.SendKeys(Keys.Enter);
            return this;
        }
        public RemoveFromCartBbPage AddToCart()
        {
            _addToCart.Click();
            return this;
        }
        public RemoveFromCartBbPage QuantityMinus()
        {
            _quantityBtn.Click();
            return this;
        }
        public RemoveFromCartBbPage UpdateCart()
        {
            _updateCart.Click();
            return this;
        }
        public void VerifyIfCartIsEmpty(string expectedResult)
        {
            Assert.AreEqual($"{expectedResult}", _checkIfEmpty.Text, "Products still on the bag");
        }
    }
}