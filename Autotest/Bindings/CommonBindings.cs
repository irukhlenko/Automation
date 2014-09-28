using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;

namespace Autotest.Bindings
{
    [Binding]
    class CommonBindings
    {
        IWebDriver driver = new ChromeDriver(@"C:\Users\Igor\Desktop\Autotest\Autotest");

        [TestFixtureSetUp]
        public void TestSetUp()
        {


            driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 0, 30));
        }

        /*
        [Given(@"Browser is started")]
        public void GivenBrowserIsStarted()
        {
            
        }
         * */

        [When(@"I navigate to ""(.*)""")]
        public void WhenINavigateTo(string value)
        {
            driver.Navigate().GoToUrl("http://" + value);

        }

        [Then(@"I see ""(.*)"" Logo")]
        public void ThenISeeYandexLogo(string value)
        {
            switch (value)
            {
                case "Google":
                    Assert.IsTrue(driver.FindElement(By.XPath("//*[@id='hplogo']")).Displayed);
                    break;
                case "Yandex":
                    Assert.IsTrue(driver.FindElement(By.XPath("//*[@class='logo__image_bg']")).Displayed);
                    //Assert.IsTrue(driver.FindElement(By.XPath("/html/body/div[1]/div[3]/div[2]/table/tbody/tr/td[2]/form/table/tbody/tr/td[2]/button")).Displayed);
                    break;
                default:
                    Console.WriteLine("Cannot find this element");
                    break;
            }
        }

        [When(@"I search following content ""(.*)"" on ""(.*)"" page")]
        public void WhenITypeFollowingTextInTextboxOnPage(string text, string system)
        {
            switch (system)
            {
                case "Google":
                    var googleSearch = driver.FindElement(By.XPath("//*[@class='gbqfif']"));
                    if (googleSearch.Displayed)
                    {
                        googleSearch.SendKeys(text);
                        googleSearch.SendKeys(Keys.Enter);
                    }
                    else
                    {
                        Console.WriteLine("Cannot find element!!!!!!");
                    }
                    break;
                case "Yandex":
                    var yandexSearch = driver.FindElement(By.XPath("//*[@class='input__control']"));
                    if (yandexSearch.Displayed)
                    {
                        yandexSearch.SendKeys(text);
                        yandexSearch.SendKeys(Keys.Enter);
                    }
                    else
                    {
                        Console.WriteLine("Cannot find element!!!!!!");
                    }
                    break;
            }
        }

        [When(@"I click ""(.*)"" button on ""(.*)"" page")]
        public void WhenIClickButton(string searchButton, string system)
        {
            switch (system)
            {
                case "Google":
                    var googleSearch = driver.FindElement(By.XPath("//*[@value='Google Search']"));
                    if (googleSearch.Displayed)
                    {
                        googleSearch.Submit();
                    }
                    else
                    {
                        Console.WriteLine("Cannot find element!!!!!!");
                    }
                    break;
                case "Yandex":
                    var yandexSearch = driver.FindElement(By.XPath("//*[@class='button button_theme_websearch arrow2 arrow2_size_l arrow2_theme_websearch-button suggest2-form__button i-bem button_js_inited']"));
                    if (yandexSearch.Displayed)
                    {
                        yandexSearch.Submit();
                    }
                    else
                    {
                        Console.WriteLine("Cannot find element!!!!!!");
                    }
                    break;
            }
        }

        [Then(@"I see following serach results")]
        public void ThenISeeFollowingSerachResults(TechTalk.SpecFlow.Table table)
        {
            foreach (var row in table.Rows)
            {
                var result = driver.FindElement(By.LinkText(row["Result"]));
                var link = driver.FindElement(By.LinkText(row["Link"]));
                Assert.IsTrue(result.Displayed, "Cannot find the result with text {0}", row["Result"]);
                Assert.IsTrue(link.Displayed, "Cannot find the link {0}", row["Link"]);
            }
        }


        [TestFixtureTearDown]
        public void FixtureTearDown()
        {
            if (driver != null)
            {
                driver.Close();
                driver.Quit();
                driver.Dispose();
            }

        }

    }
}
