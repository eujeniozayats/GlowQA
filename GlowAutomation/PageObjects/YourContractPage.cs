using GlowAutomation.Framework;
using GlowAutomation.Framework.Elements;
using OpenQA.Selenium;

namespace GlowAutomation.PageObjects
{
    internal class YourContractPage : BasePage
    {
        private readonly Button _btnPreContractNext = new Button(By.Id("loanSubmitFormComponent-nextPreContactAgreement"), "PreContract Next");
        private readonly Button _btnOpenDoc = new Button(By.Id("preContractAgreementOption"), "Open Precontract");
        private readonly Button _btnLoanAgreement = new Button(By.Id("loanSubmitFormComponent-accordionLoanAgreement"), "Loan Agreement");
        private readonly Button _btnLoanAgreementOption = new Button(By.Id("loanAgreementOption"), "Agree doc");
        private readonly Button _btnClickESign = new Button(By.Id("agreementBox-openESignDialog"), "E-sign");
        private readonly Button _btnType = new Button(By.Id("esignDialog-optionTyping"), "Type");
        private readonly TextBox _txbSign = new TextBox(By.Id("signature-text-input"), "Type sign");
        private readonly Button _btnSignTheAgreement = new Button(By.Id("esignDialog-confirm"), "Sign");
        private readonly Button _btnAgreementNext = new Button(By.Id("loanSubmitFormComponent-nextLoanAgreement"), "Agr next");
        private readonly CheckBox _chbDebitFirst = new CheckBox(By.XPath("//input[@type='checkbox' and @value='false']"), "chb 1");
        private readonly CheckBox _chbDebitSecond = new CheckBox(By.Id("loanSubmitFormComponent-checkboxPrivacyNotice"), "chb 2");
        private readonly CheckBox _chbDebitThird = new CheckBox(By.Id("loanSubmitFormComponent-checkboxTermsAndConditions"), "chb 3");
        private readonly Button _btnAccept = new Button(By.Id("loanSubmitFormComponent-confirm"), "Accept");
        private readonly Button _btnCancelBottom = new Button(By.Id("loanSubmitFormComponent-preferencesRevoke"), "Cancel");
        private readonly Label _lblAgreementLink = new Label(By.XPath("//p[@class='MuiTypography-root MuiTypography-body1 MuiTypography-alignCenter']"), "Lbl Link");
        private readonly Label _lblContractLink = new Label(By.XPath("//p/div/div/div/pre"), "Lbl Link");
        private readonly Button _btnPause = new Button(By.Id("loanSubmitFormComponent-submitPauseApplication"), "Pause button");
        private readonly Button _btnCancel = new Button(By.Id("loanSubmitFormComponent - cancelPauseApplication"), "Cancel button");
        private readonly RadioButton _passRadio = new RadioButton(By.Id("loanSubmitFormComponent-radioGroupComponent-0"), "Pass radio");
        private readonly RadioButton _stopRadio = new RadioButton(By.Id("loanSubmitFormComponent-radioGroupComponent-1"), "Stop radio");
        private readonly Button _closeDialog = new Button(By.Id("agreementDialog-close"), "Close window");
        private readonly Label _lblDirectDebit = new Label(By.XPath("//span[text()='View the Direct Debit Guarantee.']"), "Direct Debit Label");
        private readonly Button _btnDirectDebitClose = new Button(By.XPath("//span[text()='CLOSE']"), "Direct Debit Close Button");
        private readonly Spinner _spinner = new Spinner(By.Id("spinner"), "spinner");

        public void PassDirectDebit()
        {
            _spinner.WaitUntilNotVisible();
            _lblDirectDebit.Click();
            _btnDirectDebitClose.Click();
            _chbDebitFirst.Check();
            _spinner.WaitUntilNotVisible();
            _chbDebitSecond.Check();
            _chbDebitThird.Check();
            _btnAccept.Click();
        }

        public void SignLoanAgreement()
        {
            _btnAgreementNext.AssertIsDisabled();
            _btnLoanAgreement.Click();
            _btnLoanAgreementOption.Click();
            _lblAgreementLink.MoveToTheElement();
            _closeDialog.Click();
            _btnClickESign.Click();
            _btnType.Click();
            _txbSign.Click();
            _btnSignTheAgreement.AssertIsDisabled();
            _txbSign.SendKeys(Config.SigninTxt);
            _btnSignTheAgreement.AssertIsEnabled();
            _btnSignTheAgreement.Click();
            _btnAgreementNext.AssertIsEnabled();
            _btnAgreementNext.Click();
            _btnCancelBottom.AssertIsEnabled();
        }

        public void OpenContractAndAgree()
        {
            _btnPreContractNext.AssertIsDisabled();
            _spinner.WaitUntilNotVisible();
            _lblContractLink.MoveToTheElement();
            _passRadio.Check();
            _btnPreContractNext.AssertIsEnabled();
        }

        public void OpenContractAndStop()
        {
            _spinner.WaitUntilNotVisible();
            _btnOpenDoc.Click();
            _lblContractLink.MoveToTheElement();
            _closeDialog.Click();
            _stopRadio.Check();
            _spinner.WaitUntilNotVisible();
        }

        public void ClickPauseApplication()
        {
            _btnPause.AssertIsDisplayed();
            _btnPause.Click();
        }

        public void ClickCancelApplication()
        {
            _btnCancel.AssertIsDisplayed();
            _btnCancel.Click();
        }
    }
}