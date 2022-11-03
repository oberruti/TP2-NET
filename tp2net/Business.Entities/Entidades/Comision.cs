using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Comision : BusinessEntity
    {
        private string _Desc_comision;
        private int _Anio_especialidad;
        private int _IDPlan;

        public string Desc_comision { get => _Desc_comision; set => _Desc_comision = value; }
        public int Anio_especialidad { get => _Anio_especialidad; set => _Anio_especialidad = value; }
        public int IDPlan { get => _IDPlan; set => _IDPlan = value; }
    }
}
