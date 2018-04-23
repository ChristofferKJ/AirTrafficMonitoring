using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitoring;
using NSubstitute.ExceptionExtensions;
using NUnit.Framework;

namespace AitTrafficMonitoring.Test.Unit
{
    [TestFixture]
    class ConvertStringToDateTimeUnitTest
    {
        private ConvertStringToDateTime _uut;

        [SetUp]
        public void Setup()
        {
           _uut = new ConvertStringToDateTime();
        }

        [Test]
        public void ConvertToDateTime_GoodString_ConvertingOK()
        {
            string date = "20180709170815852";

            _uut.ConvertToDateTime(date);

            Assert.That(_uut.DT.Year,Is.EqualTo(2018));
            Assert.That(_uut.DT.Month, Is.EqualTo(07));
            Assert.That(_uut.DT.Day, Is.EqualTo(09));
            Assert.That(_uut.DT.Hour, Is.EqualTo(17));
            Assert.That(_uut.DT.Minute, Is.EqualTo(08));
            Assert.That(_uut.DT.Second, Is.EqualTo(15));
            Assert.That(_uut.DT.Millisecond, Is.EqualTo(852));
        }

        [Test]
        public void ConvertToDateTime_BadString_ThrowsExeption()
        {
            string date = "2018070917081585";

            Assert.Throws<FormatException>(() => _uut.ConvertToDateTime(date));
        }
    }
}
