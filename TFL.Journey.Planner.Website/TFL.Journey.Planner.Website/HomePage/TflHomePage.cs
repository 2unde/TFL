using OpenQA.Selenium;
using TFL.Journey.Planner.Website.BaseClass;
using TFL.Journey.Planner.Website.ResultsPage;

namespace TFL.Journey.Planner.Website.HomePage
{

    public class TflHomePage : TflBaseClass
    {
        private readonly int waitTime = 10;

        public TflHomePage JourneyPlanerForm
        {
            get { return new TflHomePage(); }
        }

        public TflHomePage NavigationBar { get { return new TflHomePage(); } }
        public JourneyResultPage JourneyResultForm { get { return new JourneyResultPage(); } }

        private IWebElement TFLLogo => Driver.FindElement(By.CssSelector("div[class='logo']"));
        private IWebElement PlanFrom => Driver.FindElement(By.Id("InputFrom"));
        private IWebElement PlanTo => Driver.FindElement(By.Id("InputTo"));
        private IWebElement PlanJourneyButton => Driver.FindElement(By.CssSelector("input[id='plan-journey-button']"));
        private IWebElement PlanFromAutoSuggestion => Driver.FindElement(By.Id("InputFrom-dropdown"));
        private IList<IWebElement> PlanFromOption => Driver.FindElements(By.CssSelector("div[class='tt-suggestion'] span"));
        private IWebElement PlanToAutoSuggestion => Driver.FindElement(By.Id("InputFrom-dropdown"));

        public bool IsAt()
        {
            try
            {
                return TFLLogo.Displayed;
            }
            catch (NoSuchElementException)
            {

                return false;
            }
        }

        public JourneyResultPage PlanYourJorney(string from, string to)
        {
            PlanFrom.SendKeys(from);
            WaitForTheListOfElementsToBeVisible(waitTime, "div[class='tt-suggestion'] span");
            PressKeysDownAndEnterToSelectAutoSuggestion(PlanFrom);

            PlanTo.SendKeys(to);
            WaitForTheListOfElementsToBeVisible(waitTime, "div[class='tt-suggestion'] span");
            PressKeysDownAndEnterToSelectAutoSuggestion(PlanTo);
            WaitForElementsToBeVisible(waitTime, "input[id='plan-journey-button']");
            PlanJourneyButton.Click();
            return new JourneyResultPage();


        }

        private void PressKeysDownAndEnterToSelectAutoSuggestion(IWebElement element)
        {
            element.SendKeys(Keys.Down);
            element.SendKeys(Keys.Enter);

        }


    }
}


