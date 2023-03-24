using CodeMer.Temp;

namespace CodeMer.BusinessLogicTests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    [TestCase(0, 0, 0)]
    public void Test1(int num1, int num2, int res)
    {
        var task1 = new Task1();
        
        var result = task1.Sum(num1, num2);
        
        Assert.AreEqual(res, result);
    }
}