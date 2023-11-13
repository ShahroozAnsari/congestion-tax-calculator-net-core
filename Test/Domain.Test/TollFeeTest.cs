using Moq;
using Domain.TollFees.Services;
using Domain.TollFees;
namespace Domain.Test
{
    [TestClass]
    public class TollFeeTests
    {
        private Mock<ITollFeeOverlapChecker> _tollFeeOverlapCheckerMock = new();

        [TestInitialize]
        public void TestInit()
        {
            _tollFeeOverlapCheckerMock.Setup(x => x.HaveOverlap(It.IsAny<Guid>(), It.IsAny<int>(), It.IsAny<TimeOnly>(), It.IsAny<TimeOnly>())).Returns(false);
        }

        [TestMethod]
        public void Constructor_ShouldCreateTollFee_WhenNoOverlap()
        {
            // Arrange
            var year = 2023;
            var from = new TimeOnly(8, 0);
            var to = new TimeOnly(9, 0);

            // Act
            var tollFee = new TollFee(_tollFeeOverlapCheckerMock.Object, year, from, to);

            // Assert
            Assert.AreEqual(year, tollFee.Year);
            Assert.AreEqual(from, tollFee.From);
            Assert.AreEqual(to, tollFee.To);
        }

        [TestMethod]
        [ExpectedException(typeof(TollFeeHaveOverlapsException))]
        public void Constructor_ShouldThrowTollFeeIsOverlap_WhenOverlap()
        {
            // Arrange
            var id = Guid.NewGuid();
            var year = 2023;
            var from = new TimeOnly(8, 0);
            var to = new TimeOnly(9, 0);
            _tollFeeOverlapCheckerMock.Setup(x => x.HaveOverlap(id, year, from, to)).Returns(true);

            // Act

            //Assert Expected Exception
            new TollFee(_tollFeeOverlapCheckerMock.Object, year, from, to);
        }


    }

}
