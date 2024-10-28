namespace Journey.Planner.Website.Test.StepDefinitions
{
    using Journey.Planner.Website.Test.TflHook;
    using NUnit.Framework;
    using TechTalk.SpecFlow.Assist;
    using TFL.Journey.Planner.Website.HomePage;
    using TFL.Journey.Planner.Website.Properties;

    [Binding]
    public sealed class JourneyPlannerStepDefinitions :Hook
    {
        private readonly TflHomePage tfhHomePage;

        public JourneyLocations DistanceResult { get; private set; }

        public JourneyPlannerStepDefinitions(TflHomePage tflHomePage)
        {
            this.tfhHomePage = tflHomePage;
            
        }

        [Given(@"a tfl user is on the Tfl website")]
        public void GivenATflUserIsOnTheTflWebsite()
        {
          Assert.IsTrue(tfhHomePage.NavigationBar.IsAt(), "TFL logo not display on the home page");
        }


        [When(@"I plan a new journey from ""([^""]*)"" to ""([^""]*)""")]
        public void WhenIPlanANewJourneyFromTo(string from, string to)
        {
            tfhHomePage.JourneyPlanerForm.PlanYourJorney(from, to);
        }

        [Then(@"Jorney result should display the following:")]
        public void ThenJorneyResultShouldDisplayTheFollowing(Table table)
        {
            DistanceResult = table.CreateInstance<JourneyLocations>();
            tfhHomePage.JourneyResultForm.IsWalkingAndCyclingDistance(DistanceResult);

            
        }

    }
}
