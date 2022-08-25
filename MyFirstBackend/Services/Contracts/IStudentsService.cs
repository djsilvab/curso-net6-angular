using MyFirstBackend.Models.DataModels;

namespace MyFirstBackend.Services.Contracts
{
    public interface IStudentsService
    {
        IEnumerable<Student> GetStudentsWithCourses();
        IEnumerable<Student> GetStudentsWithoutCourses();
    }
}
