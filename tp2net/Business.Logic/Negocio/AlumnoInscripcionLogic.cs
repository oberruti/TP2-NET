using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class AlumnoInscripcionLogic : BusinessLogic
    {
        private AlumnoInscripcionAdapter _AlumnoInscripcionData;
        public AlumnoInscripcionAdapter AlumnoInscripcionData { get => _AlumnoInscripcionData; set => _AlumnoInscripcionData = value; }

        public AlumnoInscripcionLogic()
        {

            AlumnoInscripcionData = new AlumnoInscripcionAdapter();

        }

        public List<AlumnoInscripcion> GetAll() { return AlumnoInscripcionData.GetAll(); }

        public AlumnoInscripcion GetOne(int id) { return AlumnoInscripcionData.GetOne(id); }

        public List<AlumnoInscripcion> GetInscripcionesByCursoId(int cursoId) { return AlumnoInscripcionData.GetInscripcionesByCursoId(cursoId); }

        public void Save(AlumnoInscripcion ai) { AlumnoInscripcionData.Save(ai); }

        public List<AlumnoInscripcion> GetAllCurso(int idCurso)
        {
            return AlumnoInscripcionData.GetAllCurso(idCurso);
        }

        public List<AlumnoInscripcion> GetAllAlum(int idAlumno)
        {
            return AlumnoInscripcionData.GetAllAlum(idAlumno);
        }

        public List<AlumnoInscripcion> GetInscripcionesByCursoId(int cursoId) { return AlumnoInscripcionData.GetInscripcionesByCursoId(cursoId); }
    }
}
