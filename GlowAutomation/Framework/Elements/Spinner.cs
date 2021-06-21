using OpenQA.Selenium;

namespace GlowAutomation.Framework.Elements
{
    internal class Spinner : BaseElement
    {
        public Spinner(By locator, string name) : base(locator, name)
        {
        }

        protected override string GetElementType()
        {
            return "Spinner";
        }
    }
}