using GlowAutomation.Framework;
using GlowAutomation.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace GlowAutomation.TestCases
{

    [TestClass]
    public class TC001_HappyPathTest : BaseTest
    {

        public override void RunTest()
        {
            string currentClass = this.GetType().Name;

           

                Initialize(Config.UatUrl, Config.AutomationLogin, Config.AutomationPass);

                Logger.Step(1);
                var eligibilityPage = new EligibilityPage();
                eligibilityPage.GoToYourLoanPage();



                /*Logger.Step(2);
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
                yourContractPage.OpenContractAndAgree();
                yourContractPage.SignLoanAgreement();
                yourContractPage.PassDirectDebit();

                Logger.Step(5);
                var congratulationsPage = new CongratulationsPage();
                congratulationsPage.ValidateCloseButton();*/
            }
            
        }
    }




