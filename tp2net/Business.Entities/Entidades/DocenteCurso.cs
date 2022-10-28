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
        public enum TiposCargo
        {
            Titular = 1,
            Ayudante = 2
        }
    }
}
