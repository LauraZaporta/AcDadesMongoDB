using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EA1.model.gradesCollection;
using Newtonsoft.Json;

namespace EA1.model.gradesBD
{
    [Serializable]
    public class Grade
    {
        public _Id? _id { get; set; }
        public Student_id? student_id { get; set; }
        public IList<Score>? scores { get; set; }
        public Class_id? class_id { get; set; }
    }
}
