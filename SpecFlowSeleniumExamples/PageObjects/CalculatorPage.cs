using OpenQA.Selenium;
using SpecFlow.Actions.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowSeleniumExamples.PageObjects
{
    public class CalculatorPage
    {
        private readonly IBrowserInteractions _browserInteractions;

        public CalculatorPage(IBrowserInteractions browserInteractions)
        {
            _browserInteractions = browserInteractions;
        }

        private static string PageUrl => "https://specflowoss.github.io/Calculator-Demo/Calculator.html";

        private IWebElement FirstNumberInput => _browserInteractions.WaitAndReturnElement(By.Id("first-number"));
        private IWebElement SecondNumberInput => _browserInteractions.WaitAndReturnElement(By.Id("second-number"));
        private IWebElement AddButton => _browserInteractions.WaitAndReturnElement(By.Id("add-button"));
        private IWebElement ResultField => _browserInteractions.WaitAndReturnElement(By.Id("result"));
        private IWebElement ResetButton => _browserInteractions.WaitAndReturnElement(By.Id("reset-button"));

        public void Goto()
        {
            _browserInteractions.GoToUrl(PageUrl);
        }

        public void EnterFirstNumber(string number)
        {
            FirstNumberInput.SendKeysWithClear(number);
        }

        public void EnterSecondNumber(string number)
        {
            SecondNumberInput.SendKeysWithClear(number);
        }

        public void ClickAdd()
        {
            AddButton.ClickWithRetry();
        }

        public void ClickReset() 
        { 
            ResetButton.ClickWithRetry();
        }

        public bool FirstNumberIsEmpty()
        {
            return FirstNumberInput.HasValue(string.Empty);
        }

        public bool SecondNumberIsEmpty()
        {
            return SecondNumberInput.HasValue(string.Empty);
        }

        public bool ResultIsEmpty()
        {
            return ResultField.HasValue(string.Empty);
        }

        public string WaitForNonEmptyResult()
        {
            return _browserInteractions.WaitUntil(
                () => ResultField.GetAttribute("value"),
                result => !string.IsNullOrEmpty(result));
        }

    }
}
