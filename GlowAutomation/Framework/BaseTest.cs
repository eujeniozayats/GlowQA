
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GlowAutomation.Framework
{
    //[TestClass]
    public abstract class BaseTest : BaseEntity
    {
        protected override string FormatLogMsg(string message)
        {
            return message;
        }
    }
}