using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BaigiamasisVCSDarbas.Page
{
    class AddToCartBbPage : BasePage
    {
        private const string PageAddress = "https://beautybee.lt/shop";
        private IWebElement _clickOnProduct => Driver.FindElement(By.CssSelector("#main > div > div.col.large-9 > div > div.products.row.row-small.large-columns-3.medium-columns-3.small-columns-2.has-equal-box-heights > div.product-small.col.has-hover.product.type-product.post-96.status-publish.first.instock.product_cat-headphones.has-post-thumbnail.shipping-taxable.purchasable.product-type-variable.has-default-attributes > div > div.product-small.box > div.box-image > div.image-fade_in_back > a > img"));
        private SelectElement _dropDownSize => new SelectElement(Driver.FindElement(By.Id("size")));
        private SelectElement _dropDownColor => new SelectElement(Driver.FindElement(By.Id("color")));
        private IWebElement _addOneMoreBtn => Driver.FindElement(By.CssSelector("#product-96 > div > div.product-main > div > div.product-info.summary.col-fit.col.entry-summary.product-summary.text-center > form > div > div.woocommerce-variation-add-to-cart.variations_button.woocommerce-variation-add-to-cart-enabled > div > input.plus.button.is-form"));
        private IWebElement _addToCart => Driver.FindElement(By.CssSelector("#product-96 > div > div.product-main > div > div.product-info.summary.col-fit.col.entry-summary.product-summary.text-center > form > div > div.woocommerce-variation-add-to-cart.variations_button.woocommerce-variation-add-to-cart-enabled > button"));
        private IWebElement _priceAmountCheck => Driver.FindElement(By.CssSelector("#masthead > div.header-inner.flex-row.container.logo-left.medium-logo-center > div.flex-col.hide-for-medium.flex-right > ul > li.cart-item.has-icon.has-dropdown > a > span.header-cart-title > span > span"));

        public AddToCartBbPage(IWebDriver webdriver) : base(webdriver) { }

        public AddToCartBbPage NavigateToDefaultPage()
        {
            if (Driver.Url != PageAddress)
            {
                Driver.Url = PageAddress;
            }

            return this;
        }
        public AddToCartBbPage ClickOnProduct()
        {
            _clickOnProduct.Click();
            Thread.Sleep(1000);
            return this;
        }
        public AddToCartBbPage SizeDropDownSelectByText(string text)
        {
            _dropDownSize.SelectByText(text);

            return this;
        }
        public AddToCartBbPage ColorDropDownSelectByText(string text)
        {
            _dropDownColor.SelectByText(text);

            return this;
        }

        public AddToCartBbPage AddOneMoreProduct()
        {
            GetWait(1).Until(x => _addOneMoreBtn.Displayed);
            _addOneMoreBtn.Click();
            _addOneMoreBtn.Click();

            return this;
        }

        public AddToCartBbPage AddToCart()
        {
            _addToCart.Click();

            return this;
        }

        public void VerifyIfProductsAdded(string expectedResult)
        {
            Assert.AreEqual($"{expectedResult}", _priceAmountCheck.Text, "Products might be not added");
        }
    }
}
