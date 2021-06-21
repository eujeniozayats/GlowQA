using GlowAutomation.Framework;
using GlowAutomation.Framework.Elements;
using OpenQA.Selenium;

namespace GlowAutomation.PageObjects

{
    public class PlatLogin : BasePage
    {
        private readonly TextBox _txbEmail = new TextBox(By.Name("email"), "Email field");
        private readonly TextBox _txbPass = new TextBox(By.Name("password"), "Pass field");
        private readonly Button _btnSbmt = new Button(By.Id("loginForm-buttonSubmit"), "Btn Submit");
        private readonly Spinner _spinner = new Spinner(By.XPath("//div[@class='MuiCircularProgress-root ModalSpinner-loader-23 MuiCircularProgress-colorPrimary MuiCircularProgress-indeterminate']"), "Spinner");

        public void PLogin(string email, string password)
        {
            _spinner.WaitUntilNotVisible();
            _txbEmail.SendKeys(email);
            _txbPass.SendKeys(password);
            _btnSbmt.AssertIsEnabled();
            _btnSbmt.Click();
        }
    }
}