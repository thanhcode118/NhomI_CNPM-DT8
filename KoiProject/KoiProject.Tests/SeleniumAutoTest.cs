using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace KoiProject.Tests
{
    public class SeleniumAutoTest
    {
        IWebDriver driver;

        [SetUp]
        public void SetupTest()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        public void Login()
        {
            driver.Navigate().GoToUrl("https://courses.ut.edu.vn/login/index.php");
            Thread.Sleep(1000);

            driver.FindElement(By.Name("username")).Clear();
            driver.FindElement(By.Name("username")).SendKeys("");// Nhập tài khoản
            Thread.Sleep(1000);
            driver.FindElement(By.Id("password")).Clear();
            driver.FindElement(By.Id("password")).SendKeys("");// Nhập mật khẩu
            Thread.Sleep(1000);
            driver.FindElement(By.Id("loginbtn")).Click();
            Thread.Sleep(2000);
        }

        [Test]
        public void RunTestLogin()
        {
            driver.Navigate().GoToUrl("https://courses.ut.edu.vn/login/index.php");
            Thread.Sleep(1000);

            driver.FindElement(By.Name("username")).Clear();
            driver.FindElement(By.Name("username")).SendKeys("052205001988"); // Tài khoản mẫu
            Thread.Sleep(1000);
            driver.FindElement(By.Id("password")).Clear();
            driver.FindElement(By.Id("password")).SendKeys("@ngoctoanV29"); // Mật khẩu mẫu
            Thread.Sleep(1000);
            driver.FindElement(By.Id("loginbtn")).Click();

            Thread.Sleep(2000);
            Assert.IsTrue(driver.Url.Contains("https://courses.ut.edu.vn/my/")); // Kiểm tra xem đã login thành công
        }
        [TearDown]
        public void CloseTest()
        {
            driver.Quit();
        }
    }
}
