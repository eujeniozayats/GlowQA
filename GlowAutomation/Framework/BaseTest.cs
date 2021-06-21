
using GlowAutomation.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace GlowAutomation.TestCases
{

    public abstract class BaseTest : BaseEntity
    {

            public abstract void RunTest();

            [TestMethod]
            public void xTest()
            {
                try
                {
                    RunTest();
                }
                catch
                {
                    AttachScreenShotFileToTestResult("Failure");
                    Assert.Fail();
                }
            }





            protected override string FormatLogMsg(string message)
            {
                return message;
            }
        }
    }
