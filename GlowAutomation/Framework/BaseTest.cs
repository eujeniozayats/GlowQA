using NUnit.Framework;

namespace GlowAutomation.Framework
{
    [TestFixture]
    public abstract class BaseTest : BaseEntity
    {
        protected override string FormatLogMsg(string message)
        {
            return message;
        }
    }
}