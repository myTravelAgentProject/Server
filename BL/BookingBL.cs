using Entity;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Reflection;
using System.Text;
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
             /* var error= chromeDriver.FindElement(By.Id("IDa0830f96-c7ab-c9dd-6d57-9ad5e71b704f"));
                if(error!=null)*/

                //wait until search results stats appear which confirms that the search finished
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.ClassName("info-box-child")));
                List<Order> comparePriceOrders = await orderBL.getOrsersToCheck(DateTime.Now);

                for(int j=8;j< comparePriceOrders.Count();j++)
                {
                    
                    //Find result stats and assign to variable name resultStats
                    /*var HotelsButton = chromeDriver.FindElement(By.LinkText("Hotels"));*/
                    var HotelsButton = chromeDriver.FindElement(By.LinkText("Hotels"));
                    HotelsButton.Click();
                    Thread.Sleep(1000);                     /* comparePriceOrders.ForEach(order =>
                     {*/
                    var order = comparePriceOrders[j];
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
                    try
                    {
                        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.ClassName("search-result-item")));
                    }
                    catch
                    {
                        continue;
                    }
                    //if ()
                        //  We are sorry, but there are no results available that match your search criteria.Please try changing your filters or expand your search criteria to include more options and click the search button again. 
                      //  wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[contains(text(), 'We are sorry, but there are no results available that match your search criteria.Please try changing your filters or expand your search criteria to include more options and click the search button again.')]|| //div[@class='search-result-item]'")));
                 //   wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.ClassName("search-result-item")));
                    // IWebElement divOfRoomType=
                    //IList< IWebElement> typeOfRommDiv = chromeDriver.FindElements(By.XPath("//h5[contains(text(),'" + typeOfRoom + "')]/following-sibling::div[1]/div/span/[@class='formatted-price']"));
                    //var a=divOfRoomType.FindElements(By.ClassName("grid-x"))
                    IList<IWebElement> priceAtrribute = chromeDriver.FindElements(By.XPath("//h5[contains(text(),'" + typeOfRoom + "')]//parent::div//span[@class='formatted-price']"));

                    //IWebElement price =chromeDriver.FindElement(By.ClassName("formatted-price"));
                    //var p = price.GetAttribute("amount");
                    var price = priceAtrribute[0].GetAttribute("amount");
                    float np = float.Parse(price);
                    int newPrice = (int)np;


                    //close Chrome
                    //chromeDriver.Close();

                    if ((order.CostPrice - newPrice) > (order.CostPrice / 10))
                    {
                        order.NewPrice = newPrice;
                        order.Change = true;
                        orderBL.updateOrder(order, order.Id); //checking if the student already got a mail

                        //send a mail
                        MailMessage message = new MailMessage();
                        message.From = new MailAddress("mytravelProject22@gmail.com");
                        message.To.Add(new MailAddress("mytravelProject22@gmail.com"));
                        message.Subject = "New Discount on order number";
                        //string mailbody = ;
                        message.Subject = "We have good News For You:)";
                        message.Body = "We are happy to tell you about a discount on the price of the order you placed Of a customer:" + order.Customer.FirstName + "\n" + order.Customer.LastName + "\n Hotel name: \n" + order.Hotel.Name + "\n Order dates:\n " + order.CheckInDate + " - " + order.CheckOutDate + "\n The new price is: " + newPrice;
                        message.BodyEncoding = Encoding.UTF8;
                        message.IsBodyHtml = true;
                        SmtpClient client = new SmtpClient("smtp.gmail.com", 587); //Gmail smtp    
                        System.Net.NetworkCredential basicCredential1 = new
                        System.Net.NetworkCredential("mytravelProject22@gmail.com", "kxbfxdziccmrcweo");
                        client.EnableSsl = true;
                        client.UseDefaultCredentials = false;
                        client.Credentials = basicCredential1;
                        try
                        {
                            client.Send(message);
                        }

                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    }




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

                };
                chromeDriver.Close();
            }
            }

        }
    }


//public bool IsElementVisible(IWebElement element)
//{
//    return element.Displayed && element.Enabled;
//}
