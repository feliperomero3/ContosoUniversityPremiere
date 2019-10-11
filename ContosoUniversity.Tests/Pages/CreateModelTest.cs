using System;
using ContosoUniversity.Data;
using ContosoUniversity.Entities;
using ContosoUniversity.Pages.Students;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace ContosoUniversity.Tests.Pages
{
    public class CreateModelTest
    {
        [Fact]
        public async void OnPostAsync_Creates_a_Student()
        {
            // Arrange
            var mockRepository = new Mock<IStudentRepository>();

            var mockUnitOfWork = new Mock<IUnitOfWork>();

            mockUnitOfWork.SetupGet(u => u.Student).Returns(mockRepository.Object);

            var createModel = new CreateModel(mockUnitOfWork.Object)
            {
                Student = new Student
                {
                    FirstMidName = "Carson",
                    LastName = "Alexander",
                    EnrollmentDate = DateTime.Parse("2005-09-01")
                }
            };

            // Act
            var result = await createModel.OnPostAsync();

            // Assert
            Assert.IsType<RedirectToPageResult>(result);
            mockUnitOfWork.Verify(u => u.Student.Add(It.IsAny<Student>()), Times.Once);
            mockUnitOfWork.Verify(u => u.CompleteAsync(), Times.Once);
        }
    }
}