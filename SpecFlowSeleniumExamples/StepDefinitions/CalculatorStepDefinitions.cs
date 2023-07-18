using SpecFlowSeleniumExamples.PageObjects;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowSeleniumExamples.StepDefinitions
{
    [Binding]
    public class CalculatorStepDefinitions
    {
        private readonly CalculatorPage _calculatorPage;

        public CalculatorStepDefinitions(CalculatorPage calculatorPage)
        {
            _calculatorPage = calculatorPage;
        }

        [Given("the first number is (.*)")]
        public void GivenTheFirstNumberIs(string number)
        {
            _calculatorPage.EnterFirstNumber(number);
        }

        [Given("the second number is (.*)")]
        public void GivenTheSecondNumberIs(string number)
        {
            _calculatorPage.EnterSecondNumber(number);
        }

        [When("the two numbers are added")]
        public void WhenTheTwoNumbersAreAdded()
        {
            _calculatorPage.ClickAdd();
        }

        [Then("the result should be (.*)")]
        public void ThenTheResultShouldBe(string result)
        {
            var actualResult = _calculatorPage.WaitForNonEmptyResult();

            actualResult.Should().Be(result);    
        }
    }
}
