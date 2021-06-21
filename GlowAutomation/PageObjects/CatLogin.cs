using GlowAutomation.Framework;
using GlowAutomation.Framework.Elements;
using OpenQA.Selenium;

namespace GlowAutomation.PageObjects
{
    public class CatLogin : BasePage
    {
        private readonly Button _btnLogIn = new Button(By.Id("layout-buttonCustomerLogInPage"), "Log In Btn");
        private readonly TextBox _txbMobile = new TextBox(By.Name("mobileNumber"), "Mobile number");
        private readonly TextBox _txbPass = new TextBox(By.Name("password"), "Pass field");
        private readonly Button _btnSubmit = new Button(By.Id("loginForm-buttonSubmit"), "Submit");
        private readonly Button _btnQuickBuy = new Button(By.Id("productCard-buttonQuickBuy-4"), "Quick Buy");
        private readonly CheckBox _chbCheckBox = new CheckBox(By.Id("cardManage-checkboxAgreement"), "Chbx");
        private readonly Spinner _spinner = new Spinner(By.XPath("//div[@class='MuiCircularProgress-root ModalSpinner-loader-23 MuiCircularProgress-colorPrimary MuiCircularProgress-indeterminate']"), "Spinner");
        private readonly Button _btnPayWithSamsung = new Button(By.Id("cardContent-buttonContinue"), "Pay with sams");

        public void CatalogLogin(string number, string password)
        {
            _spinner.WaitUntilNotVisible();
            _btnLogIn.Click();
            _spinner.WaitUntilNotVisible();
            _txbMobile.SendKeys(number);
            _txbPass.SendKeys(password);
            _btnSubmit.Click();
        }

        public void BuyWithSamsung()
        {
            _spinner.WaitUntilNotVisible();
            _btnQuickBuy.Click();
            _spinner.WaitUntilNotVisible();
            _chbCheckBox.Check();
            _btnPayWithSamsung.Click();
            ChangeBrowserWindow("Glow");
        }
    }
}