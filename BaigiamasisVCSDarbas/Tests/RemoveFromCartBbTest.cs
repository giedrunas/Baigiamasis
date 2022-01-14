using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaigiamasisVCSDarbas.Tests
{
    class RemoveFromCartBbTest : TestBase
    {
        [Test]

        public static void RemoveFromCart()
        {
            string cart = "Your cart is currently empty.";
            string text = "Headphones";

            removeFromCartBbPage.NavigateToDefaultPage()
                .ClickOnSearchField()
                .InsertTextOnHover(text)
                .AddToCart();

            couponUsageBbPage.GoToCart();

            removeFromCartBbPage.QuantityMinus()
                .UpdateCart()
                .VerifyIfCartIsEmpty(cart);
        }
    }
}
