using GlowAutomation.Framework;
using GlowAutomation.Framework.Elements;
using OpenQA.Selenium;

namespace GlowAutomation.PageObjects
{
    internal class CongratulationsPage : BasePage
    {
        private readonly Button _btnClose = new Button(By.Id("proposalSuccess-close"), "Close Button");
        private readonly Spinner _spinner = new Spinner(By.Id("spinner"), "spinner");

        public void ValidateCloseButton()
        {
            _spinner.WaitUntilNotVisible();
            _btnClose.AssertIsDisplayed();
            _btnClose.AssertIsEnabled();
        }
    }
}