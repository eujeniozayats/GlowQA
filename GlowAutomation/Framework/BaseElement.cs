
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace GlowAutomation.Framework
{
    public abstract class BaseElement : BaseEntity
    {
        protected IWebElement Element;
        protected By Locator;
        protected string Name;
        protected TestContext tc;

        protected BaseElement(By loc, string name)
        {
            Locator = loc;
            Name = name;
        }

        protected abstract string GetElementType();

        protected override string FormatLogMsg(string message)
        {
            return string.Format("{0} {1} {2} {3}", GetElementType(), Name, Logger.LogDelimiterString, message);
        }

        public void Check()
        {
            IsPresent(Locator);
            Info("Checkbox setting");
            Element.Click();
            IsReadyStateComplete();
        }

        public void Click()
        {
            IsClickable(Locator);
            AssertIsDisplayed();
            AssertIsEnabled();
            Info("Clicking");
            Element.Click();
            IsReadyStateComplete();
        }

        public void AssertIsDisplayed()
        {
            IsReadyStateComplete();
            IsPresent(Locator);

            try
            {
                Assert.IsTrue(Element.Displayed, "Error! Element with id: " + Element.GetAttribute("id").Trim() + " should be displayed!");
                Info("Assert Displayed");
            }
            catch
            {
                //AttachScreenshotOnFailure();
            }
        }

        public void AssertIsEnabled()
        {
            IsReadyStateComplete();
            IsClickable(Locator);
            IsPresent(Locator);

            try
            {
                Assert.IsTrue(Element.Enabled, "Error! Element with id: " + Element.GetAttribute("id").Trim() + " should be enabled!");
                Info("Assert Enabled");
            }
            catch
            {
                //AttachScreenshotOnFailure();
            }
        }

        public void AssertIsDisabled()
        {
            IsReadyStateComplete();
            IsPresent(Locator);

            try
            {
                Assert.IsFalse(Element.Enabled, "Error! Element with id: " + Element.GetAttribute("id").Trim() + " should be disabled!");
                Info("Assert Disabled");
            }
            catch
            {
                //AttachScreenshotOnFailure();
            }
        }

        /*public void AttachScreenshotOnFailure()
        {

            if (tc.CurrentTestOutcome == UnitTestOutcome.Passed)
                TestContext.AddResultFile(testPassedFile);
            else
                TestContext.AddResultFile(testFailedFile);

            var filePath = $"{tc.AddResultFile() .TestDirectory}\\{TestContext.CurrentContext.Test.MethodName}.jpg";
            ((ITakesScreenshot)Driver).GetScreenshot().SaveAsFile(filePath);
            TestContext.AddTestAttachment(filePath);
            Assert.Fail();
        }*/

        public void SendKeys(string key)
        {
            IsPresent(Locator);
            Info("Value sending");
            GetDriver().FindElement(Locator).SendKeys(key);
        }

        public void Clear()
        {
            IsClickable(Locator);
            GetDriver().FindElement(Locator).Clear();
        }

        public bool IsClickable(By locator)
        {
            GetWaiter().Until(SeleniumExtras.WaitHelpers.ExpectedConditions.PresenceOfAllElementsLocatedBy(locator));
            GetWaiter().Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
            GetWaiter().Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(locator));
            IsReadyStateComplete();
            Element = GetDriver().FindElement(locator);

            return Element.Displayed;
        }

        public bool IsPresent(By locator)
        {
            GetWaiter().Until(SeleniumExtras.WaitHelpers.ExpectedConditions.PresenceOfAllElementsLocatedBy(locator));
            IsReadyStateComplete();
            Element = GetDriver().FindElement(locator);

            return Element.Displayed;
        }

        public void IsReadyStateComplete()
        {
            GetWaiter().Until(driver1 => ((IJavaScriptExecutor)GetDriver()).ExecuteScript("return document.readyState").Equals("complete"));
        }

        public void WaitUntilNotVisible()
        {
            GetWaiter().Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(Locator));
        }

        public void MoveToTheElement()
        {
            IsPresent(Locator);
            Actions Actions = new Actions(GetDriver());
            Actions.MoveToElement(Element).Build().Perform();
        }

        public string GetText()
        {
            IsPresent(Locator);
            return Element.Text;
        }

        public string GetAttribute(string attribute)
        {
            IsPresent(Locator);
            return Element.GetAttribute(attribute);
        }

        public void MakeElementVisible()
        {
            IsPresent(Locator);
            IJavaScriptExecutor executor = GetDriver();
            string js = "arguments[0].type = 'text';";
            executor.ExecuteScript(js, Element);
        }
    }
}