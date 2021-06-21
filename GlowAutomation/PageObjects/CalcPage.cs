using GlowAutomation.Framework;
using GlowAutomation.Framework.Elements;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Threading;

namespace GlowAutomation.PageObjects
{
    public class CalcPage : BasePage
    {
        private readonly TextBox _txbInputField = new TextBox(By.Id("TotalCartPrice"), "Total Cart Price Field");
        private readonly TextBox _txbUpfrontPaymentPercentField = new TextBox(By.Id("upfrontPaymentHiddenValue"), "Upfront Payment Percents Field");
        private readonly TextBox _txbTermValue = new TextBox(By.Id("loanDurationHiddenValue"), "Term Value Field");
        private readonly Label _lblApR = new Label(By.Id("interestRateValue"), "ApR Value");
        private readonly Label _lblUpFront = new Label(By.Id("upfrontPaymentValue"), "Upfront Payment Value");
        private readonly Label _lblTotalBorrowed = new Label(By.Id("totalBorrowedValue"), "Total Borrowed Value");
        private readonly Label _lblMonthlyPayment = new Label(By.Id("monthlyPaymentValue"), "Monthly Payment Value");
        private readonly Label _lblTotalCost = new Label(By.Id("totalCostValue"), "Total Cost Value");

        public void ProvideValues(string price, string term, string percent)
        {
            _txbUpfrontPaymentPercentField.MakeElementVisible();
            _txbTermValue.MakeElementVisible();
            _txbUpfrontPaymentPercentField.SendKeys(Keys.Enter);
            _txbInputField.Clear();
            _txbInputField.SendKeys(price);
            _txbTermValue.SendKeys(term);
            _txbTermValue.SendKeys(Keys.Enter);
            _txbUpfrontPaymentPercentField.SendKeys(percent);
            _txbInputField.SendKeys(Keys.Enter);
            Thread.Sleep(2000);
            _txbTermValue.SendKeys(term);
            _txbTermValue.SendKeys(Keys.Enter);
            Thread.Sleep(2000);
        }

        public void ValidateOutput(
            string apr,
            string upfrontPaymentValue,
            string totalBorrowed,
            string monthlyPayment,
            string totalCostOfCredit,
            int row)
        {
            DateTime DateTime = DateTime.Now;

            if (_lblApR.GetText().Equals(apr)
                 & _lblUpFront.GetAttribute("value").Equals(upfrontPaymentValue)
                 & _lblTotalBorrowed.GetText().Equals(totalBorrowed)
                 & _lblMonthlyPayment.GetText().Equals(monthlyPayment)
                 & _lblTotalCost.GetText().Equals(totalCostOfCredit)
                )

            {
                GoogleSheetManager.Write(new List<object> { "PASS: " + DateTime }, row);
            }
            else
            {
                GoogleSheetManager.Write(new List<object> { "FAIL: " + DateTime }, row);
            }
        }
    }
}