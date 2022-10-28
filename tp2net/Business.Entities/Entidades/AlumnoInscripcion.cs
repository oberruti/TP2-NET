using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class AlumnoInscripcion : BusinessEntity
    {
        private int _IdCurso;
        private int _IdAlumno;
        private string _Condicion;
        private int _Nota;

        public int IdCurso { get => _IdCurso; set => _IdCurso = value; }
        public int IdAlumno { get => _IdAlumno; set => _IdAlumno = value; }
        public string Condicion { get => _Condicion; set => _Condicion = value; }
        public int Nota { get => _Nota; set => _Nota = value; }
    }
}
