using BaigiamasisVCSDarbas.Drivers;
using BaigiamasisVCSDarbas.Page;
using BaigiamasisVCSDarbas.Tools;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaigiamasisVCSDarbas.Tests
{
    class TestBase
    {
        protected static IWebDriver Driver;

        public static LoginBbPage loginBbPage;
        public static AddToCartBbPage addToCartBbPage;
        public static AddToWishlistBbPage addToWishlistBbPage;
        public static CouponUsageBbPage couponUsageBbPage;
        public static RemoveFromCartBbPage removeFromCartBbPage;

        [SetUp]
        public static void Setup()
        {
            Driver = CustomDriver.GetChromeDriver();

            loginBbPage = new LoginBbPage(Driver);
            addToCartBbPage = new AddToCartBbPage(Driver);
            addToWishlistBbPage = new AddToWishlistBbPage(Driver);
            couponUsageBbPage = new CouponUsageBbPage(Driver);
            removeFromCartBbPage = new RemoveFromCartBbPage(Driver);
        }

        [TearDown]
        public static void OneTimeTearDown()
        {
            Driver.Quit();
        }

        [TearDown]
        public static void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                MyScreenshot.TakeScreenshot(Driver);
            }
        }
    }
}
