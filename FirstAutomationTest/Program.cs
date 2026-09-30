using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge; 
namespace FirstAutomationTest
{
    class Program
    {
        static void Main(string[] args)
        {
            
            IWebDriver driver = new EdgeDriver();

            try
            {
                
                driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/login");

                Thread.Sleep(2000);

               
                IWebElement usernameField = driver.FindElement(By.Id("username"));
                usernameField.SendKeys("tomsmith");

                
                IWebElement passwordField = driver.FindElement(By.Id("password"));
                passwordField.SendKeys("SuperSecretPassword!");

                Thread.Sleep(2000);

                
                IWebElement loginButton = driver.FindElement(By.CssSelector("button[type='submit']"));
                loginButton.Click();

                Thread.Sleep(2000);

                IWebElement successMessage = driver.FindElement(By.Id("flash"));
                string messageText = successMessage.Text;

                
                if (messageText.Contains("You logged into a secure area!"))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("loge in success");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("loge in error.");
                }

               
                Console.ResetColor();
               
                Thread.Sleep(3000);
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("a mistake come up " + ex.Message);
                Console.ResetColor();
            }
            finally
            {
                
                driver.Quit();
            }
        }
    }
}