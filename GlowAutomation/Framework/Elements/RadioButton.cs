using OpenQA.Selenium;

namespace GlowAutomation.Framework.Elements
{
    internal class RadioButton : BaseElement
    {
        public RadioButton(By locator, string name) : base(locator, name)
        {
        }

        protected override string GetElementType()
        {
            return "RadioButton";
        }
    }
}