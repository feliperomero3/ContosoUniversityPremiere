using System.Threading.Tasks;
using ContosoUniversity.Data;
using ContosoUniversity.Entities;
using ContosoUniversity.Pages.Students;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Moq;
using Xunit;

namespace ContosoUniversity.Tests.Pages.Students
{
    public class DetailsModelTest
    {
        [Fact]
        public async void Gets_a_Student_Details()
        {
            // Arrange
            var mockRepository = new Mock<IStudentRepository>();

            mockRepository.Setup(r => r.GetStudentDetailAsync(It.IsAny<int>()))
                .Returns(Task.FromResult(new Student()));

            var mockUnitOfWork = new Mock<IUnitOfWork>();

            mockUnitOfWork.SetupGet(u => u.Student).Returns(mockRepository.Object);

            var target = new DetailsModel(mockUnitOfWork.Object);

            // Act
            var result = await target.OnGetAsync(It.IsAny<int>());

            // Assert
            Assert.IsType<PageResult>(result);
            Assert.NotNull(target.Student);
            mockUnitOfWork.Verify(u => u.Student.GetStudentDetailAsync(It.IsAny<int>()), Times.Once);
        }
    }
}
