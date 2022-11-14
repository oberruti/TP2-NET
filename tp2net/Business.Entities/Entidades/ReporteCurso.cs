using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class ReporteCurso
    {
        public int comisionID { get; set; }
        public int materiaID { get; set; }

        public Persona persona { get; set; }

    }
}
