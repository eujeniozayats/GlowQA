using OpenQA.Selenium;

namespace GlowAutomation.Framework.Elements
{
    internal class CheckBox : BaseElement
    {
        public CheckBox(By locator, string name) : base(locator, name)
        {
        }

        protected override string GetElementType()
        {
            return "Checkbox";
        }
    }
}