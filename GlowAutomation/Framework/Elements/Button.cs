using OpenQA.Selenium;

namespace GlowAutomation.Framework.Elements
{
    internal class Button : BaseElement
    {
        public Button(By locator, string name) : base(locator, name)
        {
        }

        protected override string GetElementType()
        {
            return "Button";
        }
    }
}