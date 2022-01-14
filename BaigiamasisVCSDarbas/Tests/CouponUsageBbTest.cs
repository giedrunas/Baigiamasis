using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaigiamasisVCSDarbas.Tests
{
    class CouponUsageBbTest : TestBase
    {

        [TestCase("vcs10", 750, TestName = "Can I Buy If I Have 750 With 10 percent discount")]
        [TestCase("vcs20", 750, TestName = "Can I Buy If I Have 750 With 20 percent discount")]

        public static void CouponUsage(string coupon, int myMoney)
        {

            couponUsageBbPage.NavigateToDefaultPage()
                .ReturnToShop();

            addToCartBbPage.ClickOnProduct()
                .AddOneMoreProduct()
                .AddToCart();

            couponUsageBbPage.GoToCart()
                .InsertCoupon(coupon)
                .ApplyCouponBtn()
                .CheckIfICanBuy(myMoney);
        }
    }
}
