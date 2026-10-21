using Exo_ASPMVC_02.Models;

namespace Exo_ASPMVC_02.Services.Interfaces
{
    public interface IStudentService
    {
        public IEnumerable<Student> GetAll();
        public Student? GetById(int id);
        public int Add(Student data);
        public void Delete(int id);

        public bool CheckDuplicate(Student data);
    }
}
