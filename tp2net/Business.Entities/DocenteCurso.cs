using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class DocenteCurso : BusinessEntity
    {
        private TiposCargo _Cargo;
        public TiposCargo Cargo
        {
            get { return _Cargo; }
            set { _Cargo = value; }
        }

        private int _IdCurso;
        public int IdCurso
        {
            get { return _IdCurso; }
            set { _IdCurso = value; }
        }

        private int _IdDocente;
        public int IdDocente
        {
            get { return _IdDocente; }
            set { _IdDocente = value; }
        }
        public enum TiposCargo
        {
            Titular,
            Ayudante
        }

    }
}
