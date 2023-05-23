namespace TimeAndTimePeriodUnitTests;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using TimeAndTimePeriod;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void TimeConstructorInvalidHourValueThrowsArgumentException()
    {
        Assert.ThrowsException<ArgumentException>(() => new Time(24, 40, 6));
    }

    [TestMethod]
    public void TimeConstructorInvalidMinuteValueThrowsArgumentException()
    {
        Assert.ThrowsException<ArgumentException>(() => new Time(23, 60, 6));
    }

    [TestMethod]
    public void TimeConstructorInvalidSecondValueThrowsArgumentException()
    {
        Assert.ThrowsException<ArgumentException>(() => new Time(23, 40, 60));
    }

    [TestMethod]
    public void TimeConstructorStringFormatValidTimeReturnsTimeObject()
    {
        Time time = new Time("12:59:04");
        Assert.AreEqual(12, time.Hours);
        Assert.AreEqual(59, time.Minutes);
        Assert.AreEqual(4, time.Seconds);
    }

    [TestMethod]
    public void TimeConstructorWithoutSecondsPassedReturnsTimeObject()
    {
        Time time = new Time(3,44);
        Assert.AreEqual(3, time.Hours);
        Assert.AreEqual(44, time.Minutes);
        Assert.AreEqual(0, time.Seconds);
    }

    [TestMethod]
    public void TimeConstructorWithoutSecondsAndMinutesPassedReturnsTimeObject()
    {
        Time time = new Time(20);
        Assert.AreEqual(20, time.Hours);
        Assert.AreEqual(0, time.Minutes);
        Assert.AreEqual(0, time.Seconds);
    }

    [TestMethod]
    public void TimeConstructorStringFormatMissingValuesThrowsArgumentException()
    {
        Assert.ThrowsException<ArgumentException>(() => new Time("12:30"));
    }

    [TestMethod]
    public void TimeConstructorStringFormatInvalidValuesThrowsArgumentException()
    {
        Assert.ThrowsException<ArgumentException>(() => new Time("12:60:03"));
    }

    [TestMethod]
    public void TimeToStringProducesValidResult()
    {
        Time time = new Time(1,59,5);
        Assert.AreEqual("01:59:05", time.ToString());
    }

    [TestMethod]
    public void TimeEqualsForOtherThanTimeTypeReturnsFalse()
    {
        Time time1 = new Time(10, 20, 30);
        string str = "12:23:03";
        Assert.IsFalse(time1.Equals(str));
    }

    [TestMethod]
    public void TimeEqualsForTwoEqualTimesReturnsTrue()
    {
        Time time1 = new Time(10, 20, 30);
        Time time2 = new Time(10, 20, 30);
        Assert.IsTrue(time1.Equals(time2));
    }

    [TestMethod]
    public void TimeEqualsWithTwoParametersForTwoEqualTimesReturnsTrue()
    {
        Time time1 = new Time(10, 20, 30);
        Time time2 = new Time(10, 20, 30);
        Assert.IsTrue(Equals(time1,time2));
    }

}