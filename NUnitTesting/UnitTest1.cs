using LeetCode;

namespace NUnitTesting;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        Assert.Pass();
    }

    [Test]
    public void TestWithConsoleMock()
    {
        const string testInput =
            @"4
2
TS TC
AD AH
3
2H 3H
9S 9C
4D QS
3
4C 7H
4H 4D
6S 6H
3
2S 3H
2C 2D
3C 3D";

        const string expectedOutput =
            @"2
TD
TH
0
3
7S
7C
7D
0";
        
        var output = new StringWriter();
        var input = new StringReader(testInput);
        Console.SetOut(output);
        Console.SetIn(input);

        LeetCode.Ozon_Route_256_Middle_Contest_2023.TaskG.G();

        Assert.That(output.ToString(), Is.EqualTo(expectedOutput));
    }

    [Test]
    public void S()
    {
        Assert.That(FormatNumber(1000), Is.EqualTo( "1 000,00"));
        Assert.That(FormatNumber(100), Is.EqualTo( "100,00"));
        Assert.That(FormatNumber(1000000), Is.EqualTo( "1 000 000,00"));
        Assert.That(FormatNumber(200000), Is.EqualTo( "200 000,00"));
        Assert.That(FormatNumber(123456), Is.EqualTo( "123 456,00"));
        Assert.That(FormatNumber(0), Is.EqualTo( "0,00"));
        Assert.That(FormatNumber(19), Is.EqualTo( "19,00"));
        
        static string FormatNumber(int number)
        {

            string numberString = number.ToString("N2");

            // Replace the comma with a space
            // numberString = numberString.Replace(",", " ");
            
            return numberString;
        }
    }
}