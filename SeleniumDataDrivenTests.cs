using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;

namespace Tests_Data_Driven
{
    class SeleniumDataDrivenTests
    {
        RemoteWebDriver driver;
        IWebElement textBoxNum1;
        IWebElement selectBoxOperation;
        IWebElement textBoxNum2;
        IWebElement buttonCalculate;
        IWebElement buttonReset;
        IWebElement divResult;

        [OneTimeSetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://number-calculator.nakov.repl.co/");
            textBoxNum1 = driver.FindElement(By.Id("number1"));
            selectBoxOperation = driver.FindElement(By.Id("operation"));
            textBoxNum2 = driver.FindElement(By.Id("number2"));
            buttonCalculate = driver.FindElement(By.Id("calcButton"));
            buttonReset = driver.FindElement(By.Id("resetButton"));
            divResult = driver.FindElement(By.Id("result"));
        }

        // Tests valid integers
        [TestCase("5", "+", "3", "Result: 8")]
        [TestCase("5", "-", "3", "Result: 2")]
        [TestCase("5", "*", "3", "Result: 15")]
        [TestCase("12", "/", "3", "Result: 4")]

        // Tests valid decimal numbers
        [TestCase("5.23", "+", "3.88", "Result: 9.11")]
        [TestCase("3.14", "-", "12.763", "Result: -9.623")]
        [TestCase("3.14", "*", "-7.534", "Result: -23.65676")]
        [TestCase("12.5", "/", "4", "Result: 3.125")]

        // Tests with invalid inputs
        [TestCase("", "+", "3", "Result: invalid input")]
        [TestCase("", "-", "3", "Result: invalid input")]
        [TestCase("", "*", "3", "Result: invalid input")]
        [TestCase("", "/", "3", "Result: invalid input")]
        [TestCase("5", "+", "", "Result: invalid input")]
        [TestCase("5", "-", "", "Result: invalid input")]
        [TestCase("5", "*", "", "Result: invalid input")]
        [TestCase("5", "/", "", "Result: invalid input")]
        [TestCase("asfd", "*", "20", "Result: invalid input")]
        [TestCase("3.14", "*", "asfd", "Result: invalid input")]
        [TestCase("jhhfsdgfsda", "*", "jkdfsjfhsd", "Result: invalid input")]

        // Tests with invalid operations
        [TestCase("3", "@", "7", "Result: invalid operation")]
        [TestCase("3", "", "7", "Result: invalid operation")]
        [TestCase("3", "!!!!!!", "7", "Result: invalid operation")]

        // Tests with Infinity
        [TestCase("Infinity", "+", "1", "Result: Infinity")]
        [TestCase("Infinity", "-", "1", "Result: Infinity")]
        [TestCase("Infinity", "*", "1", "Result: Infinity")]
        [TestCase("Infinity", "/", "1", "Result: Infinity")]
        [TestCase("1", "+", "Infinity", "Result: Infinity")]
        [TestCase("2", "-", "Infinity", "Result: -Infinity")]
        [TestCase("3", "*", "Infinity", "Result: Infinity")]
        [TestCase("4", "/", "Infinity", "Result: 0")]
        [TestCase("Infinity", "+", "Infinity", "Result: Infinity")]
        [TestCase("Infinity", "-", "Infinity", "Result: invalid calculation")]
        [TestCase("Infinity", "*", "Infinity", "Result: Infinity")]
        [TestCase("Infinity", "/", "Infinity", "Result: invalid calculation")]

        // Tests with exponential numbers
        [TestCase("1.5e53", "*", "150", "Result: 2.25e+55")]
        [TestCase("1.5e53", "/", "150", "Result: 1e+51")]

        public void TestCalculatorWebApp(string num1, string op, string num2, string expectedResult)
        {
            // Arrange
            buttonReset.Click();
            if (num1 != "")
                textBoxNum1.SendKeys(num1);
            if (op != "")
                selectBoxOperation.SendKeys(op);
            if (num2 != "")
                textBoxNum2.SendKeys(num2);

            // Act
            buttonCalculate.Click();

            // Assert
            var actualResult = divResult.Text;
            Assert.AreEqual(expectedResult, actualResult);
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
