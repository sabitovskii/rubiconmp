using Geometry.App;
using Geometry.App.DTOs;
using Geometry.App.Exceptions;
using Geometry.App.Validators;
using Geometry.Domain.Entities;
using Geometry.Domain.Interfaces;
using Geometry.Infrastructure.Services;
using Moq;

namespace Geometry.Tests
{
    public class RectangleServiceTests
    {
        [Fact]
        public async Task CreateAsync_RectangleWithNullPoint_ThrowsException()
        {
            // Arrange
            var rectangleValidator = new RectangleValidator();
            var repositoryMock = new Mock<IRectangleRepository>();
            var sut = new RectangleService(repositoryMock.Object, rectangleValidator);
            var nullPointRectangleDto = new RectangleDto();
            var expectedErrorMessage = "Rectangle cannot have an empty point.";

            // Act & Assert
            var exception =
                await Assert.ThrowsAsync<InvalidRectangleException>(async () => await sut.CreateAsync(nullPointRectangleDto));
            Assert.Contains(expectedErrorMessage, exception.Message);
        }

        [Theory]
        [InlineData(-2, 4, 4, 1, 3, -1, -3, 3)]
        [InlineData(-1, -2, -3, -4, -5, -6, -7, -8)]
        public async Task CreateAsync_RectangleSidesNotEqual_ThrowsException(double p1, double q1, double p2, double q2,
                                                                            double p3, double q3, double p4, double q4)
        {
            // Arrange
            var rectangleValidator = new RectangleValidator();
            var repositoryMock = new Mock<IRectangleRepository>();
            var sut = new RectangleService(repositoryMock.Object, rectangleValidator);
            var DifferentSidesRectangleDto = new RectangleDto()
            {
                A = new PointDto(p1, q1),
                B = new PointDto(p2, q2),
                C = new PointDto(p3, q3),
                D = new PointDto(p4, q4)
            };
            var expectedErrorMessage = "Opposite sides of a rectangle are not equal.";

            // Act & Assert
            var exception =
                await Assert.ThrowsAsync<InvalidRectangleException>(async () => await sut.CreateAsync(DifferentSidesRectangleDto));
            Assert.Contains(expectedErrorMessage, exception.Message);
        }



        [Theory]
        [InlineData(-2, 4, 4, 1, 3, -1, -3, 2)]
        [InlineData(-2, -2, -2, 2, 2, 2, 2, -2)]
        public async Task CreateAsync_ValidRectangle_ReturnSuccess(double p1, double q1, double p2, double q2,
                                                                    double p3, double q3, double p4, double q4)
        {
            // Arrange
            var rectangleValidator = new RectangleValidator();
            var repositoryMock = new Mock<IRectangleRepository>();
            var sut = new RectangleService(repositoryMock.Object, rectangleValidator);
            var validDto = new RectangleDto()
            {
                A = new PointDto(p1, q1),
                B = new PointDto(p2, q2),
                C = new PointDto(p3, q3),
                D = new PointDto(p4, q4)
            };
            var createdEntity = validDto.ToEntity();
            createdEntity.Id = 1;

            repositoryMock.Setup(r => r.CreateAsync(It.IsAny<Rectangle>())).ReturnsAsync(createdEntity);

            // Act
            var createdDto = await sut.CreateAsync(validDto);

            // Assert
            repositoryMock.Verify(r => r.CreateAsync(It.IsAny<Rectangle>()), Times.Once);
        }

        [Theory]
        [InlineData(-4.5, 4.5, 4.5, 4.5, 0)]
        [InlineData(-5, -5, 5, 5, 5)]
        [InlineData(-5, -5, -5, 0, 1)]
        [InlineData(-5, -5, 0, 0, 5)]
        public async Task GetIntersectingListAsync_WorksProperly(double p1, double q1, double p2, double q2, int resultCount)
        {
            // Arrange
            var rectangleValidator = new RectangleValidator();
            var repositoryMock = new Mock<IRectangleRepository>();
            var sut = new RectangleService(repositoryMock.Object, rectangleValidator);
            var segmentDto = new SegmentDto(new PointDto(p1, q1), new PointDto(p2, q2));
            var batch = new List<Rectangle>();
            for (int i = 1; i <= 20; i++)
            {
                var rectangle = new Rectangle()
                {
                    Id = i,
                    A = new Point() { X = -i, Y = i },
                    B = new Point() { X = i, Y = i },
                    C = new Point() { X = i, Y = -i },
                    D = new Point() { X = -i, Y = -i }
                };
                batch.Add(rectangle);
            }

            repositoryMock.Setup(r => r.GetBatchAsync(0, 100)).ReturnsAsync(batch);
            repositoryMock.Setup(r => r.GetBatchAsync(100, 100)).ReturnsAsync(new List<Rectangle>());

            // Act
            var intersectingRectangles = await sut.GetIntersectingListAsync(segmentDto);

            // Assert
            Assert.Equal(resultCount, intersectingRectangles.Count);
        }
    }
}