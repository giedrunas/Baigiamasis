using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaigiamasisVCSDarbas.Page
{
    class CouponUsageBbPage : BasePage
    {
        private const string PageAddress = "https://beautybee.lt/cart/";

        private IWebElement _returnToShopBtn => Driver.FindElement(By.CssSelector("#main > div.cart-container.container.page-wrapper.page-checkout > div > div > p.return-to-shop > a"));
        private IWebElement _goToCart => Driver.FindElement(By.CssSelector("#masthead > div.header-inner.flex-row.container.logo-left.medium-logo-center > div.flex-col.hide-for-medium.flex-right > ul > li.cart-item.has-icon > a > span.header-cart-title"));
        private IWebElement _couponField => Driver.FindElement(By.Id("coupon_code"));
        private IWebElement _applyCouponBtn => Driver.FindElement(By.CssSelector("#main > div.cart-container.container.page-wrapper.page-checkout > div > div.woocommerce.row.row-large.row-divided > div.cart-collaterals.large-5.col.pb-0 > div > form > div > input.is-form.expand"));
        private IWebElement _totalAmount => Driver.FindElement(By.CssSelector("#main > div.cart-container.container.page-wrapper.page-checkout > div > div.woocommerce.row.row-large.row-divided > div.cart-collaterals.large-5.col.pb-0 > div > div.cart_totals > table.shop_table.shop_table_responsive > tbody > tr.order-total > td > strong > span > bdi"));

        public CouponUsageBbPage(IWebDriver webdriver) : base(webdriver) { }

        public CouponUsageBbPage NavigateToDefaultPage()
        {
            if (Driver.Url != PageAddress)
            {
                Driver.Url = PageAddress;
            }

            return this;
        }
        public CouponUsageBbPage ReturnToShop()
        {
            _returnToShopBtn.Click();
            return this;
        }
        public CouponUsageBbPage GoToCart()
        {
            _goToCart.Click();
            return this;
        }

        public CouponUsageBbPage InsertCoupon(string coupon)
        {
            _couponField.Clear();
            _couponField.SendKeys(coupon);
            return this;
        }

        public CouponUsageBbPage ApplyCouponBtn()
        {
            _applyCouponBtn.Click();
            return this;
        }
        public CouponUsageBbPage CheckIfICanBuy(int myMoney)
        {
            string amountWithCoupon = _totalAmount.Text.Trim().Replace(",00 €", "");
            Assert.IsTrue(myMoney > Convert.ToInt32(amountWithCoupon), "No products for me");

            return this;
        }
        public void VerifyIfProductsAdded(string expectedResult)
        {
            Assert.AreEqual($"{expectedResult}", _totalAmount.Text, "Products might be not added");
        }
    }
}
