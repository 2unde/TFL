using TFL.Journey.Planner.Website.BaseClass;

namespace Journey.Planner.Website.Test.TflHook
{
    [Binding]
    public class Hook: TflBaseClass
    {
        [BeforeScenario]
        public static void SetUp()
        {

            StartBrowser();
        }

        [AfterScenario]
        public static void Close()
        {
            ClosBrowser();
        }

    }
}
