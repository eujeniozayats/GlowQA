﻿using GlowAutomation.Framework;
using GlowAutomation.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GlowAutomation.TestCases
{
    [TestClass]
    public class TC002_DeclinedByAccertifyTest : BaseTest
    {
        
        public override void RunTest()
        {
            Initialize(Config.DevUrl, Config.AccertifyDeclineLogin, Config.AccertifyDeclinePass);

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
            yourDetailsPage.CancelIfDeclinedByAccertify();
        }
    }
}