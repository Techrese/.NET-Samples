using CalculatorService;
using Moq;
namespace CalculatorServiceTests
{
    public class Tests
    {
        private readonly Calculator _calculatorService = new();

        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void ShoudlReturnExceptionWhenInputNULL()
        {
            Assert.Throws<ArgumentNullException>(() => _calculatorService.Add(null));
        }

        [Test]
        public void ShouldReturnExceptionWhenWrongFormat()
        {
            Assert.Throws<ArgumentException>(() => _calculatorService.Add("AB"));
        }

        [Test]
        public void ShouldReturnExceptionWhenTooManyCommas()
        {
            Assert.Throws<ArgumentException>(() => _calculatorService.Add("A,B,C"));
        }

        [Test]
        public void ShoudlReturnExceptionWhenPartOneCannotConvert()
        {
            Assert.Throws<FormatException>(() => _calculatorService.Add("A, 1"));
        }

        [Test]
        public void ShoudlReturnExceptionWhenPartTwoCannotConvert()
        {
            Assert.Throws<FormatException>(() => _calculatorService.Add("1, A"));
        }

        [Test]
        public void ShouldReturnResult()
        {
            Assert.AreEqual(expected: 3, actual: _calculatorService.Add("1,2"));
        }


        [Test]
        public void ShouldReturnResultWithMOQ()
        {
            Mock<Calculator> moq = new Mock<Calculator>();            

            moq.Setup(x => x.ExtraAdd).Returns(4);

            Calculator stub = moq.Object;

            Assert.AreEqual(expected: 11, actual: stub.Add("3,4"));
        }

    }
}