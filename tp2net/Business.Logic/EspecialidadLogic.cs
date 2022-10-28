using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class EspecialidadLogic : BusinessLogic
    {

        private EspecialidadAdapter _EspecialidadData;

        public EspecialidadAdapter EspecialidadData { get => _EspecialidadData; set => _EspecialidadData = value; }

        public EspecialidadLogic()
        {
            EspecialidadData = new EspecialidadAdapter();
        }

        public List<Especialidad> GetAll()
        {
            
            return EspecialidadData.GetAll();
        }

        public Especialidad GetOne(int ID)
        {
            return EspecialidadData.GetOne(ID);
        }

        public void Delete(int ID)
        {
            //Borra la especialidad
            EspecialidadData.Delete(ID);

            //Borra los planes que dependen de esa especialidad
            ////PlanAdapter PlanData = new PlanAdapter();
            ////PlanData.DeleteByEspecialidad(ID);

        }

        public void Save(Especialidad esp)
        {
            EspecialidadData.Save(esp);
        }
    }
}
