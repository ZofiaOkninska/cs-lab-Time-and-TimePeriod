namespace TimeAndTimePeriodUnitTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TimeAndTimePeriod;

[TestClass]
public class UnitTest1
{
    // Time tests

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
        Assert.IsTrue(Time.Equals(time1,time2));
    }

    [TestMethod]
    public void TimeEqualtyOperatorForTwoEqualTimesReturnsTrue()
    {
        Time time1 = new Time(10, 20, 30);
        Time time2 = new Time(10, 20, 30);
        Assert.IsTrue(time1 == time2);
    }

    [TestMethod]
    public void TimeNonEqualtyOperatorForTwoEqualTimesReturnsFalse()
    {
        Time time1 = new Time(10, 20, 30);
        Time time2 = new Time(10, 20, 30);
        Assert.IsFalse(time1 != time2);
    }

    [TestMethod]
    public void TimeCompareToForNullReturnsOne()
    {
        Time time1 = new Time(10, 20, 30);
        string? str = null;
        Assert.AreEqual(time1.CompareTo(str),1);
    }

    [TestMethod]
    public void TimeCompareToOtherTypeThanTimeThrowsArgumentException()
    { 
        Time time1 = new Time(10, 20, 30);
        string str = "11:11:11";
        Assert.ThrowsException<ArgumentException>(() => time1.CompareTo(str));
    }

    [TestMethod]
    public void Time_CompareTo_LessThan_ReturnsNegativeValue()
    {
        Time time1 = new Time(10, 20, 30);
        Time time2 = new Time(12, 0, 0);
        Assert.IsTrue(time1.CompareTo(time2) < 0);
    }

    [TestMethod]
    public void Time_CompareTo_GreaterThan_ReturnsPositiveValue()
    {
        Time time1 = new Time(14, 30, 0);
        Time time2 = new Time(12, 40, 40);
        Assert.IsTrue(time1.CompareTo(time2) > 0);
    }

    [DataTestMethod]
    [DataRow((byte)12, (byte)10, (byte)10, (byte)14, (byte)5, (byte)5, true)]
    [DataRow((byte)12, (byte)10, (byte)10, (byte)12, (byte)5, (byte)5, false)]
    [DataRow((byte)12, (byte)10, (byte)10, (byte)12, (byte)10, (byte)5, false)]
    public void Time_LessThanOperator_ReturnsExpectedResult(byte hours1, byte min1, byte sec1,
                                                     byte hours2, byte min2, byte sec2,
                                                     bool expectedResult)
    {
        Time time1 = new Time(hours1, min1, sec1);
        Time time2 = new Time(hours2, min2, sec2);

        bool result = time1 < time2;

        Assert.AreEqual(expectedResult, result);
    }

    [DataTestMethod]
    [DataRow((byte)12, (byte)10, (byte)10, (byte)12, (byte)10, (byte)10, true)]
    [DataRow((byte)12, (byte)10, (byte)10, (byte)12, (byte)5, (byte)5, false)]
    [DataRow((byte)12, (byte)10, (byte)10, (byte)12, (byte)10, (byte)5, false)]
    public void Time_LessThanOrEqualOperator_ReturnsExpectedResult(byte hours1, byte min1, byte sec1,
                                                     byte hours2, byte min2, byte sec2,
                                                     bool expectedResult)
    {
        Time time1 = new Time(hours1, min1, sec1);
        Time time2 = new Time(hours2, min2, sec2);

        bool result = time1 <= time2;

        Assert.AreEqual(expectedResult, result);
    }

    [DataTestMethod]
    [DataRow((byte)12, (byte)10, (byte)10, (byte)14, (byte)5, (byte)5, false)]
    [DataRow((byte)12, (byte)10, (byte)10, (byte)12, (byte)5, (byte)5, true)]
    [DataRow((byte)12, (byte)10, (byte)10, (byte)12, (byte)10, (byte)5, true)]
    public void Time_GreaterThanOperator_ReturnsExpectedResult(byte hours1, byte min1, byte sec1,
                                                     byte hours2, byte min2, byte sec2,
                                                     bool expectedResult)
    {
        Time time1 = new Time(hours1, min1, sec1);
        Time time2 = new Time(hours2, min2, sec2);

        bool result = time1 > time2;

        Assert.AreEqual(expectedResult, result);
    }

    [DataTestMethod]
    [DataRow((byte)12, (byte)10, (byte)10, (byte)12, (byte)10, (byte)10, true)]
    [DataRow((byte)12, (byte)10, (byte)10, (byte)12, (byte)5, (byte)5, true)]
    [DataRow((byte)12, (byte)10, (byte)10, (byte)12, (byte)10, (byte)5, true)]
    public void Time_GreaterThanOrEqualOperator_ReturnsExpectedResult(byte hours1, byte min1, byte sec1,
                                                      byte hours2, byte min2, byte sec2,
                                                      bool expectedResult)
    {
        Time time1 = new Time(hours1, min1, sec1);
        Time time2 = new Time(hours2, min2, sec2);

        bool result = time1 >= time2;

        Assert.AreEqual(expectedResult, result);
    }

    // TimePeriod tests

    [TestMethod]
    public void TimePeriodConstructorInvalidMinuteValueThrowsArgumentException()
    {
        Assert.ThrowsException<ArgumentException>(() => new TimePeriod(29, 60, 6));
    }

    [TestMethod]
    public void TimePeriodConstructorInvalidSecondValueThrowsArgumentException()
    {
        Assert.ThrowsException<ArgumentException>(() => new TimePeriod(29, 40, 60));
    }

    [TestMethod]
    public void TimePeriodConstructorTotalSecondsSmallerThanZeroThrowsArgumentException()
    {
        Assert.ThrowsException<ArgumentException>(() => new TimePeriod(-30));
    }

    [TestMethod]
    public void TimePeriodConstructorWithoutSecondsPassedReturnsTimePeriodObject()
    {
        TimePeriod timeP = new TimePeriod(3, 44);
        Assert.AreEqual(3 * 3600L + 44 * 60L + 0, timeP.TotalSeconds);
    }

    [TestMethod]
    public void TimePeriodConstructorWithoutHoursAndMinutesPassedReturnsTimePeriodObject()
    {
        TimePeriod timeP = new TimePeriod((byte)30);
        Assert.AreEqual(0 * 3600L + 0 * 60L + 30, timeP.TotalSeconds);
    }

    [TestMethod]
    public void TimePeriod_Constructor_StringFormat_ValidTimePeriod_ReturnsTimePeriodObject()
    {
        TimePeriod timeP = new TimePeriod("12:30:45");
        Assert.AreEqual(12 * 3600L + 30 * 60L + 45, timeP.TotalSeconds);
    }

    [TestMethod]
    public void TimePeriod_ConstructorStringFormatMissingValuesThrowsArgumentException()
    {
        Assert.ThrowsException<ArgumentException>(() => new TimePeriod("21:30"));
    }

    [TestMethod]
    public void TimePeriod_ConstructorStringFormatInvalidValuesThrowsArgumentException()
    {
        Assert.ThrowsException<ArgumentException>(() => new TimePeriod("26:60:03"));
    }

    [TestMethod]
    public void TimePeriod_Constructor_CalculatesTotalSecondsCorrectlyWithTwoTimeTypesGiven()
    {
        Time startTime = new Time(10, 30, 0);
        Time endTime = new Time(12, 15, 30);

        //long startSeconds = startTime.Hours * 3600L + startTime.Minutes * 60L + startTime.Seconds;
        //long endSeconds = endTime.Hours * 3600L + endTime.Minutes * 60L + endTime.Seconds;

        TimePeriod timePeriod = new TimePeriod(startTime, endTime);

        Assert.AreEqual(6330L, timePeriod.TotalSeconds);
    }
}