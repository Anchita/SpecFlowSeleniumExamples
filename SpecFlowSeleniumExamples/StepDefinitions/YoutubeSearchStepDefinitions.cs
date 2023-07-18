using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace SpecFlowSeleniumExamples.StepDefinitions
{
    [Binding]

    public class YoutubeSearchStepDefinitions : IDisposable
    {
        private ChromeDriver chromeDriver;
        private string searchKeyword;

        public YoutubeSearchStepDefinitions()
        {
            chromeDriver = new ChromeDriver();
        }
 

        [Given(@"I have navigated to youtube website")]
        public void GivenIHaveNavigatedToYoutubeWebsite()
        {
            chromeDriver.Navigate().GoToUrl("https://www.youtube.com");
            Assert.IsTrue(chromeDriver.Title.ToLower().Contains("youtube"));
        }

        [Given(@"I have entered (.*) as search keyword")]
        public void GivenIHaveEnteredEnglandAsSearchKeyword(String searchString)
        {
            searchKeyword = searchString.ToLower();
            var searchInputBox = chromeDriver.FindElement(By.Id("search"));
            var wait = new WebDriverWait(chromeDriver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("search")));
            searchInputBox.SendKeys(searchKeyword);
        }

        [When(@"I press the search button")]
        public void WhenIPressTheSearchButton()
        {
            var searchButton = chromeDriver.FindElement(By.CssSelector("button#search-icon-legacy"));
            searchButton.Click();
        }

        [Then(@"I should be navigate to search results page")]
        public void ThenIShouldBeNavigateToSearchResultsPage()
        {
            System.Threading.Thread.Sleep(2000);

            Assert.IsTrue(chromeDriver.Url.ToLower().Contains(searchKeyword));
            Assert.IsTrue(chromeDriver.Title.ToLower().Contains(searchKeyword));
        }

        public void Dispose()
        {
            if (chromeDriver != null)
            {
                chromeDriver.Dispose();
                chromeDriver = null;
            }
        }
    }
}
