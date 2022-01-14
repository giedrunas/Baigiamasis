using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaigiamasisVCSDarbas.Tests
{
    class AddToWishlistBbTest : TestBase
    {

        [Test]
        public static void AddToWishlist()
        {
            string text = "MY ACCOUNT";
            string demo = "demo";
            string product = "Camo Headphones";
            loginBbPage.NavigateToDefaultPage()
                .ClickLogInMenuBtn()
                .InsertUsername(demo)
                .InsertPassword(demo)
                .ClickLogIn()
                .VerifyIfLoggedIn(text);

            addToWishlistBbPage.FindHoverButton()
                .GoToMyAccount()
                .GoToWishlist()
                .CheckIfProductOnWishlist(product);
        }
    }
}
