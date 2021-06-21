using GlowAutomation.Framework;
using GlowAutomation.Framework.Elements;
using OpenQA.Selenium;

namespace GlowAutomation.PageObjects
{
    internal class YourDetailsPage : BasePage
    {
        private readonly TextBox _txbDoB = new TextBox(By.Id("dateOfBirth"), "Date of Birth text field");
        private readonly Button _btnAboutYouNext = new Button(By.Id("customerDetails-nextAddress"), "About You Next");
        private readonly TextBox _txbAddress = new TextBox(By.Id("addresses[0].tenure"), "Address field");
        private readonly Button _btnAddressNext = new Button(By.Id("customerDetails-nextBankDetails"), "Address Next");
        private readonly TextBox _txbBankAccountName = new TextBox(By.Id("financialsForm-inputAccountName"), "Bank Name");
        private readonly TextBox _txbBankSortCode = new TextBox(By.Id("financialsForm-inputSordCode"), "Bank Sort");
        private readonly TextBox _txbBankAccountNumber = new TextBox(By.Id("financialsForm-inputAccountNumber"), "Bank Account Number");
        private readonly Button _txbRentMortgageCost = new Button(By.Id("financialsForm-inputRentMortgageCost"), "Mortgage");
        private readonly Button _btnNumberOfDependants = new Button(By.Id("mui-component-select-numberOfDependants"), "Number");
        private readonly Button _btnNumberChoice = new Button(By.Id("0-item"), "Choice");
        private readonly Button _btnFinancialsNext = new Button(By.Id("customerDetails-nextEmployment"), "Fin Next");
        private readonly Button _btnEmploymentType = new Button(By.Id("mui-component-select-occupationType"), "Employment Type");
        private readonly Button _btnEmploymentTypeChoice = new Button(By.Id("Full-time-item"), "Choice");
        private readonly TextBox _txbOccupationField = new TextBox(By.Id("employmentForm-inputOccupation"), "Occupation");
        private readonly TextBox _txbEmployerName = new TextBox(By.Id("employmentForm-inputEmployerName"), "Employer");
        private readonly TextBox _txbYearWithEmployee = new TextBox(By.Id("yearWithEmployee"), "Year with");
        private readonly TextBox _txbSalary = new TextBox(By.Id("employmentForm-inputSalary"), "Salary");
        private readonly Button _btnEmploymentNext = new Button(By.Id("customerDetails-nextConfirmData"), "Next");
        private readonly Button _btnYourDetailsContinue = new Button(By.Id("customerDetails-continue"), "Continue");
        private readonly Button _btnCancelDeclinedByAccertify = new Button(By.Id("applicationDeclinedDialog-submit"), "Cancel");
        private readonly Button _btnCancelDeclinedByAnchor = new Button(By.XPath("//span[@class='MuiButton-label' and text()='USE ALTERNATIVE PAYMENT METHOD']"), "Cancel");
        private readonly Spinner _spinner = new Spinner(By.Id("spinner"), "Spinner");
        private readonly RadioButton _identityYes = new RadioButton(By.XPath("//input[@id='identityForm-radio-0-option']"), "Identity Yes");
        private readonly TextBox _txbAlternative = new TextBox(By.Id("identityForm-inputAlternative"), "Alternative");

        private readonly Label _lblDoBRequired = new Label(By.Id("dateOfBirth-Required"), "DoB Required");
        private readonly Label _lblDoBGreaterThan = new Label(By.Id("dateOfBirth-Date_should_be_greater_than_1900-01-01"), "DoB Greater");
        private readonly Label _lblYearsOld = new Label(By.Id("dateOfBirth-You_must_be_at_least_18_Years_old"), "Years old");
        private readonly Label _lblAlternativeRequired = new Label(By.Id("documentationSpecificRequirements-Required"), "Alternative Required");

        private readonly Label _lblMoveInRequired = new Label(By.Id("addresses[0].tenure-Required"), "Move In required");
        private readonly Label _lblMoveInInvalid = new Label(By.Id("addresses[0].tenure-Invalid_date"), "Move In invalid");
        private readonly Label _lblMoveInSeventy = new Label(By.Id("addresses[0].tenure-Date_should_not_be_older_than_70_years"), "Move In older than");
        private readonly Label _lblMoveInBefore = new Label(By.Id("addresses[0].tenure-Date_should_be_before_today_date"), "Move In before");

        private readonly Label _lblNameAccountRequired = new Label(By.Id("bankAccountName-Required"), "Name Account Required");
        private readonly Label _lblSortCodeRequired = new Label(By.Id("bankSortCode-Required"), "Sort Code Required");
        private readonly Label _lblSortCodeVerify = new Label(By.Id("bankSortCode-Bank_details_can_not_be_verified"), "Sort Code Verification");
        private readonly Label _lblAccountNumberRequired = new Label(By.Id("bankAccountNumber-Required"), "Account Number Required");
        private readonly Label _lblPcmRequired = new Label(By.Id("rentMortgageCost-Required"), "Pcm Required");
        private readonly Label _lblDependantsRequired = new Label(By.Id("numberOfDependants"), "Dependants Required");

        private readonly Label _lblEmploymentTypeRequired = new Label(By.Id("occupationType"), "Employment Type Required");
        private readonly Label _lblOccupationRequired = new Label(By.Id("occupation-Required"), "Occupation Required");
        private readonly Label _lblStartDateRequired = new Label(By.Id("yearWithEmployee-Required"), "Start date Required");
        private readonly Label _lblAfterBirth = new Label(By.Id("yearWithEmployee-Date_should_be_after_date_of_birth"), "After Birth Required");
        private readonly Label _lblBeforeBirth = new Label(By.Id("yearWithEmployee-Date_should_be_before_today_date"), "Before Birth Required");
        private readonly Label _lblStartDateInvalid = new Label(By.Id("yearWithEmployee-The_date_is_invalid"), "Date Invalid");
        private readonly Label _lblEmployerRequired = new Label(By.Id("employerName-Required"), "Employer Required");
        private readonly Label _lblIncomeRequired = new Label(By.Id("salary-Required"), "Salary Required");

        public void CheckEmploymentErrors()
        {
            _spinner.WaitUntilNotVisible();
            _btnEmploymentType.Click();
            _btnEmploymentTypeChoice.Click();
            _txbOccupationField.Click();
            _txbEmployerName.Click();
            _txbYearWithEmployee.Click();
            _txbSalary.Click();
            _lblOccupationRequired.AssertIsDisplayed();
            _lblStartDateRequired.AssertIsDisplayed();
            _lblEmployerRequired.AssertIsDisplayed();
            _txbYearWithEmployee.Click();
            _lblIncomeRequired.AssertIsDisplayed();
            _txbYearWithEmployee.SendKeys("1");
            _lblStartDateInvalid.AssertIsDisplayed();
            _txbYearWithEmployee.SendKeys("11111");
            _lblAfterBirth.AssertIsDisplayed();
            for (int i = 0; i < 4; i++)
            {
                _txbYearWithEmployee.SendKeys(Keys.Backspace);
            }
            _txbYearWithEmployee.SendKeys("2222");
            _lblBeforeBirth.AssertIsDisplayed();
            for (int i = 0; i < 4; i++)
            {
                _txbYearWithEmployee.SendKeys(Keys.Backspace);
            }
            _txbYearWithEmployee.SendKeys("2015");
            _btnEmploymentType.Click();
            _btnEmploymentTypeChoice.Click();
            _txbOccupationField.Click();
            _txbOccupationField.SendKeys(Config.Test);
            _txbEmployerName.Click();
            _txbEmployerName.SendKeys(Config.Test);
            _txbSalary.Click();
            _txbSalary.SendKeys(Config.AnnualIncome);
        }

        public void CheckFinancialsErrors()
        {
            _txbRentMortgageCost.Click();
            _btnNumberOfDependants.Click();
            _btnNumberChoice.Click();
            _lblPcmRequired.AssertIsDisplayed();
            _txbRentMortgageCost.SendKeys("1111");
            _txbBankAccountName.Click();
            _txbBankSortCode.Click();
            _lblNameAccountRequired.AssertIsDisplayed();
            _txbBankAccountNumber.Click();
            _lblSortCodeRequired.AssertIsDisplayed();
            _txbBankSortCode.Click();
            _lblAccountNumberRequired.AssertIsDisplayed();
            _txbBankAccountName.SendKeys(Config.Test);
            _txbBankAccountNumber.SendKeys(Config.BankAccountNumber);
            _txbBankSortCode.SendKeys("1");
            _lblSortCodeVerify.AssertIsDisplayed();
            _txbBankSortCode.SendKeys(Keys.Backspace);
            _txbBankSortCode.SendKeys(Config.SortCode);
            _btnFinancialsNext.Click();
        }

        public void CheckDobFieldErrors()
        {
            _txbDoB.Click();
            _txbDoB.SendKeys(Config.DoBTooOld);
            _lblDoBGreaterThan.AssertIsDisplayed();
            for (int i = 0; i < 8; i++)
            {
                _txbDoB.SendKeys(Keys.Backspace);
            }
            _txbDoB.SendKeys(Config.DoBTooYoung);
            _lblYearsOld.AssertIsDisplayed();
            for (int i = 0; i < 8; i++)
            {
                _txbDoB.SendKeys(Keys.Backspace);
            }
            _identityYes.Check();
            _identityYes.Check();
            _lblDoBRequired.AssertIsDisplayed();
            _txbAlternative.SendKeys(Config.Test);
            for (int i = 0; i < 4; i++)
            {
                _txbAlternative.SendKeys(Keys.Backspace);
            }
            _txbDoB.Click();
            _lblAlternativeRequired.AssertIsDisplayed();
            _txbAlternative.SendKeys(Config.Test);
            _txbDoB.SendKeys(Config.DoB);
            _btnAboutYouNext.Click();
        }

        public void CheckAddressHistoryErrors()
        {
            _txbAddress.Click();
            _txbAddress.SendKeys("11/11");
            _lblMoveInInvalid.AssertIsDisplayed();
            for (int i = 0; i < 4; i++)
            {
                _txbAddress.SendKeys(Keys.Backspace);
            }
            _txbAddress.SendKeys("11/1111");
            _lblMoveInSeventy.AssertIsDisplayed();
            for (int i = 0; i < 8; i++)
            {
                _txbAddress.SendKeys(Keys.Backspace);
            }
            _lblMoveInRequired.AssertIsDisplayed();
            _txbAddress.SendKeys("11/2222");
            _lblMoveInBefore.AssertIsDisplayed();
            for (int i = 0; i < 8; i++)
            {
                _txbAddress.SendKeys(Keys.Backspace);
            }
            _txbAddress.SendKeys("11/2010");
            _btnAddressNext.Click();
        }

        public void CancelIfDeclinedByAnchor()
        {
            _btnCancelDeclinedByAnchor.AssertIsDisplayed();
        }

        public void CancelIfDeclinedByAccertify()
        {
            _btnCancelDeclinedByAccertify.AssertIsDisplayed();
        }

        public void SetDoBAndValidate(string value)
        {
            _txbDoB.Click();
            _btnAboutYouNext.AssertIsDisabled();
            _txbDoB.SendKeys(value);
            _btnAboutYouNext.AssertIsEnabled();
            _btnAboutYouNext.Click();
        }

        public void GoToYourContractPage()
        {
            _btnYourDetailsContinue.Click();
        }

        public void SetMoveIn(string value)
        {
            _spinner.WaitUntilNotVisible();
            _txbAddress.Click();
            _btnAddressNext.AssertIsDisabled();
            _txbAddress.SendKeys(value);
            _btnAddressNext.AssertIsEnabled();
            _btnAddressNext.Click();
        }

        public void ProvideBankDetails(string name, string sort, string bankNum, string rent)
        {
            _spinner.WaitUntilNotVisible();
            _txbBankAccountName.Click();
            _txbBankAccountName.SendKeys(name);
            _txbBankSortCode.Click();
            _txbBankSortCode.SendKeys(sort);
            _txbBankAccountNumber.Click();
            _txbBankAccountNumber.SendKeys(bankNum);
            _txbRentMortgageCost.Click();
            _txbRentMortgageCost.SendKeys(rent);
            _btnFinancialsNext.AssertIsDisabled();
            _btnNumberOfDependants.Click();
            _btnNumberChoice.Click();
            _btnFinancialsNext.Click();
        }

        public void ProvideEmploymentDetails(string occupationValue, string employername, string date, string tax)
        {
            _spinner.WaitUntilNotVisible();
            _btnEmploymentType.Click();
            _btnEmploymentTypeChoice.Click();
            _txbOccupationField.Click();
            _txbOccupationField.SendKeys(occupationValue);
            _txbEmployerName.Click();
            _txbEmployerName.SendKeys(employername);
            _txbYearWithEmployee.Click();
            _txbYearWithEmployee.SendKeys(date);
            _txbSalary.Click();
            _btnEmploymentNext.AssertIsDisabled();
            _txbSalary.SendKeys(tax);
            _btnEmploymentNext.AssertIsEnabled();
        }
    }
}