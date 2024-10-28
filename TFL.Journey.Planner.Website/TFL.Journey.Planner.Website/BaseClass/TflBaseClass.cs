namespace TFL.Journey.Planner.Website.BaseClass
{
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;

    public class TflBaseClass
    {

        public static IWebDriver Driver { get; private set; }
        public static WebDriverWait Wait { get; private set; }

        public static IWebDriver InitDriver()
        {
            Driver = new ChromeDriver();
            return Driver;
        }

        public static void StartBrowser()
        {
            InitDriver();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            Driver.Navigate().GoToUrl("https://tfl.gov.uk/plan-a-journey/?cid=plan-a-journey");
            Driver.Manage().Window.Maximize();
            Acceptookies();
        }

        public static void ClosBrowser()
        {
            Driver.Close();
            Driver.Quit();
        }

        public void WaitForTheListOfElementsToBeVisible(int waitTime, string planFromAutoSuggestion)
        {
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(waitTime));
            Wait.Until(SeleniumExtras.WaitHelpers
                .ExpectedConditions
                .VisibilityOfAllElementsLocatedBy(By.CssSelector(planFromAutoSuggestion)));
        }

        public void WaitForElementsToBeVisible(int waitTime, string elementText)
        {
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(waitTime));
            Wait.Until(SeleniumExtras.WaitHelpers
                .ExpectedConditions
                .ElementExists(By.CssSelector(elementText)));
        }
        private static void Acceptookies()
        {
            var isCookiesPresent = IsElementExist(By.Id("CybotCookiebotDialogBodyLevelButtonLevelOptinAllowAll"));
            var clickCookiesButton = Driver.FindElement(By.Id("CybotCookiebotDialogBodyLevelButtonLevelOptinAllowAll"));
            if (isCookiesPresent)
            {
                Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
                Wait.Until(SeleniumExtras.WaitHelpers
                    .ExpectedConditions
                    .ElementToBeClickable(By.Id("CybotCookiebotDialogBodyLevelButtonLevelOptinAllowAll")));

                clickCookiesButton.Click();

            }
        }
        private static bool IsElementExist(By by)
        {
            try
            {
                Driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {

                return false;
            }
        }

    }
}