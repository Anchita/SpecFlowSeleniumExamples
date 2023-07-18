using SpecFlowSeleniumExamples.PageObjects;
using TechTalk.SpecFlow;

namespace SpecFlowSeleniumExamples.Hooks
{
    [Binding]
    public sealed class Hooks1
    {
        [BeforeScenario]
        public void BeforeScenario(CalculatorPage calculatorPage)
        {
            calculatorPage.Goto();
        }
    }
}