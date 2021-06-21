namespace GlowAutomation.Framework
{
    public abstract class BasePage : BaseEntity
    {
        public BasePage()
        {
        }

        protected override string FormatLogMsg(string message)
        {
            return message;
        }
    }
}