using OpenQA.Selenium;

namespace GlowAutomation.Framework.Elements
{
    internal class TextBox : BaseElement
    {
        public TextBox(By locator, string name) : base(locator, name)
        {
        }

        protected override string GetElementType()
        {
            return "Textbox";
        }
    }
}