using MegaExam.Models;

namespace MegaExam.Repository
{
    public interface IStudentRepository
    {
        bool StudInsert(StudentModel stud);
        bool StudUpdate(StudentModel stud);
        bool StudDelete(int id);
        List<StudentModel> GetAllStud();
        StudentModel FetchbyId(int id);
    }
}
