using GlowAutomation.Framework;
using GlowAutomation.Framework.Elements;
using OpenQA.Selenium;

namespace GlowAutomation.PageObjects
{
    internal class YourLoanPage : BasePage
    {
        private readonly Button _btnContinue = new Button(By.Id("cartCustomerConfigure-continue"), "Continue Button");
        private readonly TextBox _txbUpfront = new TextBox(By.Id("creditInfo-input"), "Upfront value");

        public void GoToYourDetailsPage()
        {
            _txbUpfront.AssertIsEnabled();
            _btnContinue.Click();
        }
    }
}