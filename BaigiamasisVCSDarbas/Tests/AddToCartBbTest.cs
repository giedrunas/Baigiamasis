using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaigiamasisVCSDarbas.Tests
{
    class AddToCartBbTest : TestBase
    {
        [Test]
        public static void AddToCartBb()
        {
            string size = "Small";
            string color = "Blue";
            string amount = "900,00 €";

            addToCartBbPage.NavigateToDefaultPage()
                .ClickOnProduct()
                .SizeDropDownSelectByText(size)
                .ColorDropDownSelectByText(color)
                .AddOneMoreProduct()
                .AddToCart()
                .VerifyIfProductsAdded(amount);
        }
    }
}
