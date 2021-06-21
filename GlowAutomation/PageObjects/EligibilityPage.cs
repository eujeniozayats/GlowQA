using GlowAutomation.Framework;
using GlowAutomation.Framework.Elements;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace GlowAutomation.PageObjects
{
    internal class EligibilityPage : BasePage
    {
        private readonly Button _btnPay = new Button(By.Id("eligibilityRulesForm-submit"), "Eligibility Pay Button");
        private readonly Spinner _spinner = new Spinner(By.Id("spinner"), "Spinner");

        public void GoToYourLoanPage()
        {
            _spinner.WaitUntilNotVisible();
            _btnPay.AssertIsEnabled();
            _btnPay.Click();
        }
    }
}