# Data-Driven Tests with C#, NUnit and Selenium

Data-Driven Testing == running the same test case with multiple data 
This example demonstrates how to write data-driven NUnit tests:
 - Parameterized tests with `[TestCase]`
 - Excel-based tests: `[TestCaseSource]`
 - Data-driven Selenium tests (based on Selenium + `[TestCase]`)

## Code Examples

```
[TestCase("BG", "1000", "Sofija")]
[TestCase("BG", "5000", "Veliko Turnovo")]
[TestCase("CA", "M5S", "Toronto")]
[TestCase("GB", "B1", "Birmingham")]
[TestCase("DE", "01067", "Dresden")]
public void TestZippopotamus(
    string countryCode, string zipCode, string expectedPlace)
{
   ...
}
```

## Screenshots

![image](https://user-images.githubusercontent.com/1689586/107420677-d6657c00-6b21-11eb-9f43-75cb64aced9b.png)
