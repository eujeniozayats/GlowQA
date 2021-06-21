using OpenQA.Selenium;

namespace GlowAutomation.Framework.Elements
{
    public class Label : BaseElement
    {
        public Label(By locator, string name) : base(locator, name)
        {
        }

        protected override string GetElementType()
        {
            return "Label";
        }
    }
}