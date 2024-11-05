using StudentTeacherManagement.Core.Interfaces;
using StudentTeacherManagement.Core.Models;
using StudentTeacherManagement.Storage;

namespace StudentTeacherManagement.API.Services
{
    public class StudentService : IStudentService
    {
        private const int MinStudentAgeInYears = 4;

        private readonly DataContext _dataContext;

        public StudentService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }


        public Task<IEnumerable<Student>> GetStudents(int skip, int take, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Student?> GetStudentById(Guid id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<Student> AddStudent(Student student, CancellationToken cancellationToken = default)
        {
            ValidateStudent(student);

            _dataContext.Add(student);
            await _dataContext.SaveChangesAsync(cancellationToken);

            return student;
        }

        private void ValidateStudent(Student student)
        {
            if (string.IsNullOrEmpty(student.FirstName))
            {
                throw new ArgumentException("FirstName must have value", nameof(student.FirstName));
            }
            if (string.IsNullOrEmpty(student.LastName))
            {
                throw new ArgumentException("LastName must have value", nameof(student.LastName));
            }
            if (student.DateOfBirth >= DateTime.Now.AddYears(-MinStudentAgeInYears))
            {
                throw new ArgumentException("Student should be older", nameof(student.DateOfBirth));
            }
        }

        public Task<Student> UpdateStudent(Guid id, Student student, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Student> DeleteStudent(Guid id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
