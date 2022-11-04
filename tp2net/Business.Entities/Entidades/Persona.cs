using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Persona : Usuario
    {
        private string _Direccion;
        private DateTime _FechaNacimiento;
        private int _IDPlan;
        private int _Legajo;
        private string _Telefono;
        private TiposPersonas _TipoPersona;

        public string Direccion { get => _Direccion; set => _Direccion = value; }
        public DateTime FechaNacimiento { get => _FechaNacimiento; set => _FechaNacimiento = value; }
        public int IDPlan { get => _IDPlan; set => _IDPlan = value; }
        public int Legajo { get => _Legajo; set => _Legajo = value; }
        public string Telefono { get => _Telefono; set => _Telefono = value; }
        public TiposPersonas TipoPersona { get => _TipoPersona; set => _TipoPersona = value; }
        
    }
    public enum TiposPersonas
    {
        Admin = 1,
        Docente = 2,
        Alumno = 3
    }
}
