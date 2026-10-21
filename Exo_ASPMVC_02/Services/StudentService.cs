using Exo_ASPMVC_02.Exceptions;
using Exo_ASPMVC_02.Models;
using Exo_ASPMVC_02.Services.Interfaces;

namespace Exo_ASPMVC_02.Services
{
    public class StudentService : IStudentService
    {
        #region FakeData
        private static List<Student> _students = [
            new Student {
                Id = 1,
                FirstName = "Della",
                LastName = "Duck",
                BirthDate = new DateTime(1989, 3, 5),
                Remark = null,
                IsBlamed = false
            },
            new Student {
                Id = 2,
                FirstName = "Gontran",
                LastName = "Bonheur",
                BirthDate = new DateTime(1990, 9, 5),
                Remark = "Moins de balatro !",
                IsBlamed = true
            }
        ];
        private static int _nextId = 3;
        #endregion

        public int Add(Student data)
        {
            Student st = new Student{
                Id = _nextId++,
                FirstName = data.FirstName,
                LastName = data.LastName,
                BirthDate = data.BirthDate,
                Remark = !string.IsNullOrWhiteSpace(data.Remark) ? data.Remark : null,
                IsBlamed = data.IsBlamed
            };
            _students.Add(st);
            return st.Id;
        }

        public bool CheckDuplicate(Student data)
        {
            return _students.Any(st => st.FirstName.Equals(data.FirstName, StringComparison.CurrentCultureIgnoreCase)
                && st.LastName.Equals(data.LastName, StringComparison.CurrentCultureIgnoreCase)
                && st.BirthDate == data.BirthDate);
        }

        public void Delete(int id)
        {
            int targetIndex = _students.FindIndex(st => st.Id == id);

            if (targetIndex < 0)
            {
                throw new StudentFailDeletedException();
            }
            _students.RemoveAt(targetIndex);
        }

        public IEnumerable<Student> GetAll()
        {
            return _students.AsReadOnly();
        }

        public Student? GetById(int id)
        {
            return _students.SingleOrDefault(st => st.Id == id);
        }
    }
}
