using GlowAutomation.PageObjects;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;
using System.Reflection;

namespace GlowAutomation.Framework
{
    public abstract class BaseEntity
    {
        public static ChromeDriver Driver = null;
        public static WebDriverWait Wait = null;
        public static ConfigSetting Config;

        protected static string s_configSettingPath = Directory.GetParent(@"../../../").FullName
            + Path.DirectorySeparatorChar + "Configuration/configsetting.json";

        public void RunConfig()
        {
            Config = new ConfigSetting();
            var configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddJsonFile(s_configSettingPath);
            IConfigurationRoot configuration = configurationBuilder.Build();
            configuration.Bind(Config);
        }

        protected virtual Logger Logger => Logger.Instance;

        protected virtual GoogleSheetManager GoogleSheetManager => GoogleSheetManager.Instance;

        protected abstract string FormatLogMsg(string message);

        protected void Info(string message)
        {
            Logger.Info(FormatLogMsg(message));
        }

        public void Initialize(string env, string mobileC, string passC)
        {
            var chromeOptions = new ChromeOptions
            {
                PageLoadStrategy = PageLoadStrategy.Normal
            };
            chromeOptions.AddArgument("headless");
            Driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), chromeOptions);
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(60));
            Driver.Manage().Cookies.DeleteAllCookies();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl(env);
            var platLogin = new PlatLogin();
            platLogin.PLogin(Config.ClientLogin, Config.ClientPass);
            var catLogin = new CatLogin();
            catLogin.CatalogLogin(mobileC, passC);
            catLogin.BuyWithSamsung();
        }

        public void InitializeDebug()
        {
            var chromeOptions = new ChromeOptions
            {
                PageLoadStrategy = PageLoadStrategy.Normal
            };
            Driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), chromeOptions);
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(60));
            Driver.Manage().Cookies.DeleteAllCookies();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl("https://app.platform.uat.glowfinsvs.com/application/e5ec7e7a-c6d7-4212-8093-1b4eb74d68b8/submit");
        }

        public static void InitializeStandaloneCalculator()
        {
            var chromeOptions = new ChromeOptions
            {
                PageLoadStrategy = PageLoadStrategy.Normal
            };

            Driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), chromeOptions);
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(60));
            Driver.Manage().Cookies.DeleteAllCookies();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl(Config.CalcUatUrl);
        }

        public static void Quit()
        {
            Driver.Quit();
            Driver = null;
        }

        public static ChromeDriver GetDriver()
        {
            return Driver;
        }

        public static WebDriverWait GetWaiter()
        {
            return Wait;
        }

        public void ChangeBrowserWindow(string windowTitle)
        {
            Wait.Until(wd => wd.WindowHandles.Count == 2);
            foreach (string window in GetDriver().WindowHandles)
            {
                if (GetDriver().CurrentWindowHandle != window)
                {
                    GetDriver().SwitchTo().Window(window);
                    break;
                }
            }
            Wait.Until(wd => wd.Title == windowTitle);
        }

        [TestInitialize]
        public void SetUp()
        {
            RunConfig();
        }

        [TestCleanup]
        public void TearDown()
        {
            Quit();
        }
    }
}