
using GlowAutomation.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace GlowAutomation.TestCases
{

    public abstract class BaseTest : BaseEntity
    {

         
        public abstract void RunTest();


        
        public void xTest()
            {
            string currentClass = this.GetType().Name;

            
                try
                {
                   RunTest();
                }
                catch(Exception ex)
                {
                var testFilePath = ScreenGrab(currentClass);
                AttachScreenShotFileToTestResult(testFilePath);
                TestContext.WriteLine(ex.ToString());
                Assert.Fail();
            }
            }





            protected override string FormatLogMsg(string message)
            {
                return message;
            }
        }
    }
