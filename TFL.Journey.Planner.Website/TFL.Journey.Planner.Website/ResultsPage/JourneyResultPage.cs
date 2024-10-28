namespace TFL.Journey.Planner.Website.ResultsPage
{
    using OpenQA.Selenium;
    using TFL.Journey.Planner.Website.BaseClass;
    using TFL.Journey.Planner.Website.Properties;

    public class JourneyResultPage : TflBaseClass
    {
        private int waitTime = 15;

        private IWebElement ResultSumary => Driver.FindElement(By.CssSelector("div[class='journey-result-summary']"));

        private IWebElement CyclingSnipet => Driver.FindElement(By.CssSelector("a[class='journey-box cycling'] h4"));
        private IList<IWebElement> WalkingAndCyclingSnipet => Driver.FindElements(By.CssSelector("div[class='route-data moderate'] p"));
        private IWebElement WalkingSnipet => Driver.FindElement(By.CssSelector("div[class='method walking notranslate'] h4"));
        private IList<IWebElement> WalkingAndCyclingSnipetInMin => Driver.FindElements(By.CssSelector("div[class='col2 journey-info']"));

        public string IsWalkingAndCyclingDistance(JourneyLocations distanceResult)
        {
            WaitForElementsToBeVisible(waitTime, "div[class='journey-result-summary']");

            CyclingSnipet.Text.Equals(distanceResult.Cycling);
            WalkingAndCyclingTexts(distanceResult.Route.ToString());
            WalkingAndCyclinginMinutes(distanceResult.CyclingDistance.ToString());
            WalkingAndCyclingTexts(distanceResult.CyclingDistanceInkm.ToString());
            WalkingSnipet.Text.Equals(distanceResult.Walking);
            WalkingAndCyclingTexts(distanceResult.WalkingSpeed.ToString());
            WalkingAndCyclinginMinutes(distanceResult.WalkingDistance.ToString());
            WalkingAndCyclingTexts(distanceResult.WalkingDistanceInkm.ToString());

            return distanceResult.ToString(); ;
        }

        private string WalkingAndCyclingTexts(string distanceResult)
        {
            WalkingAndCyclingSnipet.Any(item => item.Text.Equals(distanceResult.Trim()));
            return distanceResult.ToString();
        }

        private string WalkingAndCyclinginMinutes(string distanceResult)
        {
            WalkingAndCyclingSnipetInMin.Any(item => item.Text.Equals(distanceResult.Trim()));
            return distanceResult.ToString();
        }
    }
}