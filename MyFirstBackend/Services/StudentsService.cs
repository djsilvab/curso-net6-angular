using MyFirstBackend.Models.DataModels;

namespace MyFirstBackend.Services
{
    public class StudentsService : Contracts.IStudentsService
    {
        public IEnumerable<Student> GetStudentsWithCourses()
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Student> GetStudentsWithoutCourses()
        {
            throw new NotImplementedException();
        }
    }
}
