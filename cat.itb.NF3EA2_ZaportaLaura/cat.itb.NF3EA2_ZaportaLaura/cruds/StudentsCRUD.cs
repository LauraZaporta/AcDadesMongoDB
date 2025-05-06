using cat.itb.NF3EA2_ZaportaLaura.cruds.others;
using EA1.model.studentsCollection;

namespace cat.itb.NF3EA2_ZaportaLaura.cruds
{
    public class StudentsCRUD
    {
        public static void LoadStudentsCollection()
        {
            HelperClass.LoadCollection<Student>("students", "Student");
        }
    }
}