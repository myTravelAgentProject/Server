using Entity;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace BL
{
    public class BookingBL : IBookingBL
    {
        IOrderBL orderBL;
        List<Order> ordersToCheck;
        int newPrice;
        public BookingBL(IOrderBL orderBL)
        {
            this.orderBL = orderBL;
        }

        /*(updateOrders) first gets from orderBL all the alerts within two monthes and the importence alerts
        then, run on the list and for each order:
            gets from booking.com the up to date price,
            compare the price with the old price (booking price while booked)
            and if the new price is cheeper,
        through orderBL - saves in the orders table the new price and update the feild 'change' of the order*/
        public async Task updateOrders()
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
                var wait = new WebDriverWait(chromeDriver, new TimeSpan(0, 0, 2, 0));

                //Wait until an element on the page with the name q is visible.
                //Google named their search box q. probably short for query.
                //We are waiting until that appears but will wait no longer than 1 minute as defined above.
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Name("AccountName")));
                //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Name("Username")));
                //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Name("Password")));
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

                Thread.Sleep(5000);
                //chromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
                ////Wait until Google Search button is visible but don't wait more than 1 minute.
                //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.ClassName("disable-margin-bottom")));
                ////Find "Google Search" button and assign to variable name "searchButton"
                var submitButton1 = chromeDriver.FindElement(By.XPath("//button[contains(text(), 'Submit')]"));
                //Click search button
                submitButton1.Click();

                //wait until search results stats appear which confirms that the search finished
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.ClassName("info-box-child")));

                //Find result stats and assign to variable name resultStats
                /*var HotelsButton = chromeDriver.FindElement(By.LinkText("Hotels"));*/
                var HotelsButton = chromeDriver.FindElement(By.LinkText("Hotels"));
                HotelsButton.Click();

                List<Order> comparePriceOrders = await orderBL.getOrsersToCheck(DateTime.Now);
                /*comparePriceOrders.ForEach(order =>
                {*/




                //comparePriceOrders.ForEach(order =>
                //{
                var order = comparePriceOrders[4];
                string hotelName = order.Hotel.Name;
                int hotelWordIndex = hotelName.IndexOf("Hotel");
                if (hotelWordIndex != -1)
                {
                    hotelName = hotelName.Substring(0, hotelWordIndex);
                }
                string typeOfRoom = order.TypeOfRoom;
                //string typeOfRoom = "Superior";
                int checkInYear = order.CheckInDate.Year;
                int checkOutYear = order.CheckOutDate.Year;
                int checkInMonth = order.CheckInDate.Month;
                int checkOutMonth = order.CheckOutDate.Month;
                int checkInDay = order.CheckInDate.Day;
                int checkOutDay = order.CheckOutDate.Day;
                DateTime currentDate = DateTime.Now;
                int year = currentDate.Year;
                int month = currentDate.Month;
                int day = currentDate.Day;
                int monthToMove = 0;
                if (year == checkInYear)
                {
                    monthToMove = checkInMonth - month;
                }
                else
                {
                    monthToMove = checkInMonth - month + (12 * (checkInYear - year));
                }

                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[contains(text(), 'Submit')]")));
                var HotelInputBox = chromeDriver.FindElement(By.ClassName("input-group-field"));
                //var checkIn = chromeDriver.FindElement(By.Name("startDate"));
                //var CheckInBox = chromeDriver.FindElement(By.ClassName("cell small-5 vertical-center-parent picker-txt"));
                var submitButton = chromeDriver.FindElement(By.XPath("//button[contains(text(), 'Submit')]"));

                HotelInputBox.Clear();
                //CheckInBox.Clear();
                //checkIn.Clear();
                HotelInputBox.SendKeys(hotelName + ",Israel");
                //checkIn.SendKeys(checkInDate); callout small disable-margin-bottom
                //var selectDate = chromeDriver.FindElement(By.XPath("//span[@aria-controls='datetimepicker_dateview']"));
                var selectDate = chromeDriver.FindElement(By.ClassName("picker-grid"));
                selectDate.Click();

                // var prevLink = chromeDriver.FindElement(By.ClassName("datepicker__month-button--prev"));


                // nextLink.Click();
                for (int i = 0; i < monthToMove; i++)
                {
                    var nextLinks = chromeDriver.FindElements(By.ClassName("datepicker__month-button--next"));

                    var nextLinkdispaly = nextLinks.FirstOrDefault(n => n.Displayed && n.Enabled);

                    Thread.Sleep(2000);
                    if (nextLinkdispaly != null)

                    {
                        nextLinkdispaly.Click();
                    }
                }


                IList<IWebElement> listOfElements = chromeDriver.FindElements(By.TagName("td"));
                DateTime firstDayOfTheMonth = new DateTime(checkInYear, checkInMonth, 1);
                int dayOfTheFirstDate = (int)firstDayOfTheMonth.DayOfWeek;
                int checkInDayToClick = dayOfTheFirstDate - 1 + checkInDay;
                int checkOutDayToClick = dayOfTheFirstDate - 1 + checkOutDay;
                if (checkInMonth != checkOutMonth)
                {
                    DateTime firstDayOfTheSecondMonth = new DateTime(checkOutYear, checkOutMonth, 1);
                    int dayOfTheFirstDateOfTheCheckOutMonth = (int)firstDayOfTheSecondMonth.DayOfWeek;
                    checkOutDayToClick = dayOfTheFirstDateOfTheCheckOutMonth + 34 + checkOutDay;
                }
              
                Thread.Sleep(1000);
                listOfElements[checkInDayToClick].Click();
                listOfElements[checkOutDayToClick].Click();
                var submitButton2 = chromeDriver.FindElement(By.XPath("//button[contains(text(), 'Submit')]"));
                Thread.Sleep(2000);
                submitButton2.Click();
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.ClassName("search-result-item")));
                // IWebElement divOfRoomType=
               IList< IWebElement> typeOfRommDiv = chromeDriver.FindElements(By.XPath("//h5[contains(text(),'" + typeOfRoom + "')]/following-sibling::div[1]/div"));
                //var a=divOfRoomType.FindElements(By.ClassName("grid-x"))

                IWebElement price =chromeDriver.FindElement(By.ClassName("formatted-price"));
                var p = price.GetAttribute("amount");
                float np = float.Parse(p);
                    int newPrice = (int)np;

                    //}
                    //);
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







                //        ordersToCheck=await orderBL.getOrsersToCheck(DateTime.Now);
                //        foreach(Order order in ordersToCheck)
                //        {
                //            //string url= "https://booking-com.p.rapidapi.com/v1/hotels/search-filters?"
                //            //check if order had change in booking and save the new price into newPrice
                //            //update the order:
                //            if (order.TotalPrice > newPrice)
                //            {
                //                order.NewPrice = newPrice;
                //                order.Change = true;
                //                await orderBL.updateOrder(order, order.Id);
                //            }
                //        }
                //        var client = new HttpClient();
                //        var request = new HttpRequestMessage
                //        {
                //            Method = HttpMethod.Get,
                //            RequestUri = new Uri("https://booking-com.p.rapidapi.com/v1/hotels/search?units=metric&order_by=popularity&checkout_date=2022-05-10&adults_number=2&checkin_date=2022-05-09&room_number=1&filter_by_currency=AED&dest_type=city&locale=en-gb&dest_id=-553173&include_adjacency=true&page_number=0&children_number=2&children_ages=5%2C0&categories_filter_ids=class%3A%3A2%2Cclass%3A%3A4%2Cfree_cancellation%3A%3A1"),
                //            Headers =
                //{
                //    { "x-rapidapi-host", "booking-com.p.rapidapi.com" },
                //    { "x-rapidapi-key", "16945ab38dmsh7cf2c60b016f2fep18d5c7jsna1ddd961ba77" },
                //},
                //        };
                //        using (var response = await client.SendAsync(request))
                //        {
                //            response.EnsureSuccessStatusCode();
                //            var body = await response.Content.ReadAsStringAsync();
                //            Console.WriteLine(body);
                //        }
             
                    if ((order.CostPrice - newPrice) > (order.CostPrice / 10))
                    {
                        order.NewPrice = newPrice;
                        order.Change = true;
                        orderBL.updateOrder(order, order.Id);
                    }
               // });

        }

    }
    }
}

//public bool IsElementVisible(IWebElement element)
//{
//    return element.Displayed && element.Enabled;
//}
