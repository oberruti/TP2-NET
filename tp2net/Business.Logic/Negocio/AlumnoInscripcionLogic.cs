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

        public void Save(AlumnoInscripcion ai) { AlumnoInscripcionData.Save(ai); }
    }
}
