using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class PersonaLogic : BusinessLogic
    {
        private PersonaAdapter _PersonaData;

        public PersonaAdapter PersonaData { get => _PersonaData; set => _PersonaData = value; }

        public PersonaLogic()
        {

            PersonaData = new PersonaAdapter();

        }

        public Persona GetOne(int id) { return PersonaData.GetOne(id); }

        //public Persona GetOne(string nombreUsuario) { return PersonaData.GetOne(nombreUsuario); }

        public List<Persona> GetAll() { return PersonaData.GetAll(); }

        public void Save(Persona p) { PersonaData.Save(p); }

        public void Delete(int id) { PersonaData.Delete(id); }

        public bool ValidarPersona(string username, string pass)
        {
            return PersonaData.ValidarPersona(username, pass);
        }

        public Persona GetOneByNombreUsuario(string nombreUsuario) {
            return PersonaData.GetOneByNombreUsuario(nombreUsuario);
        }

        public Persona LoginUsuario(string nombreUsuario, string clave)
        {
            return PersonaData.LoginUsuario(nombreUsuario, clave);
        }

        public List<Persona> GetAllDocentes()
        {
            return PersonaData.GetAllTipoPersona((int)TiposPersonas.Docente);
        }

        public List<Persona> GetAllAlumnos()
        {
            return PersonaData.GetAllTipoPersona((int)TiposPersonas.Alumno);
        }

        public List<Persona> GetDocentesByCourse(int idCurso)
        {
            return PersonaData.GetPersonasByCourse(idCurso, (int)TiposPersonas.Docente);
        }

        public List<Persona> GetAlumnsByCourse(int idCurso)
        {
            return PersonaData.GetPersonasByCourse(idCurso, (int)TiposPersonas.Alumno);
        }
    }
}
