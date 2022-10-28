using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Curso : BusinessEntity
    {
        // id_curso, año calendario, cupo
        
        private int _Año_calendario;
        public int Año_calendario 
        {
            get { return _Año_calendario; }
            set { _Año_calendario = value; }
        }
        private int _Cupo;
        public int Cupo
        {
            get { return _Cupo; }
            set { _Cupo = value; }
        }
        private int _ID_materia;
        public int Id_materia
        {
            get { return _ID_materia; }
            set { _ID_materia = value; }
        }
        private int _ID_comision;
        public int Id_comision
        {
            get { return _ID_comision; }
            set { _ID_comision = value; }
        }
    }
}
