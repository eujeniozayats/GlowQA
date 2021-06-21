using GlowAutomation.Framework;
using GlowAutomation.PageObjects;

namespace GlowAutomation.CalculatorTests
{
    public partial class TC001_CalculateLoan : BaseTest
    {
        //[TestCaseSource(nameof(GetData))]
        public void Should_BePossibleTo_CalculateRight(TestData data)
        {
            InitializeStandaloneCalculator();
            var CalcPage = new CalcPage();

            CalcPage.ProvideValues
               (
                data.Price,
                data.Term,
                data.UpfrontPaymentPercents
               );
            CalcPage.ValidateOutput
               (
                data.APR,
                data.UpfrontPaymentValue,
                data.TotalBorrowed,
                data.MonthlyPayment,
                data.CostOfCredit,
                data.RownNumber
               );
        }
    }
}