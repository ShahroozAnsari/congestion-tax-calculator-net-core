
using Domain.TollFreeWeaks;
using Domain.TollFreeWeaks.Exceptions;
using Domain.TollFreeWeaks.Services;
using Moq;

namespace Tests
{
    [TestClass]
    public class TollFreeWeakTests
    {
        private Mock<ITollFreeWeaksDuplicationChecker> _tollFreeDuplicationCheckerMock = new();

        [TestInitialize]
        public void Setup()
        {
            _tollFreeDuplicationCheckerMock.Setup(x => x.IsDuplicate(It.IsAny<int>(), It.IsAny<DayOfWeek>())).Returns(false);
        }

        [TestMethod]
        public void Constructor_ShouldCreateTollFreeWeak()
        {
            // Arrange
            var year = 2023;
            var dayOfWeek = DayOfWeek.Monday;

            // Act
            var tollFreeWeak = GetTollFreeWeak(2023, dayOfWeek);

            // Assert       
            Assert.AreEqual(year, tollFreeWeak.Year);
            Assert.AreEqual(dayOfWeek, tollFreeWeak.DayOfWeek);
        }

        [TestMethod]
        [ExpectedException(typeof(TollFreeWeakIsDuplicate))]
        public void Constructor_ShouldThrowTollFreeWeakIsDuplicate_WhenDuplication()
        {
            // Arrange & Act

            _tollFreeDuplicationCheckerMock.Setup(x => x.IsDuplicate(It.IsAny<int>(), It.IsAny<DayOfWeek>())).Returns(true);
            GetTollFreeWeak();

            // Exception Assert


        }
        [TestMethod]
        public void Constructor_ShouldCallTollFreeDuplicationCheckerOnce()
        {
            // Arrange & Act
            GetTollFreeWeak();


            // Act and Assert
            _tollFreeDuplicationCheckerMock.Verify(a => a.IsDuplicate(It.IsAny<int>(), It.IsAny<DayOfWeek>()), Times.Once());

        }
        [TestMethod]
        public void Constructor_ShouldCallTollFreeDuplicationCheckerWithSpecifictParameters()
        {
            // Arrange & Act
            var year = 2023;
            var dayOfWeek = DayOfWeek.Monday;
            _tollFreeDuplicationCheckerMock.Setup(x => x.IsDuplicate(year, dayOfWeek)).Returns(false);
            GetTollFreeWeak(year, dayOfWeek);

       
        }

        private TollFreeWeak GetTollFreeWeak(int year = 2013, DayOfWeek dayOfWeek = DayOfWeek.Tuesday)
        {
            return new TollFreeWeak(_tollFreeDuplicationCheckerMock.Object, year, dayOfWeek);

        }
    }
}