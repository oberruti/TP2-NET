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
        private int _IDCurso;
        private int _IDDocente;

        public TiposCargo Cargo { get => _Cargo; set => _Cargo = value; }
        public int IDCurso { get => _IDCurso; set => _IDCurso = value; }
        public int IDDocente { get => _IDDocente; set => _IDDocente = value; }

        public enum TiposCargo
        {
            Titular = 1,
            Ayudante = 2
        }
    }
}
