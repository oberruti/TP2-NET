using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;
using static Business.Entities.BusinessEntity;

namespace Business.Logic
{
    public class AlumnoLogic : BusinessLogic
    {
        public AlumnoLogic()
        {
            this.AlumnoData = new PersonaAdapter();
        }

        private PersonaAdapter _AlumnoData;

        public PersonaAdapter AlumnoData { get => _AlumnoData; set => _AlumnoData = value; }

        public List<Persona> GetAllAlumnos() {
            return AlumnoData.GetAllAlumnos();
        }
    }
}
