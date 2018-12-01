using System;
using Moq;
using NUnit.Framework;
using XmlLib.Helpers;
using XmlLib.Interfaces;

namespace XmlLib.Tests
{
    [TestFixture]
    public class XmlLibTest
    {
        [Test]
        public void ValidateTest_ForStringWhichReturnsTrue()
        {
            string url = "https://github.com/AnzhelikaKravchuk/Training-Autumn-2018/tree/master/Days%2020-23";
            IValidator<string> validator =
            Mock.Of<IValidator<string>>(d => d.Check(url) == true);
            var currentChecker = validator.Check(url);
            Assert.That(currentChecker, Is.EqualTo(true));
        }

        [Test]
        public void ValidateTest_ForAnyString_ReturnsFalse()
        {
            string url = "https://github.com/AnzhelikaKravchuk/Training-Autumn-2018/tree/master/Days%2020-23";
            IValidator<string> validator =
            Mock.Of<IValidator<string>>(d => d.Check(It.IsAny<string>()) == false);

            var currentChecker = validator.Check(url);
            Assert.That(currentChecker, Is.EqualTo(false));
        }

        [Test]
        public void ValidateTest_ForAnyString_ReturnsFalseIfLengthMoreThan20()
        {
            Mock<IValidator<string>> validatorStub = new Mock<IValidator<string>>();
            validatorStub.Setup(v => v.Check(It.IsAny<string>())).Returns<string>(x => x.Length > 20);

            string firstUrl = "https://github.com/AnzhelikaKravchuk/Training-Autumn-2018/tree/master/Days%2020-23";
            string secondUrl = "https://github.com";
            IValidator<string> validator = validatorStub.Object;
            bool firstResult = validator.Check(firstUrl);
            bool secondResult = validator.Check(secondUrl);

            Assert.That(firstResult, Is.EqualTo(true));
            Assert.That(secondResult, Is.EqualTo(false));
        }

        [Test]
        public void ParseTest_ParseAnyStringInto5()
        {
            IParser<string, int> parser = Mock.Of<IParser<string, int>>(x => x.Parse(It.IsAny<string>()) == 5);

            string stringForTest = "simpleString";
            int currentResult = parser.Parse(stringForTest);

            Assert.That(currentResult, Is.EqualTo(5));
            Assert.That(currentResult, Is.InRange(1, 10));
            Assert.That(currentResult, Is.Not.EqualTo(7));
        }

        [Test]
        public void MapperTest()
        {
            var validatorMock = new Mock<IValidator<string>>();
            var parserMock = new Mock<IParser<string, int>>();
            //parserMock.Setup(x => x.Parse(It.IsAny<string>()) == 5);

            var mapper = new Mapper<string, int>(parserMock.Object, validatorMock.Object);
            string url = "https://github.com";
            int result=mapper.MapSomethingInSomething(url);

           validatorMock.Verify(x => x.Check(It.IsAny<string>()));
           //parserMock.Verify(x=>x.Parse(url));
        }
    }
}
