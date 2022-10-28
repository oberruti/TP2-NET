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
        public int IdCurso
        {
            get { return _IdCurso; }
            set { _IdCurso = value; }
        }

        private int _IdAlumno;
        public int IdAlumno
        {
            get { return _IdAlumno; }
            set { _IdAlumno = value; }
        }

        private string _Condicion;
        public string Condicion
        {
            get { return _Condicion; }
            set { _Condicion = value; }
        }

        private int _Nota;
        public int Nota
        {
            get { return _Nota; }
            set { _Nota = value; }
        }
    }
}
