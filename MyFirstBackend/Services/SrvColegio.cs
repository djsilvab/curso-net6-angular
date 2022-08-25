using MyFirstBackend.DataAccess;
using MyFirstBackend.Models.DataModels;

namespace MyFirstBackend.Services
{
    public class SrvColegio
    {
        //Buscar usuarios por email
        public User? FindUsersByEmail(List<User> users, string email)
        {            
            return users.FirstOrDefault(u => u.Email.Equals(email));        
        }

        //Buscar alumnos mayores de edad
        public List<Student> FindStudentsByMoreAge(List<Student> students)
        {
            DateTime zeroTime = new DateTime(1, 1, 1);
            //return students.Where(x => DateTime.Now.Subtract(x.DateOfBirth).TotalDays/365.2425 >= 18 ).ToList();
            //return students.Where(x => new DateTime((DateTime.Now - x.DateOfBirth).Ticks).Year - 1 > 17).ToList();
            return students.Where(x => (zeroTime + DateTime.Now.Subtract(x.DateOfBirth)).Year - 1 > 17).ToList();
        }

        //Buscar alumnos que tengan al menos un curso
        public List<Student> FindStudentsAlMenosUnCurso(List<Student> students)
        {
            return students.Where(x => x.Courses.Any()).ToList();
        }

        //Buscar cursos de un nivel determinado que al menos tengan un alumno inscrito
        public List<Curso> FindCoursesByNivelAlMenosStudentInscrito(List<Curso> cursos, TipoNivel nivel)
        {
            return cursos.Where(x => x.Nivel.Equals(nivel) && x.Students.Any()).ToList();
        }

        //Buscar cursos de un nivel determinado que sean de una categoría determinada
        public List<Curso> FindCoursesByNivelAndCategoria(List<Curso> cursos, TipoNivel nivel, Category category)
        {
            return cursos.Where(x => x.Nivel.Equals(nivel) && x.Categories.Contains<Category>(category)).ToList();
        }        

        //Buscar cursos sin alumnos
        public List<Curso> FindCoursesWithoutStudents(List<Curso> cursos)
        {
            //cursos = new List<Curso>
            //{
            //    new Curso{ Id = 1, Nombre = "Curso 1" },
            //    new Curso{ Id = 2, Nombre = "Curso 2" },
            //    new Curso{ Id = 3, Nombre = "Curso 3" }
            //};

            return cursos.Where(x => !x.Students.Any()).ToList();
        }
    }
}
