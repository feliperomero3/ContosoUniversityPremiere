using ContosoUniversity.Data;
using ContosoUniversity.Entities;
using ContosoUniversity.Pages.Students;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace ContosoUniversity.Tests.Pages.Students
{
    public class CreateModelTest
    {
        [Fact]
        public async void Creates_a_Student()
        {
            // Arrange
            var mockRepository = new Mock<IStudentRepository>();

            var mockUnitOfWork = new Mock<IUnitOfWork>();

            mockUnitOfWork.SetupGet(u => u.Student).Returns(mockRepository.Object);

            var createModel = new CreateModel(mockUnitOfWork.Object);

            // Act
            var result = await createModel.OnPostAsync();

            // Assert
            Assert.IsType<RedirectToPageResult>(result);
            mockUnitOfWork.Verify(u => u.Student.Add(It.IsAny<Student>()), Times.Once);
            mockUnitOfWork.Verify(u => u.CompleteAsync(), Times.Once);
        }
    }
}