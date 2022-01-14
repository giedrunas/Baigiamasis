using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaigiamasisVCSDarbas.Tests
{
    class LoginBbTest : TestBase
    {
        [Test]
        public static void Login()
        {
            string text = "MY ACCOUNT";
            string demo = "demo";

            loginBbPage.NavigateToDefaultPage()
                .ClickLogInMenuBtn()
                .InsertUsername(demo)
                .InsertPassword(demo)
                .ClickLogIn()
                .VerifyIfLoggedIn(text);
        }
    }
}
