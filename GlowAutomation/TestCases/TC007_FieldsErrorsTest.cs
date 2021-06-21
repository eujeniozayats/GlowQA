using GlowAutomation.Framework;
using GlowAutomation.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace GlowAutomation.TestCases
{
    internal class TC007_FieldsErrorsTest : BaseTest
    {
        [TestMethod]
        public void Should_BePossibleTo_ValidateFieldsErrors()
        {
            Initialize(Config.DevUrl, Config.AutomationLogin, Config.AutomationPass);

            Logger.Step(1);
            var eligibilityPage = new EligibilityPage();
            eligibilityPage.GoToYourLoanPage();

            Logger.Step(2);
            var yourLoanPage = new YourLoanPage();
            yourLoanPage.GoToYourDetailsPage();

            Logger.Step(3);
            var yourDetailsPage = new YourDetailsPage();
            yourDetailsPage.CheckDobFieldErrors();
            yourDetailsPage.CheckAddressHistoryErrors();
            yourDetailsPage.CheckFinancialsErrors();
            yourDetailsPage.CheckEmploymentErrors();
        }
    }
}