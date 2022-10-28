using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Curso : BusinessEntity
    {
        private int _Año_calendario;
        private int _Cupo;
        private string _Descripcion;
        private int _IDMateria;
        private int _IDComision;

        public int Año_calendario { get => _Año_calendario; set => _Año_calendario = value; }
        public int Cupo { get => _Cupo; set => _Cupo = value; }
        public string Descripcion { get => _Descripcion; set => _Descripcion = value; }
        public int IDMateria { get => _IDMateria; set => _IDMateria = value; }
        public int IDComision { get => _IDComision; set => _IDComision = value; }
    }
}
