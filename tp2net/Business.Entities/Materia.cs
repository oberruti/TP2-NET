﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Materia : BusinessEntity
    {

        private string _Descripcion;
        private int _HSSemanales;
        private int _HSTotales;
        private int _IDPlan;

        public string Descripcion { get => _Descripcion; set => _Descripcion = value; }
        public int HSSemanales { get => _HSSemanales; set => _HSSemanales = value; }
        public int HSTotales { get => _HSTotales; set => _HSTotales = value; }
        public int IDPlan { get => _IDPlan; set => _IDPlan = value; }

        public Materia()
        {
        }
    }
}

