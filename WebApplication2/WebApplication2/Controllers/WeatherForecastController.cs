using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.IO;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {


            //Find folder with Chrome Driver (chromedriver.exe)
            var browserDriverPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            //Set Chrome to start with maximized window
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--start-maximized");

            //Open Chrome
            using (var chromeDriver = new ChromeDriver(browserDriverPath, options))
            {
                //Assign google.com to variable named url
                var url = "http://www.jerusalem1stclass.com/agent/login?return=http%3A%2F%2Fwww.jerusalem1stclass.com%2Fbookings%2Flist";
                //Go to Google.com
                chromeDriver.Navigate().GoToUrl(url);

                //Create new wait timer and set it to 1 minute
                var wait = new WebDriverWait(chromeDriver, new TimeSpan(0, 0, 1, 0));

                //Wait until an element on the page with the name q is visible.
                //Google named their search box q. probably short for query.
                //We are waiting until that appears but will wait no longer than 1 minute as defined above.
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Name("AccountName")));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Name("Username")));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Name("Password")));
                //Find the Google Search Box now that it is visible and
                //assign to the variable "googleSearchBox"
                var AccountNameBox = chromeDriver.FindElement(By.Name("AccountName"));
                var UserNameBox = chromeDriver.FindElement(By.Name("Username"));
                var PasswordBox = chromeDriver.FindElement(By.Name("Password"));

                //clear search box just in case anything is already typed in
                AccountNameBox.Clear();
                UserNameBox.Clear();
                //PasswordBox.Clear();

                //Type "Selenium HQ" into the search box
                AccountNameBox.SendKeys("my");
                UserNameBox.SendKeys("menucha");
                PasswordBox.SendKeys("travel");

                ////Wait until Google Search button is visible but don't wait more than 1 minute.
                //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.ClassName("disable-margin-bottom")));
                ////Find "Google Search" button and assign to variable name "searchButton"
                var submitButton = chromeDriver.FindElement(By.XPath("//button[contains(text(), 'Submit')]"));

                //Click search button
                submitButton.Click();

                //wait until search results stats appear which confirms that the search finished
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.ClassName("info-box-child")));

                //Find result stats and assign to variable name resultStats
                var HotelsButton = chromeDriver.FindElement(By.LinkText("Hotels"));
                HotelsButton.Click();

                ////Confirm the stats contain the words About, results and seconds.
                ////Example Result stats: "About 1,090,000 results (0.49 seconds)"
                //Assert.IsTrue(resultStats.Text.Contains("About"));
                //Assert.IsTrue(resultStats.Text.Contains("results"));
                //Assert.IsTrue(resultStats.Text.Contains("seconds"));

                ////Find a search result in the list
                //var results = chromeDriver.FindElement(By.ClassName("r"));

                ////Confirm that the result text contains Selenium
                //Assert.IsTrue(results.Text.Contains("Selenium"));

                //close Chrome
                chromeDriver.Close();

                var rng = new Random();
                return Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = rng.Next(-20, 55),
                    Summary = Summaries[rng.Next(Summaries.Length)]
                })
                .ToArray();
            }
        }
    }
}
