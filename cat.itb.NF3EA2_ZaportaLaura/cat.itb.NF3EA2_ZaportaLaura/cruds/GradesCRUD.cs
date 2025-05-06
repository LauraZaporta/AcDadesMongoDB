using cat.itb.NF3EA2_ZaportaLaura.cruds.others;
using EA1.model.gradesBD;

namespace cat.itb.NF3EA2_ZaportaLaura.cruds
{
    public class GradesCRUD
    {
        public static void LoadGradesCollection()
        {
            HelperClass.LoadCollection<Grade>("grades", "Grade");
        }
    }
}