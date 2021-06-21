﻿using GlowAutomation.Framework;
using GlowAutomation.PageObjects;
using NUnit.Framework;

namespace GlowAutomation.TestCases
{
    internal class TC005_CancelApplicationTest : BaseTest
    {
        [Test]
        public void Should_BePossibleTo_CancelApplication()
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
            yourDetailsPage.SetDoBAndValidate(Config.DoB);
            yourDetailsPage.SetMoveIn(Config.MoveIn);
            yourDetailsPage.ProvideBankDetails(Config.NameOnTheAccount, Config.SortCode, Config.BankAccountNumber, Config.PCM);
            yourDetailsPage.ProvideEmploymentDetails(Config.Occupation, Config.EmployerName, Config.StartDate, Config.AnnualIncome);
            yourDetailsPage.GoToYourContractPage();

            Logger.Step(4);
            var yourContractPage = new YourContractPage();
            yourContractPage.OpenContractAndStop();
        }
    }
}